using System.Collections.Generic;
using api_teste_pagueveloz.Models;

namespace api_teste_pagueveloz.Services {
    public class ValorDistribuirServices {
        private readonly ConexaoDb conexao = new ConexaoDb();
        public Empresa empresa = new Empresa();
        
        public void SalvaSaldo(Dictionary<string, decimal> valor) {
            foreach (string i in valor.Keys) {
                empresa.totalDisponibilizado = valor["valor_distribuir"];

                var salvaSaldo = new Empresa {
                    totalDisponibilizado = valor["valor_distribuir"]
                };

                conexao.SalvaDados(0, 1, "Empresa/", salvaSaldo);
            }
        }
    }
}
