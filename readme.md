# Caracan.Pdf
[![Build Status](https://dev.azure.com/CaracanTeam/CaracanPdf/_apis/build/status/caracan-team.Caracan.Pdf?branchName=master)](https://dev.azure.com/CaracanTeam/CaracanPdf/_build/latest?definitionId=1&branchName=master)

Caracan.Pdf is a .NET Core library for generating beautiful PDF documents from Html.

## Installation

Use the nuget manager to install libraries.

```bash
Install-Package Caracan.Pdf -version 1.0.0
Install-Package Caracan.Templates -version 1.0.0
Install-Package Caracan.Charts -version 1.0.0
```

## Usage

In Startup.cs
```csharp 
services.AddCaracan();
```
or alternatively with providing configuration section

```csharp 
services.AddCaracan("your configuration section");
```

In appsettings.json
```json 
"caracan":{
  "connection":"127.0.0.1:9222"
}
```
In your service, use dependency injection

```csharp 
public YourService(ICaracanPdfGenerator caracan){

}
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
