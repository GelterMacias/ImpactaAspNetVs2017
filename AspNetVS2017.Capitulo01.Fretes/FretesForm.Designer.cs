namespace AspNetVS2017.Capitulo01.Fretes
{
    partial class FretesForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FretesForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.calcularButton = new System.Windows.Forms.Button();
            this.clienteTextBox = new System.Windows.Forms.TextBox();
            this.valorTextBox = new System.Windows.Forms.TextBox();
            this.freteTextBox = new System.Windows.Forms.TextBox();
            this.ufComboBox = new System.Windows.Forms.ComboBox();
            this.resultadoTextBox = new System.Windows.Forms.TextBox();
            this.limparButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(24, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(24, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Valor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(24, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "UF:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(24, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "%Frete:";
            // 
            // calcularButton
            // 
            this.calcularButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.calcularButton.Location = new System.Drawing.Point(28, 221);
            this.calcularButton.Name = "calcularButton";
            this.calcularButton.Size = new System.Drawing.Size(147, 62);
            this.calcularButton.TabIndex = 5;
            this.calcularButton.Text = "Calcular";
            this.calcularButton.UseVisualStyleBackColor = true;
            this.calcularButton.Click += new System.EventHandler(this.calcularButton_Click);
            // 
            // clienteTextBox
            // 
            this.clienteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.clienteTextBox.Location = new System.Drawing.Point(112, 32);
            this.clienteTextBox.Name = "clienteTextBox";
            this.clienteTextBox.Size = new System.Drawing.Size(237, 26);
            this.clienteTextBox.TabIndex = 1;
            // 
            // valorTextBox
            // 
            this.valorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.valorTextBox.Location = new System.Drawing.Point(112, 78);
            this.valorTextBox.Name = "valorTextBox";
            this.valorTextBox.Size = new System.Drawing.Size(237, 26);
            this.valorTextBox.TabIndex = 2;
            // 
            // freteTextBox
            // 
            this.freteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.freteTextBox.Location = new System.Drawing.Point(112, 172);
            this.freteTextBox.Name = "freteTextBox";
            this.freteTextBox.ReadOnly = true;
            this.freteTextBox.Size = new System.Drawing.Size(237, 26);
            this.freteTextBox.TabIndex = 4;
            // 
            // ufComboBox
            // 
            this.ufComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ufComboBox.FormattingEnabled = true;
            this.ufComboBox.Items.AddRange(new object[] {
            "SP",
            "MG",
            "RJ",
            "AM",
            "Outros"});
            this.ufComboBox.Location = new System.Drawing.Point(112, 124);
            this.ufComboBox.Name = "ufComboBox";
            this.ufComboBox.Size = new System.Drawing.Size(237, 28);
            this.ufComboBox.TabIndex = 3;
            // 
            // resultadoTextBox
            // 
            this.resultadoTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.resultadoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultadoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultadoTextBox.Location = new System.Drawing.Point(28, 312);
            this.resultadoTextBox.Name = "resultadoTextBox";
            this.resultadoTextBox.ReadOnly = true;
            this.resultadoTextBox.Size = new System.Drawing.Size(320, 38);
            this.resultadoTextBox.TabIndex = 4;
            this.resultadoTextBox.TabStop = false;
            // 
            // limparButton
            // 
            this.limparButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.limparButton.Location = new System.Drawing.Point(201, 221);
            this.limparButton.Name = "limparButton";
            this.limparButton.Size = new System.Drawing.Size(147, 62);
            this.limparButton.TabIndex = 6;
            this.limparButton.Text = "Limpar";
            this.limparButton.UseVisualStyleBackColor = true;
            this.limparButton.Click += new System.EventHandler(this.limparButton_Click);
            // 
            // FretesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 392);
            this.Controls.Add(this.resultadoTextBox);
            this.Controls.Add(this.ufComboBox);
            this.Controls.Add(this.freteTextBox);
            this.Controls.Add(this.valorTextBox);
            this.Controls.Add(this.clienteTextBox);
            this.Controls.Add(this.limparButton);
            this.Controls.Add(this.calcularButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FretesForm";
            this.Text = "Cálculo de Fretes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button calcularButton;
        private System.Windows.Forms.TextBox clienteTextBox;
        private System.Windows.Forms.TextBox valorTextBox;
        private System.Windows.Forms.TextBox freteTextBox;
        private System.Windows.Forms.ComboBox ufComboBox;
        private System.Windows.Forms.TextBox resultadoTextBox;
        private System.Windows.Forms.Button limparButton;
    }
}

