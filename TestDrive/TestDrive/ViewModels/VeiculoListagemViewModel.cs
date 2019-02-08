using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Model;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class VeiculoListagemViewModel
    {
        public List<Veiculo> Veiculos { get; set; }

        private Veiculo veiculoSelecionado;

        public Veiculo VeiculoSelecionado
        {
            get { return veiculoSelecionado; }
            set
            {
                veiculoSelecionado = value;
                if (veiculoSelecionado != null)
                    MessagingCenter.Send(veiculoSelecionado, "VeiculoSelecionado");
            }
        }


        public VeiculoListagemViewModel()
        {
            Veiculos = new ListagemVeiculos().Veiculos;
        }
    }
}
