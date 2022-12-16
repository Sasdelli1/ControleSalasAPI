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
    public class Turma : ControllerBase
    {
        [HttpGet]
        public string Lista_Turmas(string p_nome_turma)

        {
            string Chaveconexao = "Data Source=10.39.45.44;Initial Catalog=ControleSalas;User ID=Turma2022;Password=Turma2022@2022";
            DataSet resultadoCEP2 = new DataSet();


            SqlConnection Conexao = new SqlConnection(Chaveconexao);
            Conexao.Open();

            string wQuery = $"select * from Turma where Nome like '%{p_nome_turma}%' ";
            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(resultadoCEP2);

            string json = JsonConvert.SerializeObject(resultadoCEP2, Formatting.Indented);

            return json;
        }
        [HttpPost]
        public string Atualizar_Turmas (int Id, string Curso, int QuantidadeAluno, string Professor, string Sala)
        {

            string ChaveConexao = "Data Source=10.39.45.44; Initial Catalog=ControleSalas; User ID=Turma2022;Password=Turma2022@2022";
            DataSet DataSetAgenda = new DataSet();
            try
            {
                SqlConnection Conexao = new SqlConnection(ChaveConexao); Conexao.Open();

                string oQueryUpdate = $" UPDATE  Turma  " +
                                        $" SET  Curso =  '{Curso}'" +
                                        $",QuantidadeAluno =     '{QuantidadeAluno}'  " +
                                        $",Professor =  '{Professor}' " +
                                        $",Agenda =   '{Sala}' " +
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
        public string Inserir_Turmas(string Curso, int QuantidadeAluno, string Professor, string Sala)
        {
            string Chaveconexao = "Data Source=10.39.45.44;Initial Catalog=ControleSalas;User ID=Turma2022;Password=Turma2022@2022";
            DataSet resultadoPost = new DataSet();

            SqlConnection Conexao = new SqlConnection(Chaveconexao);
            Conexao.Open();

            string wQuery = ($"insert into Turmas (Curso, QuantidadeAluno, Professor, ProfessorResponsavel)" +
                            $" Values('{Curso}'," +
                            $"'{QuantidadeAluno}'," +
                            $"'{Professor}'," +
                            $"'{Sala}'");

            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(resultadoPost);

            string json = JsonConvert.SerializeObject(resultadoPost, Formatting.Indented);

            return json;
        }

        [HttpDelete]
        public string Deletar_Turmas(int Id)
        {
            string Chaveconexao = "Data Source=10.39.45.44;Initial Catalog=ControleSalas;User ID=Turma2022;Password=Turma2022@2022";
            DataSet resultadoPost = new DataSet();

            SqlConnection Conexao = new SqlConnection(Chaveconexao);
            Conexao.Open();

            string wQuery = ($"delete from Turmas where id = '{Id}'");

            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(resultadoPost);

            string json = JsonConvert.SerializeObject(resultadoPost, Formatting.Indented);

            return json;
        }
    }
}
