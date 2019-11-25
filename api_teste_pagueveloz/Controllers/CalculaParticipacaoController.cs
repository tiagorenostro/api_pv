using System.Collections.Generic;
using System.Web.Http;
using Desafio.Services;
using Desafio.DTO;

namespace Desafio.Controllers {
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
