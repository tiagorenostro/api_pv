using System.Collections.Generic;
using api_teste_pagueveloz.Models;
using api_teste_pagueveloz.DTO;

namespace api_teste_pagueveloz.Services {
    public class CalculaParticipacaoService {
        private readonly ConexaoDb conexao = new ConexaoDb();
        public Empresa empresa = new Empresa();
        public List<Funcionario> listaFuncionarios = new List<Funcionario>();
        public List<Empresa> listaEmpresa = new List<Empresa>();
        public EmpresaDTO empresaDTO = new EmpresaDTO();
        public List<EmpresaDTO> listaEmpresaDTO = new List<EmpresaDTO>();
        public FuncionarioServices funcServ = new FuncionarioServices();

        public void CalculaParticipacao() {
            listaFuncionarios = conexao.BuscaFuncionarioDb();

            for (int i = 0; i < listaFuncionarios.Count; i++) {
                if (listaFuncionarios[i] == null) {
                    listaFuncionarios.Remove(listaFuncionarios[i]);
                }
                listaFuncionarios[i].CalculaParticipacao();
                empresa.participacoes.Add(listaFuncionarios[i]);

                var atualizaValorParticipacao = new Funcionario {
                    idFuncionario = listaFuncionarios[i].idFuncionario,
                    matricula = listaFuncionarios[i].matricula,
                    nome = listaFuncionarios[i].nome,
                    area = listaFuncionarios[i].area,
                    cargo = listaFuncionarios[i].cargo,
                    salarioBruto = listaFuncionarios[i].salarioBruto,
                    dataAdmissao = listaFuncionarios[i].dataAdmissao,
                    valorParticipacao = listaFuncionarios[i].valorParticipacao
                };
                conexao.SalvaDados(1, listaFuncionarios[i].idFuncionario, "Funcionario/", atualizaValorParticipacao);
            }
        }

        public IEnumerable<EmpresaDTO> CalculaEmpresa() {
            CalculaParticipacao();
            empresa.SetTotalFuncionarios();
            empresa.SetTotalDistribuidos();

            listaEmpresa = conexao.BuscaEmpresaDb();

            for (int i = 0; i < listaEmpresa.Count; i++) {
                if (listaEmpresa[i] == null) {
                    listaEmpresa.Remove(listaEmpresa[i]);
                }

                empresa.totalDisponibilizado = listaEmpresa[i].totalDisponibilizado;
                empresa.SetSaldoTotalDisponibilizado();

                var atualizaEmpresa = new Empresa {
                    totalFuncionarios = empresa.totalFuncionarios,
                    totalDistribuidos = empresa.totalDistribuidos,
                    totalDisponibilizado = empresa.totalDisponibilizado,
                    saldoTotalDisponibilizado = empresa.saldoTotalDisponibilizado,
                };
                conexao.SalvaDados(1, 1, "Empresa/", atualizaEmpresa);

                listaEmpresa[i].participacoes = empresa.participacoes;

                empresaDTO.participacoes = funcServ.ObterFuncionario();
                empresaDTO.totalFuncionarios = empresa.totalFuncionarios;
                empresaDTO.totalDisponibilizado = empresa.totalDisponibilizado;
                empresaDTO.totalDistribuidos = empresa.totalDistribuidos;
                empresaDTO.saldoTotalDisponibilizado = empresa.saldoTotalDisponibilizado;
                listaEmpresaDTO.Add(empresaDTO);
            }
            return listaEmpresaDTO;
        }
    }
}
