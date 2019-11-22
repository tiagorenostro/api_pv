using System.Collections.Generic;

namespace api_teste_pagueveloz.Models {
    public class Empresa {
        public List<Funcionario> participacoes = new List<Funcionario>(); 
        public int totalFuncionarios; 
        public decimal totalDistribuidos; 
        public decimal totalDisponibilizado;
        public decimal saldoTotalDisponibilizado; 

        public void SetTotalFuncionarios() {
            totalFuncionarios = participacoes.Count;
        }

        public void SetSaldoTotalDisponibilizado() {
            saldoTotalDisponibilizado = totalDisponibilizado - totalDistribuidos;
        }

        public void SetTotalDistribuidos() {
            foreach (Funcionario f in participacoes) {
                totalDistribuidos += f.valorParticipacao;
            }
        }
    }
}
