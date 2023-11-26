# Usa a imagem oficial do SDK do .NET como base
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copia os arquivos do projeto para o contêiner
COPY . .

# Publica a aplicação
RUN dotnet publish -c Release -o out

# Usa a imagem mínima do ASP.NET Core para reduzir o tamanho final
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

# Copia os arquivos publicados da etapa de compilação
COPY --from=build /app/out .

# Define o comando de entrada para iniciar a aplicação
ENTRYPOINT ["dotnet", "EstagioJaAPI.dll"]

