Set-Location "XamlMultiLanguageEditor.Winform"
dotnet build
& ".\bin\Debug\net8.0-windows\XamlMultiLanguageEditor.Winform.exe" --load "../../../../KitX Clients/KitX Dashboard/KitX Dashboard/Languages"
