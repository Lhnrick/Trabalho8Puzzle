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


        public void Gerar(int[,] estadoObjetivo)
        {
            Posicao espacoVazio = EncontrarEspacoVazio(No.EstadoAtual);

            var estados = new List<int[,]>();
            int[,] estadoGerado;
            bool foiGerado;


            int[,] estadoAtual = No.EstadoAtual;

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

            // Remover o estado anterior
            var noPai = No.Pai;
            if (noPai != null)
            {
                var estadoRetorno = RemoverEstadoAnterior(estados, noPai.EstadoAtual);

                if (estadoRetorno != null)
                {
                    bool foiRemovido = estados.Remove(estadoRetorno);

                    Console.WriteLine(foiRemovido);
                }
            }

            var nosFilhos = new List<No>();

            var custoManhattan = new CustoManhattan();
            var valorHamming = new CustoHamming();

            foreach (int[,] estado in estados)
            {
                var no = new No(estado, No);
                no.Pontuacao = 0;
                no.ValorDistanciaManhattan = custoManhattan.DistanciaManhattan(no, estadoObjetivo);
                no.ValorHamming = valorHamming.CompararEstados(estadoAtual, estadoObjetivo);
                no.Profundidade = No.Profundidade + 1;

                nosFilhos.Add(no);
            }

            No.Filhos = nosFilhos;
        }

        private int[,] RemoverEstadoAnterior(List<int[,]> estados, int[,] estadoAnterior)
        {
            foreach (int[,] estado in estados)
            {
                bool EhIgual = CompararEstadosIguais(estado, estadoAnterior);

                if (EhIgual)
                {
                    return estado;
                }
            }

            return null;
        }

        private bool CompararEstadosIguais(int[,] estado, int[,] estado2)
        {
            for (int i = 0; i < estado.GetLength(0); i++)
            {
                for (int j = 0; j < estado.GetLength(1); j++)
                {
                    bool ehIgual = estado[i, j] == estado2[i, j];
                    if (!ehIgual)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool GerarPossibilidadeCima(int[,] estado, Posicao espacoVazio, out int[,] estadoGerado)
        {
            Posicao paraCima = new Posicao(espacoVazio.Linha - 1, espacoVazio.Coluna);
            if (PosicaoValida(paraCima))
            {
                int[,] novoEstado = (int[,])estado.Clone();

                int valorAntesMovimento = novoEstado[paraCima.Linha, paraCima.Coluna];

                novoEstado[paraCima.Linha, paraCima.Coluna] = novoEstado[espacoVazio.Linha, espacoVazio.Coluna];

                novoEstado[espacoVazio.Linha, espacoVazio.Coluna] = valorAntesMovimento;

                estadoGerado = novoEstado;
                return true;
            }

            estadoGerado = estado;
            return false;
        }

        private bool GerarPossibilidadeDireita(int[,] estado, Posicao espacoVazio, out int[,] estadoGerado)
        {
            Posicao paraCima = new Posicao(espacoVazio.Linha, espacoVazio.Coluna + 1);
            if (PosicaoValida(paraCima))
            {
                int[,] novoEstado = (int[,])estado.Clone();

                int valorAntesMovimento = novoEstado[paraCima.Linha, paraCima.Coluna];

                novoEstado[paraCima.Linha, paraCima.Coluna] = novoEstado[espacoVazio.Linha, espacoVazio.Coluna];

                novoEstado[espacoVazio.Linha, espacoVazio.Coluna] = valorAntesMovimento;

                estadoGerado = novoEstado;
                return true;
            }

            estadoGerado = estado;
            return false;
        }

        private bool GerarPossibilidadeBaixo(int[,] estado, Posicao espacoVazio, out int[,] estadoGerado)
        {
            Posicao paraCima = new Posicao(espacoVazio.Linha + 1, espacoVazio.Coluna);
            if (PosicaoValida(paraCima))
            {
                int[,] novoEstado = (int[,])estado.Clone();

                int valorAntesMovimento = novoEstado[paraCima.Linha, paraCima.Coluna];

                novoEstado[paraCima.Linha, paraCima.Coluna] = novoEstado[espacoVazio.Linha, espacoVazio.Coluna];

                novoEstado[espacoVazio.Linha, espacoVazio.Coluna] = valorAntesMovimento;

                estadoGerado = novoEstado;
                return true;
            }

            estadoGerado = estado;
            return false;
        }

        private bool GerarPossibilidadeEsquerda(int[,] estado, Posicao espacoVazio, out int[,] estadoGerado)
        {
            Posicao paraCima = new Posicao(espacoVazio.Linha, espacoVazio.Coluna - 1);
            if (PosicaoValida(paraCima))
            {
                int[,] novoEstado = (int[,])estado.Clone();

                int valorAntesMovimento = novoEstado[paraCima.Linha, paraCima.Coluna];

                novoEstado[paraCima.Linha, paraCima.Coluna] = novoEstado[espacoVazio.Linha, espacoVazio.Coluna];

                novoEstado[espacoVazio.Linha, espacoVazio.Coluna] = valorAntesMovimento;

                estadoGerado = novoEstado;
                return true;
            }

            estadoGerado = estado;
            return false;
        }


        private Posicao EncontrarEspacoVazio(int[,] estado)
        {
            for (int i = 0; i < estado.GetLength(0); i++)
            {
                for (int j = 0; j < estado.GetLength(1); j++)
                {
                    int valorPosicao = estado[i, j];

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
