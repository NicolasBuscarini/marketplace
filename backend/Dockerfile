FROM mcr.microsoft.com/dotnet/sdk:6.0.202-bullseye-slim-arm64v8 AS base

WORKDIR /usr/share/app
COPY . .

#CMD ["/bin/sh", "-ec", "while :; do echo '.'; sleep 6 ; done"]

RUN dotnet tool install --global dotnet-ef
RUN dotnet ef database update

RUN dotnet build


WORKDIR /usr/share/app/bin/Debug/net6.0

EXPOSE 5000

ENTRYPOINT ["dotnet", "MarketPlace.dll"]