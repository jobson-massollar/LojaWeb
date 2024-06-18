using Api.Contracts;
using Domain.Model;
using Domain.Model.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Entry;

public interface IPedidoServices
{
    Result<Pedido> CriarPedido(CriarPedidoData dados);
}
