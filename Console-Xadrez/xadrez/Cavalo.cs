using tabuleiro;

namespace xadrez
{
    class Cavalo : Peca
    {

        public Cavalo(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "C";
        }

        private bool _podeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Collor != Collor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linha, Tab.Coluna];

            Posicao pos = new Posicao(0, 0);

            pos.DefinirValores(Position.Linha - 1, Position.Coluna - 2);
            if (Tab.PosicaoValida(pos) && _podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Position.Linha - 2, Position.Coluna - 1);
            if (Tab.PosicaoValida(pos) && _podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Position.Linha - 2, Position.Coluna + 1);
            if (Tab.PosicaoValida(pos) && _podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Position.Linha - 1, Position.Coluna + 2);
            if (Tab.PosicaoValida(pos) && _podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Position.Linha + 1, Position.Coluna + 2);
            if (Tab.PosicaoValida(pos) && _podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Position.Linha + 2, Position.Coluna + 1);
            if (Tab.PosicaoValida(pos) && _podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Position.Linha + 2, Position.Coluna - 1);
            if (Tab.PosicaoValida(pos) && _podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Position.Linha + 1, Position.Coluna - 2);
            if (Tab.PosicaoValida(pos) && _podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }
    }
}
