using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Dados.Daos
{
    public interface ILeilaoDao
    {
        IEnumerable<Leilao> BuscarLeiloes();
        Leilao BuscarLeilaoPorId(int id);
        void IncluirLeilao(Leilao leilao);
        void AlterarLeilao(Leilao leilao);
        void ExcluirLeilao(Leilao leilao);


    }
}
