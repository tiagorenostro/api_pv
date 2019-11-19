using System.Collections.Generic;
using api_teste_pagueveloz.Models;

namespace api_teste_pagueveloz.DTO {
    public class EmpresaDTO {
        public List<FuncionarioDTO> participacoes = new List<FuncionarioDTO>();
        public int TotalFuncionarios;
        public decimal TotalDistribuidos;
        public decimal TotalDisponibilizado;
        public decimal SaldoTotalDisponibilizado;
    }
}
