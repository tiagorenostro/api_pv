using System.Net;
using System.Collections.Generic;
using System.Web.Http;
using Desafio.Services;

namespace Desafio.Controllers {
    public class ValorDistribuirController : ApiController {
        public ValorDistribuirServices valor_distribuir_services = new ValorDistribuirServices();

        [HttpPost]
        [Route("api/Empresa/ValorDistribuir")]
        public HttpStatusCode PostSaldo([FromBody] Dictionary<string, decimal> valor) {
                valor_distribuir_services.SalvaSaldo(valor);
                return HttpStatusCode.OK;

        }
    }
}
