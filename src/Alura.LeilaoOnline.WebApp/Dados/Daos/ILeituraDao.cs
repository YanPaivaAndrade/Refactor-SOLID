using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Dados.Daos
{
    public interface ILeituraDao<T>
    {
        IEnumerable<T> BuscarTodos();
        T BuscarPorId(int id);        

    }
}
