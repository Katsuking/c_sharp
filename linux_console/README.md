### Linux 環境

[vs code C#](https://learn.microsoft.com/ja-jp/dotnet/core/tutorials/with-visual-studio-code?pivots=dotnet-8-0)

### linux_console.csproj

この２行の追加が必要らしい

```xml
  <PropertyGroup>
    <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
    <GenerateTargetFrameworkAttribute>false</GenerateTargetFrameworkAttribute>
  </PropertyGroup>
```
