namespace _8Puzzle.Models
{
    public class VerificaParidade
    {
        public bool IsSolvable(int[,] estadoInicial, int[,] estadoFinal)
        {

            if (estadoFinal.GetLength(0) == 3)
                return IsSolvable3x3(estadoInicial, estadoFinal);

            if (estadoFinal.GetLength(0) == 4)
                return IsSolvable4x4(estadoInicial) && IsSolvable4x4(estadoFinal);

            return false;
        }


        private int PegarInversoes3x3(int[,] estado)
        {
            int inv_count = 0;
            for (int i = 0; i < 3 - 1; i++)
            {
                for (int j = i + 1; j < 3; j++)
                {
                    if (estado[j, i] > 0 && estado[j, i] > estado[i, j])
                        inv_count++;
                }
            }

            return inv_count;
        }

        private bool IsSolvable3x3(int[,] estadoInicial, int[,] estadoFinal)
        {
            int contEstadoInicial = PegarInversoes3x3(estadoInicial);
            int contEstadoFinal = PegarInversoes3x3(estadoFinal);

            int restoDivEstadoInicial = contEstadoInicial % 2;
            int restoDivEstadoFinal = contEstadoFinal % 2;

            return (restoDivEstadoInicial == 0 && restoDivEstadoFinal == 0) || (restoDivEstadoInicial == 1 && restoDivEstadoFinal == 1);
        }

        private bool IsSolvable4x4(int[,] estadoRecebido)
        {
            int[] estado = ConverterMatrizParaArray(estadoRecebido);

            int tipoPuzzle = estadoRecebido.GetLength(0);

            int contParidade = 0;

            int linha = 0;
            int linhaEspacoVazio = 0;

            for (int i = 0; i < estado.Length; i++)
            {
                if (i % tipoPuzzle == 0)
                {
                    linha++;
                }

                if (estado[i] == 0)
                {
                    linhaEspacoVazio = linha;
                    continue;
                }

                // Percorre da posição atual para frente 
                for (int j = i + 1; j < estado.Length; j++)
                {
                    // Verifica se é a posição atual é maior
                    if (estado[i] > estado[j] && estado[j] != 0)
                        contParidade++;
                }
            }

            /*
                https://www.geeksforgeeks.org/check-instance-8-puzzle-solvable/
                 
                Se N for ímpar, a instância do quebra-cabeça poderá ser resolvida se o número de inversões for par no estado de entrada.

                Se N for par, a instância do quebra-cabeça pode ser resolvida 
                    se o espaço em branco está em uma linha par, contando a partir da parte inferior (penúltimo, quarto penúltimo etc.) 
                    e o número de inversões é ímpar.
                    o espaço em branco está em uma linha ímpar contando a partir da parte inferior (último, penúltimo, quinto penúltimo, etc.) e o número de inversões é par.
                Para todos os outros casos, a instância do puzzle não tem solução.             
            */

            if (linhaEspacoVazio % 2 == 0)
                return contParidade % 2 == 0;
            else
                return contParidade % 2 != 0;
        }

        private int[] ConverterMatrizParaArray(int[,] estado)
        {
            int totalQuadrados = estado.GetLength(0) * estado.GetLength(1);

            int[] novoArr = new int[totalQuadrados];
            int contAux = 0;

            for (int i = 0; i < estado.GetLength(0); i++)
            {
                for (int j = 0; j < estado.GetLength(1); j++)
                {
                    novoArr[contAux] = estado[i, j];
                    contAux++;
                }
            }

            return novoArr;
        }
    }
}