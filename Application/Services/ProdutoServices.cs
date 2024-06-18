using Application.Interfaces.Entry;
using Application.Interfaces.Infrastructure.Repository;
using Domain.Model;
using Domain.Model.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        var result = new ProdutoBuilder(data.CodigoBarras, data.Descricao, data.Moeda, data.Preco).Build();

        if (result.IsSuccess)
            produtoRepository.Add(result.Value!);

        return result;
    }

    public Produto? RecuperarPorCodigo(string codigo)
    {
        return produtoRepository.RecuperarPorCodigo(codigo);
    }

    public List<Produto> RecuperarTodos()
    {
        return produtoRepository.RecuperarTodos();
    }

    public int RemoverProduto(string codigo)
    {
        return produtoRepository.Remove(codigo);
    }

    public int RemoverProduto(Guid id)
    {
        return produtoRepository.Remove(id);
    }
}
