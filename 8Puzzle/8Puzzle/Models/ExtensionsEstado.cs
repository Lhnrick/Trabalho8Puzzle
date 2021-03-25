namespace _8Puzzle.Models
{
    public static class ExtensionsEstado
    {
        public static bool EhEstadoObjetivo(this int[][] estado, int[][] estadoObjetivo)
        {
            for (int i = 0; i < estado.GetLength(0); i++)
            {
                for (int j = 0; j < estado.GetLength(1); j++)
                {
                    bool ehDiferente = estado[i][j] != estadoObjetivo[i][j];
                    if (ehDiferente)
                        break;
                }
            }

            return true;
        }
    }
}
