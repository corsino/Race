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

![Postman-input](https://user-images.githubusercontent.com/6096675/63709665-bc40bc80-c80d-11e9-9338-7194a4ed181c.JPG)



A saída esperada é um JSON na seguinte estrutura:

```{
    "success": true,
    "data": {
        "principalMetrics": [
            {
                "position": 1,
                "pilotNumber": "038",
                "pilotName": "F.MASSA",
                "quantityCompletedLap": 4,
                "pilotTotalTime": "00:04:11.5780000",
                "bestLap": "Melhor volta do piloto: 3, Tempo: 00:01:02.7690000",
                "averageSpeed": 44.24575
            },
            {
                "position": 3,
                "pilotNumber": "033",
                "pilotName": "R.BARRICHELLO",
                "quantityCompletedLap": 4,
                "pilotTotalTime": "00:04:16.0800000",
                "bestLap": "Melhor volta do piloto: 3, Tempo: 00:01:03.7160000",
                "averageSpeed": 43.468
            },
            {
                "position": 2,
                "pilotNumber": "002",
                "pilotName": "K.RAIKKONEN",
                "quantityCompletedLap": 4,
                "pilotTotalTime": "00:04:15.1530000",
                "bestLap": "Melhor volta do piloto: 4, Tempo: 00:01:03.0760000",
                "averageSpeed": 43.62725
            },
            {
                "position": 4,
                "pilotNumber": "023",
                "pilotName": "M.WEBBER",
                "quantityCompletedLap": 4,
                "pilotTotalTime": "00:04:17.7220000",
                "bestLap": "Melhor volta do piloto: 4, Tempo: 00:01:04.2160000",
                "averageSpeed": 43.19125
            },
            {
                "position": 5,
                "pilotNumber": "015",
                "pilotName": "F.ALONSO",
                "quantityCompletedLap": 4,
                "pilotTotalTime": "00:04:54.2210000",
                "bestLap": "Melhor volta do piloto: 2, Tempo: 00:01:07.0110000",
                "averageSpeed": 38.06625
            },
            {
                "position": 6,
                "pilotNumber": "011",
                "pilotName": "S.VETTEL",
                "quantityCompletedLap": 3,
                "pilotTotalTime": "00:06:27.2760000",
                "bestLap": "Melhor volta do piloto: 3, Tempo: 00:01:18.0970000",
                "averageSpeed": 25.745666666666666666666666667
            }
        ],
        "adicionalMetrics": {
            "bestRaceLap": "Melhor volta da corrida: 3, Tempo: 00:01:02.7690000, Piloto: F.MASSA"
        }
    },
    "messages": []
}```

