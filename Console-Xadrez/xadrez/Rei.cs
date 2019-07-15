using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;
using xadrez;

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
            if (Tab.PosicaoValida(pos) && _podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //nordeste
            pos.DefinirValores(Position.Linha - 1, Position.Coluna + 1);
            if (Tab.PosicaoValida(pos) && _podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //direita
            pos.DefinirValores(Position.Linha, Position.Coluna + 1);
            if (Tab.PosicaoValida(pos) && _podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //sudeste
            pos.DefinirValores(Position.Linha + 1, Position.Coluna + 1);
            if (Tab.PosicaoValida(pos) && _podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //baixo
            pos.DefinirValores(Position.Linha + 1, Position.Coluna);
            if (Tab.PosicaoValida(pos) && _podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //suloeste
            pos.DefinirValores(Position.Linha + 1, Position.Coluna - 1);
            if (Tab.PosicaoValida(pos) && _podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //esquerda
            pos.DefinirValores(Position.Linha, Position.Coluna - 1);
            if (Tab.PosicaoValida(pos) && _podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //noroeste
            pos.DefinirValores(Position.Linha - 1, Position.Coluna - 1);
            if (Tab.PosicaoValida(pos) && _podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            return mat;
        }
    }
}
