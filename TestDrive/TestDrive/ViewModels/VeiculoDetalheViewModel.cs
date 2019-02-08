using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TestDrive.Model;

namespace TestDrive.ViewModels
{
    public class VeiculoDetalheViewModel : INotifyPropertyChanged
    {
        public VeiculoDetalheViewModel(Veiculo veiculo)
        {
            this.Veiculo = veiculo;
        }

        public Veiculo Veiculo { get; set; }

        public bool TemFreioAbs
        {
            get
            {
                return Veiculo.TemFreioAbs;
            }
            set
            {
                Veiculo.TemFreioAbs = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool TemArCondicionado
        {
            get
            {
                return Veiculo.TemArCondicionado;
            }
            set
            {
                Veiculo.TemArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool TemMp3Player
        {
            get
            {
                return Veiculo.TemMp3Player;
            }
            set
            {
                Veiculo.TemMp3Player = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public string ValorTotal
        {
            get
            {
                return Veiculo.PrecoTotalFormatado;
            }
        }


        public string TextoFreioAbs
        {
            get
            {
                return string.Format("Freio ABS = R$ {0}", Veiculo.FREIO_ABS);
            }
        }

        public string TextoArcodicionado
        {
            get
            {
                return string.Format("Ar condicionado = R$ {0}", Veiculo.AR_CONDICIONADO);
            }
        }

        public string TextoMp3Player
        {
            get
            {
                return string.Format("MP3 player = R$ {0}", Veiculo.MP3_PLAYER);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
