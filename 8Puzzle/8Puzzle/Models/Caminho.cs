using System.Collections.Generic;

namespace _8Puzzle.Models
{
    public class Caminho
    {        
        public List<No> PegarCaminho(No no)
        {
            List<No> nos = new List<No>();

            No noAux = no;
            while (noAux != null)
            {
                nos.Add(noAux);
                noAux = noAux.Pai;
            }

            return nos;
        }
    }
}
