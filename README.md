# XMLServico

Descrição
O projeto XMLServico é uma aplicação desenvolvida em C# e direcionada para a plataforma .NET 8.0. A aplicação tem como objetivo principal a manipulação e comparação de arquivos XML, além de interagir com um banco de dados para obter e exibir informações relevantes.
Estrutura do Projeto
Arquivo: FrmXML.cs
Este arquivo contém a lógica principal da aplicação, incluindo métodos para:
•	Selecionar e validar arquivos XML.
•	Conectar-se ao banco de dados.
•	Manipular e comparar estruturas XML.
•	Preencher e manipular grids de dados (DataGridView).
Principais métodos:
•	btnSelecionarXML_Click: Seleciona um arquivo XML.
•	ValidarArquivoXML: Valida o arquivo XML selecionado.
•	btnConexaoBd_Click: Conecta-se ao banco de dados.
•	tdbResultado_CellClick: Manipula cliques em células do DataGridView.
Arquivo: FrmXML.Designer.cs
Este arquivo define a interface gráfica do usuário (GUI) da aplicação. Inclui a declaração de componentes como:
•	TabControl e TabPage para navegação entre diferentes seções.
•	DataGridView para exibição de dados.
•	Button, Label e TextBox para interação do usuário.
Arquivo: AlteraXmlParaComparacao.cs
Este arquivo contém a classe AlteraXmlParaComparacao, responsável por manipular e alterar o conteúdo dos arquivos XML para fins de comparação.
Principais métodos:
•	LerArquivoTexto: Lê o conteúdo de um arquivo de texto.
•	RetornarXMLAlterado: Retorna o XML alterado com base em parâmetros específicos.
Arquivo: Dom_modeloserviconfse.cs
Este arquivo define a classe Dom_modeloserviconfse, que representa o modelo de serviço de configuração. Inclui propriedades como:
•	Compatibilidade
•	IdModeloServico
•	IdModelo
•	Xml
•	NoCodigoIbge
•	NoCodigoIbgeOrgaoPrestadorServico
•	NoUfPrestadorServico
Requisitos
•	.NET 8.0
•	Visual Studio
Como Executar
1.	Clone o repositório.
2.	Abra o projeto no Visual Studio.
3.	Compile e execute a aplicação.
Contribuição
Sinta-se à vontade para contribuir com melhorias e correções. Para isso, faça um fork do repositório, crie uma branch para suas alterações e envie um pull request.
