using Alura.LeilaoOnline.WebApp.Dados.Daos;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Services.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Services.ServicosImp
{
    public class AdminService : IAdminService
    {
        private ILeilaoDao _leilaoDao;
        private ICategoriaDao _categoriaDao;

        public AdminService(ILeilaoDao leilaoDao, ICategoriaDao categoriaDao)
        {
            _leilaoDao = leilaoDao;
            _categoriaDao = categoriaDao;
        }

        public void CadastraLeilao(Leilao leilao)
        {
            _leilaoDao.Incluir(leilao);
        }

        public IEnumerable<Categoria> ConsultaCategorias()
        {
            return _categoriaDao.BuscarTodos();
        }

        public Leilao ConsultaLeilaoPorId(int id)
        {
            return _leilaoDao.BuscarPorId(id);
        }

        public IEnumerable<Leilao> ConsultaLeiloes()
        {
            return _leilaoDao.BuscarTodos();
        }

        public void FinalizaLeilaoDePregaoComId(int id)
        {
            var leilao = _leilaoDao.BuscarPorId(id);
            if(leilao != null && leilao.Situacao == SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Finalizado;
                leilao.Termino = DateTime.Now;
                _leilaoDao.Alterar(leilao);
            }
        }

        public void IniciaPregaoDeLeilaoComId(int id)
        {
            var leilao = _leilaoDao.BuscarPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Rascunho)
            {
                leilao.Situacao = SituacaoLeilao.Pregao;
                leilao.Inicio = DateTime.Now;
                _leilaoDao.Alterar(leilao);
            }
        }

        public void ModificaLeilao(Leilao leilaoEditado)
        {
            _leilaoDao.Alterar(leilaoEditado);
        }

        public void RemoveLeilao(int idLeilao)
        {
            var leilao = _leilaoDao.BuscarPorId(idLeilao);
            if (leilao == null || leilao.Situacao == SituacaoLeilao.Pregao)
            {
                return;
            }
            _leilaoDao.Excluir(leilao);
        }
        public IEnumerable<Leilao> PesquisaLeilaoEmPregaoPorTermo(string termo)
        {
            var termoNormalized = termo.ToUpper();
            var leiloes = _leilaoDao.BuscarTodos();
            leiloes = leiloes.Where(l => string.IsNullOrWhiteSpace(termo) ||
                    l.Titulo.ToUpper().Contains(termoNormalized) ||
                    l.Descricao.ToUpper().Contains(termoNormalized) ||
                    l.Categoria.Descricao.ToUpper().Contains(termoNormalized)
                );
            return leiloes;
        }
    }
}
