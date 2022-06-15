using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Services.Servicos
{
    public interface IAdminService
    {
        IEnumerable<Categoria> ConsultaCategorias();
        IEnumerable<Leilao> ConsultaLeiloes();
        Leilao ConsultaLeilaoPorId(int id);
        void CadastraLeilao(Leilao leilao);
        void ModificaLeilao(Leilao leilaoEditado);
        void RemoveLeilao(int idLeilao);
        void IniciaPregaoDeLeilaoComId(int id);
        void FinalizaLeilaoDePregaoComId(int id);
        IEnumerable<Leilao> PesquisaLeilaoEmPregaoPorTermo(string termo);
    }
}
