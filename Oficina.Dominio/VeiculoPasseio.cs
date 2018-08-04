using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Dominio
{

    //ToDo: OO - Classe ou abstração. (resumir a realidade)
    //ToDo: OO : Veiculo - Herança.
    public class VeiculoPasseio : Veiculo
    {
        public TipoCarroceria Carroceria { get; set; }

        //ToDO: OO - polimorfismo por substituição - Override (Pai tbm tem Validar)
        public override List<string> Validar()  //OVERRIDE obrigatorio por conta do abstract na classe pai
        {
            var erros = base.ValidarBase(); //base. Puxa a validação da classe Pai

            if (!Enum.IsDefined(typeof(TipoCarroceria),Carroceria)) //Validação de enumerador
            {
                erros.Add($"Acarroceria informada ({Carroceria}) não é válida.");
            }

            return erros;
        }
    }
}
