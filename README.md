# Corrida

![Postman](https://user-images.githubusercontent.com/6096675/63708230-37a06f00-c80a-11e9-8511-ff546212c338.JPG)

Esse projeto contém uma estrutura desenvolvida em .Net Core em clean architecture (https://miro.medium.com/max/700/1*B7LkQDyDqLN3rRSrNYkETA.jpeg) adaptad.
Para não gerar uma complexidade desnecessária, algumas camadas não foram aplicadas, como por exemplo UseCases,
e tem por objetivo atender os requisitos:
- Importação de log
- Output de informações: **Posição Chegada, Código Piloto, Nome Piloto, Qtde Voltas Completadas e Tempo Total de Prova.**
- Bônus: **Melhor volta de cada piloto, melhor volta da corrida, velocidade média de cada piloto**
- Clean code
- Imutabilidade
- Tratamento de Erros;
- Separação clara de responsabilidades (Domínios, Serviços, Repositórios, etc);

## TechStack

### Projetos:

No desenvolvimento da solução foram utilizados os seguintes targets de compilação:

- Bibliotecas - .Net Standard 4.7.1
- Entrypoint\Web API - .Net Core 2.2

### Testes:

Para testes utilizei xUnits

### Documentação de API 

Uso do pacote [SwashBuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) para gerar a documentação da API no formato OpenAPI / Swagger. Para explorar a API, acesse https://localhost:44323/swagger em modo de runtime.

As configurações podem ser encontradas no projeto `Gyp.Corrida.InfraStructure.Bootstrap`, nos arquivos `/ApplicationBuilder/SwaggerApplicationBuilderExtensions.cs` e  `/ServiceCollection/SwaggerServiceCollectionExtensions.cs`.

Maiores informações podem ser encontradas na documentação da biblioteca em 
https://github.com/domaindrivendev/Swashbuckle.AspNetCore#include-descriptions-from-xml-comments

###Uso

O Projeto pode ser executado pelo próprio Visual Studio, ou então, instalado no IIS para execução.

Uma API será disponibilizada na URI: api/race
A entrada é um arquivo no formato texto, conforme exibido na imagem abaixo:




A saída esperada é um JSON na seguinte estrutura:


