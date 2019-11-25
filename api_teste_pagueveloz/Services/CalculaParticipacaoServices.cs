using System.Collections.Generic;
using Desafio.Models;
using Desafio.DTO;
using api_teste_pagueveloz.Repositorio;

namespace Desafio.Services {
    public class CalculaParticipacaoService {
        private Repositorio Repositorio = new Repositorio();
        public Empresa empresa = new Empresa();
        public List<Funcionario> listaFuncionarios = new List<Funcionario>();
        public List<Empresa> listaEmpresa = new List<Empresa>();
        public FuncionarioServices funcServ = new FuncionarioServices();
        public EmpresaDTO empresaDTO = new EmpresaDTO();
        public List<EmpresaDTO> listaEmpresaDTO = new List<EmpresaDTO>();

        public void CalculaParticipacao() {
            List<Funcionario> listaFuncRepo = (List<Funcionario>)Repositorio.ObterFuncionario();

            for (int i = 0; i < listaFuncRepo.Count; i++) {
                listaFuncRepo[i].CalculaParticipacao();
                empresa.participacoes.Add(listaFuncRepo[i]);

                var atualizaValorParticipacao = new Funcionario {
                    idFuncionario = listaFuncRepo[i].idFuncionario,
                    matricula = listaFuncRepo[i].matricula,
                    nome = listaFuncRepo[i].nome,
                    area = listaFuncRepo[i].area,
                    cargo = listaFuncRepo[i].cargo,
                    salarioBruto = listaFuncRepo[i].salarioBruto,
                    dataAdmissao = listaFuncRepo[i].dataAdmissao,
                    valorParticipacao = listaFuncRepo[i].valorParticipacao
                };
                Repositorio.Inserir(listaFuncRepo[i].idFuncionario, "Funcionario/", atualizaValorParticipacao);
            }
        }

        public IEnumerable<EmpresaDTO> CalculaEmpresa() {
            CalculaParticipacao();
            empresa.SetTotalFuncionarios();
            empresa.SetTotalDistribuidos();

            List<Empresa> listaEmpRepo = (List<Empresa>)Repositorio.ObterEmpresa();

            for (int i = 0; i < listaEmpRepo.Count; i++) {
                empresa.totalDisponibilizado = listaEmpRepo[i].totalDisponibilizado;
                empresa.SetSaldoTotalDisponibilizado();

                var atualizaEmpresa = new Empresa {
                    totalFuncionarios = empresa.totalFuncionarios,
                    totalDistribuidos = empresa.totalDistribuidos,
                    totalDisponibilizado = empresa.totalDisponibilizado,
                    saldoTotalDisponibilizado = empresa.saldoTotalDisponibilizado,
                };
                Repositorio.Inserir(1, "Empresa/", atualizaEmpresa);

                listaEmpRepo[i].participacoes = empresa.participacoes;

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
