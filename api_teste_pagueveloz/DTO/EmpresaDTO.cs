using System.Collections.Generic;
using api_teste_pagueveloz.Models;

namespace api_teste_pagueveloz.DTO {
    public class EmpresaDTO {
        public List<FuncionarioDTO> participacoes = new List<FuncionarioDTO>();
        public int totalFuncionarios;
        public decimal totalDistribuidos;
        public decimal totalDisponibilizado;
        public decimal saldoTotalDisponibilizado;
    }
}
