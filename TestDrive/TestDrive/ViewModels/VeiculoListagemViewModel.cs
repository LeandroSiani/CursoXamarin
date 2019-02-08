using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Model;

namespace TestDrive.ViewModels
{
    public class VeiculoListagemViewModel
    {
        public List<Veiculo> Veiculos { get; set; }

        public VeiculoListagemViewModel()
        {
            Veiculos = new ListagemVeiculos().Veiculos;
        }
    }
}
