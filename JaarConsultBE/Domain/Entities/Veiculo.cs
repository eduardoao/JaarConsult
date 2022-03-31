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
