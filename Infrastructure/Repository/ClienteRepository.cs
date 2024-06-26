﻿using Application.Interfaces.Infrastructure.Repository;
using Domain.Model;
using Domain.Model.Errors;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ClienteRepository : Repositorio<Cliente>, IClienteRepository
{
    public ClienteRepository(LojaDbContext db) : base(db) { }

    public bool JaExisteCPF(long cpf) => db.Clientes.SingleOrDefault(c => c.CPF.Valor == cpf) is Cliente;

    public bool JaExisteEmail(string email) => db.Clientes.SingleOrDefault(c => c.Email == email) is Cliente;

    public Result<List<Pedido>?> RecuperarPedidos(Guid id)
    {
        var cliente = RecuperarPorIdComPedidos(id);

        return cliente is not null ? cliente.Pedidos : (List<ErroEntidade>)[ErroEntidade.CLIENTE_NAO_ENCONTRADO];
    }

    public Cliente? RecuperarPorCPF(long cpf) =>
        db.Clientes
            .Include(c => c.Endereco)
            .ThenInclude(e => e.UF)
            .SingleOrDefault(c => c.CPF.Valor == cpf);

    public override Cliente? RecuperarPorId(Guid id) =>
        db.Clientes
            .Include(c => c.Endereco)
            .ThenInclude(e => e.UF)
            .SingleOrDefault(c => c.Id == id);

    public Cliente? RecuperarPorIdComPreferencias(Guid id) =>
        db.Clientes
            .Include(c => c.Preferencias)
            .SingleOrDefault(c => c.Id == id);

    public Cliente? RecuperarPorIdComPedidos(Guid id) =>
        db.Clientes
            .Include(c => c.Pedidos)
            .ThenInclude(p => p.Itens)
            .ThenInclude(it => it.Produto)
            .SingleOrDefault(c => c.Id == id);

    public Result<List<Preferencia>?> RecuperarPreferencias(Guid id)
    {
        var cliente = RecuperarPorIdComPreferencias(id);

        return cliente is not null ? cliente.Preferencias : (List<ErroEntidade>)[ErroEntidade.CLIENTE_NAO_ENCONTRADO];
    }

    public void AtualizarPreferencias(Cliente cliente, List<Preferencia> preferencias)
    {
        db.Clientes.Update(cliente);
        db.SaveChanges();

    }

    public override List<Cliente> RecuperarTodos() =>
        db.Clientes
            .Include(c => c.Endereco)
            .ThenInclude(e => e.UF)
            .ToList();

    public override Result<int> RemoverPorId(Guid id) => RemoverPorId(id, ErroEntidade.CLIENTE_NAO_ENCONTRADO);

    public Result<int> RemoverPorCpf(long cpf) => Remover(c => c.CPF.Valor == cpf, ErroEntidade.CLIENTE_NAO_ENCONTRADO);
}
