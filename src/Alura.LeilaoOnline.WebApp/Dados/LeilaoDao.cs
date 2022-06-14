using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public class LeilaoDao
    {
        AppDbContext _context;

        public LeilaoDao()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<Leilao> BuscarLeiloes()
        {
            return _context.Leiloes.Include(l => l.Categoria).ToList();
        }
        public Leilao BuscarLeilaoPorId(int id)
        {
            return _context.Leiloes.First(l => l.Id == id);
        }
        public void IncluirLeilao(Leilao leilao)
        {
            _context.Leiloes.Add(leilao);
            _context.SaveChanges();
        }
        public void AlterarLeilao(Leilao leilao)
        {
            _context.Update(leilao);
            _context.SaveChanges();
        }
        public void ExcluirLeilao(Leilao leilao)
        {
            _context.Remove(leilao);
            _context.SaveChanges();
        }
    }
}
