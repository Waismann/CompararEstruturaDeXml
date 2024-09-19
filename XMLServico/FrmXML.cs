using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Data.SqlClient;
using System.Data;

namespace XMLServico
{
    public partial class frmXML : Form
    {
        private ConexaoBD conexaoBD;
        private AlteraXmlParaComparacao alteraXmlParaComparacao;
        private Dom_modeloserviconfse dom_Modeloserviconfse;
        string strCabecalhoXmlSelecionado;
        string strXmlSelecionadoAlterado;
        string strXmlBancoDominioAlterado;
        string strSeparadorNota;
        string IdMunicipioSelecionado;
        string NomeMunicipioSelecionado;
        string stridmodeloserviconfse;
        string stridmodelo;
        string strxml;
        string strnocodigoibge;
        string strnoufprestadorservico;
        string strnocodigoibgeorgaoprestadorservico;

        public frmXML()
        {
            InitializeComponent();
            DesabilitarControles();
            lblnfsemunicipio.Visible = false;
            tdbnfsemunicipio.Visible = false;
        }

        private void btnSelecionarXML_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirArquivo = new OpenFileDialog
            {
                Filter = "Arquivos XML (*.xml)|*.xml|Todos os arquivos (*.*)|*.*",
                Title = "Selecionar arquivo XML"
            };

            if (abrirArquivo.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivoSelecionado = abrirArquivo.FileName;
                lblcaminhoxml.Text = caminhoArquivoSelecionado;

                if (ValidarArquivoXML(caminhoArquivoSelecionado))
                {
                    string xmlSelecionado = File.ReadAllText(caminhoArquivoSelecionado);

                    strCabecalhoXmlSelecionado = AlteraXmlParaComparacao.LerArquivoTexto(caminhoArquivoSelecionado);


                    if (alteraXmlParaComparacao == null)
                    {
                        alteraXmlParaComparacao = new AlteraXmlParaComparacao();
                    }
                    ControlePrincipal.SelectedTab = ControlePrincipal.TabPages["Control2"];
                    EncontraNoCodigoIbge(xmlSelecionado);
                }
                else
                {
                    MessageBox.Show("Arquivo selecionado não é um XML válido.");
                }
            }
        }

        private bool ValidarArquivoXML(string caminhoArquivoSelecionado)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(caminhoArquivoSelecionado);
                return true;
            }
            catch (XmlException)
            {
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao validar o arquivo: {ex.Message}");
                return false;
            }
        }

        private void btnConexaoBd_Click(object sender, EventArgs e)
        {
            string instanciaSql = txtconexao.Text;
            string id = txtid.Text;
            string senha = txtsenha.Text;

            if (string.IsNullOrEmpty(instanciaSql))
            {
                MessageBox.Show("Por favor, digite uma instância do SQL Server.");
                return;
            }

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Por favor, digite o login do SQL Server.");
                return;
            }

            if (string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Por favor, digite a senha do SQL Server.");
                return;
            }

            try
            {
                conexaoBD = new ConexaoBD(instanciaSql, id, senha);
                using (SqlConnection conexao = conexaoBD.AbrirConexao())
                {
                    if (conexao != null)
                    {
                        MessageBox.Show("Conexão realizada. Selecione seu arquivo XML.");
                        HabilitarControles();
                    }
                    else
                    {
                        MessageBox.Show("Falha ao conectar ao banco de dados.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar ao banco de dados: {ex.Message}");
            }
        }

        private void DesabilitarControles()
        {
            btnSelecionarXML.Enabled = false;
            lblcaminhoxml.Text = string.Empty;
            ControlePrincipal.TabPages["Control2"].Enabled = false;
            ControlePrincipal.TabPages["Control3"].Enabled = false;
        }

        private void HabilitarControles()
        {
            btnSelecionarXML.Enabled = true;
            ControlePrincipal.TabPages["Control2"].Enabled = true;
            ControlePrincipal.TabPages["Control3"].Enabled = true;

        }

        private void EncontraNoCodigoIbge(string xmlSelecionado)
        {
            try
            {
                XmlDocument documentoXmlSelecionado = new XmlDocument();
                documentoXmlSelecionado.LoadXml(xmlSelecionado);

                List<string> nosXmlSelecionado = ObterTodosOsCaminhosDosNos(documentoXmlSelecionado.DocumentElement, "");

                if (nosXmlSelecionado.Count == 0)
                {
                    MessageBox.Show("Nenhum caminho encontrado no XML selecionado.");
                    return;
                }

                List<Dom_modeloserviconfse> dom_modeloserviconfse = new List<Dom_modeloserviconfse>();

                foreach (var caminho in nosXmlSelecionado)
                {
                    //Usa o real caminho (nó) do XML selecionado para o select do nocodigoibge
                    var resultados = CompararCaminhoComBancoDeDados(caminho);

                    //Caso não encontre irá remover o primeiro Nó do caminho e assim realizar uma nova busca (Paliativo enquanto não tratar o separador corretamente)
                    if (resultados.Count == 0)
                    {
                        string caminhoReduzido = RemoverPrimeiroNo(caminho);
                        if (!string.IsNullOrEmpty(caminhoReduzido))
                        {
                            resultados = CompararCaminhoComBancoDeDados(caminhoReduzido);
                        }
                    }
                    if (resultados.Count > 0)
                    {
                        dom_modeloserviconfse.AddRange(resultados);
                    }
                }

                if (dom_modeloserviconfse.Count > 0)//TRATAR AQUI A COMPARACAO
                {
                    CompararEstrutura(dom_modeloserviconfse, xmlSelecionado);
                    PreencherGrid(dom_modeloserviconfse);
                }
                else
                {
                    MessageBox.Show("Nenhum drive encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao comparar estrutura: {ex.Message}");
            }
        }

        private List<string> ObterTodosOsCaminhosDosNos(XmlNode no, string caminho)
        {
            List<string> caminhos = new List<string>();

            string caminhoAtual = string.IsNullOrEmpty(caminho) ? no.Name : $"{caminho}/{no.Name}";
            caminhos.Add(caminhoAtual);

            foreach (XmlNode noFilho in no.ChildNodes)
            {
                caminhos.AddRange(ObterTodosOsCaminhosDosNos(noFilho, caminhoAtual));
            }

            return caminhos;
        }

        //private string RemoverTagsEspecificas(string caminho)
        //{
        //    // Lista de tags específicas a serem removidas
        //    string[] tagsEspecificas = { "inicio", "SeparadorNotas", "SeparadorItens" };

        //    foreach (var tag in tagsEspecificas)
        //    {
        //        // Remover tags de abertura e fechamento
        //        caminho = caminho.Replace($"/{tag}", "").Replace($"{tag}/", "");
        //    }

        //    return caminho;
        //}

        private string RemoverPrimeiroNo(string caminho)
        {
            int index = caminho.IndexOf('/');
            if (index >= 0)
            {
                return caminho.Substring(index + 1);
            }
            return string.Empty;
        }

        private List<Dom_modeloserviconfse> CompararCaminhoComBancoDeDados(string caminho)
        {
            List<Dom_modeloserviconfse> resultados = new List<Dom_modeloserviconfse>();
            try
            {

                using (SqlConnection conexao = conexaoBD.AbrirConexao())
                {
                    if (conexao == null)
                    {
                        MessageBox.Show("Erro ao conectar ao banco de dados.");
                        return resultados;
                    }

                    string consulta = "SELECT idmodeloserviconfse,idmodelo, xml, nocodigoibge, noufprestadorservico,noCodigoIbgeOrgaoPrestadorServico FROM dom_modeloserviconfse WHERE nocodigoibge = @caminho ORDER BY idmodeloserviconfse DESC";
                    SqlCommand comando = new SqlCommand(consulta, conexao);
                    comando.Parameters.AddWithValue("@caminho", "//" + caminho);


                    using (SqlDataReader leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            resultados.Add(new Dom_modeloserviconfse
                            {
                                IdModeloServico = leitor["idmodeloserviconfse"].ToString(),
                                IdModelo = leitor["idModelo"].ToString(),
                                Xml = leitor["xml"].ToString(),
                                NoCodigoIbge = leitor["nocodigoibge"].ToString(),
                                NoCodigoIbgeOrgaoPrestadorServico = leitor["noCodigoIbgeOrgaoPrestadorServico"].ToString(),
                                NoUfPrestadorServico = leitor["noUfPrestadorServico"].ToString()
                            });
                        }
                    }

                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Erro SQL ao executar a consulta: {sqlEx.Message}");
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao executar a consulta: {ex.Message}");
            }

            return resultados;
        }

        private void CompararEstrutura(List<Dom_modeloserviconfse> resultados, string xmlSelecionado)
        {
            try
            {
                List<Dom_modeloserviconfse> resultadosComCompatibilidade = new List<Dom_modeloserviconfse>();

                foreach (var resultado in resultados)
                {

                    string xmlDriver = resultado.Xml;
                    string idModeloServico = resultado.IdModeloServico;

                    XmlDocument xmlDriverDoc = new XmlDocument();
                    xmlDriverDoc.LoadXml(xmlDriver);
                    string strSeparadorNota = RetornarSeparador(xmlDriverDoc, "SeparadorNotas");
                    string xmlSelecionadoCopia = xmlSelecionado;
                    string xmlDriverCopia = xmlDriver;

                    xmlDriverCopia = alteraXmlParaComparacao.RetornarXMLAlterado(xmlDriverCopia, strCabecalhoXmlSelecionado, strSeparadorNota, true, resultado.IdModeloServico);
                    xmlSelecionadoCopia = alteraXmlParaComparacao.RetornarXMLAlterado(xmlSelecionadoCopia, strCabecalhoXmlSelecionado, strSeparadorNota, false, resultado.IdModeloServico);

                    int compatibilidade = 0;
                    try
                    {

                        compatibilidade = CompararCaminhosXml(xmlSelecionadoCopia, xmlDriver);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao comparar caminhos com o XML do driver (ID: {idModeloServico}): {ex.Message}");
                        continue;
                    }

                    resultado.Compatibilidade = compatibilidade;
                    resultadosComCompatibilidade.Add(resultado);
                }

                resultadosComCompatibilidade = resultadosComCompatibilidade.OrderByDescending(r => r.Compatibilidade).ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao executar a comparação: {ex.Message}");
            }
        }


        private int CompararCaminhosXml(string xmlSelecionado, string xmlDriver)
        {
            XmlDocument documentoXmlSelecionado = new XmlDocument();
            XmlDocument documentoXmlDriver = new XmlDocument();
            int compatibilidade = 0;

            try
            {
                documentoXmlSelecionado.LoadXml(xmlSelecionado);
            }
            catch (XmlException ex)
            {
                MessageBox.Show($"Erro ao carregar o XML selecionado: {ex.Message}");
                return compatibilidade;
            }

            try
            {
                documentoXmlDriver.LoadXml(xmlDriver);
            }
            catch (XmlException ex)
            {
                MessageBox.Show($"Erro ao carregar o XML do driver: {ex.Message}");
                return compatibilidade;
            }

            // Obter todos os caminhos dos nós dos XMLs
            List<string> caminhosXmlSelecionados = ObterTodosOsCaminhosDosNos(documentoXmlSelecionado.DocumentElement, "");
            List<string> caminhosXmlDriver = ObterTodosOsCaminhosDosNos(documentoXmlDriver.DocumentElement, "");

            
            HashSet<string> caminhosSetDriver = new HashSet<string>(caminhosXmlDriver.Select(c => (c)));

            foreach (string caminhoSelecionado in caminhosXmlSelecionados)
            {
                if (caminhosSetDriver.Contains(caminhoSelecionado))
                {
                    compatibilidade++;
                }
            }

            return compatibilidade;
        }

        public string RetornarSeparador(XmlDocument objXMLDriverRPS, string strSeparador)
        {
            try
            {
                // Seleciona o nó baseado no caminho especificado
                XmlNode node = objXMLDriverRPS.SelectSingleNode("//inicio/" + strSeparador);

                // Retorna o texto do nó, se encontrado, caso contrário, retorna o separador original
                if (node != null && !string.IsNullOrEmpty(node.InnerText))
                {
                    return node.InnerText;
                }
                else
                {
                    return strSeparador;
                }
            }
            catch (Exception)
            {
                // Em caso de erro, retorna o separador original
                return strSeparador;
            }
        }

        private void PreencherGrid(List<Dom_modeloserviconfse> resultados)
        {
            tdbResultado.Rows.Clear();

            foreach (var resultado in resultados)
            {
                tdbResultado.Rows.Add(
                    false,
                    resultado.Compatibilidade,
                    resultado.IdModeloServico,
                    resultado.NoCodigoIbge,
                    resultado.NoCodigoIbgeOrgaoPrestadorServico,
                    resultado.Xml,
                    resultado.IdModelo,
                    resultado.NoUfPrestadorServico
                );
            }
            tdbResultado.Sort(tdbResultado.Columns["Compatibilidade"], System.ComponentModel.ListSortDirection.Descending);
        }

        private void tdbResultado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.RowIndex >= 0)
            {
                string conteudoXml = tdbResultado.Rows[e.RowIndex].Cells[5].Value.ToString();

                Clipboard.SetText(conteudoXml);

                MessageBox.Show("Xml Copiado.");
            }

            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                if ((bool)tdbResultado.Rows[e.RowIndex].Cells[0].Value == false)
                {
                    DialogResult confirmacao = MessageBox.Show("Deseja continuar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmacao == DialogResult.Yes)
                    {
                        DataGridViewRow row = tdbResultado.Rows[e.RowIndex];

                        stridmodeloserviconfse = row.Cells["idmodeloserviconfse"].Value.ToString();
                        stridmodelo = row.Cells["IdModelo"].Value != null ? row.Cells["IdModelo"].Value.ToString() : "NULL";
                        strxml = row.Cells["Xml"].Value.ToString();
                        strnocodigoibge = row.Cells["NoCodigoIbge"].Value.ToString();
                        strnoufprestadorservico = row.Cells["NoUfPrestadorServico"].Value != null ? row.Cells["NoUfPrestadorServico"].Value.ToString() : "NULL";
                        strnocodigoibgeorgaoprestadorservico = row.Cells["NoCodigoIbgeOrgaoPrestadorServico"].Value != null ? row.Cells["NoCodigoIbgeOrgaoPrestadorServico"].Value.ToString() : "NULL";

                        ControlePrincipal.SelectedTab = ControlePrincipal.TabPages["Control3"];
                    }
                }
            }
        }

        private void btnpesquisar_Click(object sender, EventArgs e)
        {
            string municipio = txtmunicipio.Text;

            if (string.IsNullOrEmpty(municipio))
            {
                MessageBox.Show("Por favor, digite um município ou código IBGE para pesquisar.");
                return;
            }

            try
            {
                using (SqlConnection conexao = conexaoBD.AbrirConexao())
                {
                    if (conexao == null)
                    {
                        MessageBox.Show("Erro ao conectar ao banco de dados.");
                        return;
                    }

                    string consulta = @"
                                SELECT dom_uf.abreviaturauf, dom_municipio.idmunicipio, dom_municipio.nomemunicipio, dom_municipio.codigoibge
                                FROM ng_dominio..dom_municipio dom_municipio
                                INNER JOIN ng_dominio..dom_uf dom_uf ON dom_municipio.iduf = dom_uf.iduf
                                WHERE dom_municipio.nomemunicipio LIKE @municipio OR dom_municipio.codigoibge LIKE @municipio";

                    SqlCommand comando = new SqlCommand(consulta, conexao);
                    comando.Parameters.AddWithValue("@municipio", "%" + municipio + "%");

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabelaResultados = new DataTable();
                    adaptador.Fill(tabelaResultados);

                    tdbMunicipio.Rows.Clear();
                    foreach (DataRow row in tabelaResultados.Rows)
                    {
                        tdbMunicipio.Rows.Add(
                            false,
                            row["idmunicipio"],
                            row["nomemunicipio"],
                            row["abreviaturauf"],
                            row["codigoibge"]

                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao executar a consulta: {ex.Message}");
            }
        }

        private void btnconfirmar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in tdbMunicipio.Rows)
            {
                if (Convert.ToBoolean(row.Cells["SelecionarMunicipio"].Value))
                {
                    IdMunicipioSelecionado = row.Cells["idmunicipio"].Value.ToString();
                    NomeMunicipioSelecionado = row.Cells["municipio"].Value.ToString();
                    break;
                }
            }

            if (string.IsNullOrEmpty(IdMunicipioSelecionado))
            {
                MessageBox.Show("Nenhum município selecionado.");
                lblnfsemunicipio.Visible = false;
                tdbnfsemunicipio.Visible = false;
            }
            else
            {
                lblmunicipio.Text = "Município: " + NomeMunicipioSelecionado + " / IDMunicipio: " + IdMunicipioSelecionado;
                Encontramodelovinculado(IdMunicipioSelecionado);
                lblnfsemunicipio.Visible = true;
                tdbnfsemunicipio.Visible = true;
                lblproximoid.Text = "Próximo ID a ser inserido: " + RetornaUltimoId(conexaoBD.AbrirConexao());
            }

        }

        private void Encontramodelovinculado (string idmunicipioSelecionado)
        {
            try
            {
                using (SqlConnection conexao = conexaoBD.AbrirConexao())
                {
                    if (conexao == null)
                    {
                        MessageBox.Show("Erro ao conectar ao banco de dados.");
                        return;
                    }

                    string consulta = @"
                                Select idmodeloserviconfsemunicipio, idmunicipio,idmodeloserviconfse from  ng_dominio..dom_modeloserviconfsemunicipio
                                where idmunicipio = @idmunicipioSelecionado";

                    SqlCommand comando = new SqlCommand(consulta, conexao);
                    comando.Parameters.AddWithValue("@idmunicipioSelecionado", idmunicipioSelecionado);

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabelaResultados = new DataTable();
                    adaptador.Fill(tabelaResultados);

                    tdbnfsemunicipio.Rows.Clear();
                    foreach (DataRow row in tabelaResultados.Rows)
                    {
                        tdbnfsemunicipio.Rows.Add(
                            row["idmodeloserviconfsemunicipio"],
                            row["idmunicipio"],
                            row["idmodeloserviconfse"]

                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao executar a consulta: {ex.Message}");
            }
        }

        private int RetornaUltimoId(SqlConnection conexao)
        {
            try
            {
                string consultaMaxId = "SELECT MAX(idmodeloserviconfsemunicipio) FROM ng_dominio..dom_modeloserviconfsemunicipio";
                SqlCommand comandoMaxId = new SqlCommand(consultaMaxId, conexao);
                object resultadoMaxId = comandoMaxId.ExecuteScalar();
                return (resultadoMaxId != DBNull.Value) ? Convert.ToInt32(resultadoMaxId) + 1 : 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter o último ID: {ex.Message}");
                return 1; 
            }
        }


        private void btnexportar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblmunicipio.Text))
            {
                MessageBox.Show("Favor selecionar um município");
                return;
            }

            string scriptSQL = GerarScriptSQL(stridmodeloserviconfse,stridmodelo,strxml,strnocodigoibge,strnocodigoibgeorgaoprestadorservico,strnoufprestadorservico);
            string dataHora = DateTime.Now.ToString("yyyyMMddHHmm");
            SaveFileDialog salvarArquivo = new SaveFileDialog
            {
                Filter = "Arquivos SQL (*.sql)|*.sql|Todos os arquivos (*.*)|*.*",
                Title = "Salvar script SQL",
                FileName = $"DDL_{dataHora}_DOM_MODELOSERVICONFSEMUNICIPIO_XXXXXX_R.sql"
            };

            if (salvarArquivo.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(salvarArquivo.FileName, scriptSQL);
                MessageBox.Show("Script SQL exportado com sucesso!");
            }
            return;

        }

        private string GerarScriptSQL(string idmodeloservico, string idmodelo, string xml, 
                                      string nocodigoibge, string noCodigoIbgeOrgaoPrestadorServico, string noufprestadorservico)
        { 
            int idmodeloserviconfsemunicipio = RetornaUltimoId(conexaoBD.AbrirConexao()); 
            if (string.IsNullOrEmpty(noCodigoIbgeOrgaoPrestadorServico))
              {
                  noCodigoIbgeOrgaoPrestadorServico = "NULL";
              }
            if (string.IsNullOrEmpty(noufprestadorservico))
              {
                  noufprestadorservico = "NULL";
              }
            if (string.IsNullOrEmpty(idmodelo))
            {
                idmodelo = "NULL";
            }


                return $@"
USE NG_Dominio
GO
IF NOT EXISTS(SELECT 1 FROM .dbo.dom_modeloserviconfse where idmodeloserviconfse = {idmodeloserviconfsemunicipio})		
BEGIN
    SET DATEFORMAT YMD
    INSERT INTO .dbo.dom_modeloserviconfse (
        idmodeloserviconfse,
        idmodelo,				
        XML,
        nocodigoibge,
        idusuariolog,
        datahoralog,
        nocodigoibgeorgaoprestadorservico,
        noufprestadorservico) 				
    VALUES (
        {idmodeloservico},
        {idmodelo},
        '{xml}', 
        '{nocodigoibge}',
        2,
        GETDATE(),
        {noCodigoIbgeOrgaoPrestadorServico},
        {noufprestadorservico})			
END
IF NOT EXISTS(SELECT 1 FROM dom_modeloserviconfsemunicipio WHERE idmodeloserviconfsemunicipio = {idmodeloserviconfsemunicipio})
BEGIN
    INSERT INTO dom_modeloserviconfsemunicipio (idmodeloserviconfsemunicipio, idmunicipio, idmodeloserviconfse) 
    VALUES ({idmodeloserviconfsemunicipio}, {IdMunicipioSelecionado}, {idmodeloservico})
END
GO
            ";
        }
    }
}
