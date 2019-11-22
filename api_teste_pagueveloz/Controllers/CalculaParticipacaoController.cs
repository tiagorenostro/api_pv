using System.Collections.Generic;
using System.Web.Http;
using api_teste_pagueveloz.Models;
using api_teste_pagueveloz.Services;
using api_teste_pagueveloz.DTO;

namespace api_teste_pagueveloz.Controllers {
    public class CalculaParticipacaoController : ApiController {
        public List<EmpresaDTO> listaEmpresaDTO = new List<EmpresaDTO>();
        private readonly CalculaParticipacaoService calculaParticipacaoServ = new CalculaParticipacaoService();

        [HttpGet]
        [Route("api/Empresa/Calcula")]
        public IEnumerable<EmpresaDTO> GetCalculaPLR() {
            listaEmpresaDTO = (List<EmpresaDTO>)calculaParticipacaoServ.CalculaEmpresa();
            return listaEmpresaDTO;
        }
    }
}
