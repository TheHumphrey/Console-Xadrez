using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
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
                pos.DefinirValores(Position.Coluna - 1, Position.Coluna - 1);

                if (Tab.PosicaoValida(pos) && _existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Position.Linha - 1, Position.Coluna + 1);

                if (Tab.PosicaoValida(pos) && _existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
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
                
            }

            return mat;
        }
    }
}
