using System.Collections.Generic;

namespace Desafio.Models {
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
