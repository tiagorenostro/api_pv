using System.Collections.Generic;
using System.Web.Http;
using api_teste_pagueveloz.Models;
using api_teste_pagueveloz.Services;
using api_teste_pagueveloz.DTO;

namespace api_teste_pagueveloz.Controllers {
    public class CalculaParticipacaoController : ApiController {
        public List<EmpresaDTO> empDtoList = new List<EmpresaDTO>();
        private readonly CalculaParticipacaoService calcula_participacao_service = new CalculaParticipacaoService();

        [HttpGet]
        [Route("api/Empresa/Calcula")]
        public IEnumerable<EmpresaDTO> GetCalculaPLR() {
            empDtoList = (List<EmpresaDTO>)calcula_participacao_service.CalculaEmpresa();
            return empDtoList;
        }
    }
}
