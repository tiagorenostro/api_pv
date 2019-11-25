using System;
using System.Collections.Generic;
using Desafio.Models;

namespace api_teste_pagueveloz.Repositorio {
    public interface IRepositorio : IDisposable {
        IEnumerable<Empresa> ObterEmpresa();
        IEnumerable<Funcionario> ObterFuncionario();
        void Inserir(int id, string nome_chave, object dados);
        void Atualizar(int id, string nome_chave, object dados);
    }
}
