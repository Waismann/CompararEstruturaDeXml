using System.Data.SqlClient;


namespace XMLServico
{
    public class ConexaoBD
    {
        public string connectionString;

        public ConexaoBD(string instanciaSql,string id, string senha)
        {
            connectionString = $@"Server={instanciaSql};Database=ng_dominio;User Id={id};Password={senha};MultipleActiveResultSets=true;";
        }

        public SqlConnection AbrirConexao()
        {
            try
            {
                SqlConnection conexao = new SqlConnection(connectionString);
                conexao.Open();
                return conexao;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir a conexão: {ex.Message}");
                return null;
            }
        }

        public void FecharConexao(SqlConnection conexao)
        {
            if (conexao != null && conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }

}
