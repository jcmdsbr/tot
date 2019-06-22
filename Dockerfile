FROM microsoft/dotnet:2.2-sdk-alpine AS build
WORKDIR /tot

COPY *.sln ./
COPY src/ /src/
COPY test/ /test/
RUN dotnet restore /src/Tot.Api/Tot.Api.csproj
COPY . ./

RUN dotnet build -c Release && \
dotnet test --verbosity=normal --results-directory /TestResults/ --logger:trx && \
dotnet publish -c Release -o /app

FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
EXPOSE 80
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Tot.Api.dll"]