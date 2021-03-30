using System;

namespace _8Puzzle.Models
{
    public class CustoManhattan
    {
        public int DistanciaManhattan(No noAtual, int[,] estadoObjetivo)
        {
            int totalQuadrados = noAtual.EstadoAtual.GetLength(0) * noAtual.EstadoAtual.GetLength(1);
            int[] arrNoAtual = new int[totalQuadrados];            
            int contAux = 0;

            for (int i = 0; i < noAtual.EstadoAtual.GetLength(0); i++)
            {
                for (int j = 0; j < noAtual.EstadoAtual.GetLength(1); j++)
                {
                    arrNoAtual[contAux] = noAtual.EstadoAtual[i,j];
                    contAux++;
                }
            }

            int distance = 0;
            for (int i = 0; i < noAtual.EstadoAtual.GetLength(0); i++)
            {
                for (int j = 0; j < noAtual.EstadoAtual.GetLength(1); j++)
                {
                    int valorAtual = noAtual.EstadoAtual[i,j];
                    if (valorAtual != 0)
                    {
                        var posicao = EncontrarValor(estadoObjetivo, valorAtual);
                        distance += Math.Abs(i - posicao.Linha) + Math.Abs(j - posicao.Coluna);                        
                    }
                }
            }

            return distance;
        }

        private Posicao EncontrarValor(int[,] estado, int valor)
        {
            for (int i = 0; i < estado.GetLength(0); i++)
            {
                for (int j = 0; j < estado.GetLength(1); j++)
                {
                    if (estado[i,j] == valor)
                    {
                        return new Posicao(i, j);
                    }
                }
            }
            return null;
        }
    }
}
