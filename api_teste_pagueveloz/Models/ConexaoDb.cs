using System.Collections.Generic;
using FireSharp;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace api_teste_pagueveloz.Models {
    public class ConexaoDb {
        public readonly IFirebaseConfig config = new FirebaseConfig {
            AuthSecret = "v2hoErEVZibNeVxUkiOLKj1dAupLk6vs0kDU74S0",
            BasePath = "https://api-pagueveloz.firebaseio.com/"
        };
        public IFirebaseClient cliente;
        public FirebaseResponse resposta;
        public List<Funcionario> lista_funcionario;
        public List<Empresa> lista_empresa;

        public void SalvaDados(int acao, int id, string nome_chave, object dados) {
            cliente = new FirebaseClient(config);
            // 0 salva
            if (acao == 0) {
                if (nome_chave == "Funcionario/") {
                    resposta = cliente.Set(nome_chave + id, dados);
                } else if (nome_chave == "Empresa/") {
                    resposta = cliente.Set(nome_chave + id, dados);
                }
                //1 atualiza
            } else if (acao == 1) {
                if (nome_chave == "Funcionario/") {
                    resposta = cliente.Update(nome_chave + id, dados);
                } else if (nome_chave == "Empresa/") {
                    resposta = cliente.Update(nome_chave + id, dados);
                }
            } 
        }

        public List<Funcionario> BuscaFuncionarioDb() {
            cliente = new FirebaseClient(config);
            lista_funcionario = new List<Funcionario>();
            
            resposta = cliente.Get("Funcionario/");
            lista_funcionario = resposta.ResultAs<List<Funcionario>>();
            return lista_funcionario;
        }

        public List<Empresa> BuscaEmpresaDb() {
            cliente = new FirebaseClient(config);
            lista_empresa = new List<Empresa>();
            
            resposta = cliente.Get("Empresa/");
            lista_empresa = resposta.ResultAs<List<Empresa>>();
            return lista_empresa;
        }
    }
}
