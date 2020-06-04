#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/mssql-server-linux
ENV RUN_USER 500
ENV RUN_GROUP 0
ENV ACCEPT_EULA Y
ENV SA_PASSWORD 123456
RUN mkdir /var/opt/mssql &&
chown -R ${RUN_USER}:${RUN_GROUP} /var/opt/mssql &&
chmod -R 770 /var/opt/mssql
ADD scripts /scripts # This adds the new entrypoint, listed below
RUN dpkg -i /scripts/libnss-wrapper_1.1.2-1_amd64.deb
USER ${RUN_USER}:${RUN_GROUP}
ENTRYPOINT ["/scripts/entrypoint"]

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["com.redhat.netcore.webapp/com.redhat.netcore.webapp.csproj", "com.redhat.netcore.webapp/"]
RUN dotnet restore "com.redhat.netcore.webapp/com.redhat.netcore.webapp.csproj"
COPY . .
WORKDIR "/src/com.redhat.netcore.webapp"
RUN dotnet build "com.redhat.netcore.webapp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "com.redhat.netcore.webapp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "com.redhat.netcore.webapp.dll"]
