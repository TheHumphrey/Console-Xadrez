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

        private bool _podeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Collor != this.Collor;
        }

        public override bool[,] MovimentosPosssiveis()
        {
            bool[,] mat = new bool[Tab.Linha, Tab.Coluna];

            Posicao pos = new Posicao(0, 0);

            // acima
            pos.DefinirValores(Position.Linha - 1, Position.Coluna);
            while(Tab.PosicaoValida(pos) && _podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if(Tab.Peca(pos) != null && Tab.Peca(pos).Collor != Collor)
                {
                    break;
                }
                pos.Linha--;
            }

            // abaixo
            pos.DefinirValores(Position.Linha + 1, Position.Coluna);
            while (Tab.PosicaoValida(pos) && _podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Collor != Collor)
                {
                    break;
                }
                pos.Linha++;
            }

            // direita
            pos.DefinirValores(Position.Linha, Position.Coluna + 1);
            while (Tab.PosicaoValida(pos) && _podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Collor != Collor)
                {
                    break;
                }
                pos.Coluna++;
            }

            // esquerda
            pos.DefinirValores(Position.Linha, Position.Coluna - 1);
            while (Tab.PosicaoValida(pos) && _podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Collor != Collor)
                {
                    break;
                }
                pos.Coluna --;
            }

            return mat;
        }
    }
}
