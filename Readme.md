# HaaV Catalog microservice

Denne microsoft er et løsningsforslag til den gennemgående **CatalogService** som er tilknyttet undervisningen i IT-Arkitektur og Infrastruktur.

På nuværende tidspunkt indeholder den løsninger fra følgende moduler:

- Modul 3:
  - Oprettelse af webapi projekt
  - anvendelse af Swagger og OpenAPI
  - Lidt Logging
  
- Modul 6:
  - Oprettelse af Solution med API projekt og Unit Test projekt
  - Tilføjelse af gitignore fil
  - Tilføjelse af Dockerfile
  - Brug af docker volumes til **Upload** og **list** af billeder
  - Logik til at hente de uploadede billeder
  - Docker compose miljø til test af CatalogController og ImageController
  - **BEMÆRK 1:** De 2 services fra opgave M6.03 er samlet i ImageController'en på CatalogService
  - **BEMÆRK 2:** Kig i folderen **Environments/TestImageController** [for mere information](Environments/TestImageController/Readme.md)
  
- Modul 8:
  - Tilføjet Semantisk versionering og metadata og **versions**-endepunkt (Op.M8.02)
  - Anvendelse af Git Flow -> projektet har 2 hoved-branches: **main** og **develop**

- Modul 9:
  - Github build-pipelines for:
    - Bygge et .NET-projekt og køre unit-tests --> **.github/workflows/dotnet.yml**
    - Bygge et Docker image og push'e det til DockerHub --> **.github/workflows/docker-image.yml**
  - NLOG.config fil som både skriver til consol'et, en fil og til en Loki-server
