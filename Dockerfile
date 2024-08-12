FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app
EXPOSE 8080

# copy .csproj and restore as distinct layers
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS build
WORKDIR /src
COPY "TestRecipient/TestRecipient.csproj" "TestRecipient/TestRecipient.csproj"
RUN dotnet restore "TestRecipient/TestRecipient.csproj"

# copy everything else and build
COPY . .
WORKDIR "/app/TestRecipient"
RUN dotnet build "TestRecipient/TestRecipient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestRecipient/TestRecipient.csproj" -c Release -o /app/publish

# build a runtime image
WORKDIR /app
COPY --from=build-env /app/publish .
ENTRYPOINT [ "dotnet", "TestRecipient.dll" ]
