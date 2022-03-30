using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Veiculo: BaseEntity
    {
        public string Placa { get; private set; }
        public decimal Valor { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int AnoModelo { get; private set; }
        public string Combustivel { get; private set; }
        public string CodigoFipe { get; private set; }
        public string MesReferencia { get; private set; }

    }
}
