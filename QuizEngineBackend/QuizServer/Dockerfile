FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 44348

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY QuizServer.csproj QuizServer/
RUN dotnet restore QuizServer/QuizServer.csproj
COPY . .
WORKDIR /src
RUN dotnet build QuizServer.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish QuizServer.csproj -c Release -o /app


FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "QuizServer.dll"]