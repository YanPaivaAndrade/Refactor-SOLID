using Alura.LeilaoOnline.WebApp.Dados.Daos;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Services.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Services.ServicosImp
{
    public class ProdutoService : IProdutoService
    {
        private ILeilaoDao _leilaoDao;
        private ICategoriaDao _categoriaDao;

        public ProdutoService(ILeilaoDao leilaoDao, ICategoriaDao categoriaDao)
        {
            _leilaoDao = leilaoDao;
            _categoriaDao = categoriaDao;
        }

        public Categoria ConsultaCategoriaPorId(int id)
        {
            return _categoriaDao.BuscarCategoriaPorId(id);
        }

        public IEnumerable<CategoriaComInfoLeilao> ConsultaCategoriasComTotalDeLeiloes()
        {
            var categorias = _categoriaDao.BuscarCategoriasEIncluirLeiloes();
            var categoriaComInfo = categorias
            .Select(c => new CategoriaComInfoLeilao
             {
                 Id = c.Id,
                 Descricao = c.Descricao,
                 Imagem = c.Imagem,
                 EmRascunho = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Rascunho).Count(),
                 EmPregao = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Pregao).Count(),
                 Finalizados = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Finalizado).Count(),
             });
            return categoriaComInfo;
        }

        public IEnumerable<Leilao> PesquisaLeilaoEmPregaoPorTermo(string termo)
        {
            var termoNormalized = termo.ToUpper();
            var leiloes = _leilaoDao.BuscarLeiloes();
            leiloes = leiloes.Where(l => string.IsNullOrWhiteSpace(termo) ||
                    l.Titulo.ToUpper().Contains(termoNormalized) ||
                    l.Descricao.ToUpper().Contains(termoNormalized) ||
                    l.Categoria.Descricao.ToUpper().Contains(termoNormalized)
                );
            return leiloes;
        }
    }
}
