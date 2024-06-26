﻿using Domain.Model;
using Domain.Model.Errors;

namespace Application.Interfaces.Infrastructure.Repository;

public interface IPedidoRepository
{
    void Adicionar(Pedido pedido);

    void Remover(Pedido pedido);

    Pedido? RecuperarPorId(Guid id);

    Result<Pedido> RecuperarPorId(Guid id, ErroEntidade erro);

    List<Pedido> RecuperarTodos();

    Result<int> RemoverPorId(Guid id);

    Result<int> RemoverPorId(Guid id, ErroEntidade erro);
}
