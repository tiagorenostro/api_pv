using System;

namespace api_teste_pagueveloz.Models {
    public class Funcionario {
        public int idFuncionario;
        public string matricula;
        public string nome;
        public string area;
        public string cargo;
        public decimal salarioBruto;
        public string dataAdmissao;
        public decimal valorParticipacao;

        public int DefinirPesoAreaAtuacao() {
            string[] areaVet = {"Diretoria", "Contabilidade",
        "Financeiro", "Tecnologia", "Serviços Gerais", "Relacionamento com o Cliente"};
            if (area == areaVet[0]) {
                return (int)Peso.Peso_1;
            } else if (area == areaVet[1]) {
                return (int)Peso.Peso_2;
            } else if (area == areaVet[2]) {
                return (int)Peso.Peso_2;
            } else if (area == areaVet[3]) {
                return (int)Peso.Peso_2;
            } else if (area == areaVet[4]) {
                return (int)Peso.Peso_3;
            } else if (area == areaVet[5]) {
                return (int)Peso.Peso_5;
            }
            return 0;
        }

        public int DefinirPesoFaixaSalarial() {
            decimal salarioMinimo = 998.00M;
            decimal faixaSalarial = salarioBruto / salarioMinimo;

            if (faixaSalarial > 8) {
                return (int)Peso.Peso_5;
            } else if (faixaSalarial > 5 && faixaSalarial < 8) {
                return (int)Peso.Peso_3;
            } else if (faixaSalarial > 3 && faixaSalarial <= 5) {
                return (int)Peso.Peso_2;
            } else if (faixaSalarial <= 3) {
                return (int)Peso.Peso_1;
            }
            return 0;
        }

        public int DefinirPesoTempoAdmissao() {
            DateTime dtDataAtual, dtDataAdmissao;
            string strDataAtual = (DateTime.Now.ToString("yyyy-MM-dd"));
            TimeSpan resultado;

            dtDataAtual = DateTime.Parse(strDataAtual);
            dtDataAdmissao = DateTime.Parse(dataAdmissao);

            resultado = dtDataAtual - dtDataAdmissao;

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
            decimal a = (salarioBruto * DefinirPesoTempoAdmissao()) + (salarioBruto * DefinirPesoAreaAtuacao());
            decimal b = (salarioBruto * DefinirPesoFaixaSalarial());
            decimal c = (Math.Round(a, 2) / Math.Round(b, 2)) * 12;
            valorParticipacao = Math.Round(c, 2);
        }
    }

    enum Peso {
        Peso_1 = 1,
        Peso_2 = 2,
        Peso_3 = 3,
        Peso_5 = 5
    }
}
