using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Infrastructure.Repository;

public interface IProdutoRepository
{
    Produto? RecuperarPorCodigo(string codigo);

    List<Produto> RecuperarTodos();

    void Add(Produto produto);

    int Remove(Guid id);

    int Remove(string descricao);
}
