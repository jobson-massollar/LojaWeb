using Application.Interfaces.Infrastructure.Repository;
using Domain.Model;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ClienteRepository : IClienteRepository
{
    private readonly LojaDbContext db;

    public ClienteRepository(LojaDbContext db) => this.db = db;

    public void Add(Cliente cliente)
    {
        db.Add(cliente);
        db.SaveChanges();
    }

    public bool JaExisteCPF(long cpf) => db.Clientes.FirstOrDefault(c => c.CPF.Valor == cpf) is Cliente;

    public bool JaExisteEmail(string email) => db.Clientes.FirstOrDefault(c => c.Email == email) is Cliente;

    public Cliente? RecuperarPorCPF(long cpf) =>
        db.Clientes
            .Include(c => c.Endereco)
            .ThenInclude(e => e.UF)
            .FirstOrDefault(c => c.CPF.Valor == cpf);

    public Cliente? RecuperarPorId(Guid id) =>
        db.Clientes
            .Include(c => c.Endereco)
            .ThenInclude(e => e.UF)
            .FirstOrDefault(c => c.Id == id);

    public List<Cliente> RecuperarTodos() =>
        db.Clientes
            .Include(c => c.Endereco)
            .ThenInclude(e => e.UF)
            .ToList();

    public int Remove(Guid id) => db.Clientes.Where(c => c.Id == id).ExecuteDelete();

    public int Remove(long cpf) => db.Clientes.Where(c => c.CPF.Valor == cpf).ExecuteDelete();
}
