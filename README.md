# LISTA DE COMPRAS

**Wendrya Andrade Oliveira**

### Aplicação

Esta aplicação foi desenvolvida em .NetFramework 4.6.1 utilizando AspNet.Mvc e EntityFramework.

### Funcionalidades

- CRUD de produtos 
- Listagem dos produtos
- Adição de produtos no carrinho de compras
- Exibição do carrinho de compras com os valores totais calculados
- Finalização da compra

### Instruções de execução

Para executar o projeto é necessário realizar os seguintes passos:
- Clonar o repositório
- Instalar os Pacotes do NuGet
- Alterar connectionString para sua conexão local. Este projeto utiliza Migrations, então é necessário colocar o nome do banco vazio, e após executar as Migrations ele será criado.
- Executar o comando "Update-Database" no console NuGet para aplicar as Migrations
