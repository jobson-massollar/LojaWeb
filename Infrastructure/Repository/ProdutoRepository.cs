using Application.Interfaces.Infrastructure.Repository;
using Domain.Model;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository;

public class ProdutoRepository : IProdutoRepository
{
    private readonly LojaDbContext db;

    public ProdutoRepository(LojaDbContext db)
    {
        this.db = db;
    }

    public void Add(Produto produto)
    {
        db.Add(produto);
        db.SaveChanges();
    }

    public Produto? RecuperarPorCodigo(string codigo)
    {
        return db.Produtos.FirstOrDefault(p => p.CodigoBarras.Valor == codigo);
    }

    public List<Produto> RecuperarTodos()
    {
        return db.Produtos.ToList();
    }

    public int Remove(Guid id)
    {
        return db.Produtos.Where(p => p.Id == id).ExecuteDelete();
    }

    public int Remove(string descricao)
    {
        return db.Produtos.Where(p => p.Descricao == descricao).ExecuteDelete();
    }
}
