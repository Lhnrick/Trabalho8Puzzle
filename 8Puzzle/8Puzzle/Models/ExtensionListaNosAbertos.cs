using System.Collections.Generic;
using System.Linq;

namespace _8Puzzle.Models
{
    public static class ExtensionListaNosAbertos
    {
        public static No BuscarNoComMenorCusto(this List<No> nosAbertos)
        {
            No noMenorCusto = nosAbertos.First();

            foreach (var no in nosAbertos)
            {

            }

            return noMenorCusto;
        }
    }
}
