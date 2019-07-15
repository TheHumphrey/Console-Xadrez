using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Position { get; set; }
        public Cor Collor { get; set; }
        public int QtMovimento { get; set; }
        public Tabuleiro Tab { get; set; }

        public Peca(Cor collor, Tabuleiro tab)
        {
            Position = null;
            Collor = collor;
            QtMovimento = 0;
            Tab = tab;
        }
        public void IncrementarQtdMovimento()
        {
            QtMovimento++;
        }

        public abstract bool[,] MovimentosPosssiveis();
    }
}

