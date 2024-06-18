using Application.Interfaces.Infrastructure.Repository;
using Domain.Model;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class UFRepository : IUFRepository
{
    private readonly LojaDbContext db;

    public UFRepository(LojaDbContext db) => this.db = db;

    public void Add(UF uf)
    {
        db.Add(uf);
        db.SaveChanges();
    }

    public UF? RecuperarPorSigla(string sigla) => db.UFs.FirstOrDefault(uf => uf.Sigla == sigla);

    public List<UF> RecuperarTodas() => db.UFs.ToList();

    public bool JaExisteUF(string siglaUF) => db.UFs.FirstOrDefault(uf => uf.Sigla == siglaUF) is UF;

    public int Remove(Guid id) => db.UFs.Where(uf => uf.Id == id).ExecuteDelete();

    public int Remove(string sigla) => db.UFs.Where(uf => uf.Sigla == sigla).ExecuteDelete();
}
