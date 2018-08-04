using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Dominio
{
    //Classe abstrata não pode ser instanciada (new), devido a ter classes filhas (com herancia)
    public abstract class Veiculo
    {
        //public Veiculo() ///ctor
        //{
        //    Id = Guid.NewGuid();
        //}

        public Guid Id { get; set; } = Guid.NewGuid(); //Global Unique Identifier

        //ToDo: OO - Encapsulamento
        // get set cria regra para property
        private string _placa; 

        public string Placa
        {
            get { return _placa.ToUpper(); }
            set { _placa = value.ToUpper(); }
        }


        //private string _placa

        //public string Placa
        //{
        //    get
        //    {
        //        return _placa.ToUpper();
        //    }
        //    set
        //    {
        //    }
        //};  

       

        public int Ano { get; set; }
        public string Observacao { get; set; }
        public Modelo Modelo { get; set; }
        public Cor Cor { get; set; }
        public Combustivel Combustivel { get; set; }
        public Cambio Cambio { get; set; }

        public abstract List<string> Validar(); //Obriga as classes filhas a terem o metodo abstrato (no exemplo: Valida())

        protected List<string> ValidarBase() //Protect só pode ser visto/acessado pelos filhos/derivados (usado somente com herança)
        {
            var erros = new List<string>();
                        
            if (Ano <= 1950 || (Ano - DateTime.Now.Year >=2 ))
            {
                erros.Add($"O ano informado {Ano} é inválido.");
            }

            return erros;
        }
    }
}
