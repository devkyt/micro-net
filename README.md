
## Annotation

## Table of Contents

## Set and Run

## Commands
### Packages
Update package:
```sh
dotnet tool update dotnet-ef -g 
```

### Migrations
Create migration:
```sh
dotnet ef migrations add "InitiaclCreate" -o Data/Migartions
```

Apply migration:
```sh
```

### Identity Server
```sh
dotnet new install Duende.IdentityServer.Templates
dotnet new isaspid -o src/IdentityService
dotnet sln add src/IdentityService
```

## Configuration
### App Settings
```json
{
  "Serilog": {
    "MinimumLevel": {
      "Default": "Debug",
      "Override": {
        "Microsoft": "Warning",
        "Microsoft.Hosting.Lifetime": "Information",
        "Microsoft.AspNetCore.Authentication": "Debug",
        "System": "Warning"
      }
    }
  },

  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost:5432;User Id=postgres;Password=resetplease;Database=identity;"
  }
}
```

### Launch Settings
```json
{
  "profiles": {
    "SelfHost": {
      "commandName": "Project",
      "launchBrowser": false,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      },
      "applicationUrl": "http://localhost:5000 "
    }
  }
}
```




## Resources
1. [Mass Transit](https://masstransit.io/documentation/concepts)
2. [Identity Server](https://docs.duendesoftware.com/identityserver/v7/overview/)