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
        VeiculoAgendamentoViewModel viewModel;
        public VeiculoAgendamentoView (Veiculo veiculo)
		{
			InitializeComponent ();
            this.viewModel = new VeiculoAgendamentoViewModel(veiculo);
            this.BindingContext = this.viewModel;
        }

        private void BtnAgendar_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento",
                String.Format("Veículo: {0}" + Environment.NewLine +
                              "Nome : {1}" + Environment.NewLine +
                              "Fone : {2}" + Environment.NewLine +
                              "Email : {3}" + Environment.NewLine +
                              "Data Agendamento : {4}" + Environment.NewLine +
                              "Hora Agendamento : {5}" + Environment.NewLine,
                              this.viewModel.Agendamento.Veiculo.Nome,
                              this.viewModel.Agendamento.Nome,
                              this.viewModel.Agendamento.Telefone,
                              this.viewModel.Agendamento.Email,
                              this.viewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyyy"),
                              this.viewModel.Agendamento.HoraAgendamento),
                "Ok");
        }
    }
}