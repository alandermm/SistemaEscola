using System;
using System.IO;
namespace Atividade.Essencial
{
    public class Turma
    {
        public int Id { get; set; }
        public string TituloTurma { get; set; }
        public Aluno[] Alunos { get; set; }
        public Professor Prof {get; set;}
        public Materia[] Materias{get; set;}
        public Sala Sal{get; set;}

        public string Salvar(){
            string msg = "";
            StreamWriter arquivo = null;
            try {
                arquivo = new StreamWriter("Turma.csv", true);
                foreach(var m in Materias){
                    foreach(var aluno in Alunos){
                        arquivo.WriteLine(
                            Id+";"+
                            TituloTurma+";"+
                            "Id do Aluno: "+aluno.Id+";"+
                            "Nome do Aluno: "+aluno.Nome+";"+
                            "Id do Professor: "+Prof.Id+";"+
                            "Nome do Professor: "+Prof.Nome+";"+
                            "Materia: "+m.Titulo+";"+
                            "Sala: "+Sal
                        );
                    }
                }
                msg = "Dados salvos com sucesso!";
            } catch (Exception ex) {
                msg = "Erro ao tentar salvar o arquivo " + ex.Message;
            } finally {
                arquivo.Close();
            }
            return msg;
        }
    }
}