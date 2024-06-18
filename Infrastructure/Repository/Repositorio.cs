using Domain.Model;
using Domain.Model.Errors;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository;

public abstract class Repositorio<T> where T : Entity<T>
{
    protected readonly LojaDbContext db;

    protected Repositorio(LojaDbContext db) => this.db = db;

    public void Adicionar(T entity)
    {
        db.Set<T>().Add(entity);
        db.SaveChanges();
    }
    public void Remover(T entity)
    {
        db.Set<T>().Remove(entity);
        db.SaveChanges();
    }

    public virtual T? RecuperarPorId(Guid id) => db.Set<T>().Find(id);

    public virtual Result<T> RecuperarPorId(Guid id, ErroEntidade erro) => db.Set<T>().Find(id) is T entity ? entity : (List<ErroEntidade>)[erro];

    public virtual List<T> RecuperarTodos() => db.Set<T>().ToList();

    public abstract Result<int> RemoverPorId(Guid id);

    public Result<int> RemoverPorId(Guid id, ErroEntidade erro) => Remover(e => e.Id == id, erro);

    protected Result<int> Remover(Expression<Func<T, bool>> condicao, ErroEntidade erro)
    {
        try
        {
            return db.Set<T>().Where(condicao).ExecuteDelete();
        }
        catch (Exception _)
        {
            return (List<ErroEntidade>)[erro];
        }
    }
}
