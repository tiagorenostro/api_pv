using System.Collections.Generic;
using System.Web.Http;
using System.Net;
using api_teste_pagueveloz.Services;
using api_teste_pagueveloz.Models;

namespace api_teste_pagueveloz.Controllers{
    public class FuncionarioController : ApiController {
        public List<Funcionario> lista_funcionarios = new List<Funcionario>();
        private readonly FuncionarioServices funciona_services = new FuncionarioServices();

        [HttpGet]
        [Route("api/Empresa/Funcionario")]
        public List<Funcionario> GetFuncionarios() {
            lista_funcionarios = (List<Funcionario>)funciona_services.ObterFuncionario();
            return lista_funcionarios;
        }

        [HttpPost]
        [Route("api/Empresa/Funcionario")]
        public HttpStatusCode PostFuncionario([FromBody] List<IDictionary<string, string>> post_funcionario) {
            funciona_services.SalvaFuncionario(post_funcionario);
            return HttpStatusCode.OK;
        } 
    }
}
