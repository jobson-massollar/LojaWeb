﻿using Domain.Model;
using Domain.Model.Errors;

namespace Application.Interfaces.Infrastructure.Repository;

public interface IClienteRepository
{
    void Adicionar(Cliente cliente);

    void Atualizar(Cliente cliente);

    void Remover(Cliente cliente);

    Cliente? RecuperarPorId(Guid id);

    Result<Cliente> RecuperarPorId(Guid id, ErroEntidade erro);

    List<Cliente> RecuperarTodos();

    Result<int> RemoverPorId(Guid id);

    Result<int> RemoverPorId(Guid id, ErroEntidade erro);

    Cliente? RecuperarPorCPF(long cpf);

    Result<List<Preferencia>?> RecuperarPreferencias(Guid id);

    Result<List<Pedido>?> RecuperarPedidos(Guid id);

    Cliente? RecuperarPorIdComPreferencias(Guid id);

    void AtualizarPreferencias(Cliente cliente, List<Preferencia> preferencias);

    bool JaExisteCPF(long cpf);

    bool JaExisteEmail(string email);

    Result<int> RemoverPorCpf(long cpf);
}
