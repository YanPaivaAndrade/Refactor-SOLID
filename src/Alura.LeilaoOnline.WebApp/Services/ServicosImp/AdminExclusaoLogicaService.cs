using Alura.LeilaoOnline.WebApp.Dados.Daos;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Services.Servicos;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Services.ServicosImp
{
    public class AdminExclusaoLogicaService : IAdminService
    {
        private IAdminService _defaultAdminService;

        public AdminExclusaoLogicaService(ILeilaoDao leilaoDao, ICategoriaDao categoriaDao)
        {
            _defaultAdminService = new AdminService(leilaoDao, categoriaDao);
        }

        public void CadastraLeilao(Leilao leilao)
        {
            _defaultAdminService.CadastraLeilao(leilao);
        }

        public IEnumerable<Categoria> ConsultaCategorias()
        {
            return _defaultAdminService.ConsultaCategorias();
        }

        public Leilao ConsultaLeilaoPorId(int id)
        {
            return _defaultAdminService.ConsultaLeilaoPorId(id);
        }

        public IEnumerable<Leilao> ConsultaLeiloes()
        {
            return _defaultAdminService.ConsultaLeiloes().Where(l => l.Situacao != SituacaoLeilao.Arquivado);
        }

        public void FinalizaLeilaoDePregaoComId(int id)
        {
            _defaultAdminService.FinalizaLeilaoDePregaoComId(id);
        }

        public void IniciaPregaoDeLeilaoComId(int id)
        {
            _defaultAdminService.IniciaPregaoDeLeilaoComId(id);
        }

        public void ModificaLeilao(Leilao leilaoEditado)
        {
            _defaultAdminService.ModificaLeilao(leilaoEditado);
        }

        public IEnumerable<Leilao> PesquisaLeilaoEmPregaoPorTermo(string termo)
        {
            return _defaultAdminService.PesquisaLeilaoEmPregaoPorTermo(termo);
        }

        public void RemoveLeilao(int idLeilao)
        {
            var leilao = _defaultAdminService.ConsultaLeilaoPorId(idLeilao);
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Arquivado;
                _defaultAdminService.ModificaLeilao(leilao);
            }
        }
    }
}
