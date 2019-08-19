# Corrida

Esse projeto contém uma estrutura desenvolvida em .Net Core em clean architecture (https://miro.medium.com/max/700/1*B7LkQDyDqLN3rRSrNYkETA.jpeg) adaptado,
para não gerar uma complexidade desnecessária, algumas camadas não foram aplicadas, como por exemplo UseCases,
e tem por objetivo atender os requisitos:
- Importação de log
- Output de informações: **Posição Chegada, Código Piloto, Nome Piloto, Qtde Voltas Completadas e Tempo Total de Prova.**
- Clean code
- Imutabilidade
- Tratamento de Erros;
- Separação clara de responsabilidades (Domínios, Serviços, Repositórios, etc);

## TechStack

### Projetos:

No desenvolvimento da solução foram utilizados os seguintes targets de compilação:

- Bibliotecas - .Net Standard 4.7.1
- Entrypoint\Web API - .Net Core 2.2

### Documentação de API 

Uso do pacote [SwashBuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) para gerar a documentação da API no formato OpenAPI / Swagger. Para explorar a API, acesse https://localhost:44323/swagger em modo de runtime.

As configurações podem ser encontradas no projeto `Gyp.Corrida.InfraStructure.Bootstrap`, nos arquivos `/ApplicationBuilder/SwaggerApplicationBuilderExtensions.cs` e  `/ServiceCollection/SwaggerServiceCollectionExtensions.cs`.

Maiores informações podem ser encontradas na documentação da biblioteca em 
https://github.com/domaindrivendev/Swashbuckle.AspNetCore#include-descriptions-from-xml-comments