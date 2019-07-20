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
                Partida partida = new Partida();

                while (!partida.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(partida);
                        Console.WriteLine();

                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaodeOrigem(origem);

                        bool[,] posicoespossiveis = partida.Tab.Peca(origem).MovimentosPosssiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab, posicoespossiveis);

                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDeDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);
                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
