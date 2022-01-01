FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HW13/HW13.csproj", "HW13/"]
RUN dotnet restore "HW13/HW13.csproj"
COPY . .
WORKDIR "/src/HW13"
RUN dotnet build "HW13.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HW13.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HW13.dll"]
