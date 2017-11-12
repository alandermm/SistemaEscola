using System;
using System.IO;
using System.Text;

namespace Atividade.Essencial
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Formacao { get; set; }
        public string Telefone { get; set; }
        public Endereco End { get; set; }

        public Professor(){

        }

        public Professor(int id, string nome, string formacao, string telefone, Endereco endereco){
            this.Id = id;
            this.Nome = nome;
            this.Formacao = formacao;
            this.Telefone = telefone;
            this.End = endereco;
        }

        public string Salvar(){
            string msg = "";
            StreamWriter arquivo = null;
            try {
                arquivo = new StreamWriter("Professor.csv", true);
                arquivo.WriteLine(
                    Id+";"+
                    Nome+";"+
                    Formacao+";"+
                    Telefone+";"+
                    End.Logradouro+";"+
                    End.Numero+";"+
                    End.Complemento+";"+
                    End.Bairro+";"+
                    End.Cidade
                );
                msg = "Dados salvos com sucesso!";
            } catch (Exception ex) {
                msg = "Erro ao tentar salvar o arquivo " + ex.Message;
            } finally {
                arquivo.Close();
            }
            return msg;
        }

        public Professor Pesquisar(int id){
            Professor professor = null;
            Endereco endereco = null;
            StreamReader arquivo = null;
            try {
                endereco = new Endereco();
                professor = new Professor();
                arquivo = new StreamReader("Professor.csv", Encoding.Default);
                string linha = "";
                while((linha = arquivo.ReadLine()) != null){
                    string[] dados = linha.Split(';');
                    if(dados[0] == id.ToString()){
                        professor.Id = int.Parse(dados[0]);
                        professor.Nome = dados[1];
                        professor.Formacao = dados[2];
                        professor.Telefone = dados[3];
                        endereco.Logradouro = dados[4];
                        endereco.Numero = dados[5];
                        endereco.Complemento = dados[6];
                        endereco.Bairro = dados[7];
                        endereco.Cidade = dados[8];
                        professor.End = endereco;
                        break;
                    }
                }
            } catch (Exception ex) {
                throw new Exception("Erro ao tentar ler o arquivo " + ex.Message);
            } finally {
                arquivo.Close();
            }
            return professor;
        }
    }
}