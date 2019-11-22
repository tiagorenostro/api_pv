using System.Collections.Generic;
using System.Web.Http;
using System.Net;
using api_teste_pagueveloz.Services;
using api_teste_pagueveloz.DTO;

namespace api_teste_pagueveloz.Controllers{
    public class FuncionarioController : ApiController {
        public List<FuncionarioDTO> listaFuncDTO = new List<FuncionarioDTO>();
        private readonly FuncionarioServices funcServices = new FuncionarioServices();

        [HttpGet]
        [Route("api/Empresa/Funcionario")]
        public List<FuncionarioDTO> GetFuncionarios() {
            listaFuncDTO = funcServices.ObterFuncionario();
            return listaFuncDTO;
        }

        [HttpPost]
        [Route("api/Empresa/Funcionario")]
        public HttpStatusCode PostFuncionario([FromBody] List<IDictionary<string, string>> postFuncionario) {
            funcServices.SalvaFuncionario(postFuncionario);
            return HttpStatusCode.OK;
        } 
    }
}
