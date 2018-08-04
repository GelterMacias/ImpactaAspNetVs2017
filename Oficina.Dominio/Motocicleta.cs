using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Dominio
{
    //Sempre verificar se veio preenchido como public
    // Motocicleta : Veiculo (dois pontos = herança) - herda todas as caracteristas do veículo
    public class Motocicleta : Veiculo
    {
        public TipoMotocicleta Tipo { get; set; }

        public override List<string> Validar() //OVERRIDE obrigatorio por conta do abstract na classe pai
        {
            throw new NotImplementedException();
        }
    }
}
