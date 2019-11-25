using System;
using System.Collections.Generic;
using Desafio.Models;
using Desafio.DataContext;

namespace api_teste_pagueveloz.Repositorio {
    public class Repositorio : IRepositorio, IDisposable {
        private ConexaoDb conexao = new ConexaoDb();

        public void Atualizar(int id, string nome_chave, object dados) {
            conexao.AtualizaDados(id, nome_chave, dados);
        }

        public void Inserir(int id, string nome_chave, object dados) {
            conexao.SalvaDados(id, nome_chave, dados);
        }

        public IEnumerable<Empresa> ObterEmpresa() {
            return conexao.ObterEmpresa();
        }

        public IEnumerable<Funcionario> ObterFuncionario() {
            return conexao.ObterFuncionario();
        }

        public void Dispose() {
            throw new NotImplementedException();
        }
    }
}
