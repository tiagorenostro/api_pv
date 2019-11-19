using System.Collections.Generic;
using api_teste_pagueveloz.Models;
using api_teste_pagueveloz.DTO;

namespace api_teste_pagueveloz.Services {
    public class CalculaParticipacaoService {
        private readonly ConexaoDb conexao = new ConexaoDb();
        public Empresa empresa = new Empresa();
        public List<Funcionario> lista_funcionarios = new List<Funcionario>();
        public List<Empresa> lista_empresa = new List<Empresa>();
        public EmpresaDTO empDto = new EmpresaDTO();
        public List<EmpresaDTO> empDtoList = new List<EmpresaDTO>();
        public FuncionarioServices funcServ = new FuncionarioServices();

        public void CalculaParticipacao() {
            lista_funcionarios = conexao.BuscaFuncionarioDb();

            for (int i = 0; i < lista_funcionarios.Count; i++) {
                if (lista_funcionarios[i] == null) {
                    lista_funcionarios.Remove(lista_funcionarios[i]);
                }
                lista_funcionarios[i].CalculaParticipacao();
                empresa.participacoes.Add(lista_funcionarios[i]);

                var atualiza_valor_participacao = new Funcionario {
                    IdFuncionario = lista_funcionarios[i].IdFuncionario,
                    Matricula = lista_funcionarios[i].Matricula,
                    Nome = lista_funcionarios[i].Nome,
                    Area = lista_funcionarios[i].Area,
                    Cargo = lista_funcionarios[i].Cargo,
                    SalarioBruto = lista_funcionarios[i].SalarioBruto,
                    DataAdmissao = lista_funcionarios[i].DataAdmissao,
                    ValorParticipacao = lista_funcionarios[i].ValorParticipacao
                };
                conexao.SalvaDados(1, lista_funcionarios[i].IdFuncionario, "Funcionario/", atualiza_valor_participacao);
            }
        }

        public IEnumerable<EmpresaDTO> CalculaEmpresa() {
            CalculaParticipacao();
            empresa._TotalFuncionarios();
            empresa._TotalDistribuidos();

            lista_empresa = conexao.BuscaEmpresaDb();

            for (int i = 0; i < lista_empresa.Count; i++) {
                if (lista_empresa[i] == null) {
                    lista_empresa.Remove(lista_empresa[i]);
                }

                empresa.TotalDisponibilizado = lista_empresa[i].TotalDisponibilizado;
                empresa._SaldoTotalDisponibilizado();

                var atualiza_empresa = new Empresa {
                    TotalFuncionarios = empresa.TotalFuncionarios,
                    TotalDistribuidos = empresa.TotalDistribuidos,
                    TotalDisponibilizado = empresa.TotalDisponibilizado,
                    SaldoTotalDisponibilizado = empresa.SaldoTotalDisponibilizado,
                };
                conexao.SalvaDados(1, 1, "Empresa/", atualiza_empresa);

                lista_empresa[i].participacoes = empresa.participacoes;

                empDto.participacoes = funcServ.ObterFuncionario();
                empDto.TotalFuncionarios = empresa.TotalFuncionarios;
                empDto.TotalDisponibilizado = empresa.TotalDisponibilizado;
                empDto.TotalDistribuidos = empresa.TotalDistribuidos;
                empDto.SaldoTotalDisponibilizado = empresa.SaldoTotalDisponibilizado;
                empDtoList.Add(empDto);
            }
            return empDtoList;
        }
    }
}
