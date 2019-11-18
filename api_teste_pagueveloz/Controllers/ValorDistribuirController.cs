using System.Net;
using System.Collections.Generic;
using System.Web.Http;
using api_teste_pagueveloz.Services;

namespace api_teste_pagueveloz.Controllers {
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
