using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Model;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class MainPage : ContentPage
    {       

        public MainPage()
        {
            InitializeComponent();
        }

        private void ListViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var veiculo = (Veiculo)e.Item;
            Navigation.PushAsync(new VeiculoDetalheView(veiculo));
        }
    }
}
