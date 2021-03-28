using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8Puzzle.Models
{
    public class VerificaParidade
    {
        public bool ehResolvivel(int[] estado)
        {
            int paridade = 0;
            int larguraGrid = (int)Math.Sqrt(estado.Length);
            int linha = 0; // a linha atual em que estamos
            int linhaBranco = 0; // a linha com o ladrilho em branco

            for (int i = 0; i < estado.GetLength(0); i++)
            {
                if (i % larguraGrid == 0)
                { // avançar para a próxima linha
                    linha++;
                }
                if (estado[i] == 0)
                { // o ladrilho em branco
                    linhaBranco = linha; // salve a linha na qual encontrou
                    continue;
                }
                for (int j = i + 1; j < estado.Length; j++)
                {
                    if (estado[i] > estado[j] && estado[j] != 0)
                    {
                        paridade++;
                    }
                }
            }

            if (larguraGrid % 2 == 0)
            { 
                if (linhaBranco % 2 == 0)
                {// em branco na linha ímpar
                    return paridade % 2 == 0;
                }
                else
                { // em branco na linha par
                    return paridade % 2 != 0;
                }
            }
            else
            {
                return paridade % 2 == 0;
            }
        }
    }
}
