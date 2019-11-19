using System.Collections.Generic;
using System.Web.Http;
using System.Net;
using api_teste_pagueveloz.Services;
using api_teste_pagueveloz.DTO;

namespace api_teste_pagueveloz.Controllers{
    public class FuncionarioController : ApiController {
        public List<FuncionarioDTO> listFuncDto = new List<FuncionarioDTO>();
        private readonly FuncionarioServices func_services = new FuncionarioServices();

        [HttpGet]
        [Route("api/Empresa/Funcionario")]
        public List<FuncionarioDTO> GetFuncionarios() {
            listFuncDto = func_services.ObterFuncionario();
            return listFuncDto;
        }

        [HttpPost]
        [Route("api/Empresa/Funcionario")]
        public HttpStatusCode PostFuncionario([FromBody] List<IDictionary<string, string>> post_funcionario) {
            func_services.SalvaFuncionario(post_funcionario);
            return HttpStatusCode.OK;
        } 
    }
}
