using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AspNetVS2017.Capitulo01.Fretes
{
    public partial class FretesForm : Form
    {
        public FretesForm()
        {
            InitializeComponent();
        }

        private void calcularButton_Click(object sender, EventArgs e)
        {
            var erros = ValidarFormulario();
            
            //if (!erros.Any())
            if (erros.Count == 0)
            {
                Calcular();
            }
            else
            {
                MessageBox.Show(string.Join(Environment.NewLine,erros),
                                "Validação",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        private void Calcular()
        {
            var percent = 0m;
            var valor = Convert.ToDecimal(valorTextBox.Text);
            var nordeste = new List<string> { "BA", "PE", "AL" }; //para classe tem que ter new

            switch (ufComboBox.Text.ToUpper())
            {
                case "SP":
                    percent = 0.2m;
                    break;
                case "ES": //Case sem corpo equivale a OR
                case "RJ":
                    percent = 0.3m;
                    break;
                case "MG":
                    percent = 0.35m;
                    break;
                case var uf when nordeste.Contains(uf):
                    percent = 0.4m;
                    break;
                case "AM":
                    percent = 0.6m;
                    break;
                case null: //Para C# 7>
                    throw new NullReferenceException("A UF não pode ser nula!");
                default: //similar ao ELSE
                    percent = 0.75m;
                    break;
            }

            freteTextBox.Text = percent.ToString("P2");
            resultadoTextBox.Text = (valor * (1 + percent)).ToString("C2");
        }

        // Tres "/" cria sumário
        /// <summary>
        /// Realiza a Validação do formulário
        /// </summary>
        /// <returns></returns>
        private List<string> ValidarFormulario()
        {
            var erros = new List<string>(); // instanciar um objeto

            if (clienteTextBox.Text.Trim() == string.Empty) //string.Empty é o mesmo que == ""
            {
                erros.Add("O campo cliente é obrigatório!");
            }

            if (string.IsNullOrEmpty(valorTextBox.Text.Trim()))
            {
                erros.Add("O campo valor é obrigatório!");
            }
            else
            {
                //decimal valor;    Para C# 2017<
                //if (decimal.TryParse(valorTextBox.Text.Trim(), out valor))
                if (!decimal.TryParse(valorTextBox.Text.Trim(),out decimal valor))
                {
                    erros.Add("O campo valor está no formato invalido!");
                }
            }

            if (ufComboBox.SelectedIndex == -1)
            {
                erros.Add("O campo UF é obrigatório!");
            }

            return erros;
        }

        private void limparButton_Click(object sender, EventArgs e)
        {
            clienteTextBox.Text = "";
            valorTextBox.Text = null;
            freteTextBox.Clear();
            ufComboBox.SelectedIndex = -1;
            resultadoTextBox.Text = string.Empty;
            clienteTextBox.Focus();
        }
    }
}
