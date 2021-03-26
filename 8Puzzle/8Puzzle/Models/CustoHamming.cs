using System;

namespace _8Puzzle.Models
{
    public class CustoHamming
    {
        public int CompararEstados(int[][] estado, int[][] estadoObjetivo)
        {
            int localerrado = 0;
            for (int i = 0; i < estado.GetLength(0); i++)
            {
                for (int j = 0; j < estado.GetLength(1); j++)
                {

                    if (estado[i][j] != estadoObjetivo[i][j])
                        localerrado++;
                }
            }
            return localerrado;
        }
    }
}