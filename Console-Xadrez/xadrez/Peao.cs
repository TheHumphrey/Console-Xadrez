using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Partida Partida { get; set; }

        public Peao(Cor cor, Tabuleiro tab, Partida partida) : base(cor, tab)
        {
            Partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool _existeInimigo(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p != null && p.Collor != Collor;
        }

        private bool _livre(Posicao pos)
        {
            return Tab.Peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linha, Tab.Coluna];

            Posicao pos = new Posicao(0, 0);

            if (Collor == Cor.Branca)
            {
                pos.DefinirValores(Position.Linha - 1, Position.Coluna);
                if (Tab.PosicaoValida(pos) && _livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Position.Linha - 2, Position.Coluna);
                Posicao p2 = new Posicao(Position.Linha - 1, Position.Coluna);

                if (Tab.PosicaoValida(p2) && _livre(p2) && Tab.PosicaoValida(pos) && _livre(pos) && QtMovimento == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Position.Linha - 1, Position.Coluna - 1);

                if (Tab.PosicaoValida(pos) && _existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Position.Linha - 1, Position.Coluna + 1);

                if (Tab.PosicaoValida(pos) && _existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                //#Jogada especial en passant
                if(Position.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Position.Linha, Position.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && _existeInimigo(esquerda) && Tab.Peca(esquerda) == Partida.VulneravelEmPassant)
                    {
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Position.Linha, Position.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && _existeInimigo(direita) && Tab.Peca(direita) == Partida.VulneravelEmPassant)
                    {
                        mat[direita.Linha - 1, direita.Coluna] = true;
                    }
                }

            }
            else
            {
                pos.DefinirValores(Position.Linha + 1, Position.Coluna);
                if (Tab.PosicaoValida(pos) && _livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Position.Linha + 2, Position.Coluna);
                Posicao p2 = new Posicao(Position.Linha + 1, Position.Coluna);
                if (Tab.PosicaoValida(p2) && _livre(p2) && Tab.PosicaoValida(pos) && _livre(pos) && QtMovimento == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Position.Linha + 1, Position.Coluna - 1);
                if (Tab.PosicaoValida(pos) && _existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Position.Linha + 1, Position.Coluna + 1);
                if (Tab.PosicaoValida(pos) && _existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                //#Jogada especial en passant
                if (Position.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Position.Linha, Position.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && _existeInimigo(esquerda) && Tab.Peca(esquerda) == Partida.VulneravelEmPassant)
                    {
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Position.Linha, Position.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && _existeInimigo(direita) && Tab.Peca(direita) == Partida.VulneravelEmPassant)
                    {
                        mat[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }

            return mat;
        }
    }
}
