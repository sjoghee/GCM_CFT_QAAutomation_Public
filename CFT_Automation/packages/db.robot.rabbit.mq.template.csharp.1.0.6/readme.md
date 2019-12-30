# dotnet core template for robot with RabbitMQ

## What is in the template

Template:

- targeting dotnet core 2.2 framework
- has referenced "RabbitMQ.Client" package Version="5.1.0
- has predefined xunit test project
- has 2 staged dockerfile, for build and run
- has `Microsoft.Extensions.Configuration.EnvironmentVariables` lib, which makes configuration from env vars easy.

## How to push the template to nuget repo

`dotnet pack db.robot.rabbit.mq.template.csharp.csproj -p:NoBuild=true -p:NoDefaultExcludes=true -o publish`

`dotnet nuget push publish/db.robot.rabbit.mq.template.csharp.1.*.*.nupkg -s https://api.nuget.org/v3/index.json -k <APIKEY>`

Note, dont forget to update `db.robot.rabbit.mq.template.csharp.nuspec` file with new version and release notes and keep correct version, while pushing to repo

## How to use template

- run `dotnet new -i db.robot.rabbit.mq.template.csharp::1.0.x` command to install template locally
- execute `dotnet new robot-rabbitmq -n <your service name>` - it will create construct in your repo folder

template update seems to have a bug within dotnet. before updating run `dotnet new -i db.robot.rabbit.mq.Template.CSharp::1.0.x --debug:reinit`