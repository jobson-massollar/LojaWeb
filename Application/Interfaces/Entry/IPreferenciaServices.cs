using Domain.Model;
using Domain.Model.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Entry;

public interface IPreferenciaServices
{
    Result<Preferencia> CriarPreferencia(string descricao);

    Preferencia? RecuperarPorDescricao(string descricao);

    List<Preferencia> RecuperarPorCliente(Guid clienteId);

    List<Preferencia> RecuperarTodas();

    int RemoverPreferencia(Guid id);

    int RemoverPreferencia(string descricao);
}
