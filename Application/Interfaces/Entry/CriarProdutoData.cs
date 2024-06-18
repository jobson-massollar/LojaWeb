using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Entry;

public record CriarProdutoData
{
    public string CodigoBarras { get; private set; }
    public string Descricao { get; private set; }
    public string Moeda { get; private set; }
    public float Preco { get; private set; }

    public CriarProdutoData() { }
}
