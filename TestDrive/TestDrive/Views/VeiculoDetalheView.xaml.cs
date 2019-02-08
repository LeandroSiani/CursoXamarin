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
        public VeiculoDetalheViewModel ViewModel { get; set; }        

        public VeiculoDetalheView (Veiculo veiculo)
		{
			InitializeComponent ();            
            this.ViewModel = new VeiculoDetalheViewModel(veiculo);
            this.BindingContext = this.ViewModel;
		}        

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "Proximo", (msg) =>
             {
                 Navigation.PushAsync(new VeiculoAgendamentoView(msg));
             });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "Proximo");
        }
    }
}