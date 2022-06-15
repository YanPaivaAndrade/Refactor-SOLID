using Alura.LeilaoOnline.WebApp.Dados.Daos;
using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Dados.DaosImp
{
    public class CategoriaDao : ICategoriaDao
    {
        AppDbContext _context;

        public CategoriaDao()
        {
            _context = new AppDbContext();
        }
        public IEnumerable<Categoria> BuscarCategorias()
        {
            return _context.Categorias.ToList();
        }
    }
}
