using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AspNetVs2017.Capitulo01.Variaveis
{
    //Variavel Passa a chamar field (deve começar com _) e ser "global"
    public partial class VariaveisForm : Form
    {
        int _x = 32;
        int _w = 45;
        int _y = 16;
        int _z = 32;

        public VariaveisForm()
        {
            InitializeComponent();
        }

        private void VariaveisForm_Load(object sender, EventArgs e)
        {

        }

        private void aritmeticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ToDo: Exemplificar a diferença entre Class e Struct
            int a = 2;
            decimal bimestre1 = 4.44m;
            string meuNome = "Gelter";
            //por boa prática uma variável deve ser inicializada na criação ( "/" Comentar Linha)
            int b = 6;
            var c = 10; //var escolhe automaticamente o tipo de variável conforme o valor após o =
            int d = 13; 
            DateTime nascimento = new DateTime(1970,12,25);

            int @int = 10;

            /*if (b > 3) ("/*" ... Comentar Bloco)
            {

            }*/

            resultadoListBox.Items.Add("a = " + a);
            resultadoListBox.Items.Add(string.Concat("b = ",b));
            resultadoListBox.Items.Add(string.Format("c = {0:C3}",c)); //Substitui o {} pela variável e formata como Currency com 3 casas decimais
            resultadoListBox.Items.Add($"d = {d}"); //String Interpolada

            resultadoListBox.Items.Add("c * d = " + (c * d));
            resultadoListBox.Items.Add("c / d = " + (c / Convert.ToDecimal(d)));//Converter uma das variaveis para ter um resultado como decimal
            resultadoListBox.Items.Add("d % a = " + (d % a)); // Operador módulo (resto)
        }

        private void reduzidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var x = 5;

            resultadoListBox.Items.Add("x = " + x);

            //x = x - 3;
            x -= 3; // Forma reduzida da linha acima

            resultadoListBox.Items.Add("x = " + x);

        }

        private void incrementaisDecrementaisToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int a;

            a = 5;

            resultadoListBox.Items.Add("Exemplo de pré-incremental");
            resultadoListBox.Items.Add("a = " + a);
            resultadoListBox.Items.Add("2 + ++a = " + (2 + ++a));
            resultadoListBox.Items.Add("a = " + a);
            
            resultadoListBox.Items.Add("--------------------");

            a = 5;
            resultadoListBox.Items.Add("Exemplo de pós-incremental");
            resultadoListBox.Items.Add("a = " + a);
            resultadoListBox.Items.Add("2 + a++ = " + (2 + a++));
            resultadoListBox.Items.Add("a = " + a);

        }

        private void booleanasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirValoresVariaveis();

            resultadoListBox.Items.Add("W <= X = " + (_w <= _x));
            resultadoListBox.Items.Add("X == Z = " + (_x == _z));
            resultadoListBox.Items.Add("X != Z = " + (_x != _z));

        }

        //Criado método 
        private void ExibirValoresVariaveis()
        {
            resultadoListBox.Items.Add("x = " + _x);
            resultadoListBox.Items.Add("w = " + _w);
            resultadoListBox.Items.Add("y = " + _y);
            resultadoListBox.Items.Add("z = " + _z);

            resultadoListBox.Items.Add(new string('-', 50));
        }

        private void lógicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirValoresVariaveis();
            // Pipe significa OR
            resultadoListBox.Items.Add("W < X = || Y ==16 =" + (_w < _x || _y == 16));
            // && significa AND
            resultadoListBox.Items.Add("X == Z && Z != X =" + (_x == _z && _z != _x));
            // ! significa NOT
            resultadoListBox.Items.Add("!(Y > W) =" + (!(_y > _w)));

            //Precedência
            //1º Negação (!)
            //2º E (&&)
            //3º OU (||)
        }   
          
            

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ternáriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ano;
            int ano2;

            ano = 2020;
            ano2 = 2018;

            // Operador Ternário = IIF
            // $ Interpolação - Usa chaves para incluir/concatenar uma variável
            resultadoListBox.Items.Add($"O ano {ano2} é bisexto ? {(ano2 % 4 == 0 ? "Sim" : "Não")}.");
            resultadoListBox.Items.Add($"O ano {ano} é bisexto ? {(DateTime.IsLeapYear(ano) ? "Sim" : "Não")}.");
            // Operador Ternário do exemplo: (ano % 4 == 0 ? "Sim" : "Não") = O Módulo da divisão do ano por 4 é igual a Zero ?
        }

        private void resultadoListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // resultadoListBox.Items.Remove(value);
        }
    }
}
