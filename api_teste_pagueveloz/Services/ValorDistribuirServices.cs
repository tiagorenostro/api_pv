using System.Collections.Generic;
using api_teste_pagueveloz.Models;

namespace api_teste_pagueveloz.Services {
    public class ValorDistribuirServices {
        public Empresa empresa = new Empresa();
        private readonly ConexaoDb conexao = new ConexaoDb();

        public void SalvaSaldo(Dictionary<string, decimal> valor) {
            foreach (string i in valor.Keys) {
                empresa.TotalDisponibilizado = valor["valor_distribuir"];

                var salva_saldo = new Empresa {
                    TotalDisponibilizado = valor["valor_distribuir"]
                };

                conexao.SalvaDados(0, 1, "Empresa/", salva_saldo);
            }
        }
    }
}
