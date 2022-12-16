using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ControleSalas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Salas : ControllerBase
    {
        [HttpGet]
        public string Lista_Salas(string p_nome_sala)

        {
            string Chaveconexao = "Data Source=10.39.45.44;Initial Catalog=ControleSalas;User ID=Turma2022;Password=Turma2022@2022";
            DataSet resultadoCEP2 = new DataSet();


            SqlConnection Conexao = new SqlConnection(Chaveconexao);
            Conexao.Open();

            string wQuery = $"select * from Sala where Nome like '%{p_nome_sala}%' ";
            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(resultadoCEP2);

            string json = JsonConvert.SerializeObject(resultadoCEP2, Formatting.Indented);

            return json;
        }

        [HttpPost]
        public string Atualizar_Professo(int Id, bool Status, int NumeroSala, string NomeSala, string ProfessorResponsavel)
        {

            string ChaveConexao = "Data Source=10.39.45.44; Initial Catalog=ControleSalas; User ID=Turma2022;Password=Turma2022@2022";
            DataSet DataSetAgenda = new DataSet();
            try
            {
                SqlConnection Conexao = new SqlConnection(ChaveConexao); Conexao.Open();

                string oQueryUpdate = $" UPDATE  Sala  " +
                                        $" SET  Status =  '{Status}'" +
                                        $",NumeroSala =     '{NumeroSala}'  " +
                                        $",NomeSala =  '{NomeSala}' " +
                                        $",ProfessorResponsavel =   '{ProfessorResponsavel}' " +
                                        $"WHERE Id  = {Id}";

                SqlCommand Cmd = new SqlCommand(oQueryUpdate, Conexao); Cmd.ExecuteNonQuery(); Conexao.Close();
            }
            catch (Exception ex)
            {
                string vErro = ex.Message.ToString();
            }
            string json = JsonConvert.SerializeObject(DataSetAgenda, Formatting.Indented);
            return json;
        }

        [HttpPut]
        public string Inserir_Salas(bool status, int numero_sala, string nome_sala, string professor_responsavel)
        {
            string Chaveconexao = "Data Source=10.39.45.44;Initial Catalog=ControleSalas;User ID=Turma2022;Password=Turma2022@2022";
            DataSet resultadoPost = new DataSet();

            SqlConnection Conexao = new SqlConnection(Chaveconexao);
            Conexao.Open();

            string wQuery = ($"insert into Salas (Status, NumeroSala, NomeSala, ProfessorResponsavel)" +
                $" Values('{status}','{numero_sala}','{nome_sala}','{professor_responsavel}'");

            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(resultadoPost);

            string json = JsonConvert.SerializeObject(resultadoPost, Formatting.Indented);

            return json;
        }

        [HttpDelete]
        public string Deletar_Salas(int Id)
        {
            string Chaveconexao = "Data Source=10.39.45.44;Initial Catalog=ControleSalas;User ID=Turma2022;Password=Turma2022@2022";
            DataSet resultadoPost = new DataSet();

            SqlConnection Conexao = new SqlConnection(Chaveconexao);
            Conexao.Open();

            string wQuery = ($"delete from Salas where id = '{Id}'");

            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(resultadoPost);

            string json = JsonConvert.SerializeObject(resultadoPost, Formatting.Indented);

            return json;
        }
    }
}
