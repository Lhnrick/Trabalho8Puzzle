using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8Puzzle.Models
{
    public class Expandir
    {

        public No No { get; set; }

        public Expandir(No no)
        {
            No = no;
        }


        public void Gerar()
        {
            Posicao espacoVazio = EncontrarEspacoVazio(No.EstadoAtual);

            List<int[][]> estados = null;

            int[][] estadoGerado;
            bool foiGerado;


            int[][] estadoAtual = No.EstadoAtual;

            // Pra cima
            foiGerado = GerarPossibilidadeCima(estadoAtual, espacoVazio, out estadoGerado);
            if (foiGerado)
                estados.Add(estadoGerado);

            // Pra baixo
            foiGerado = GerarPossibilidadeBaixo(estadoAtual, espacoVazio, out estadoGerado);
            if (foiGerado)
                estados.Add(estadoGerado);

            // Pra esquerda
            foiGerado = GerarPossibilidadeEsquerda(estadoAtual, espacoVazio, out estadoGerado);
            if (foiGerado)
                estados.Add(estadoGerado);

            // Pra direita
            foiGerado = GerarPossibilidadeDireita(estadoAtual, espacoVazio, out estadoGerado);
            if (foiGerado)
                estados.Add(estadoGerado);

            var nosFilhos = new List<No>();

            foreach (int[][] estado in estados)
                nosFilhos.Add(new No(estado, No));

            No.Filhos = nosFilhos;
        }

        private bool GerarPossibilidadeCima(int[][] estado, Posicao espacoVazio, out int[][] estadoGerado)
        {
            Posicao paraCima = new Posicao(espacoVazio.Linha - 1, espacoVazio.Coluna);
            if (PosicaoValida(paraCima))
            {
                int[][] novoEstado = (int[][])estado.Clone();

                int valorAntesMovimento = novoEstado[paraCima.Linha][paraCima.Coluna];

                novoEstado[paraCima.Linha][paraCima.Coluna] = novoEstado[espacoVazio.Linha][espacoVazio.Coluna];

                novoEstado[espacoVazio.Linha][espacoVazio.Coluna] = valorAntesMovimento;

                estadoGerado = novoEstado;
                return true;
            }

            estadoGerado = estado;
            return false;
        }

        private bool GerarPossibilidadeDireita(int[][] estado, Posicao espacoVazio, out int[][] estadoGerado)
        {
            Posicao paraCima = new Posicao(espacoVazio.Linha, espacoVazio.Coluna + 1);
            if (PosicaoValida(paraCima))
            {
                int[][] novoEstado = (int[][])estado.Clone();

                int valorAntesMovimento = novoEstado[paraCima.Linha][paraCima.Coluna];

                novoEstado[paraCima.Linha][paraCima.Coluna] = novoEstado[espacoVazio.Linha][espacoVazio.Coluna];

                novoEstado[espacoVazio.Linha][espacoVazio.Coluna] = valorAntesMovimento;

                estadoGerado = novoEstado;
                return true;
            }

            estadoGerado = estado;
            return false;
        }

        private bool GerarPossibilidadeBaixo(int[][] estado, Posicao espacoVazio, out int[][] estadoGerado)
        {
            Posicao paraCima = new Posicao(espacoVazio.Linha + 1, espacoVazio.Coluna);
            if (PosicaoValida(paraCima))
            {
                int[][] novoEstado = (int[][])estado.Clone();

                int valorAntesMovimento = novoEstado[paraCima.Linha][paraCima.Coluna];

                novoEstado[paraCima.Linha][paraCima.Coluna] = novoEstado[espacoVazio.Linha][espacoVazio.Coluna];

                novoEstado[espacoVazio.Linha][espacoVazio.Coluna] = valorAntesMovimento;

                estadoGerado = novoEstado;
                return true;
            }

            estadoGerado = estado;
            return false;
        }

        private bool GerarPossibilidadeEsquerda(int[][] estado, Posicao espacoVazio, out int[][] estadoGerado)
        {
            Posicao paraCima = new Posicao(espacoVazio.Linha, espacoVazio.Coluna - 1);
            if (PosicaoValida(paraCima))
            {
                int[][] novoEstado = (int[][])estado.Clone();

                int valorAntesMovimento = novoEstado[paraCima.Linha][paraCima.Coluna];

                novoEstado[paraCima.Linha][paraCima.Coluna] = novoEstado[espacoVazio.Linha][espacoVazio.Coluna];

                novoEstado[espacoVazio.Linha][espacoVazio.Coluna] = valorAntesMovimento;

                estadoGerado = novoEstado;
                return true;
            }

            estadoGerado = estado;
            return false;
        }


        private Posicao EncontrarEspacoVazio(int[][] estado)
        {
            for (int i = 0; i < estado.GetLength(0); i++)
            {
                for (int j = 0; j < estado.GetLength(1); j++)
                {
                    int valorPosicao = estado[i][j];

                    if (valorPosicao == 0)
                    {
                        return new Posicao(i, j);
                    }
                }
            }

            return null;
        }


        private bool PosicaoValida(Posicao posicao)
        {
            bool colunaValida = posicao.Coluna >= 0 && posicao.Coluna < No.EstadoAtual.GetLength(0);
            bool linhaValida = posicao.Linha >= 0 && posicao.Linha < No.EstadoAtual.GetLength(1);

            return colunaValida && linhaValida;
        }

    }
}
