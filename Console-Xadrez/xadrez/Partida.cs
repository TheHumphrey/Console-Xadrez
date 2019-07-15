using System;
using tabuleiro;

namespace xadrez
{
    class Partida
    {
        public Tabuleiro Tab { get; private set; }
        public int turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }

        public Partida()
        {
            Tab = new Tabuleiro(8, 8);
            turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            ColocarPecas();
        }
        private void ColocarPecas()
        {
            Tab.ColocarPeca(new Rei(Cor.Preto, Tab), new PosicaoXadrez('c', 1).ToPosicao());
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQtdMovimento();
            Peca PecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
        }

    }
}
