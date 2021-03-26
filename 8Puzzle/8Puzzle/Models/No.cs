using System.Collections.Generic;

namespace _8Puzzle.Models
{
    public class No
    {
        public List<No> Filhos { get; set; }
        public int[,] EstadoAtual { get; set; }
        public int Pontuacao { get; set; }

        public int ValorDistanciaManhattan { get; set; }
        public int ValorHamming { get; set; }

        public No Pai { get; set; }

        public No(int[,] estadoAtual, No pai)
        {
            EstadoAtual = estadoAtual;
            Pai = pai;
        }
    }
}
