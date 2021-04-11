@ECHO OFF

dotnet publish src/Communie.Server/Communie.Server.csproj -c Release -r linux-x64 --self-contained false -o ./deployment

DEL deployment\Communie.Server.pdb

SCP -r .\deployment\* user@yourserver:/var/www/communie
