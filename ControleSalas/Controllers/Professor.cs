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
    public class Professor : ControllerBase
    {
        [HttpGet]
        public string Lista_Professor(string p_nome_professor)

        {
            string Chaveconexao = "Data Source=10.39.45.44;Initial Catalog=ControleSalas;User ID=Turma2022;Password=Turma2022@2022";
            DataSet resultadoCEP2 = new DataSet();


            SqlConnection Conexao = new SqlConnection(Chaveconexao);
            Conexao.Open();

            string wQuery = $"select * from Professor where Nome like '%{p_nome_professor}%' ";
            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(resultadoCEP2);

            string json = JsonConvert.SerializeObject(resultadoCEP2, Formatting.Indented);

            return json;
        }

        [HttpPost]
        public string Atualizar_Professor(int Id, bool Status, string Nome, string Sala, string Agenda)
        {

            string ChaveConexao = "Data Source=10.39.45.44; Initial Catalog=ControleSalas; User ID=Turma2022;Password=Turma2022@2022";
            DataSet DataSetAgenda = new DataSet();
            try
            {
                SqlConnection Conexao = new SqlConnection(ChaveConexao); Conexao.Open();

                string oQueryUpdate = $" UPDATE  Professor  " +
                                        $" SET  Nome =  '{Nome}'" +
                                        $",Status =     '{Status}'  " +
                                        $",Sala =  '{Sala}' " +
                                        $",Agenda =   '{Agenda}' " +
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
        public string Inserir_Professor(bool status, string Nome, string Sala, string Agenda)
        {
            string Chaveconexao = "Data Source=10.39.45.44;Initial Catalog=ControleSalas;User ID=Turma2022;Password=Turma2022@2022";
            DataSet resultadoPost = new DataSet();

            SqlConnection Conexao = new SqlConnection(Chaveconexao);
            Conexao.Open();

            string wQuery = ($"insert into Salas (Status, Nome, Sala, Agenda)" +
                            $" Values('{status}'," +
                            $"'{Nome}'," +
                            $"'{Sala}'," +
                            $"'{Agenda}'");

            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(resultadoPost);

            string json = JsonConvert.SerializeObject(resultadoPost, Formatting.Indented);

            return json;
        }

        [HttpDelete]
        public string Deletar_Professor(int Id)
        {
            string Chaveconexao = "Data Source=10.39.45.44;Initial Catalog=ControleSalas;User ID=Turma2022;Password=Turma2022@2022";
            DataSet resultadoPost = new DataSet();

            SqlConnection Conexao = new SqlConnection(Chaveconexao);
            Conexao.Open();

            string wQuery = ($"delete from Professor where id = '{Id}'");

            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(resultadoPost);

            string json = JsonConvert.SerializeObject(resultadoPost, Formatting.Indented);

            return json;
        }
    }
}
