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

public class PreferenciaRepository : IPreferenciaRepository
{
    private readonly LojaDbContext db;

    public PreferenciaRepository(LojaDbContext db)
    {
        this.db = db;
    }

    public void Add(Preferencia preferencia)
    {
        db.Preferencias.Add(preferencia);
        db.SaveChanges();
    }

    public List<Preferencia> RecuperarPorCliente(Guid clienteId)
    {
        return db.Preferencias.Include(p => p.Clientes.Where(c => c.Id == clienteId)).ToList();
    }

    public Preferencia? RecuperarPorDescricao(string descricao)
    {
        return db.Preferencias.FirstOrDefault(p => p.Descricao == descricao);
    }

    public List<Preferencia> RecuperarTodas()
    {
        return db.Preferencias.ToList();   
    }

    public int Remove(Guid id)
    {
        return db.Preferencias.Where(p => p.Id == id).ExecuteDelete();
    }

    public int Remove(string descricao)
    {
        return db.Preferencias.Where(p => p.Descricao == descricao).ExecuteDelete();
    }
}
