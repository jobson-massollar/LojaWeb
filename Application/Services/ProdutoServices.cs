using Application.Interfaces.Entry;
using Application.Interfaces.Infrastructure.Repository;
using Domain.Model;
using Domain.Model.Errors;

namespace Application.Services;

public class ProdutoServices : IProdutoServices
{
    private readonly IProdutoRepository produtoRepository;

    public ProdutoServices(IProdutoRepository produtoRepository)
    {
        this.produtoRepository = produtoRepository;
    }

    public Result<Produto> CriarProduto(CriarProdutoData data)
    {
        List<ErroEntidade> erros = [];

        var produto = produtoRepository.RecuperarPorCodigo(data.CodigoBarras);

        if (produto is not null)
            erros.Add(ErroEntidade.PRODUTO_CODIGO_BARRAS_JA_EXISTE);

        var result = new ProdutoBuilder(data.CodigoBarras, data.Descricao, data.Moeda, data.Preco).Build();

        if (result.hasErrors)
            erros = erros.Concat(result.Errors!).ToList();

        if (erros.Count == 0)
        {
            produtoRepository.Adicionar(result.Value!);

            return result;
        }
        else
            return erros;
    }

    public Produto? RecuperarPorCodigo(string codigo)
    {
        return produtoRepository.RecuperarPorCodigo(codigo);
    }

    public List<Produto> RecuperarTodos()
    {
        return produtoRepository.RecuperarTodos();
    }

    public Result<int> Remover(string codigoBarras)
    {
        return produtoRepository.RemoverPorCodigo(codigoBarras);
    }

    public Result<int> Remover(Guid id)
    {
        return produtoRepository.RemoverPorId(id);
    }
}
