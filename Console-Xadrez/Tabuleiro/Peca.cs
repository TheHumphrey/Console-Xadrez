using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Position { get; set; }
        public Cor Collor { get; set; }
        public int QtMovimento { get; set; }
        public Tabuleiro Tab { get; set; }

        public Peca(Cor collor, Tabuleiro tab)
        {
            Position = null;
            Collor = collor;
            QtMovimento = 0;
            Tab = tab;
        }
        public void IncrementarQtdMovimento()
        {
            QtMovimento++;
        }

        public void DecrementarQtdMovimento()
        {
            QtMovimento--;
        }

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for(int i = 0; i < Tab.Linha; i++)
            {
                for (int j = 0; j < Tab.Coluna; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool MovimentoPossivel(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}

