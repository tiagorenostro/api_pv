using System.Collections.Generic;
using Desafio.Models;

namespace Desafio.DTO {
    public class EmpresaDTO {
        public List<FuncionarioDTO> participacoes = new List<FuncionarioDTO>();
        public int totalFuncionarios;
        public decimal totalDistribuidos;
        public decimal totalDisponibilizado;
        public decimal saldoTotalDisponibilizado;
    }
}
