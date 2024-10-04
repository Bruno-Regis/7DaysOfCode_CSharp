/* 
   Primeiro dia do Seven Days of Code consistiu no desafio de consumir uma API do pokemon e printar na tela os nomes dos pokemons
   disponíveis. para fazer a requisição utilizei RestSharp, e para desserealizar utilizei o JsonSerializer nativo.
   para entender melhor o Json, utilizei também o postman, vi que o json era um pouco mais complexo contendo propriedades como:
   count, next, previous e uma lista de pokemons contendo seus respectivos nomes e urls
   Primeiro desafio completo!!!!

   =======Segundo dia======
   O segundo dia do Seven Days of Code, fui desafiado a printar na tela as informações dos pokemons na tela após a escolha do usuário
   Contudo, eu fui além, consumi a APi para mostrar os pokemons disponíveis, após isso, dei a alternativa do usuário escolher o pokemon
   e novamente foi feita uma requisição com restsharp em cima da escolha do jogador, após isso, foi feito uma desserealização de todas
   as informações relevantes dado o pokemon escolhido..
   O maior desafio foi obter informações das habilidaes, visto que se encontram em níveis mais profundos do JSON
   Desafio do segundo dia completo!!

   =======Terceiro dia======
   O Terceiro dia até agora foi o mais desafiador e ao mesmo tempo o mais empolgante, o desafio em si era básico, consistiu em desenvolver
   uma classe de visualização que intereagisse com o usuário de tal forma que o desse a opção de visualizar os pokemons da api, escolher um
   e dar a opção de ver as suas características além de adicioná-lo a pokedex.
   Fui muito além, comecei a implementar um padrão MVC no meu sistema, além disso, criei uma classe Service que contém uma Task usando generics
   para que não haja tanta repetição de código ao consumir mais de uma vez a API, com isso, acredito que posso implementar uma forma de
   acessar toodos os pokemons disponíveis na API caso eu queira, que são mais de 1000. O menu está bacana, interativo
   Desafio do terceiro dia completo!!

   =======Quarto dia======
   O desafio do quarto dia foi de fato trabalhar na arquitetura do projeto implementando o padrão MVC, neste dia eu dei sequência e refatorei
   um pouco do código, passando responsabilidades de view para o view que estavam no controller, e colocando mais algumas funcionalidades visuais.
   Com isso dei uma enxugada no código do controller, ficou mais clean.
   Desafio do quarto dia completo!!
   
   =======Quinto dia======
   O desafio do quinto dia foi implementar interações com os pokemons do usuário incluindo métodos que modificassem os atributos do pokemon. Implementei
   uma lista de objetos do tipo pokemon na pokedex e os métodos.
   Desafio do quinto dia completo!!

   =======Sexto dia======
   O sexto dia, o desafio foi mapear duas classes distintas com atributos em comum utilizando autoMapper. Fui muito além, e na verdade o quinto dia se
   tornaram alguns dias, decidi refatorar o código inteiro, testar outras bibliotecas como newtonsoft, alterar o service sem utilizar generics, e o controller
   foi reabilitado para interagir de acordo com as novas alterações.. o View ficou mais interativo também. o projeto tá show, muito aprendizado até aqui!
   
   =======Sexto dia======
   O sétimo e último dia foi o dia de pensar e trabalhar nas possíveis exceptions que poderiam ocorrer, apliquei exceptions no service, controlando caso
   haja erro ao consumir a API, e também trabalhei com a interação com o usuário, desenvolvendo um método no view que obtem a escolha do jogador, faz um tryparse
   para verificar se a escolha do jogador ao decorrer do menu é valores inteiros e também se eles se encontram dentro do range de possibilidades!!
   Fim de projeto animal, me sinto muito melhor programador do que a uma semana atrás, bora para mais!!
*/
using _7DaysOfCode_CSharp.Controller;
using _7DaysOfCode_CSharp.Services;
using _7DaysOfCode_CSharp.View;

PokemonController App = new PokemonController();
App.Jogar();

