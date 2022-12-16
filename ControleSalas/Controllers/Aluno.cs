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
    public class Aluno : ControllerBase
    {
        [HttpGet]
        public string Lista_Alunos(string p_nome_aluno)

        {
            string Chaveconexao = "Data Source=10.39.45.44;Initial Catalog=ControleSalas;User ID=Turma2022;Password=Turma2022@2022";
            DataSet resultadoCEP2 = new DataSet();


            SqlConnection Conexao = new SqlConnection(Chaveconexao);
            Conexao.Open();

            string wQuery = $"select * from Alunos where Nome like '%{p_nome_aluno}%' ";
            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(resultadoCEP2);

            string json = JsonConvert.SerializeObject(resultadoCEP2, Formatting.Indented);
            return json;
        }

        [HttpPost]
        public string Atualizar_Alunos(int Id, string Nome, string Turma, string Periodo, string Sala)
        {

            string ChaveConexao = "Data Source=10.39.45.44; Initial Catalog=ControleSalas; User ID=Turma2022;Password=Turma2022@2022";
            DataSet DataSetAgenda = new DataSet();
            try
            {
                SqlConnection Conexao = new SqlConnection(ChaveConexao); Conexao.Open();

                string oQueryUpdate = $" UPDATE  Alunos  " +
                                        $" SET  Nome =  '{Nome}'" +
                                        $",Turma =     '{Turma}'  " +
                                        $",Periodo =  '{Periodo}' " +
                                        $",Sala =   '{Sala}' " +
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
        public string Inserir_Alunos(string Nome, string Turma, string Periodo, string Sala)
        {
            string Chaveconexao = "Data Source=10.39.45.44;Initial Catalog=ControleSalas;User ID=Turma2022;Password=Turma2022@2022";
            DataSet resultadoPost = new DataSet();

            SqlConnection Conexao = new SqlConnection(Chaveconexao);
            Conexao.Open();

            string wQuery = ($"insert into Alunos (Status, Nome, Turma, Periodo, Sala)" +                            
                            $"'{Nome}'" +
                            $"'{Turma}'" +
                            $"'{Periodo}'" +
                            $"'{Sala}'");

            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(resultadoPost);

            string json = JsonConvert.SerializeObject(resultadoPost, Formatting.Indented);

            return json;
        }

        [HttpDelete]
        public string Deletar_Alunos(int Id)
        {
            string Chaveconexao = "Data Source=10.39.45.44;Initial Catalog=ControleSalas;User ID=Turma2022;Password=Turma2022@2022";
            DataSet resultadoPost = new DataSet();

            SqlConnection Conexao = new SqlConnection(Chaveconexao);
            Conexao.Open();

            string wQuery = ($"delete from Alunos where id = '{Id}'");

            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(resultadoPost);

            string json = JsonConvert.SerializeObject(resultadoPost, Formatting.Indented);

            return json;
        }
    }
}
