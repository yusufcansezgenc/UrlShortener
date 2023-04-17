## URL Shortening Service
A URL Shortening Service that uses collections.

### Capabilities
* Hash shortening based on Xxh64(https://learn.microsoft.com/en-us/dotnet/api/system.io.hashing.xxhash64?view=dotnet-plat-ext-7.0)
* Setting a custom path for the given url.
* Redirecting based on given path.

### Running
You can use IIS or Docker based debugging within Visual Studio or run the app straight with Docker under UrlShortener.WebApi folder using command (Must have Docker installed):
```
docker-compose up
```
After setting the container up you can check the Swagger at: http://localhost:5065/swagger
