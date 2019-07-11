using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Cor collor, Tabuleiro tab) : base(collor, tab)
        {

        }
        public override string ToString()
        {
            return "R";
        }
    }
}
