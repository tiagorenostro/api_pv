using System.Collections.Generic;
using api_teste_pagueveloz.Models;
using api_teste_pagueveloz.DTO;

namespace api_teste_pagueveloz.Services {
    public class FuncionarioServices {

        private readonly ConexaoDb conexao = new ConexaoDb();
        private List<FuncionarioDTO> listaFuncDTO = new List<FuncionarioDTO>();
        public FuncionarioDTO funcDTO;

        public List<FuncionarioDTO> ObterFuncionario() {
            List<Funcionario> listaFuncionario = conexao.BuscaFuncionarioDb();

            for (int i = 0; i < listaFuncionario.Count; i++) {
                funcDTO = new FuncionarioDTO();
                if (listaFuncionario[i] == null) {
                    listaFuncionario.Remove(listaFuncionario[i]);
                } else {
                    funcDTO.matricula = listaFuncionario[i].matricula;
                    funcDTO.nome = listaFuncionario[i].nome;
                    funcDTO.valorParticipacao = listaFuncionario[i].valorParticipacao;
                    listaFuncDTO.Add(funcDTO);
                }
            }
            return listaFuncDTO;
        }

        public void SalvaFuncionario(List<IDictionary<string, string>> dadosFuncionario) {
            int idFuncionario = 1;
            string nomeChave = "Funcionario/";

            for (int i = 0; i < dadosFuncionario.Count; i++) {
                string[] converteString = dadosFuncionario[i]["salario_bruto"].Split(' ');
                decimal salarioBruto = decimal.Parse(converteString[1]);

                var salvaFuncionario = new Funcionario {
                    idFuncionario = idFuncionario,
                    matricula = dadosFuncionario[i]["matricula"],
                    nome = dadosFuncionario[i]["nome"],
                    area = dadosFuncionario[i]["area"],
                    cargo = dadosFuncionario[i]["cargo"],
                    salarioBruto = salarioBruto,
                    dataAdmissao = dadosFuncionario[i]["data_de_admissao"]
                };

                conexao.SalvaDados(0, idFuncionario, nomeChave, salvaFuncionario);
                idFuncionario++;
            }
        }
    }
}