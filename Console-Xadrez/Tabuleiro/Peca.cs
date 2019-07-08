using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class Peca
    {
        public Posicao Position { get; set; }
        public Cor Collor { get; set; }
        public int QtMovimento { get; set; }
        public Tabuleiro Tab { get; set; }

        public Peca(Posicao position, Cor collor, Tabuleiro tab)
        {
            Position = position;
            Collor = collor;
            QtMovimento = 0;
            Tab = tab;
        }
    }
}
