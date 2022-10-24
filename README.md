# Timely
Kako bi aplikacija radila ispravno potrebno je izvršiti reinstalaciju NuGet paketa koristeći alata Package Manager Console koji se unutar Visual Studio IDE-a nalazi na tabu Tools -> NuGet Package Manager -> Package Manager Console, unutar njega potrebno je pokrenuti naredbu "Update-Package -reinstall" kako bi se izvršila reinstalacija.

NuGet paketi koji su potrebni i koji će se instalirati prilikom reinstalacije su: Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.SqlServer i Microsoft.EntityFrameworkCore.Tools.

Nakon toga potrebno je prilagoditi ConnectionStrings koji se nalazi u datoteci "appsettings.json" odnosno potrebno mu je izmijeniti server tako da mu postavite instancu Sql servera koji vi koristite kako bi se uspješno povezao na njega. Nakon toga potrebno je samo unutar Package Manager Console alata pokrenuti naredbu "update-database" kako bi se generirala baza podataka prema već napravljenim migracijama.
