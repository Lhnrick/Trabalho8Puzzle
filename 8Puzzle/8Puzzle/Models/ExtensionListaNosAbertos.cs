using System;
using System.Collections.Generic;
using System.Linq;

namespace _8Puzzle.Models
{
    public static class ExtensionListaNosAbertos
    {
        public static No BuscarNoComMenorCusto(this List<No> nosAbertos)
        {
            // .ThenBy(no => no.ValorHamming)
            No noMenorCusto = nosAbertos.OrderBy(no => no.ValorDistanciaManhattan).FirstOrDefault();

            if (noMenorCusto == null)
                throw new Exception("Deu erro ao tentar encontrar o no com menor custo");

            return noMenorCusto;
        }
    }
}
