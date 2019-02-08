using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Model;

namespace TestDrive.ViewModels
{
    public class VeiculoAgendamentoViewModel
    {
        public Agendamento Agendamento { get; set; }        

        public VeiculoAgendamentoViewModel(Veiculo veiculo)
        {
            this.Agendamento = new Agendamento();
            this.Agendamento.Veiculo = veiculo;            
        }
    }
}
