using System.Collections.Generic;
using FireSharp;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using Desafio.Models;

namespace Desafio.DataContext {
    public class ConexaoDb {
        public readonly IFirebaseConfig config = new FirebaseConfig {
            AuthSecret = "v2hoErEVZibNeVxUkiOLKj1dAupLk6vs0kDU74S0",
            BasePath = "https://api-pagueveloz.firebaseio.com/"
        };
        public IFirebaseClient cliente;
        public FirebaseResponse resposta;
        public List<Funcionario> listaFuncionario;
        public List<Empresa> listaEmpresa;

        public void SalvaDados(int id, string nome_chave, object dados) {
            cliente = new FirebaseClient(config);
            if (nome_chave == "Funcionario/") {
                resposta = cliente.Set(nome_chave + id, dados);
            } else if (nome_chave == "Empresa/") {
                resposta = cliente.Set(nome_chave + id, dados);
            }
         } 

        public void AtualizaDados(int id, string nome_chave, object dados) {
            cliente = new FirebaseClient(config);
            if (nome_chave == "Funcionario/") {
                resposta = cliente.Update(nome_chave + id, dados);
            } else if (nome_chave == "Empresa/") {
                resposta = cliente.Update(nome_chave + id, dados);
            }
         }

        public List<Funcionario> ObterFuncionario() {
            cliente = new FirebaseClient(config);
            listaFuncionario = new List<Funcionario>();
            
            resposta = cliente.Get("Funcionario/");
            listaFuncionario = resposta.ResultAs<List<Funcionario>>();

            for (int i = 0; i < listaFuncionario.Count; i++) {
                if (listaFuncionario[i] == null) {
                    listaFuncionario.Remove(listaFuncionario[i]);
                }
            }
            return listaFuncionario;
        }

        public List<Empresa> ObterEmpresa() {
            cliente = new FirebaseClient(config);
            listaEmpresa = new List<Empresa>();
            
            resposta = cliente.Get("Empresa/");
            listaEmpresa = resposta.ResultAs<List<Empresa>>();

            for (int i = 0; i < listaEmpresa.Count; i++) {
                if (listaEmpresa[i] == null) {
                    listaEmpresa.Remove(listaEmpresa[i]);
                }
            }
            return listaEmpresa;
        }
    }
}
