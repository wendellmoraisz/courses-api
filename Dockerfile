FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CoursesAPI.csproj", "./"]
RUN dotnet restore "./CoursesAPI.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "./CoursesAPI.csproj" -c ${BUILD_CONFIGURATION} -o /app/build

FROM build as publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CoursesAPI.csproj" -c ${BUILD_CONFIGURATION} -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "CoursesAPI.dll"]