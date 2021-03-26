using System.Collections.Generic;

namespace _8Puzzle.Models
{
    public class Solver
    {
        /*         
            *** Lista de nós aberto, guarda as possibilidades geradas
            *** Lista de nós fechado, guarda os melhores nós escolhidos pelo algoritmo

            1. Iniciar o nó inicial com o estado inicial

            2. Para nó inicial calcular a distância manhattan e outros...

            3. Adicionar a lista de nós aberto

            4. Enquanto tiver nós na lista de aberto ou for menor que um possível número máximo de nós gerados
            
                4.1 Verificar a lista de aberto

                    4.1.1 Encontrar o com menor custo (obs. ver fila de prioridade)
                
                4.2 Verificar se é o estado objetivo
                    4.2.1 Se for o estado inicial FIM...

                    4.2.2 Se não for continuar

                4.3 Expandir, gerar possibilidades e armazenar como filhos no nó atual

                    4.3.1 Para cada filho gerado que não existe na lista de abertos e fechados
        
                        4.3.1.1 Pega o score do nó atual

                        4.3.1.2 Calcular a distância manhattan e outros...

                        4.3.1.3 Adicionar nó a lista de nós abertos

                4.4 Adicionar nó atual a lista de fechados 
        
                4.5 Remover da lista de aberto o nó atual
                             
         */

        public List<No> NosAbertos { get; set; }
        public List<No> Nosfechados { get; set; }

        public No NoInicial { get; set; }

        public int[][] EstadoObjetivo { get; set; }

        public Solver(No noInicial)
        {
            NoInicial = noInicial;
        }

        public void Solve()
        {
            NosAbertos = new List<No>();
            Nosfechados = new List<No>();

            // Calcular distancias manhattan

            NosAbertos.Add(NoInicial);

            while (NosAbertos.Count > 0)
            {
                No noMenorCusto = NosAbertos.BuscarNoComMenorCusto();

                if (noMenorCusto.EstadoAtual.EhEstadoObjetivo(EstadoObjetivo))
                {
                    break;
                }                

                Nosfechados.Add(noMenorCusto);

                // Gerar possibilidades
                noMenorCusto.Expandir();
            }
        }
    }
}