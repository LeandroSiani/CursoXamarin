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
            MessagingCenter.Subscribe<Agendamento>(this, "Agendar", async (msg) =>
              {
                  var confirma = await DisplayAlert("Salvar agendamento",
                    "Deseja mesmo enviar o agendamento?",
                    "Sim","Não");

                  if (confirma)
                  {
                      this.ViewModel.SalvarAgendamento();
                  }
              });
            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento", (msg) =>
            {
                DisplayAlert("Agendamento", "Agendamento salvo com sucesso!", "ok");
            });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento", (msg) =>
            {
                DisplayAlert("Agendamento", "Agendamento não foi salvo!", "ok");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendar");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "FalhaAgendamento");
        }
    }
}