using System;

namespace api_teste_pagueveloz.Models {
    public class Funcionario {
        public int IdFuncionario;
        public string Matricula;
        public string Nome;
        public string Area;
        public string Cargo;
        public decimal SalarioBruto;
        public string DataAdmissao;
        public decimal ValorParticipacao;

        public int DefinirPesoAreaAtuacao() {
            string[] area = {"Diretoria", "Contabilidade",
        "Financeiro", "Tecnologia", "Serviços Gerais", "Relacionamento com o Cliente"};
            if (Area == area[0]) {
                return (int)Peso.Peso_1;
            } else if (Area == area[1]) {
                return (int)Peso.Peso_2;
            } else if (Area == area[2]) {
                return (int)Peso.Peso_2;
            } else if (Area == area[3]) {
                return (int)Peso.Peso_2;
            } else if (Area == area[4]) {
                return (int)Peso.Peso_3;
            } else if (Area == area[5]) {
                return (int)Peso.Peso_5;
            }
            return 0;
        }

        public int DefinirPesoFaixaSalarial() {
            decimal salario_minimo = 998.00M;
            decimal faixa_salarial = SalarioBruto / salario_minimo;

            if (faixa_salarial > 8) {
                return (int)Peso.Peso_5;
            } else if (faixa_salarial > 5 && faixa_salarial < 8) {
                return (int)Peso.Peso_3;
            } else if (faixa_salarial > 3 && faixa_salarial <= 5) {
                return (int)Peso.Peso_2;
            } else if (faixa_salarial <= 3) {
                return (int)Peso.Peso_1;
            }
            return 0;
        }

        public int DefinirPesoTempoAdmissao() {
            DateTime data_atual, data_admissao;
            string str_data_atual = (DateTime.Now.ToString("yyyy-MM-dd"));
            TimeSpan resultado;

            data_atual = DateTime.Parse(str_data_atual);
            data_admissao = DateTime.Parse(DataAdmissao);

            resultado = data_atual - data_admissao;

            if (resultado.Days / 365 <= 1) {
                return (int)Peso.Peso_1;
            } else if (resultado.Days / 365 > 1 && resultado.Days / 365 <= 3) {
                return (int)Peso.Peso_2;
            } else if (resultado.Days / 365 > 3 && resultado.Days / 365 < 8) {
                return (int)Peso.Peso_3;
            } else if (resultado.Days / 365 >= 8) {
                return (int)Peso.Peso_5;
            }
            return 0;
        }
        public void CalculaParticipacao() {
            decimal a = (SalarioBruto * DefinirPesoTempoAdmissao()) + (SalarioBruto * DefinirPesoAreaAtuacao());
            decimal b = (SalarioBruto * DefinirPesoFaixaSalarial());
            decimal c = (Math.Round(a, 2) / Math.Round(b, 2)) * 12;
            ValorParticipacao = Math.Round(c, 2);
        }
    }

    enum Peso {
        Peso_1 = 1,
        Peso_2 = 2,
        Peso_3 = 3,
        Peso_5 = 5
    }
}
