# Test miljø for CatalogService

## Start miljøet op

```bash
$ docker compose up -d
```

## Test af image controllers endepunkter

Fra en terminal kør følgende kommandoer for at teste logikken i ImageController'en.

### Upload image

Testen bruger billede som ligger i subfolderen **Images4Test**.

```bash
$ curl --location 'http://localhost:5001/Image/upload' --form '=@"./Images4Test/Crispy-Buffalo-Chicken-WIngs-IMAGE-9.jpg"'
```

### List Images

```bash
 $ curl -X 'GET' 'http://localhost:5001/Image/listImages' -H 'accept: */*'
```

### Hent Billede fra static files

Hent en billedefil ned fra din applikation ved at anvende URL'en: **http://localhost:5001/images/<navn-på-filen.jpg>**:

```bash
$ curl --location 'http://localhost:5001/images/image-a552a40a-85d1-42f2-a22d-38fea275b73e.jpg' \
    --output minfil.jpg
```
