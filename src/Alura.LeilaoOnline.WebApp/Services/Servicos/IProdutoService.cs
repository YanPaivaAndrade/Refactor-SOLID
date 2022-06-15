using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Servicos
{
    public interface IProdutoService
    {
        IEnumerable<Leilao> PesquisaLeilaoEmPregaoPorTermo(string termo);
        IEnumerable<CategoriaComInfoLeilao> ConsultaCategoriasComTotalDeLeiloes();
        Categoria ConsultaCategoriaPorId(int id);
    }
}
