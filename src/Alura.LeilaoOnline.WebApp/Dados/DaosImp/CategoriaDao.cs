using Alura.LeilaoOnline.WebApp.Dados.Daos;
using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
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


        public Categoria BuscarPorId(int id)
        {
            return _context.Categorias.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Categoria> BuscarTodos()
        {
            return _context.Categorias.Include(c => c.Leiloes).ToList();
        }

    }
}
