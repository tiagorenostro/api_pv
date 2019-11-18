using System.Collections.Generic;

namespace api_teste_pagueveloz.Models {
    public class Empresa {
        public List<Funcionario> participacoes = new List<Funcionario>(); 
        public int TotalFuncionarios; 
        public decimal TotalDistribuidos; 
        public decimal TotalDisponibilizado;
        public decimal SaldoTotalDisponibilizado; 

        public void _TotalFuncionarios() {
            TotalFuncionarios = participacoes.Count;
        }

        public void _SaldoTotalDisponibilizado() {
            SaldoTotalDisponibilizado = TotalDisponibilizado - TotalDistribuidos;
        }

        public void _TotalDistribuidos() {
            foreach (Funcionario f in participacoes) {
                TotalDistribuidos += f.ValorParticipacao;
            }
        }
    }
}
