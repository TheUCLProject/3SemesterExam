# ***Project Title***

- [General Information](#general-information)
  - [Important links](#important-links)
- [Group Rules \& Norms](#group-rules--norms)
  - [General Rules](#general-rules)
  - [Group Expectations](#group-expectations)
  - [Group \& Project Management](#group--project-management)
  - [GitHub](#github)
- [Applied Technologies \& Code](#applied-technologies--code)
- [Project \& Software Requirements](#project--software-requirements)
  - [Part 1](#part-1)
    - [PROG Assignment Requirements](#prog-assignment-requirements)
    - [TEK Assignment Requirements](#tek-assignment-requirements)
  - [Part 2](#part-2)
    - [SUM Assignment Requirements](#sum-assignment-requirements)
    - [SUM Report Requirements](#sum-report-requirements)

## [General Information](#project-title)

## [Group Rules & Norms](#project-title)

### [General Rules](#project-title)

1. Everything with the exception of the report, SQL and the GUI is to be written/made in english. </br> *(That means all code, comments, commits, pull requests, descriptions etc etc is to be written/made in english).*

</br>

### [Group Expectations](#project-title)

1. It is expected that all group members set this project as their first priority from week 45 to week 1. </br> *(With the obvious exception of work, health problems and such).*

2. All group members should be ready to both give and receive critic. </br> ***Remember!*** critic is a natural part of the working process, it is not a personal attack and should not be perceived as such. However, critic should be useful.
   - **Bad critic:** *"This is pure shit. Delete it and make something better...".*
   - **Useful critic:** *"This does not work so well because A, B, C. However, one could do D, E or F to improve it".*

3. It is expected that all group members are honest and realistic in their skill level with the group. </br> ***Remember!*** we are all students in the same boat! No one is expecting anyone to be an expert and we are all here to learn. </br> *(none of that "fake it till you make it"-mindset in this group)*

4. It is expected that people voice their questions if they have any. It is better to ask one question to many than one to few. We cannot help if we do not know you need it.

5. It is expected that each group member take responsibility to keep track of the sources and references that they use.

</br>

### [Group & Project Management](#project-title)

1. The Scrum agile work process will be used for the project.

2. The duration of a sprint is only final once all 4 group members has agreed upon the duration and all deem it to be a reasonable and realistic time estimation for everyone to be able to complete their assigned tasks.

3. Once a sprint has begun nothing new can be added to it. If anything needs to be added it can first be added in the next sprint iteration.

4. Daily standup meetings is required to be posted before 13:00 every week day by all 4 group members. The following questions has to be answered in the post:
   - What did I do yesterday?
   - What am I going to do today?
   - Did I have any problems that caused me problems yesterday or do I face any problems for the task at hand today?

5. When there is a work from home day all group members must be present on discord at 13:00

6. Every friday from 13:00 - 15:00 a meeting will be held by all group members where the following will be discussed:
   - Do we need / require a meeting with the teachers for one or more reasons?
   - Do we need to make adjustments in regards to our approach or something group-related?
   - Estimation of where we are: behind schedule, on schedule or in front of schedule?

7. No one is required or expected to work on the projects during the weekend, but everyone is of course allowed to do so on their own volition. </br>
*(The weekend of week 49 group members should however not make any plans in case we need to use it as a last resort in case the group deem it impossible to honor the deadline (16th of December) unless we work through that weekend)*

8. All communication goes through the groups discord server "Studiegruppen2" and all information stays within the respective channels that has been designated for them as agreed upon.

9. All group members is allowed to contribute to all parts of the project and should be encouraged to do so by everyone in case they want to. In other words, if someone wants to contribute to the database, GUI, report, coding etc they have the right to do so, to the extend that it does not interfere with others work. No one has patent/ownership of certain part of the project. We are all in this together.

10. External deadline for the project is 15th of December 22:00. Internal deadline is 12th of December.

</br>

### [GitHub](#project-title)

All GitHub commits needs to have telling titles.

- **Acceptable:** "Applied colors to buttons" or "Fixed bugs in the SQL table creations".
- **Unacceptable:** "Bugfix" or "GUI updated" which are ambiguous titles and could be A LOT of things.

</br>

---

## [Applied Technologies & Code](#project-title)

</br>

The following technologies will be used in the the project:

| Category                  | Applied Technology                                      |
| ------------------------- | ------------------------------------------------------- |
| Languages                 | C# + SQL + HTML + CSS                                   |
| Frameworks & Tools        | ASP.NET + .NET 6 + Bootstrap + Entity Framework         |
| GUI                       | HTML + CSS + Bootstrap                                  |
| Test Tools                | xUnit + Swagger                                         |
| Database (RDBMS)          | (MS SQL Server / SQLite)                                |
| Database Management       | SQL Server Management Studio (SSMS) / DB Browser SQLite |
| Project Management System | Azure DevOps                                            |

</br>

1. Comments should be made throughout the program.

2. No one is allowed to use code they themselves do not fully understand. If you cannot explain it to the other group members on a "line by line"-level the code is not acceptable.

3. If any code is used from external sources like StackOverflow or books for example, there ***must*** be a reference/link to the source as a comment inside the code so that all group members can read about it directly from the source itself.

4. Variables, methods, properties, fields, classes etc ***must*** have a clear and precise naming convention so that they are not ambiguous, but it is obvious what they do / store. The only exception are things like for example `int i` inside for-loops for the increment variable and things of that sort where it is painfully obvious.
   - **Unacceptable** naming convention: `LName`, `LastN` | `M_ID` | `Sec` | `S_Resident`
   - **Acceptable** naming convention: `LastName` | `MemberID` | `Secretary` | `SeniorResident`

5. `PascalCase` naming convention is used for ***all*** methods, classes and structs regardless of their access level

6. `camelCase` naming convention is used for any variable, field, property of ***public*** access level

7. `_camelCase` (with an underscore) naming convention is used for any variable, field, property of ***private*** access level

8. Are any kind of nuget packages or other external libraries/frameworks/packages/dll used which are not a part of the standard System namespace that everyone *should* be familiar with at this point ***everyone*** in the group should be made aware of it, so that the group know they *are* being used and more importantly ***why***.

</br>

---

## [Project & Software Requirements](#project-title)

</br>

The page number indicate where the requirements can be found in the issued project assignment.

The progress estimation is just a rough estimation on how far from completion the requirement in question is from being completed.

The status is so that all group members know where a in the process a specific requirement is. It will be marked with the following icons.

| Completed | Inactive | active |
| :-------: | :------: | :----: |
|     ✅     |    🔴     |   🔨    |

</br>

### [Part 1](#project-title)

#### [PROG Assignment Requirements](#project-title)

| \#  | Requirements                                                                                                                                                                                                                                                                                                                                                                                 | Progress estimate in % | Status   |     |
| --- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | :--------------------: | -------- | --- |
| 1   | **Forretningslogikken skal struktureres efter en af følgende: Clean-, Onion- eller Hexagon- Architecture**                                                                                                                                                                                                                                                                                   |           0            | Inactive | 🔴   |
| 2   | **Der skal realiseres en ASP.NET Core Web App (frontend) med mindst en bagvedliggende API service (backend).**                                                                                                                                                                                                                                                                               |           0            | Inactive | 🔴   |
| 3   | **Frontend skal være afkoblet fra backend vha. således at alle kald fra frontend til backend foregår via REST**                                                                                                                                                                                                                                                                              |           0            | Inactive | 🔴   |
| 4   | **Backend: <ul><li>Forretningslogikken skal placeres i den (de) bagvedliggende API services (microservices)</li><li>Forretningslogikken skal opdeles ud fra et feature perspektiv (bounded context).</li><li> Databaser skal realiseres i en eller flere SQL databaser. </li><li>Forretningslogikken skal være:</li><ul><li>Realiseret efter SOLID principperne.</li><li>Testbar</li></ul>** |           0            | Inactive | 🔴   |
| 5   | **API’er testes/dokumenteres via swagger eller postman.**                                                                                                                                                                                                                                                                                                                                    |           0            | Inactive | 🔴   |
| 6   | **Backend API'erne skal kunne afvikles via docker.**                                                                                                                                                                                                                                                                                                                                         |           0            | Inactive | 🔴   |
| 7   | **Frontend <ul><li> Frontend skal realiseres vha. ASP.NET Core Web App (Razor Pages).</li><li>Brugere og deres roller (authentication og authorization) håndteres primært i frontend.</li></ul>**                                                                                                                                                                                            |           0            | Inactive | 🔴   |

</br>

#### [TEK Assignment Requirements](#project-title)

| \#  | Requirements                                                                                                                                                                                          | Progress estimate in % | Status   |     |
| --- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | :--------------------: | -------- | --- |
| 1   | **Serverdelen/servicedelen skal implementeres som et eller flere API’er, der deployes i Docker (dockerfile) i containere, på localhost. Den relevant Docker opsætning dokumenteres. Docker Desktop?** |           0            | Inactive | 🔴   |
| 2   | **Beskriv hvordan hostning i en driftsituation ville være fornuftig.**                                                                                                                                |           0            | Inactive | 🔴   |
| 3   | **Backend (API’er) dokumenteres ved controllernes C# kode.**                                                                                                                                          |           0            | Inactive | 🔴   |
| 4   | **For den valgte netværkskommunikation, beskrives valget af netværksprotokoller og dataudvekslingsformater.**                                                                                         |           0            | Inactive | 🔴   |
| 5   | **For den valgte client/server løsning beskrives fordelingen af funktionalitet (tyk/tynd server). Er der tale om microservices, og hvordan kan man se det?**                                          |           0            | Inactive | 🔴   |
| 6   | **Vis andre måder at tilgå (genbruge) API’erne på. WebClient?**                                                                                                                                       |           0            | Inactive | 🔴   |

</br>

---

### [Part 2](#project-title)

#### [SUM Assignment Requirements](#project-title)

| \#  | Requirements                                                                                                                                                                                                                                                                                                                      | Progress estimate in % | Status   |     |
| --- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | :--------------------: | -------- | --- |
| 1   | **Der skal udarbejdes dokumentation for projektet, således at projektets artefakter indgår. Dokumentationen skal kunne forstås af en IT-kyndig person og kunne anvendes til faglig vurdering af projektets proces og produkt. Generelt forventes der i jeres besvarelse brug af alle fagets elementer der hvor det er relevant.** |           0            | Inactive | 🔴   |
| 2   | **Der skal udarbejdes en specifikation og et design og laves eksempler på test af det kommende system. Der skal indgå horisontale og vertikale prototyper.**                                                                                                                                                                      |           0            | Inactive | 🔴   |
| 3   | **Det er væsentligt at gruppen dokumenterer konkret i rapporten, hvordan procesmodel og projektstyring er valgt og gennemført i projektforløbet.**                                                                                                                                                                                |           0            | Inactive | 🔴   |

</br>

#### [SUM Report Requirements](#project-title)

| \#  | Requirements                                                                                                                                                                                                                                                                                                                                                                                                                                  | Progress estimate in % | Status   |     |
| --- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | :--------------------: | -------- | --- |
| 1   | **Resultat af kravanalysen beskrives i en relevant og egnet form. Det er her også relevant at beskrive det overordnede design af løsningen.**                                                                                                                                                                                                                                                                                                 |           0            | Inactive | 🔴   |
| 2   | **En projektplan inkl. estimering. Projektet skal inkludere og dokumentere synlig projektplanlægning og –styring, herunder inddragelse af afleverede artefakter, møder og reviews m.v.**                                                                                                                                                                                                                                                      |           0            | Inactive | 🔴   |
| 3   | **Refleksioner over valget af procesmodel**                                                                                                                                                                                                                                                                                                                                                                                                   |           0            | Inactive | 🔴   |
| 4   | **En hvilken som helst systemudviklingmetode kan vælges til projektet, men valget skal begrundes og uddybes metodisk. Beskriv også hvilke værktøjer I vælger at understøtte processen med. Eksempelvis kan benyttes Live Share til par-programmering eller partest.**                                                                                                                                                                         |           0            | Inactive | 🔴   |
| 5   | **Kvalitetskrav og testdokumentation. Beskriv f.eks. hvordan I håndterer test og kvalitetssikring, sporbarhed og Usability test. Til test af brugergrænsefladen skal gennemføres mindst et eksempel på exploratory test med anvendelse af Test and Feedback værktøj. Beskriv også andre tiltag I måtte have valgt i forhold til produktets kvalitet. Eksempelvis kan der beregnes og vurderes metrikker der kan støtte udviklingsprocessen.** |           0            | Inactive | 🔴   |
| 6   | **Der skal være synlig, løbende projektstyring, herunder dokumentation for anvendelse af collaborative værktøjer, f.eks. Azure DevOps Board eller lignende projektstyringsværktøj.**                                                                                                                                                                                                                                                          |           0            | Inactive | 🔴   |
| 7   | **I skal i rapporten kort præsentere jeres løsning/prototype f.eks. vha. et antal skærmbilleder samt forklarende tekst.**                                                                                                                                                                                                                                                                                                                     |           0            | Inactive | 🔴   |
| 8   | **En konklusion på forløbet omkring anvendte metoder, teknikker og værktøjer sammen med eventuelle overvejelser eller anbefalinger om det fortsatte forløb under deployment, således at der opnås størst mulig sikkerhed for et succesrigt projekt for kunden.**                                                                                                                                                                              |           0            | Inactive | 🔴   |
