using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestDrive.Model;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class VeiculoAgendamentoViewModel
    {
        public Agendamento Agendamento { get; set; }        

        public VeiculoAgendamentoViewModel(Veiculo veiculo)
        {
            this.Agendamento = new Agendamento();
            this.Agendamento.Veiculo = veiculo;
            AgendarCommand = new Command(() => 
            {
                MessagingCenter.Send<Agendamento>(this.Agendamento
                    , "Agendar");
            });
        }

        public ICommand AgendarCommand { get; set; }
    }
}
