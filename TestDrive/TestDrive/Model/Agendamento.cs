using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Model
{
    public class Agendamento
    {
        public Veiculo Veiculo { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        private DateTime dataAgendamento = DateTime.Today;
        public DateTime DataAgendamento
        {
            get { return dataAgendamento; }
            set { dataAgendamento = value; }
        }

        private TimeSpan horaAgendamento;
        public TimeSpan HoraAgendamento
        {
            get { return horaAgendamento; }
            set { horaAgendamento = value; }
        }

    }
}
