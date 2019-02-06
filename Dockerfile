FROM microsoft/dotnet:2.2-sdk

COPY dotnetapp/. /app/dotnetapp/
COPY utils/. /app/utils/

WORKDIR /app/dotnetapp
RUN dotnet publish -c Release -o out

WORKDIR /app/dotnetapp/out
ENTRYPOINT ["dotnet"]
CMD ["dotnetapp.dll"]
