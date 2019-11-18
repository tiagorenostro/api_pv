using System.Collections.Generic;
using api_teste_pagueveloz.Models;

namespace api_teste_pagueveloz.Services {
    public class FuncionarioServices {

        private readonly ConexaoDb conexao = new ConexaoDb();

        public IEnumerable<Funcionario> ObterFuncionario() {

            List<Funcionario> lista_funcionario = conexao.BuscaFuncionarioDb();

            for (int i = 0; i < lista_funcionario.Count; i++) {
                if (lista_funcionario[i] == null) {
                    lista_funcionario.Remove(lista_funcionario[i]);
                }
            }
            return lista_funcionario;
        }

        public void SalvaFuncionario(List<IDictionary<string, string>> dados_funcionario) {
            int idFuncionario = 1;
            string nome_chave = "Funcionario/";

            for (int i = 0; i < dados_funcionario.Count; i++) {
                string[] converte_string = dados_funcionario[i]["salario_bruto"].Split(' ');
                decimal salario_bruto = decimal.Parse(converte_string[1]);

                var salva_funcionario = new Funcionario {
                    IdFuncionario = idFuncionario,
                    Matricula = dados_funcionario[i]["matricula"],
                    Nome = dados_funcionario[i]["nome"],
                    Area = dados_funcionario[i]["area"],
                    Cargo = dados_funcionario[i]["cargo"],
                    SalarioBruto = salario_bruto,
                    DataAdmissao = dados_funcionario[i]["data_de_admissao"]
                };

                conexao.SalvaDados(0, idFuncionario, nome_chave, salva_funcionario);
                idFuncionario++;
            }
        }
    }
}