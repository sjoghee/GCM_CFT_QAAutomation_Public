FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS buildimage
# copying csproj file and running restore, to get separate layer of the image, for faster changes
# this layer will be recreated only when new references are modified
COPY src/*.csproj /build/
WORKDIR /build
RUN dotnet restore

COPY src/. /build/
RUN dotnet publish -c release

FROM mcr.microsoft.com/dotnet/core/runtime:2.2
COPY --from=buildimage /build/bin/release/netcoreapp2.2/publish/ /app/
WORKDIR /app
ENTRYPOINT [ "dotnet", "robot.dll" ]