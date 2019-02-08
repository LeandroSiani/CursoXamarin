using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Model;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VeiculoDetalheView : ContentPage
	{
        public VeiculoDetalheViewModel viewModel { get; set; }

        public VeiculoDetalheView (Veiculo veiculo)
		{
			InitializeComponent ();
            this.viewModel = new VeiculoDetalheViewModel(veiculo);            
            this.BindingContext = this.viewModel;
		}

        private void ButtonProximo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VeiculoAgendamentoView(this.viewModel.Veiculo));
        }
    }
}