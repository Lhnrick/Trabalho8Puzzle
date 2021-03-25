# **A`*` e 8 Puzzle**

### **Pseudocódigo**

1. Iniciar com um estado atual e um estado objetivo
1. Mover o espaços em branco em todas as direções
1. Calcular o F score para cada estado gerado (expandir o estado atual)
1. Depois de expandir o estado, o estado atual deve ser colocado na lista fechada
1. Os estados recém-gerados são colocados na lista aberta
1. O estado com o menor F score é selecionado e é expandido novamente

- **Este processo se repete até que o estado atual seja igual ao objetivo**
- **Nunca gerar um estado que é igual ao anterior**

#

Sejam

**Q** = conjunto de nós a serem pesquisados

**S** = o estado inicial da busca

Faça:

- Inicialize Q com o nó de busca (S) como única entrada;
- Se Q está vazio, interrompa. Se não, escolha o melhor elemento de Q;
- Se o estado (n) é um objetivo, retorne n;
- (De outro modo) Remova n de Q;
- Encontre os descendentes do estado (n) que não estão em visitados e crie todas as extensões d
e n para cada descendente;
- Adicione os caminhos estendidos a Q e vá ao passo 2;
- caminhos expandidos;
- Uma estimativa que sempre subestima o comprimento real do caminho ate o objetivo é chamada de admissível. O uso de uma estimativa admissível garante que a busca de custo-uniforme ainda encontrará o menor caminho;

[Wikipedia](https://en.wikipedia.org/wiki/A*_search_algorithm#Pseudocode)

#

1. Obtenha o primeiro estado, que é o seu estado inicial.
1. Obtenha todos os estados possíveis em que o quebra-cabeça pode estar.
1. Adicione esses novos estados na lista de estados abertos
1. Adicionar estado processado na lista fechada
1. Escolha o próximo estado que tem o menor custo na lista aberta
1. Comece a repetir as etapas de 1 a 6, a menos que você esteja no estado final ou não haja mais estados para examinar (neste caso, não existe solução).
Assim que tiver o estado final, volte ao nó inicial e esse seria o caminho ideal para encontrar a solução.

**Distância manhattan**

https://www.geeksforgeeks.org/sum-manhattan-distances-pairs-points/

**Verificação qual estado é melhor**

Comparar com o estado objetivo e contar quantos números estão fora do lugar ainda

#
**Verificar se é possível resolver | Parity check |**

https://www.geeksforgeeks.org/check-instance-8-puzzle-solvable/

https://math.stackexchange.com/questions/293527/how-to-check-if-a-8-puzzle-is-solvable
https://stackoverflow.com/questions/36108269/does-8-puzzle-solvability-rules-work-for-any-goal-state

https://github.com/risingsudhir/8-Puzzle-A-Star-Algorithm/blob/master/README.md