namespace AspNetVs2017.Capitulo01.Variaveis
{
    partial class VariaveisForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.operacoesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aritmeticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reduzidasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incrementaisDecrementaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.booleanasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lógicasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultadoListBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ternáriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operacoesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(292, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // operacoesToolStripMenuItem
            // 
            this.operacoesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aritmeticasToolStripMenuItem,
            this.reduzidasToolStripMenuItem,
            this.incrementaisDecrementaisToolStripMenuItem,
            this.booleanasToolStripMenuItem,
            this.lógicasToolStripMenuItem,
            this.ternáriasToolStripMenuItem});
            this.operacoesToolStripMenuItem.Name = "operacoesToolStripMenuItem";
            this.operacoesToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.operacoesToolStripMenuItem.Text = "Op&erações";
            // 
            // aritmeticasToolStripMenuItem
            // 
            this.aritmeticasToolStripMenuItem.Name = "aritmeticasToolStripMenuItem";
            this.aritmeticasToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.aritmeticasToolStripMenuItem.Text = "&Aritméticas";
            this.aritmeticasToolStripMenuItem.Click += new System.EventHandler(this.aritmeticasToolStripMenuItem_Click);
            // 
            // reduzidasToolStripMenuItem
            // 
            this.reduzidasToolStripMenuItem.Name = "reduzidasToolStripMenuItem";
            this.reduzidasToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.reduzidasToolStripMenuItem.Text = "&Reduzidas";
            this.reduzidasToolStripMenuItem.Click += new System.EventHandler(this.reduzidasToolStripMenuItem_Click);
            // 
            // incrementaisDecrementaisToolStripMenuItem
            // 
            this.incrementaisDecrementaisToolStripMenuItem.Name = "incrementaisDecrementaisToolStripMenuItem";
            this.incrementaisDecrementaisToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.incrementaisDecrementaisToolStripMenuItem.Text = "&Incrementais/Decrementais";
            this.incrementaisDecrementaisToolStripMenuItem.Click += new System.EventHandler(this.incrementaisDecrementaisToolStripMenuItem_Click);
            // 
            // booleanasToolStripMenuItem
            // 
            this.booleanasToolStripMenuItem.Name = "booleanasToolStripMenuItem";
            this.booleanasToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.booleanasToolStripMenuItem.Text = "&Booleanas";
            this.booleanasToolStripMenuItem.Click += new System.EventHandler(this.booleanasToolStripMenuItem_Click);
            // 
            // lógicasToolStripMenuItem
            // 
            this.lógicasToolStripMenuItem.Name = "lógicasToolStripMenuItem";
            this.lógicasToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.lógicasToolStripMenuItem.Text = "&Logicas";
            this.lógicasToolStripMenuItem.Click += new System.EventHandler(this.lógicasToolStripMenuItem_Click);
            // 
            // resultadoListBox
            // 
            this.resultadoListBox.BackColor = System.Drawing.SystemColors.Info;
            this.resultadoListBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.resultadoListBox.FormattingEnabled = true;
            this.resultadoListBox.Location = new System.Drawing.Point(0, 54);
            this.resultadoListBox.Name = "resultadoListBox";
            this.resultadoListBox.Size = new System.Drawing.Size(292, 225);
            this.resultadoListBox.TabIndex = 1;
            this.resultadoListBox.SelectedIndexChanged += new System.EventHandler(this.resultadoListBox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(122, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "Sair";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ternáriasToolStripMenuItem
            // 
            this.ternáriasToolStripMenuItem.Name = "ternáriasToolStripMenuItem";
            this.ternáriasToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.ternáriasToolStripMenuItem.Text = "Ternárias";
            this.ternáriasToolStripMenuItem.Click += new System.EventHandler(this.ternáriasToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(209, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // VariaveisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 279);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.resultadoListBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VariaveisForm";
            this.Text = "Variáveis e Operações";
            this.Load += new System.EventHandler(this.VariaveisForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem operacoesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aritmeticasToolStripMenuItem;
        private System.Windows.Forms.ListBox resultadoListBox;
        private System.Windows.Forms.ToolStripMenuItem reduzidasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incrementaisDecrementaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem booleanasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lógicasToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem ternáriasToolStripMenuItem;
        private System.Windows.Forms.Button button2;
    }
}

