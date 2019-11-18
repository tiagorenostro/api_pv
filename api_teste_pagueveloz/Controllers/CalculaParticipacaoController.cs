using System.Collections.Generic;
using System.Web.Http;
using api_teste_pagueveloz.Models;
using api_teste_pagueveloz.Services;

namespace api_teste_pagueveloz.Controllers {
    public class CalculaParticipacaoController : ApiController {
        public List<Empresa> lista_empresa = new List<Empresa>();
        private readonly CalculaParticipacaoService calcula_participacao_service = new CalculaParticipacaoService();

        [HttpGet]
        [Route("api/Empresa/Calcula")]
        public IEnumerable<Empresa> GetCalculaPLR() {
            lista_empresa = (List<Empresa>)calcula_participacao_service.CalculaEmpresa();
            return lista_empresa;
        }
    }
}
