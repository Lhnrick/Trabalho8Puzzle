namespace _8Puzzle.Models
{
    public static class ExtensionNo
    {
        public static void Expandir(this No no, int[,] estadoObjetivo)
        {
            // Gerar as possibilidades
            new Expandir(no).Gerar(estadoObjetivo);
        }
    }
}
