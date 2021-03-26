using System;

namespace _8Puzzle.Models
{
    public class CustoManhattan
    {
        private int DistanciaManhattan(No noAtual, No noObjetivo)
        {
            int totalQuadrados = noAtual.EstadoAtual.GetLength(0) * noAtual.EstadoAtual.GetLength(1);
            int[] noAtualarr = new int[totalQuadrados];
            int contAux = 0;
            for (int i = 0; i < noAtual.EstadoAtual.GetLength(0); i++)
                for (int j = 0; j < noAtual.EstadoAtual.GetLength(1); j++)
                {
                    noAtualarr[contAux] = noAtual.EstadoAtual[i][j];
                    contAux++;
                }

            int distance = 0;
            for (int i = 0; i < totalQuadrados; i++)
            {
                for (int j = 0; j < totalQuadrados; j++)
                {
                    int valorAtual = noAtual.EstadoAtual[i][j];
                    if (valorAtual != 0)
                    {
                        var posicao = EncontrarValor(noObjetivo.EstadoAtual, valorAtual);
                        distance += Math.Abs(i - posicao.Linha) + Math.Abs(j - posicao.Coluna);
                    }
                }
            }
            return distance;
        }

        private Posicao EncontrarValor(int[][] estado, int valor)
        {
            for (int i = 0; i < estado.GetLength(0); i++)
            {
                for (int j = 0; j < estado.GetLength(1); j++)
                {
                    if (estado[i][j] == valor)
                    {
                        return new Posicao(i, j);
                    }
                }
            }
            return null;
        }

    }
}
