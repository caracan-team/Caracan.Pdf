# Caracan.Pdf
[![Build Status](https://dev.azure.com/CaracanTeam/CaracanPdf/_apis/build/status/caracan-team.Caracan.Pdf?branchName=master)](https://dev.azure.com/CaracanTeam/CaracanPdf/_build/latest?definitionId=1&branchName=master)

Caracan.Pdf is a .NET Core library for generating beautiful PDF documents from Html.

## Installation

Use the nuget manager to install library.

```bash
Install-Package Caracan.Pdf
```

## Usage

In Startup.cs
```csharp 
services.AddPdfGenerator(Configuration);
```
In appsettings.json
```json 
"PdfGeneratorOptions":{
  "Connection":"127.0.0.1:9222"
}
```
In your service, use dependency injection

```csharp 
public YourService(IPdfGenerator pdfGenerator){

}
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
