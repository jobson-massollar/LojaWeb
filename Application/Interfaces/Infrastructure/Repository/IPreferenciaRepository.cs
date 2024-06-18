using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Infrastructure.Repository;

public interface IPreferenciaRepository
{
    Preferencia? RecuperarPorDescricao(string descricao);

    List<Preferencia> RecuperarPorCliente(Guid clienteId);

    List<Preferencia> RecuperarTodas();

    void Add(Preferencia preferencia);

    int Remove(Guid id);

    int Remove(string descricao);
}
