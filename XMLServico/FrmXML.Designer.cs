namespace XMLServico
{
    partial class frmXML
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ControlePrincipal = new TabControl();
            Control1 = new TabPage();
            txtsenha = new TextBox();
            label3 = new Label();
            txtid = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtconexao = new TextBox();
            btnConexaoBd = new Button();
            lblcaminhoxml = new Label();
            btnSelecionarXML = new Button();
            Control2 = new TabPage();
            tdbResultado = new DataGridView();
            Selecionar = new DataGridViewCheckBoxColumn();
            Compatibilidade = new DataGridViewTextBoxColumn();
            idmodeloserviconfse = new DataGridViewTextBoxColumn();
            nocodigoibge = new DataGridViewTextBoxColumn();
            nocodigoibgeorgaoprestadorservico = new DataGridViewTextBoxColumn();
            Xml = new DataGridViewTextBoxColumn();
            CopiarXml = new DataGridViewButtonColumn();
            idmodelo = new DataGridViewTextBoxColumn();
            noufprestadorservico = new DataGridViewTextBoxColumn();
            Control3 = new TabPage();
            btnExportar = new Button();
            lblproximoid = new Label();
            lblnfsemunicipio = new Label();
            tdbnfsemunicipio = new DataGridView();
            idmodeloserviconfsemunicipio = new DataGridViewTextBoxColumn();
            idmunicipiovinculado = new DataGridViewTextBoxColumn();
            idmodeloserviconfsevinculado = new DataGridViewTextBoxColumn();
            lblmunicipio = new Label();
            btnconfirmar = new Button();
            btnpesquisar = new Button();
            txtmunicipio = new TextBox();
            label4 = new Label();
            tdbMunicipio = new DataGridView();
            SelecionarMunicipio = new DataGridViewCheckBoxColumn();
            idmunicipio = new DataGridViewTextBoxColumn();
            municipio = new DataGridViewTextBoxColumn();
            uf = new DataGridViewTextBoxColumn();
            ibge = new DataGridViewTextBoxColumn();
            ControlePrincipal.SuspendLayout();
            Control1.SuspendLayout();
            Control2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tdbResultado).BeginInit();
            Control3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tdbnfsemunicipio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tdbMunicipio).BeginInit();
            SuspendLayout();
            // 
            // ControlePrincipal
            // 
            ControlePrincipal.Controls.Add(Control1);
            ControlePrincipal.Controls.Add(Control2);
            ControlePrincipal.Controls.Add(Control3);
            ControlePrincipal.Location = new Point(12, 12);
            ControlePrincipal.Name = "ControlePrincipal";
            ControlePrincipal.SelectedIndex = 0;
            ControlePrincipal.Size = new Size(1262, 776);
            ControlePrincipal.TabIndex = 0;
            // 
            // Control1
            // 
            Control1.Controls.Add(txtsenha);
            Control1.Controls.Add(label3);
            Control1.Controls.Add(txtid);
            Control1.Controls.Add(label2);
            Control1.Controls.Add(label1);
            Control1.Controls.Add(txtconexao);
            Control1.Controls.Add(btnConexaoBd);
            Control1.Controls.Add(lblcaminhoxml);
            Control1.Controls.Add(btnSelecionarXML);
            Control1.Location = new Point(4, 34);
            Control1.Name = "Control1";
            Control1.Padding = new Padding(3);
            Control1.Size = new Size(1254, 738);
            Control1.TabIndex = 0;
            Control1.Text = "Selecionar XML";
            Control1.UseVisualStyleBackColor = true;
            // 
            // txtsenha
            // 
            txtsenha.Location = new Point(696, 22);
            txtsenha.Name = "txtsenha";
            txtsenha.PasswordChar = '*';
            txtsenha.Size = new Size(242, 31);
            txtsenha.TabIndex = 8;
            txtsenha.Text = "ng@mastermaq2010";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(626, 25);
            label3.Name = "label3";
            label3.Size = new Size(64, 25);
            label3.TabIndex = 7;
            label3.Text = "Senha:";
            // 
            // txtid
            // 
            txtid.Location = new Point(547, 22);
            txtid.Name = "txtid";
            txtid.Size = new Size(57, 31);
            txtid.TabIndex = 6;
            txtid.Text = "sa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(481, 25);
            label2.Name = "label2";
            label2.Size = new Size(60, 25);
            label2.TabIndex = 5;
            label2.Text = "Login:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 25);
            label1.Name = "label1";
            label1.Size = new Size(163, 25);
            label1.TabIndex = 4;
            label1.Text = "Nome do Servidor:";
            // 
            // txtconexao
            // 
            txtconexao.Location = new Point(237, 22);
            txtconexao.Name = "txtconexao";
            txtconexao.Size = new Size(216, 31);
            txtconexao.TabIndex = 3;
            txtconexao.Text = ".\\sqlserver";
            // 
            // btnConexaoBd
            // 
            btnConexaoBd.Location = new Point(968, 19);
            btnConexaoBd.Name = "btnConexaoBd";
            btnConexaoBd.Size = new Size(183, 34);
            btnConexaoBd.TabIndex = 2;
            btnConexaoBd.Text = "Conectar BD";
            btnConexaoBd.UseVisualStyleBackColor = true;
            btnConexaoBd.Click += btnConexaoBd_Click;
            // 
            // lblcaminhoxml
            // 
            lblcaminhoxml.Location = new Point(286, 292);
            lblcaminhoxml.Name = "lblcaminhoxml";
            lblcaminhoxml.Size = new Size(653, 38);
            lblcaminhoxml.TabIndex = 1;
            lblcaminhoxml.Text = "label1";
            // 
            // btnSelecionarXML
            // 
            btnSelecionarXML.Location = new Point(489, 333);
            btnSelecionarXML.Name = "btnSelecionarXML";
            btnSelecionarXML.Size = new Size(226, 34);
            btnSelecionarXML.TabIndex = 0;
            btnSelecionarXML.Text = "Selecionar XML";
            btnSelecionarXML.UseVisualStyleBackColor = true;
            btnSelecionarXML.Click += btnSelecionarXML_Click;
            // 
            // Control2
            // 
            Control2.Controls.Add(tdbResultado);
            Control2.Location = new Point(4, 34);
            Control2.Name = "Control2";
            Control2.Padding = new Padding(3);
            Control2.Size = new Size(1254, 738);
            Control2.TabIndex = 1;
            Control2.Text = "Resultado";
            Control2.UseVisualStyleBackColor = true;
            // 
            // tdbResultado
            // 
            tdbResultado.AllowUserToAddRows = false;
            tdbResultado.AllowUserToDeleteRows = false;
            tdbResultado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tdbResultado.Columns.AddRange(new DataGridViewColumn[] { Selecionar, Compatibilidade, idmodeloserviconfse, nocodigoibge, nocodigoibgeorgaoprestadorservico, Xml, CopiarXml, idmodelo, noufprestadorservico });
            tdbResultado.Location = new Point(6, 6);
            tdbResultado.Name = "tdbResultado";
            tdbResultado.RowHeadersWidth = 62;
            tdbResultado.Size = new Size(1242, 726);
            tdbResultado.TabIndex = 0;
            tdbResultado.CellClick += tdbResultado_CellClick;
            // 
            // Selecionar
            // 
            Selecionar.HeaderText = "Selecionar";
            Selecionar.MinimumWidth = 8;
            Selecionar.Name = "Selecionar";
            Selecionar.Width = 150;
            // 
            // Compatibilidade
            // 
            Compatibilidade.HeaderText = "Compatibilidade";
            Compatibilidade.MinimumWidth = 8;
            Compatibilidade.Name = "Compatibilidade";
            Compatibilidade.Width = 150;
            // 
            // idmodeloserviconfse
            // 
            idmodeloserviconfse.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            idmodeloserviconfse.HeaderText = "idmodeloserviconfse";
            idmodeloserviconfse.MinimumWidth = 8;
            idmodeloserviconfse.Name = "idmodeloserviconfse";
            idmodeloserviconfse.Resizable = DataGridViewTriState.True;
            idmodeloserviconfse.SortMode = DataGridViewColumnSortMode.NotSortable;
            idmodeloserviconfse.Width = 183;
            // 
            // nocodigoibge
            // 
            nocodigoibge.HeaderText = "nocodigoibge";
            nocodigoibge.MinimumWidth = 8;
            nocodigoibge.Name = "nocodigoibge";
            nocodigoibge.Width = 300;
            // 
            // nocodigoibgeorgaoprestadorservico
            // 
            nocodigoibgeorgaoprestadorservico.HeaderText = "nocodigoibgeorgaoprestadorservico";
            nocodigoibgeorgaoprestadorservico.MinimumWidth = 8;
            nocodigoibgeorgaoprestadorservico.Name = "nocodigoibgeorgaoprestadorservico";
            nocodigoibgeorgaoprestadorservico.Width = 300;
            // 
            // Xml
            // 
            Xml.HeaderText = "Xml";
            Xml.MinimumWidth = 8;
            Xml.Name = "Xml";
            Xml.Visible = false;
            Xml.Width = 150;
            // 
            // CopiarXml
            // 
            CopiarXml.HeaderText = "Copiar Xml";
            CopiarXml.MinimumWidth = 8;
            CopiarXml.Name = "CopiarXml";
            CopiarXml.Text = "Copiar";
            CopiarXml.ToolTipText = "Copiar";
            CopiarXml.UseColumnTextForButtonValue = true;
            CopiarXml.Width = 150;
            // 
            // idmodelo
            // 
            idmodelo.HeaderText = "idmodelo";
            idmodelo.MinimumWidth = 8;
            idmodelo.Name = "idmodelo";
            idmodelo.Visible = false;
            idmodelo.Width = 150;
            // 
            // noufprestadorservico
            // 
            noufprestadorservico.HeaderText = "noufprestadorservico";
            noufprestadorservico.MinimumWidth = 8;
            noufprestadorservico.Name = "noufprestadorservico";
            noufprestadorservico.Visible = false;
            noufprestadorservico.Width = 150;
            // 
            // Control3
            // 
            Control3.Controls.Add(btnExportar);
            Control3.Controls.Add(lblproximoid);
            Control3.Controls.Add(lblnfsemunicipio);
            Control3.Controls.Add(tdbnfsemunicipio);
            Control3.Controls.Add(lblmunicipio);
            Control3.Controls.Add(btnconfirmar);
            Control3.Controls.Add(btnpesquisar);
            Control3.Controls.Add(txtmunicipio);
            Control3.Controls.Add(label4);
            Control3.Controls.Add(tdbMunicipio);
            Control3.Location = new Point(4, 34);
            Control3.Name = "Control3";
            Control3.Padding = new Padding(3);
            Control3.Size = new Size(1254, 738);
            Control3.TabIndex = 2;
            Control3.Text = "Visualizar/Exportar";
            Control3.UseVisualStyleBackColor = true;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(161, 661);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(203, 34);
            btnExportar.TabIndex = 9;
            btnExportar.Text = "Exportar Script";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnexportar_Click;
            // 
            // lblproximoid
            // 
            lblproximoid.AutoSize = true;
            lblproximoid.Location = new Point(897, 388);
            lblproximoid.Name = "lblproximoid";
            lblproximoid.Size = new Size(0, 25);
            lblproximoid.TabIndex = 8;
            // 
            // lblnfsemunicipio
            // 
            lblnfsemunicipio.AutoSize = true;
            lblnfsemunicipio.Location = new Point(161, 360);
            lblnfsemunicipio.Name = "lblnfsemunicipio";
            lblnfsemunicipio.Size = new Size(283, 25);
            lblnfsemunicipio.TabIndex = 7;
            lblnfsemunicipio.Text = "Modelos vinculados ao município:";
            // 
            // tdbnfsemunicipio
            // 
            tdbnfsemunicipio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tdbnfsemunicipio.Columns.AddRange(new DataGridViewColumn[] { idmodeloserviconfsemunicipio, idmunicipiovinculado, idmodeloserviconfsevinculado });
            tdbnfsemunicipio.Location = new Point(161, 388);
            tdbnfsemunicipio.Name = "tdbnfsemunicipio";
            tdbnfsemunicipio.RowHeadersWidth = 62;
            tdbnfsemunicipio.Size = new Size(710, 176);
            tdbnfsemunicipio.TabIndex = 6;
            // 
            // idmodeloserviconfsemunicipio
            // 
            idmodeloserviconfsemunicipio.HeaderText = "idmodeloserviconfsemunicipio";
            idmodeloserviconfsemunicipio.MinimumWidth = 8;
            idmodeloserviconfsemunicipio.Name = "idmodeloserviconfsemunicipio";
            idmodeloserviconfsemunicipio.Width = 200;
            // 
            // idmunicipiovinculado
            // 
            idmunicipiovinculado.HeaderText = "idmunicipio";
            idmunicipiovinculado.MinimumWidth = 8;
            idmunicipiovinculado.Name = "idmunicipiovinculado";
            idmunicipiovinculado.Width = 150;
            // 
            // idmodeloserviconfsevinculado
            // 
            idmodeloserviconfsevinculado.HeaderText = "idmodeloserviconfse";
            idmodeloserviconfsevinculado.MinimumWidth = 8;
            idmodeloserviconfsevinculado.Name = "idmodeloserviconfsevinculado";
            idmodeloserviconfsevinculado.Width = 180;
            // 
            // lblmunicipio
            // 
            lblmunicipio.AutoSize = true;
            lblmunicipio.Location = new Point(384, 314);
            lblmunicipio.Name = "lblmunicipio";
            lblmunicipio.Size = new Size(0, 25);
            lblmunicipio.TabIndex = 5;
            // 
            // btnconfirmar
            // 
            btnconfirmar.Location = new Point(161, 309);
            btnconfirmar.Name = "btnconfirmar";
            btnconfirmar.Size = new Size(203, 34);
            btnconfirmar.TabIndex = 4;
            btnconfirmar.Text = "Confirmar Município";
            btnconfirmar.UseVisualStyleBackColor = true;
            btnconfirmar.Click += btnconfirmar_Click;
            // 
            // btnpesquisar
            // 
            btnpesquisar.Location = new Point(1001, 8);
            btnpesquisar.Name = "btnpesquisar";
            btnpesquisar.Size = new Size(112, 34);
            btnpesquisar.TabIndex = 3;
            btnpesquisar.Text = "Pesquisar";
            btnpesquisar.UseVisualStyleBackColor = true;
            btnpesquisar.Click += btnpesquisar_Click;
            // 
            // txtmunicipio
            // 
            txtmunicipio.Location = new Point(467, 7);
            txtmunicipio.Name = "txtmunicipio";
            txtmunicipio.Size = new Size(516, 31);
            txtmunicipio.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(93, 13);
            label4.Name = "label4";
            label4.Size = new Size(368, 25);
            label4.TabIndex = 1;
            label4.Text = "Digite o nome ou código IBGE do município:";
            // 
            // tdbMunicipio
            // 
            tdbMunicipio.AllowUserToAddRows = false;
            tdbMunicipio.AllowUserToDeleteRows = false;
            tdbMunicipio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tdbMunicipio.Columns.AddRange(new DataGridViewColumn[] { SelecionarMunicipio, idmunicipio, municipio, uf, ibge });
            tdbMunicipio.Location = new Point(161, 65);
            tdbMunicipio.Name = "tdbMunicipio";
            tdbMunicipio.RowHeadersWidth = 62;
            tdbMunicipio.Size = new Size(870, 225);
            tdbMunicipio.TabIndex = 0;
            // 
            // SelecionarMunicipio
            // 
            SelecionarMunicipio.HeaderText = "Selecionar";
            SelecionarMunicipio.MinimumWidth = 8;
            SelecionarMunicipio.Name = "SelecionarMunicipio";
            SelecionarMunicipio.Resizable = DataGridViewTriState.True;
            SelecionarMunicipio.SortMode = DataGridViewColumnSortMode.Automatic;
            SelecionarMunicipio.Width = 150;
            // 
            // idmunicipio
            // 
            idmunicipio.HeaderText = "ID Município";
            idmunicipio.MinimumWidth = 8;
            idmunicipio.Name = "idmunicipio";
            idmunicipio.Width = 150;
            // 
            // municipio
            // 
            municipio.HeaderText = "Município";
            municipio.MinimumWidth = 8;
            municipio.Name = "municipio";
            municipio.Width = 250;
            // 
            // uf
            // 
            uf.HeaderText = "UF";
            uf.MinimumWidth = 8;
            uf.Name = "uf";
            uf.Width = 150;
            // 
            // ibge
            // 
            ibge.HeaderText = "IBGE";
            ibge.MinimumWidth = 8;
            ibge.Name = "ibge";
            ibge.Width = 150;
            // 
            // frmXML
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1286, 800);
            Controls.Add(ControlePrincipal);
            Name = "frmXML";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "XML";
            ControlePrincipal.ResumeLayout(false);
            Control1.ResumeLayout(false);
            Control1.PerformLayout();
            Control2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tdbResultado).EndInit();
            Control3.ResumeLayout(false);
            Control3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tdbnfsemunicipio).EndInit();
            ((System.ComponentModel.ISupportInitialize)tdbMunicipio).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl ControlePrincipal;
        private TabPage Control1;
        private TabPage Control2;
        private Label lblcaminhoxml;
        private Button btnSelecionarXML;
        private TextBox txtconexao;
        private Button btnConexaoBd;
        private Label label1;
        private TextBox txtsenha;
        private Label label3;
        private TextBox txtid;
        private Label label2;
        private DataGridView tdbResultado;
        private TabPage Control3;
        private Label label4;
        private DataGridView tdbMunicipio;
        private Button btnpesquisar;
        private TextBox txtmunicipio;
        private DataGridViewCheckBoxColumn SelecionarMunicipio;
        private DataGridViewTextBoxColumn idmunicipio;
        private DataGridViewTextBoxColumn municipio;
        private DataGridViewTextBoxColumn uf;
        private DataGridViewTextBoxColumn ibge;
        private Button btnconfirmar;
        private Label lblmunicipio;
        private Label lblnfsemunicipio;
        private DataGridView tdbnfsemunicipio;
        private DataGridViewTextBoxColumn idmodeloserviconfsemunicipio;
        private DataGridViewTextBoxColumn idmunicipiovinculado;
        private DataGridViewTextBoxColumn idmodeloserviconfsevinculado;
        private Label lblproximoid;
        private Button btnExportar;
        private DataGridViewCheckBoxColumn Selecionar;
        private DataGridViewTextBoxColumn Compatibilidade;
        private DataGridViewTextBoxColumn idmodeloserviconfse;
        private DataGridViewTextBoxColumn nocodigoibge;
        private DataGridViewTextBoxColumn nocodigoibgeorgaoprestadorservico;
        private DataGridViewTextBoxColumn Xml;
        private DataGridViewButtonColumn CopiarXml;
        private DataGridViewTextBoxColumn idmodelo;
        private DataGridViewTextBoxColumn noufprestadorservico;
    }
}
