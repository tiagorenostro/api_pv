using System.Collections.Generic;
using System.Web.Http;
using System.Net;
using Desafio.Services;
using Desafio.DTO;

namespace Desafio.Controllers{
    public class FuncionarioController : ApiController {
        private readonly FuncionarioServices funcServices = new FuncionarioServices();
        public List<FuncionarioDTO> listaFuncDTO = new List<FuncionarioDTO>();

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
