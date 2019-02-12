using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using TestDrive.Model;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class VeiculoAgendamentoViewModel : BaseViewModel
    {
        const string URL_GET_VEICULOS = "http://aluracar.herokuapp.com/salvaragendamento";

        public Agendamento Agendamento { get; set; }

        private bool isAguardando;

        public bool IsAguardando
        {
            get { return isAguardando; }
            set
            {
                isAguardando = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsAguardando));
            }
        }

        public string Nome
        {
            get { return Agendamento.Nome; }
            set
            {
                Agendamento.Nome = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }

        public string Fone
        {
            get { return Agendamento.Telefone; }
            set
            {
                Agendamento.Telefone = value;
            }
        }

        public string Email
        {
            get { return Agendamento.Email; }
            set
            {
                Agendamento.Email = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }


        public VeiculoAgendamentoViewModel(Veiculo veiculo)
        {
            this.Agendamento = new Agendamento();
            this.Agendamento.Veiculo = veiculo;
            AgendarCommand = new Command(() => 
            {
                MessagingCenter.Send<Agendamento>(this.Agendamento
                    , "Agendar");
            }, ()=> 
            {
                return ! string.IsNullOrEmpty(this.Agendamento.Nome) &&
                       ! string.IsNullOrEmpty(this.Agendamento.Telefone) &&
                       ! string.IsNullOrEmpty(this.Agendamento.Email);
            });
        }

        public ICommand AgendarCommand { get; set; }

        public async void SalvarAgendamento()
        {
            IsAguardando = true;
            HttpClient client = new HttpClient();
            var dataHoraAgendamento = new DateTime(Agendamento.DataAgendamento.Year, Agendamento.DataAgendamento.Month, Agendamento.DataAgendamento.Day,
                Agendamento.HoraAgendamento.Hours, Agendamento.HoraAgendamento.Minutes, Agendamento.HoraAgendamento.Seconds);

            var json = JsonConvert.SerializeObject(new
            {
                nome = Agendamento.Nome,
                fone = Agendamento.Telefone,
                email = Agendamento.Email,
                carro = Agendamento.Veiculo.Nome,
                preco = Agendamento.Veiculo.Preco,
                dataAgendamento = dataHoraAgendamento
            });
            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");
            var resposta = await client.PostAsync(URL_GET_VEICULOS,conteudo);

            if (resposta.IsSuccessStatusCode)
                MessagingCenter.Send<Agendamento>(this.Agendamento, "SucessoAgendamento");
            else
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaAgendamento");
            
            IsAguardando = false;
        }
    }
}
