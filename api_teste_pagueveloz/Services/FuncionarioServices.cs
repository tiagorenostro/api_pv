using System.Collections.Generic;
using Desafio.Models;
using Desafio.DTO;
using api_teste_pagueveloz.Repositorio;

namespace Desafio.Services {
    public class FuncionarioServices {
        private List<FuncionarioDTO> listaFuncDTO = new List<FuncionarioDTO>();
        private Repositorio Repositorio = new Repositorio();
        public FuncionarioDTO funcDTO;

        public List<FuncionarioDTO> ObterFuncionario() {
            List<Funcionario> listaFuncRepo = (List<Funcionario>)Repositorio.ObterFuncionario();

            for (int i = 0; i < listaFuncRepo.Count; i++) {
                funcDTO = new FuncionarioDTO();
                funcDTO.matricula = listaFuncRepo[i].matricula;
                funcDTO.nome = listaFuncRepo[i].nome;
                funcDTO.valorParticipacao = listaFuncRepo[i].valorParticipacao;
                listaFuncDTO.Add(funcDTO);
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

                Repositorio.Inserir(idFuncionario, nomeChave, salvaFuncionario);
                idFuncionario++;
            }
        }
    }
}