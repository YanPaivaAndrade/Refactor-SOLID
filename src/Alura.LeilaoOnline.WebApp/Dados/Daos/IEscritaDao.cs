using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Dados.Daos
{
    public interface IEscritaDao <T>
    {
        void Incluir(T entity);
        void Alterar(T entity);
        void Excluir(T entity);
    }
}
