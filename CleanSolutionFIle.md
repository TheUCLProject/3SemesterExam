# Make clean solution file

## Creates a new solution file and adds all `csproj` files to the solution file

1. Navigate to UnikOpstart folder in the terminal
2. Paste the following command into the terminal and run it

> dotnet new sln -n UnikOpstart | dotnet sln add Apps\Webapp\Webapp.csproj | dotnet sln add Apps\Webapp.UserContext.Migrations\Webapp.UserContext.Migrations.csproj | dotnet sln add Services\KundeProjekter\API\KundeProjekter.Api.csproj | dotnet sln add Services\KundeProjekter\Database\SqlContext\SqlContext.csproj | dotnet sln add Services\KundeProjekter\Database\SqlMigrations\SqlMigrations.csproj | dotnet sln add Services\KundeProjekter\Features\Kunde\Application\Kunde.Application.csproj | dotnet sln add Services\KundeProjekter\Features\Kunde\Domain\Kunde.Domain.csproj | dotnet sln add Services\KundeProjekter\Features\Kunde\Infrastructure\Kunde.Infrastructure.csproj | dotnet sln add Services\KundeProjekter\Features\Opgave\Application\Opgave.Application.csproj | dotnet sln add Services\KundeProjekter\Features\Opgave\Domain\Opgave.Domain.csproj | dotnet sln add Services\KundeProjekter\Features\Opgave\Domain.Test\Opgaver.Domain.Test.csproj | dotnet sln add Services\KundeProjekter\Features\Opgave\Infrastructure\Opgave.Infrastructure.csproj | dotnet sln add Services\KundeProjekter\Features\Projekt\Application\Projekt.Application.csproj | dotnet sln add Services\KundeProjekter\Features\Projekt\Domain\Projekt.Domain.csproj | dotnet sln add Services\KundeProjekter\Features\Projekt\Domain.Test\Domain.Test.csproj | dotnet sln add Services\KundeProjekter\Features\Projekt\Infrastructure\Projekt.Infrastructure.csproj | dotnet sln add Services\MedarbejderKompetencer\API\MedarbejderKompetencer.Api.csproj | dotnet sln add Services\MedarbejderKompetencer\Database\SqlContext\SqlContext.csproj | dotnet sln add Services\MedarbejderKompetencer\Database\SqlMigrations\SqlMigrations.csproj | dotnet sln add Services\MedarbejderKompetencer\Features\Kompetence\Application\Kompetence.Application.csproj | dotnet sln add Services\MedarbejderKompetencer\Features\Kompetence\Domain\Kompetence.Domain.csproj | dotnet sln add Services\MedarbejderKompetencer\Features\Kompetence\Domain.Test\Kompetence.Domain.Test.csproj | dotnet sln add Services\MedarbejderKompetencer\Features\Kompetence\Infrastructure\Kompetence.Infrastructure.csproj | dotnet sln add Services\MedarbejderKompetencer\Features\KompetenceStored\Application\KompetenceStored.Application.csproj | dotnet sln add Services\MedarbejderKompetencer\Features\KompetenceStored\Domain\KompetenceStored.Domain.csproj | dotnet sln add Services\MedarbejderKompetencer\Features\KompetenceStored\Domain.Test\Kompetence.Domain.Test.csproj | dotnet sln add Services\MedarbejderKompetencer\Features\KompetenceStored\Infrastructure\KompetenceStored.Infrastructure.csproj | dotnet sln add Services\MedarbejderKompetencer\Features\Medarbejder\Application\Medarbejder.Application.csproj | dotnet sln add Services\MedarbejderKompetencer\Features\Medarbejder\Domain\Medarbejder.Domain.csproj | dotnet sln add Services\MedarbejderKompetencer\Features\Medarbejder\Domain.Test\Medarbejder.Domain.Test.csproj | dotnet sln add Services\MedarbejderKompetencer\Features\Medarbejder\Infrastructure\Medarbejder.Infrastructure.csproj | dotnet sln add Services\MedarbejderKompetencer\MedarbejderKompetencer.Crosscut\MedarbejderKompetencer.Crosscut.csproj

## Breakdown of the command above

> dotnet new sln -n UnikOpstart

Creates a new solution file

Webapp

> dotnet sln add Apps\Webapp\Webapp.csproj
>
> dotnet sln add Apps\Webapp.UserContext.Migrations\Webapp.UserContext.Migrations.csproj

KundeProjekt Service

> dotnet sln add Services\KundeProjekter\API\KundeProjekter.Api.csproj
>
> dotnet sln add Services\KundeProjekter\Database\SqlContext\SqlContext.csproj
>
> dotnet sln add Services\KundeProjekter\Database\SqlMigrations\SqlMigrations.csproj
>
> dotnet sln add Services\KundeProjekter\Features\Kunde\Application\Kunde.Application.csproj
>
> dotnet sln add Services\KundeProjekter\Features\Kunde\Domain\Kunde.Domain.csproj
>
> dotnet sln add Services\KundeProjekter\Features\Kunde\Infrastructure\Kunde.Infrastructure.csproj
>
> dotnet sln add Services\KundeProjekter\Features\Opgave\Application\Opgave.Application.csproj
>
> dotnet sln add Services\KundeProjekter\Features\Opgave\Domain\Opgave.Domain.csproj
>
> dotnet sln add Services\KundeProjekter\Features\Opgave\Domain.Test\Opgaver.Domain.Test.csproj
>
> dotnet sln add Services\KundeProjekter\Features\Opgave\Infrastructure\Opgave.Infrastructure.csproj
>
> dotnet sln add Services\KundeProjekter\Features\Projekt\Application\Projekt.Application.csproj
>
> dotnet sln add Services\KundeProjekter\Features\Projekt\Domain\Projekt.Domain.csproj
>
> dotnet sln add Services\KundeProjekter\Features\Projekt\Domain.Test\Domain.Test.csproj
>
> dotnet sln add Services\KundeProjekter\Features\Projekt\Infrastructure\Projekt.Infrastructure.csproj

MedarbejderKompetencer Service

> dotnet sln add Services\MedarbejderKompetencer\API\MedarbejderKompetencer.Api.csproj
>
> dotnet sln add Services\MedarbejderKompetencer\Database\SqlContext\SqlContext.csproj
>
> dotnet sln add Services\MedarbejderKompetencer\Database\SqlMigrations\SqlMigrations.csproj
>
> dotnet sln add Services\MedarbejderKompetencer\Features\Kompetence\Application\Kompetence.Application.csproj
>
> dotnet sln add Services\MedarbejderKompetencer\Features\Kompetence\Domain\Kompetence.Domain.csproj
>
> dotnet sln add Services\MedarbejderKompetencer\Features\Kompetence\Domain.Test\Kompetence.Domain.Test.csproj
>
> dotnet sln add Services\MedarbejderKompetencer\Features\Kompetence\Infrastructure\Kompetence.Infrastructure.csproj
>
> dotnet sln add Services\MedarbejderKompetencer\Features\KompetenceStored\Application\KompetenceStored.Application.csproj
>
> dotnet sln add Services\MedarbejderKompetencer\Features\KompetenceStored\Domain\KompetenceStored.Domain.csproj
>
> dotnet sln add Services\MedarbejderKompetencer\Features\KompetenceStored\Domain.Test\Kompetence.Domain.Test.csproj
>
> dotnet sln add Services\MedarbejderKompetencer\Features\KompetenceStored\Infrastructure\KompetenceStored.Infrastructure.csproj
>
> dotnet sln add Services\MedarbejderKompetencer\Features\Medarbejder\Application\Medarbejder.Application.csproj
>
> dotnet sln add Services\MedarbejderKompetencer\Features\Medarbejder\Domain\Medarbejder.Domain.csproj
>
> dotnet sln add Services\MedarbejderKompetencer\Features\Medarbejder\Domain.Test\Medarbejder.Domain.Test.csproj
>
> dotnet sln add Services\MedarbejderKompetencer\Features\Medarbejder\Infrastructure\Medarbejder.Infrastructure.csproj
>
> dotnet sln add Services\MedarbejderKompetencer\MedarbejderKompetencer.Crosscut\MedarbejderKompetencer.Crosscut.csproj

All of the above commands adds the specific `csproj` file to the solution.

There are 32 `csproj` files total