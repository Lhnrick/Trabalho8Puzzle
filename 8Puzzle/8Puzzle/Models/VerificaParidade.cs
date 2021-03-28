using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8Puzzle.Models
{
    public class VerificaParidade
    {

        // A utility function to count
        // inversions in given array 'arr[]'
       public static int GetInvCount(int[,] estado)
        {
            int inv_count = 0;
            for (int i = 0; i < 3 - 1; i++)
                for (int j = i + 1; j < 3; j++)

                    // Value 0 is used for empty space
                    if (estado[j, i] > 0 && estado[j, i] > estado[i, j])
                        inv_count++;
            return inv_count;
        }

        // This function returns true
        // if given 8 puzzle is solvable.
       public static bool IsSolvable(int[,] matriz)
        {
            // Count inversions in given 8 puzzle
            int invCount = GetInvCount(matriz);

            // return true if inversion count is even.
            return (invCount % 2 == 0);
        }
    }

    }