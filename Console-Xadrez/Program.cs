using System;
using tabuleiro;
using xadrez;

namespace Console_Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.ColocarPeca(new Rei(Cor.Preto, tab), new Posicao(0, 1));
                tab.ColocarPeca(new Torre(Cor.Preto, tab), new Posicao(0, 2));
                tab.ColocarPeca(new Rei(Cor.Branca, tab), new Posicao(0, 3));

                Tela.ImprimirTabuleiro(tab);
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
