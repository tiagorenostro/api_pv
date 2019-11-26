using System.Collections.Generic;
using System.Web.Http;
using Desafio.Services;
using Desafio.DTO;

namespace Desafio.Controllers {
    public class CalculaParticipacaoController : ApiController {
        private readonly CalculaParticipacaoService calculaParticipacaoServ = new CalculaParticipacaoService();
        public List<EmpresaDTO> listaEmpresaDTO = new List<EmpresaDTO>();

        [HttpGet]
        [Route("api/Empresa/Calcula")]
        public IEnumerable<EmpresaDTO> GetCalculaPLR() {
            listaEmpresaDTO = (List<EmpresaDTO>)calculaParticipacaoServ.CalculaEmpresa();
            return listaEmpresaDTO;
        }
    }
}
