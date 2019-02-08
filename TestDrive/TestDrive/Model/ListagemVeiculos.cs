using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Model
{
    public class ListagemVeiculos
    {
        public  List<Veiculo> Veiculos { get; set; }

        public ListagemVeiculos()
        {
            Veiculos = new List<Veiculo>()
            {
                new Veiculo() { Nome = "Azera", Preco = new Decimal(20450.99)},
                new Veiculo() { Nome = "Eco Sport", Preco = new Decimal(20450.55)}
            };

        }
    }
}
