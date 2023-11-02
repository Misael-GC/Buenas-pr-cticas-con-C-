## Código base para completar el curso de buenas prácticas y código limpio en C#
Debe descargar el codigo y usar el branch master o 0-codigobase


# Instalar dotnet en Ubuntu

Crea una carpeta para C#
```jsx
mkdir Curso-C#
```

Primero debemos saber que 

versión de Ubuntu tienes 

```jsx
lsb_release -a
```

Yo tengo el siguiente resultado

```jsx
No LSB modules are available.
Distributor ID: Ubuntu
Description:    Ubuntu 20.04.6 LTS
Release:        20.04
Codename:       focal
```

Tengo la versión 20.04 de Ubuntu.

Entonces voy a la siguiente documentación y seguir estos pasos:

https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu-2004

Si tienes otra versión más actualizada busca cuál te puede ayudar en está página

https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu?WT.mc_id=servsept20-devto-cxaall

### ****Add the Microsoft package repository****

```bash
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

### ****Install the SDK****

```bash
sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-7.0
```

### ****Install the runtime****

```bash
sudo apt-get update && \
  sudo apt-get install -y aspnetcore-runtime-7.0
```

```bash
sudo apt-get install -y dotnet-runtime-7.0
```

```bash
sudo apt install zlib1g
```

Ahora cuando descargue el repositorio a mi entorno local y ponia el comando

`dotnet build` y `dotnet run` me salía un errores como que yo tenía la versión 17.7 y el framework era del 3.1, como a continuación

```sql
you mustinstallorupdate .NETto run this application.

App: /home/mgc22/Cursos-C#/Curso-Buenas-Prácticas-2/curso-codigo-limpio-csharp/bin/Debug/netcoreapp3.1/ToDo
Architecture: x64
Framework: 'Microsoft.NETCore.App',version '3.1.0' (x64)
.NET location: /usr/share/dotnet

Thefollowing frameworks werefound:
  7.0.13at [/usr/share/dotnet/shared/Microsoft.NETCore.App]

Learn about framework resolution:
https://aka.ms/dotnet/app-launch-failedToinstallmissing framework, download:
https://aka.ms/dotnet-core-applaunch?framework=Microsoft.NETCore.App&framework_version=3.1.0&arch=x64&rid=ubuntu.20.04-x64

```

o este problema

```
dotnet build
MSBuild version 17.7.3+4fca21998for .NET
MSBUILD : error MSB1003: Specifya projector solution file. The current working directory doesnot containa projector solution file.

```

Para eso, lo pude solucionar haciendo lo siguiente:

- Borrar las carpetas bin-, obj- y en el archivo ToDo.csproj mdifique está linea de código `<TargetFramework>netcoreapp7.0</TargetFramework>`En fin el código completo quedo así

```xml
<ProjectSdk="Microsoft.NET.Sdk"><PropertyGroup><OutputType>Exe</OutputType><TargetFramework>netcoreapp7.0</TargetFramework></PropertyGroup></Project>
```

Espero te sea de ayuda si es que sí, regalame un like y sígueme 😃

https://twitter.com/MisaelG51069440


💡 olvide mencionar la tercera parte es volver a correr los comandos `dotnet build` y `dotnet run` y ya ejecutaras como en la clase, 😃


https://stackoverflow.com/questions/73131168/you-must-install-or-update-net-to-run-this-application