namespace AspNetVS2017.Capitulo01.Troco
{
    partial class TrocoForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, "100.png", System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, "50.png", System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, "25.png", System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Microsoft Sans Serif", 12F));
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, "10.png", System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Microsoft Sans Serif", 12F));
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, "5.png", System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Microsoft Sans Serif", 12F));
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, "1.png", System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Microsoft Sans Serif", 12F));
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrocoForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.calcButton = new System.Windows.Forms.Button();
            this.trocoTextBox = new System.Windows.Forms.TextBox();
            this.pagoTextBox = new System.Windows.Forms.TextBox();
            this.compraTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.moedasListView = new System.Windows.Forms.ListView();
            this.moedasImageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.calcButton);
            this.groupBox1.Controls.Add(this.trocoTextBox);
            this.groupBox1.Controls.Add(this.pagoTextBox);
            this.groupBox1.Controls.Add(this.compraTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 442);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Valores";
            // 
            // calcButton
            // 
            this.calcButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.calcButton.Font = new System.Drawing.Font("Castellar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calcButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.calcButton.Location = new System.Drawing.Point(6, 191);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(242, 42);
            this.calcButton.TabIndex = 4;
            this.calcButton.Text = "Ca&lcular";
            this.calcButton.UseVisualStyleBackColor = false;
            this.calcButton.Click += new System.EventHandler(this.calcButton_Click);
            // 
            // trocoTextBox
            // 
            this.trocoTextBox.Location = new System.Drawing.Point(97, 143);
            this.trocoTextBox.Name = "trocoTextBox";
            this.trocoTextBox.ReadOnly = true;
            this.trocoTextBox.Size = new System.Drawing.Size(151, 20);
            this.trocoTextBox.TabIndex = 3;
            // 
            // pagoTextBox
            // 
            this.pagoTextBox.Location = new System.Drawing.Point(97, 78);
            this.pagoTextBox.Name = "pagoTextBox";
            this.pagoTextBox.Size = new System.Drawing.Size(151, 20);
            this.pagoTextBox.TabIndex = 2;
            // 
            // compraTextBox
            // 
            this.compraTextBox.Location = new System.Drawing.Point(97, 13);
            this.compraTextBox.Name = "compraTextBox";
            this.compraTextBox.Size = new System.Drawing.Size(151, 20);
            this.compraTextBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Troco:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Valor &Pago:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor da &Compra:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.moedasListView);
            this.groupBox2.Location = new System.Drawing.Point(276, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(695, 441);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Troco";
            // 
            // moedasListView
            // 
            this.moedasListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moedasListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12});
            this.moedasListView.LargeImageList = this.moedasImageList;
            this.moedasListView.Location = new System.Drawing.Point(3, 16);
            this.moedasListView.Name = "moedasListView";
            this.moedasListView.Size = new System.Drawing.Size(689, 422);
            this.moedasListView.TabIndex = 0;
            this.moedasListView.UseCompatibleStateImageBehavior = false;
            // 
            // moedasImageList
            // 
            this.moedasImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("moedasImageList.ImageStream")));
            this.moedasImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.moedasImageList.Images.SetKeyName(0, "1.png");
            this.moedasImageList.Images.SetKeyName(1, "5.png");
            this.moedasImageList.Images.SetKeyName(2, "10.png");
            this.moedasImageList.Images.SetKeyName(3, "25.png");
            this.moedasImageList.Images.SetKeyName(4, "50.png");
            this.moedasImageList.Images.SetKeyName(5, "100.png");
            // 
            // TrocoForm
            // 
            this.AcceptButton = this.calcButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 466);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TrocoForm";
            this.Text = "Troco";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.TextBox trocoTextBox;
        private System.Windows.Forms.TextBox pagoTextBox;
        private System.Windows.Forms.TextBox compraTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView moedasListView;
        private System.Windows.Forms.ImageList moedasImageList;
    }
}

