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
	public partial class VeiculoAgendamentoView : ContentPage
	{
        public VeiculoAgendamentoViewModel ViewModel { get; set; }

        public VeiculoAgendamentoView (Veiculo veiculo)
		{
			InitializeComponent ();
            this.ViewModel = new VeiculoAgendamentoViewModel(veiculo);
            this.BindingContext = this.ViewModel;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "Agendar", (msg) =>
              {
                  DisplayAlert("Agendamento",
                    String.Format("Veículo: {0}" + Environment.NewLine +
                                  "Nome : {1}" + Environment.NewLine +
                                  "Fone : {2}" + Environment.NewLine +
                                  "Email : {3}" + Environment.NewLine +
                                  "Data Agendamento : {4}" + Environment.NewLine +
                                  "Hora Agendamento : {5}" + Environment.NewLine,
                                  msg.Veiculo.Nome,
                                  msg.Nome,
                                  msg.Telefone,
                                  msg.Email,
                                  msg.DataAgendamento.ToString("dd/MM/yyyy"),
                                  msg.HoraAgendamento),
                    "Ok");
              });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendar");
        }
    }
}