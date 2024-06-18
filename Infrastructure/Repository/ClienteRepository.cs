using Application.Interfaces.Infrastructure.Repository;
using Domain.Model;
using Domain.Model.Errors;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ClienteRepository : Repositorio<Cliente>, IClienteRepository
{
    public ClienteRepository(LojaDbContext db) : base(db) { }

    public bool JaExisteCPF(long cpf) => db.Clientes.FirstOrDefault(c => c.CPF.Valor == cpf) is Cliente;

    public bool JaExisteEmail(string email) => db.Clientes.FirstOrDefault(c => c.Email == email) is Cliente;

    public Result<List<Pedido>?> RecuperarPedidos(Guid clienteId)
    {
        var result = RecuperarPorId(clienteId, ErroEntidade.CLIENTE_NAO_ENCONTRADO);

        return result.IsSuccess ? result.Value!.Pedidos : result.Errors!;
    }

    public Cliente? RecuperarPorCPF(long cpf) =>
        db.Clientes
            .Include(c => c.Endereco)
            .ThenInclude(e => e.UF)
            .FirstOrDefault(c => c.CPF.Valor == cpf);

    public override Cliente? RecuperarPorId(Guid id) =>
        db.Clientes
            .Include(c => c.Endereco)
            .ThenInclude(e => e.UF)
            .FirstOrDefault(c => c.Id == id);

    public Result<List<Preferencia>?> RecuperarPreferencias(Guid clienteId)
    {
        var result = RecuperarPorId(clienteId, ErroEntidade.CLIENTE_NAO_ENCONTRADO);

        return result.IsSuccess ? result.Value!.Preferencias : result.Errors!;
    }

    public override List<Cliente> RecuperarTodos() =>
        db.Clientes
            .Include(c => c.Endereco)
            .ThenInclude(e => e.UF)
            .ToList();

    public override Result<int> RemoverPorId(Guid id) => RemoverPorId(id, ErroEntidade.CLIENTE_NAO_ENCONTRADO);

    public Result<int> RemoverPorCpf(long cpf) => Remover(c => c.CPF.Valor == cpf, ErroEntidade.CLIENTE_NAO_ENCONTRADO);
}
