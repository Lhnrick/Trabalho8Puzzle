namespace _8Puzzle.Models
{
    public class ValidaCampos
    {
        public bool ExistemRepeticoes(int[,] estado, out int repeticoes)
        {            
            repeticoes = 0; //Contador para valores repetidos.

            for (int i = 0; i < estado.GetLength(0); i++)
            {
                for (int j = 0; j < estado.GetLength(1); j++)
                {
                    //Nesse ponto, valorVerificado vai assumir os valores da sua matriz, um de cada vez.
                    //Depois, vai acontecer um loop novamente na matriz pra ver se tem algum valor igual ao valorVerificado
                    int valorVerificado = estado[i, j];
                    for (int k = 0; k < estado.GetLength(0); k++)
                    {
                        for (int l = 0; l < estado.GetLength(1); l++)
                        {
                            if (i == k && j == l)
                                continue;

                            if (valorVerificado == estado[k, l])
                            {
                                repeticoes++;
                                //return true;
                            }
                        }
                    }
                }
            }

            if (repeticoes > 0)
                return true;

            return false;
        }
    }
}



