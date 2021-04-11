@ECHO OFF

dotnet publish src/Communie.Server/Communie.Server.csproj -c Release -r linux-x64 --self-contained false -o ./deployment

DEL deployment\Communie.Server.pdb

SCP -r .\deployment\* root@spelos.net:/var/www/communie
