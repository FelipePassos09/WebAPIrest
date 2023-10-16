# Otimização e Performance de Consulta
Para melhoria de performance em consultas sempre utilizar um ou mais dos m�todos descritos abaixo.

## Consultas à entidade sem aplicação de rastreamento
O recurso do Entity Framework Core realiza o armazenamento das entidades no contexto da aplica��o (em cache) o que adiciona uma sobrecarga de trabalho para a aplicação.Para evitarmos isso podemos utilizar o recurso AsNoTracking() que implementa a remo��o do rastreamento da entidade. O recurso AsNoTracking deve ser evitado em casos onde a entidade sofrer algum tipo de altera��o pois, caso ocorra n�o ocorreram as altera��es previstas dado não haver o status de modificação do objeto.

## Controle do retorno
Evitar retornar todo o resultado de uma consulta, neste caso implementando filtros junto � consulta realizada ao banco como, por exemplo, o uso de Where, limitar a quantidade retornada com Take.O uso de filtros na consulta ir� adicionar uma camada a mais de performance visxto haver menos tr�fego de dados, seja ele entre banco e aplica��o ou aplica��o cliente.