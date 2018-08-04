using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Dominio
{
    public class Caminhao : Veiculo
    {
        public QuantidadeEixo QuantidadeEixo { get; set; }

        public override List<string> Validar() //OVERRIDE obrigatorio por conta do abstract na classe pai
        {
            throw new NotImplementedException();
        }
    }
}
