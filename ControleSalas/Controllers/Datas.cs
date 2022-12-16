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
    public class Datas : ControllerBase
    {
        [HttpGet]
        public string Lista_Dias(string p_dia)

        {
            string Chaveconexao = "Data Source=10.39.45.44;Initial Catalog=ControleSalas;User ID=Turma2022;Password=Turma2022@2022";
            DataSet resultadoCEP2 = new DataSet();


            SqlConnection Conexao = new SqlConnection(Chaveconexao);
            Conexao.Open();

            string wQuery = $"select * from Datas where dia like '%{p_dia}%' ";
            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(resultadoCEP2);

            string json = JsonConvert.SerializeObject(resultadoCEP2, Formatting.Indented);
            return json;
        }

        [HttpPost]
        public string Atualizar_Datas(int Id, int Dia, int QuantidadeSalaOcupado, int QuantidadeSalaLivre)
        {

            string ChaveConexao = "Data Source=10.39.45.44; Initial Catalog=ControleSalas; User ID=Turma2022;Password=Turma2022@2022";
            DataSet DataSetAgenda = new DataSet();
            try
            {
                SqlConnection Conexao = new SqlConnection(ChaveConexao); Conexao.Open();

                string oQueryUpdate = $" UPDATE  Datas  " +
                                        $" SET  Dia =  '{Dia}'" +
                                        $",QuantidadeSalaOcupado =     '{QuantidadeSalaOcupado}'  " +
                                        $",QuantidadeSalaLivre =  '{QuantidadeSalaLivre}' " +                                       
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
        public string Inserir_Datas(int Dia, int QuantidadeSalaOcupado, int QuantidadeSalaLivre)
        {
            string Chaveconexao = "Data Source=10.39.45.44;Initial Catalog=ControleSalas;User ID=Turma2022;Password=Turma2022@2022";
            DataSet resultadoPost = new DataSet();

            SqlConnection Conexao = new SqlConnection(Chaveconexao);
            Conexao.Open();

            string wQuery = ($"insert into Datas (Dia, QuantidadeSalaOcupado, Turma, Periodo, Sala)" +
                            $" Values('{Dia}'" +
                            $"'{QuantidadeSalaOcupado}'" +
                            $"'{QuantidadeSalaLivre}'");

            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(resultadoPost);

            string json = JsonConvert.SerializeObject(resultadoPost, Formatting.Indented);

            return json;
        }

        [HttpDelete]
        public string Deletar_Datas(int Id)
        {
            string Chaveconexao = "Data Source=10.39.45.44;Initial Catalog=ControleSalas;User ID=Turma2022;Password=Turma2022@2022";
            DataSet resultadoPost = new DataSet();

            SqlConnection Conexao = new SqlConnection(Chaveconexao);
            Conexao.Open();

            string wQuery = ($"delete from Datas where id = '{Id}'");

            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(resultadoPost);

            string json = JsonConvert.SerializeObject(resultadoPost, Formatting.Indented);

            return json;
        }
    }
}
