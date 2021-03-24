using System.Collections.Generic;
using System.Linq;

namespace AStar8Puzzle
{
    class EightPuzzleSolver
    {
        /*
             Sejam

                **Q** = conjunto de nós a serem pesquisados
                
                **S** = o estado inicial da busca
                
                Faça:
                
                - Inicialize Q com o nó de busca (S) como única entrada;
                - Se Q está vazio, interrompa. Se não, escolha o melhor elemento de Q;
                - Se o estado (n) é um objetivo, retorne n;
                - (De outro modo) Remova n de Q;
                - Encontre os descendentes do estado (n) que não estão em visitados e crie todas as extensões de n para cada descendente;
                - Adicione os caminhos estendidos a Q e vá ao passo 2;
                - caminhos expandidos;
                - Uma estimativa que sempre subestima o comprimento real do caminho ate o objetivo é chamada de admissível. O uso de uma estimativa admissível garante que a busca de custo-uniforme ainda encontrará o menor caminho;
                
                [Wikipedia](https://en.wikipedia.org/wiki/A*_search_algorithm#Pseudocode)         
         */

        public int[][] EstadoAtual { get; private set; }
        public int[][] EstadoObjetivo { get; private set; }

        private List<int[][]> Estados;

        // Classe estado
        public EightPuzzleSolver(int[][] estadoInicial, int[][] estadoObjetivo)
        {
            EstadoAtual = estadoInicial;
            EstadoObjetivo = estadoObjetivo;
        }

        public void Resolver()
        {
            AlgoritmoResolvedor(EstadoAtual, EstadoAtual /* VERIFICAR */);
        }

        private void AlgoritmoResolvedor(int[][] estado, int[][] estadoAnterior)
        {
            List<int[][]> estadosGerados = GerarEstadosPossiveis(estado);            

            // Remover o estado anterior

            // Erro, não consegui-o gerar nenhum novo estado
            if (estadosGerados.Count <= 0)
            {
                return;
            }

            //TODO: ESCOLHER A MELHOR POSSIBILIDADE - IMPLEMENTAR
            int[][] melhorEstadoGerado = estadosGerados.First();

            if (EhEstadoObjetivo(estado))
            {
                // Encontrou o estado objetivo
                return;
            }

            AlgoritmoResolvedor(melhorEstadoGerado, estado);
        }

        private List<int[][]> GerarEstadosPossiveis(int[][] estado)
        {
            Posicao espacoVazio = EncontrarEspacoVazio(estado);

            List<int[][]> estados = null;

            int[][] estadoGerado = null;
            bool foiGerado;

            // Pra cima
            foiGerado = GerarPossibilidadeCima(estado, espacoVazio, out estadoGerado);
            if (foiGerado)
                estados.Add(estadoGerado);

            // Pra baixo
            foiGerado = GerarPossibilidadeBaixo(estado, espacoVazio, out estadoGerado);
            if (foiGerado)
                estados.Add(estadoGerado);

            // Pra esquerda
            foiGerado = GerarPossibilidadeEsquerda(estado, espacoVazio, out estadoGerado);
            if (foiGerado)
                estados.Add(estadoGerado);

            // Pra direita
            foiGerado = GerarPossibilidadeDireita(estado, espacoVazio, out estadoGerado);
            if (foiGerado)
                estados.Add(estadoGerado);

            return estados;
        }

        private bool PosicaoValida(Posicao posicao)
        {
            bool colunaValida = posicao.Coluna >= 0 && posicao.Coluna < EstadoObjetivo.GetLength(0);
            bool linhaValida = posicao.Linha >= 0 && posicao.Linha < EstadoObjetivo.GetLength(1);

            return colunaValida && linhaValida;
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


        private bool EhEstadoObjetivo(int[][] estado)
        {

            for (int i = 0; i < EstadoObjetivo.GetLength(0); i++)
            {
                for (int j = 0; j < EstadoObjetivo.GetLength(1); j++)
                {
                    // Não é o estado objetivo
                    if (estado[i][j] != EstadoObjetivo[i][j])
                    {
                        return false;
                    }
                }
            }

            // É o estado objetivo
            return true;
        }
    }
}
