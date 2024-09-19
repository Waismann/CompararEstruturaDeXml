using System.Collections.Generic;
using System.Data.SqlClient;

namespace XMLServico
{
    public class Dom_modeloserviconfse
    {
        public int Compatibilidade { get; set; }
        public string IdModeloServico { get; set; }
        public string IdModelo { get; set; }
        public string Xml { get; set; }
        public string NoCodigoIbge { get; set; }
        public string NoCodigoIbgeOrgaoPrestadorServico { get; set; }
        public string NoUfPrestadorServico { get; set; }
    }

    //public class Dom_modeloserviconfseDAO //DAO = Data Access Object
    //{
    //    private SqlConnection _conexao;

    //    public Dom_modeloserviconfseDAO(SqlConnection conexao)
    //    {
    //        _conexao = conexao;
    //    }

    //    public List<Dom_modeloserviconfse> ObterModelosServico(string noCodigoIbge)
    //    {
    //        List<Dom_modeloserviconfse> modelosServico = new List<Dom_modeloserviconfse>();
    //        try
    //        {
    //            string query = "SELECT idmodeloserviconfse, xml, nocodigoibge, noufprestadorservico FROM dom_modeloserviconfse WHERE nocodigoibge = @noCodigoIbge ORDER BY idmodeloserviconfse DESC";
    //            SqlCommand cmd = new SqlCommand(query, _conexao);
    //            cmd.Parameters.AddWithValue("@noCodigoIbge", "//" + noCodigoIbge);
    //            SqlDataReader reader = cmd.ExecuteReader();
    //            while (reader.Read())
    //            {
    //                Dom_modeloserviconfse modeloServico = new Dom_modeloserviconfse
    //                {
    //                    IdModeloServico = reader["idModeloServico"].ToString(),
    //                    IdModelo = reader["idModelo"].ToString(),
    //                    Xml = reader["xml"].ToString(),
    //                    NoCodigoIbge = reader["noCodigoIbge"].ToString(),
    //                    NoCodigoIbgeOrgaoPrestadorServico = reader["noCodigoIbgeOrgaoPrestadorServico"].ToString(),
    //                    NoUfPrestadorServico = reader["noUfPrestadorServico"].ToString()
    //                };
    //                modelosServico.Add(modeloServico);
    //            }
    //            reader.Close();
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show($"Erro ao obter os modelos de serviço: {ex.Message}");
    //        }
    //        return modelosServico;
    //    }
    //}
}
