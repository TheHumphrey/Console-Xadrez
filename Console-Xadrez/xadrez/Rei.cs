using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;
using xadrez;

namespace xadrez
{
    class Rei : Peca
    {
        public Partida Partida { get; private set; }

        public Rei(Cor collor, Tabuleiro tab, Partida partida) : base(collor, tab)
        {
            Partida = partida;
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

        private bool _testeTorreRoque(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p != null && p is Torre && p.Collor == Collor && p.QtMovimento == 0;
        }

        public override bool[,] MovimentosPossiveis()
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

            // #Jogada especial roque

            if(QtMovimento == 00 && !Partida.Xeque)
            {
                //#Jogado especial roque pequeno
                Posicao posT1 = new Posicao(Position.Linha, Position.Coluna + 3);
                if (_testeTorreRoque(posT1))
                {
                    Posicao p1 = new Posicao(Position.Linha, Position.Coluna + 1);
                    Posicao p2 = new Posicao(Position.Linha, Position.Coluna + 2);
                    if(Tab.Peca(p1) == null && Tab.Peca(p2) == null)
                    {
                        mat[Position.Linha, Position.Coluna + 2] = true;
                    }
                }
                //#Jogado especial roque grande
                Posicao posT2 = new Posicao(Position.Linha, Position.Coluna - 4);
                if (_testeTorreRoque(posT1))
                {
                    Posicao p1 = new Posicao(Position.Linha, Position.Coluna - 1);
                    Posicao p2 = new Posicao(Position.Linha, Position.Coluna - 2);
                    Posicao p3 = new Posicao(Position.Linha, Position.Coluna - 3);
                    if (Tab.Peca(p1) == null && Tab.Peca(p2) == null && Tab.Peca(p3) == null)
                    {
                        mat[Position.Linha, Position.Coluna - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
