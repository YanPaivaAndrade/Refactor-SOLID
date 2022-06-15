using Alura.LeilaoOnline.WebApp.Dados.Daos;
using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados.DaosImp
{
    public class LeilaoDao : ILeilaoDao
    {
        AppDbContext _context;

        public LeilaoDao()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<Leilao> BuscarTodos()
        {
            return _context.Leiloes.Include(l => l.Categoria).ToList();
        }
        public Leilao BuscarPorId(int id)
        {
            return _context.Leiloes.First(l => l.Id == id);
        }
        public void Incluir(Leilao leilao)
        {
            _context.Leiloes.Add(leilao);
            _context.SaveChanges();
        }
        public void Alterar(Leilao leilao)
        {
            _context.Update(leilao);
            _context.SaveChanges();
        }
        public void Excluir(Leilao leilao)
        {
            _context.Remove(leilao);
            _context.SaveChanges();
        }
    }
}
