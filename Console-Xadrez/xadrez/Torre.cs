using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Cor collor, Tabuleiro tab) : base(collor, tab)
        {

        }
        public override string ToString()
        {
            return "T";
        }
    }
}
