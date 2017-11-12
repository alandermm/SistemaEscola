using System;
using System.IO;
using System.Text;

namespace Atividade.Essencial
{
    public class Materia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string CargaHoraria { get; set; }

        public string Salvar(){
            string msg = "";
            StreamWriter arquivo = null;
            try {
                arquivo = new StreamWriter("Materias.csv", true);
                arquivo.WriteLine(
                    Id+";"+
                    Titulo+";"+
                    CargaHoraria
                );
                msg = "Dados salvos com sucesso!";
            } catch (Exception ex) {
                msg = "Erro ao tentar salvar o arquivo " + ex.Message;
            } finally {
                arquivo.Close();
            }
            return msg;
        }

        public Materia Pesquisar(int id){
            Materia materia = null;
            StreamReader arquivo = null;
            try {
                materia = new Materia();
                arquivo = new StreamReader("Materias.csv", Encoding.Default);
                string linha = "";
                while((linha = arquivo.ReadLine()) != null){
                    string[] dados = linha.Split(';');
                    if(dados[0] == id.ToString()){
                        materia.Id = int.Parse(dados[0]);
                        materia.Titulo = dados[1];
                        materia.CargaHoraria = dados[2];
                        break;
                    }
                }
            } catch (Exception ex) {
                throw new Exception ("Erro ao tentar ler o arquivo " + ex.Message);
            } finally {
                arquivo.Close();
            }
            return materia;
        }
    }
}