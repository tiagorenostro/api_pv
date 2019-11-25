using System.Collections.Generic;
using Desafio.Models;
using api_teste_pagueveloz.Repositorio;

namespace Desafio.Services {
    public class ValorDistribuirServices {
        private Repositorio Repositorio = new Repositorio();
        public Empresa empresa = new Empresa();
        
        public void SalvaSaldo(Dictionary<string, decimal> valor) {
            foreach (string i in valor.Keys) {
                empresa.totalDisponibilizado = valor["valor_distribuir"];

                var salvaSaldo = new Empresa {
                    totalDisponibilizado = valor["valor_distribuir"]
                };

                Repositorio.Atualizar(1, "Empresa/", salvaSaldo);
            }
        }
    }
}
