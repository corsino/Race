# Race

![Postman](https://user-images.githubusercontent.com/6096675/63708230-37a06f00-c80a-11e9-8511-ff546212c338.JPG)

This project has a .Net Core adapted Clean Architecture. See references(https://gist.github.com/ygrenzinger/14812a56b9221c9feca0b3621518635b)

![CleanArch](https://user-images.githubusercontent.com/6096675/63718441-f7002000-c820-11e9-82a8-fcc5edec1b2a.JPG)

Some layers proposed by Clean Architecture like *Adapters* was not applied to avoid complexity in this current project.

Requirements:

- Log file import
- Basic Output: **Pilot Position, Pilot Code, Pilot Name, Completed Laps and Pilot total time.**
- Bonus: **Better lap by pilot, better race lap, average speed by pilot**
- Clean code
- Immutability
- Handle errors;
- Clear Responsibility segregation (Domains, Services, Repositories, etc);

## TechStack

### Projects:

The following compilation target was assigned to this project:
- Libraries - .Net Standard 4.7.1
- Entrypoint\Web API - .Net Core 2.2

### Unit tests:

**xUnits** Used to unit tests in this application

### API documentation

Package usage [SwashBuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) to generate API documentation in OpenAPI / Swagger format. To explore API documentation, browse https://localhost:44323/swagger in runtime mode.

![swagger](https://user-images.githubusercontent.com/6096675/63715634-87873200-c81a-11e9-9614-c0df4c6b314e.JPG)

Configuration Project could be find in `Gyp.Race.InfraStructure.Bootstrap`, files `/ApplicationBuilder/SwaggerApplicationBuilderExtensions.cs` and `/ServiceCollection/SwaggerServiceCollectionExtensions.cs`.

More libraries and document informations in:
https://github.com/domaindrivendev/Swashbuckle.AspNetCore#include-descriptions-from-xml-comments

###Usage


Visual Studio could browse this project or by installing an application in IIS windows or HTTP server in Linux.

An API route is available in URI: api/race

A TXT file input is required, you could find it in the root directory of this project in github **FileImportExample.txt**, see image below:

![Postman-input](https://user-images.githubusercontent.com/6096675/63709665-bc40bc80-c80d-11e9-9338-7194a4ed181c.JPG)

Expected JSON output structure:

```
{
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
}
```

