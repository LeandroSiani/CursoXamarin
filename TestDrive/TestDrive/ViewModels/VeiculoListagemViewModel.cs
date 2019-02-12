using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Model;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class VeiculoListagemViewModel : BaseViewModel
    {
        const string URL_GET_VEICULOS = "http://aluracar.herokuapp.com/";

        public ObservableCollection<Veiculo> Veiculos { get; set; }

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
            Veiculos = new ObservableCollection<Veiculo>();
        }

        public async Task GetVeiculos()
        {
            //return URL_GET_VEICULOS;
            IsAguardando = true;
            HttpClient client = new HttpClient();
            var resultado = await client.GetStringAsync(URL_GET_VEICULOS);

            var lista = JsonConvert.DeserializeObject<IEnumerable<VeiculoJson>>(resultado);

            foreach (var item in lista)
            {
                Veiculos.Add(new Veiculo()
                {
                    Nome = item.Nome,
                    Preco = item.Preco
                });
            }
            IsAguardando = false;
        }
    }

    class VeiculoJson
    {
        public string Nome { get; set; }
        public int Preco { get; set; }
    }
}
