using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLServico
{
    public class AlteraXmlParaComparacao
    {
        public static string LerArquivoTexto(string caminhoArquivo)
        {
            if (!File.Exists(caminhoArquivo))
            {
                throw new FileNotFoundException("Arquivo não encontrado.", caminhoArquivo);
            }

            byte[] buffer = new byte[3];
            using (FileStream fs = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read))
            {
                fs.Read(buffer, 0, buffer.Length); // Lê os primeiros 3 bytes para detectar o BOM
            }

            // Detectar a assinatura do arquivo (BOM)
            Encoding encoding;
            if (buffer[0] == 0xEF && buffer[1] == 0xBB && buffer[2] == 0xBF) // UTF-8 BOM
            {
                encoding = Encoding.UTF8;
            }
            else if (buffer[0] == 0xFF && buffer[1] == 0xFE) // UTF-16 Little Endian
            {
                encoding = Encoding.Unicode;
            }
            else if (buffer[0] == 0xFE && buffer[1] == 0xFF) // UTF-16 Big Endian
            {
                encoding = Encoding.BigEndianUnicode;
            }
            else
            {
                // Sem BOM ou UTF-8 sem BOM por padrão
                encoding = Encoding.Default;
            }

            // Agora, lê todo o arquivo com a codificação detectada
            using (StreamReader reader = new StreamReader(caminhoArquivo, encoding))
            {
                return reader.ReadToEnd();
            }
        }

        public string RetornarXMLAlterado(string xml, string cabecalho, string separadorNota, bool leituraDriver,
                                   string idModeloServicoConfse)
        {
            string strCabecalho = string.Empty;
            string strAtributo = string.Empty;
            string strXMLAux = string.Empty;
            int posicaoInicial = 0;
            int posicaoFinal = 0;

            try
            {
                if (separadorNota.Contains("SeparadorNotas"))
                {
                    return xml;
                }

                if (cabecalho.StartsWith("<?xml"))
                {
                    strCabecalho = cabecalho.Substring(cabecalho.IndexOf("<"));
                    strCabecalho = strCabecalho.Substring(0, strCabecalho.IndexOf(">") + 1);
                }

                if (idModeloServicoConfse == "310")
                {
                    strCabecalho = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
                }

                if (xml.Contains("xmlns:") && idModeloServicoConfse != "7")
                {
                    strAtributo = xml.Substring(xml.IndexOf("xmlns:"));
                    strAtributo = strAtributo.Substring(0, strAtributo.IndexOf(">"));
                    strAtributo = " " + strAtributo;
                }

                if (idModeloServicoConfse == "7" || idModeloServicoConfse == "325")
                {
                    xml = xml.Replace("<CompNfse xmlns=\"ISSResponsivo\">", "<CompNfse>");
                    xml = xml.Replace("<ns2:Signature/>", "");
                }


                if (idModeloServicoConfse == "74" && !leituraDriver)
                {
                    posicaoInicial = xml.IndexOf("<IdentificacaoTomador>");
                    if (posicaoInicial > 0 && !xml.Contains("<CpfCnpj>"))
                    {
                        posicaoInicial = xml.IndexOf("<Cnpj>", posicaoInicial);
                        posicaoFinal = xml.IndexOf("</Cnpj>", posicaoInicial);

                        if (string.IsNullOrWhiteSpace(xml.Substring(posicaoInicial + 6, posicaoFinal - posicaoInicial - 6).Replace("\r\n", "").Replace("\t", "")))
                        {
                            xml = xml.Substring(0, posicaoInicial) + xml.Substring(posicaoFinal + 7);
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(separadorNota))
                {

                    if (xml.Contains($"<{separadorNota}>"))
                    {
                        strXMLAux = xml.Substring(xml.IndexOf($"<{separadorNota}>"));
                    }
                    else if (xml.Contains($"<{separadorNota}"))
                    {
                        strXMLAux = xml.Substring(xml.IndexOf($"<{separadorNota}"));
                    }

                    if (!leituraDriver && idModeloServicoConfse == "347" && separadorNota == "NfseSubstituidora")
                    {
                        if (strXMLAux.IndexOf($"<{separadorNota}>", 1) > 0)
                        {
                            strXMLAux = strXMLAux.Substring(strXMLAux.IndexOf($"<{separadorNota}>", 1));
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(strXMLAux))
                    {
                        if (!leituraDriver && idModeloServicoConfse == "347" && separadorNota == "NfseSubstituida")
                        {
                            if (strXMLAux.IndexOf($"</{separadorNota}>", 300) + $"</{separadorNota}>".Length > 0)
                            {
                                strXMLAux = strXMLAux.Substring(0, strXMLAux.IndexOf($"</{separadorNota}>", 300) + $"</{separadorNota}>".Length);
                            }
                        }
                        else
                        {
                            strXMLAux = strXMLAux.Substring(0, strXMLAux.LastIndexOf($"</{separadorNota}>") + $"</{separadorNota}>".Length);
                        }

                        xml = (strCabecalho.ToLower() != "<inicio>" ? strCabecalho : "") + "<inicio" + strAtributo + ">\n";

                        xml += strXMLAux + "\n</inicio>";

                        return xml;
                    }
                }
            }
            catch (Exception ex)
            {                
                MessageBox.Show($"Erro: {ex.Message}, Fonte: {ex.Source}, StackTrace: {ex.StackTrace}");                
            }

            return string.Empty;
        }
    }
}
