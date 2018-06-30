using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AspNetVS2017.Capitulo01.Troco
{
    public partial class TrocoForm : Form
    {
        public TrocoForm()
        {
            InitializeComponent();
        }
        
        private void calcButton_Click(object sender, EventArgs e)
        {

            var valorPago = Convert.ToDecimal(pagoTextBox.Text); //Comando mais evoluido
            var valorCompra = decimal.Parse(compraTextBox.Text); //Mais limitado
            var troco = valorPago - valorCompra;

            trocoTextBox.Text = troco.ToString("c2"); //c2 mostra como currency e duas casas decimais

            // Convert arredonda decimal, Cast despreza o decimal (trunca)
            var moedas1 = (int)(troco/1); // Cast (significado moldar), pode usar uma classe (converter uma classe para outra)
            troco = troco % 1;

            var moedas050 = (int)(troco / 0.50m); //m após 0.50 força transformar para decimal
            troco %= 0.50m;

            var moedas025 = (int)(troco / 0.25m);
            troco %= 0.25m;

            var moedas010 = (int)(troco / 0.10m);
            troco %= 0.10m;

            var moedas005 = (int)(troco / 0.05m);
            troco %= 0.05m;

            var moedas001 = (int)(troco / 0.01m);
            troco %= 0.01m;

            moedasListView.Items[0].Text = moedas1.ToString();
            moedasListView.Items[1].Text = moedas050.ToString();
            moedasListView.Items[2].Text = moedas025.ToString();
            moedasListView.Items[3].Text = moedas010.ToString();
            moedasListView.Items[4].Text = moedas005.ToString();
            moedasListView.Items[5].Text = moedas001.ToString();


        }
    }
}
