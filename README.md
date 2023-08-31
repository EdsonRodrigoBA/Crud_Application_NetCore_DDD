# Crud - Gerenciamento de Produtos
<h4>Projeto Desenvolvido pra fins de Avaliação </h4>
<h5>Objetivo do Projeto:</h5>
<p>Desenvolver uma aplicação Net Core 6.xxx implementando funcionanlidades conforme o DDD Domain Driven Design (DDD). </p>
<h4>Recursos Ultilizados;</h4>
<p>Net Core 6</p>
<p>Api Rest Full</p>
<p>Entity Framework Core</p>
<p>Boas Práticas na Construção de Apis</p>
<p>Testes Unitários com X-Unit</p>
<p>Conceitos do DDD Domain Driven Design (DDD)</p>
<p>Banco de Dados: MySQL e SQLite</p>
<p>Fluent Validator</p>
<p>Swagger Open Api</p>

<h4>Intruções:</h4>
<h5>Execução do Projeto</h5>
<p>1° Altere a Conection String do Mysql com base na sua instancia do Mysql, no arquivo appseting.json </p>

<h5>Pra Criar a Migration MySql:</h5>
<p>add-migration InicialMigration -Context ProdutosMysqlDbContext</p>
<p>Pra criar o script da Migration:</p>
<p>script-migration -Contex -Output ./scriptSQL/scriptInicial.sql</p>
<p>Aplicando Migration de Forma Padrão</p>
<p>update-database -Context ProdutosMysqlDbContext</p>
<p>Gerando Bundle Pra aplicar as Migration:</p>
<p>bundle-migration  -Context ProdutosMysqlDbContext</p>
<p>bundle-migration -Context ProdutosMysqlDbContext</p>

<h5>Pra Criar a Migration SqlLite:</h5>
add-migration InicialMigration -Context ProdutosSqlLiteDbContext</p>
Pra criar o script da Migration:</p>
script-migration -Contex -Output ./scriptSQL/scriptInicialSqlLite.sql</p>
Aplicando Migration de Forma Padrão</p>
update-database -Context ProdutosSqlLiteDbContext</p>
Gerando Bundle Pra aplicar as Migration:</p>
bundle-migration  -Context ProdutosSqlLiteDbContext</p>
bundle-migration -Context ProdutosSqlLiteDbContext</p>

<h4>
  Execução do projeto:
</h4>
<p>O projeto pode ser executado no Visual estudio ou VsCode</p>

