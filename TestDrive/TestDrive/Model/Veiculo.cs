using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Model
{
    public class Veiculo
    {
        public string Nome { get; set; }
        public Decimal Preco { get; set; }
        public string PrecoFormatado
        {
            get { return string.Format("R$ {0}", Preco); }
        }
        public const Decimal FREIO_ABS = 800;
        public const Decimal AR_CONDICIONADO = 1000;
        public const Decimal MP3_PLAYER = 400;

        public bool TemFreioAbs { get; set; }
        public bool TemArCondicionado { get; set; }
        public bool TemMp3Player { get; set; }

        public string PrecoTotalFormatado {
            get
            {
                return string.Format("Valor total: R$ {0}",
                    Preco +
                    (TemFreioAbs ? FREIO_ABS : 0) +
                    (TemArCondicionado ? AR_CONDICIONADO : 0) +
                    (TemMp3Player ? MP3_PLAYER : 0));
            }
        }
    }
}
