using Domain.Common;
using System;

namespace Domain.Entities
{
    public  class Veiculo: BaseEntity
    {
        public Veiculo(string codigoFipe, int anoModelo)
        {
            CodigoFipe = codigoFipe;
            AnoModelo = anoModelo;  
        }

        public Veiculo(string placa, decimal valor, string modelo, string marca ,int anoModelo, string combustivel, string codigoFipe, string mesReferencia)
        {
            Placa = placa;
            Valor = valor;
            Modelo = modelo;
            Marca = marca;
            AnoModelo = anoModelo;
            Combustivel = combustivel;
            CodigoFipe = codigoFipe;
            MesReferencia = mesReferencia;
        }


        public string Placa { get;  set; }
        public decimal Valor { get;  set; }
        public string Marca { get;  set; }
        public string Modelo { get;  set; }
        public int AnoModelo { get;  set; }
        public string Combustivel { get;  set; }
        public string CodigoFipe { get;  set; }
        public string MesReferencia { get;  set; }
     
    }
}
