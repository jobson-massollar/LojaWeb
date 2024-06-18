using Api.Contracts;
using Application.Interfaces.Entry;
using Application.Interfaces.Infrastructure.Repository;
using Domain.Model;
using Domain.Model.Errors;

namespace Application.Services;

public class PedidoServices : IPedidoServices
{
    private readonly IClienteRepository clienteRepository;
    private readonly IPedidoRepository pedidoRepository;
    private readonly IUFRepository ufRepository;
    private readonly IProdutoRepository produtoRepository;

    public PedidoServices(IClienteRepository clienteRepository,
                          IPedidoRepository pedidoRepository,
                          IUFRepository ufRepository,
                          IProdutoRepository produtoRepository)
    {
        this.clienteRepository = clienteRepository;
        this.pedidoRepository = pedidoRepository;
        this.ufRepository = ufRepository;
        this.produtoRepository = produtoRepository;
    }

    public Result<Pedido> CriarPedido(CriarPedidoData dados)
    {
        List<ErroEntidade> erros = [];

        var uf = ufRepository.RecuperarPorSigla(dados.Uf);

        var cliente = clienteRepository.RecuperarPorCPF(dados.Cpf);

        if (cliente is null)
            erros.Add(ErroEntidade.CLIENTE_NAO_ENCONTRADO);

        var result = new PedidoBuilder(cliente,
                                       dados.Logradouro,
                                       dados.Numero,
                                       dados.Complemento,
                                       dados.Bairro,
                                       dados.Cep,
                                       uf).Build();

        if (result.hasErrors)
        {
            if (cliente is null)
                result.Errors!.Remove(ErroEntidade.PEDIDO_CLIENTE_INVALIDO);

            return erros.Concat(result.Errors!).ToList();
        }

        var pedido = result.Value!;

        foreach (var item in dados.Itens)
        {
            var produto = produtoRepository.RecuperarPorCodigo(item.CodigoBarras);

            if (produto is null)
                erros.Add(ErroEntidade.PRODUTO_NAO_ENCONTRADO);
            else
            {
                var resultItem = pedido.AddItem(produto, item.Quantidade);

                if (resultItem.hasErrors)
                    erros = erros.Concat(resultItem.Errors!).ToList();
            }
        }

        if (erros.Count == 0)
        {
            pedidoRepository.Adicionar(pedido);

            return pedido;
        }
        else
            return erros;
    }

    public List<Pedido> RecuperarTodos() => pedidoRepository.RecuperarTodos();

    public Result<int> Remover(Guid id) => pedidoRepository.RemoverPorId(id);
}
