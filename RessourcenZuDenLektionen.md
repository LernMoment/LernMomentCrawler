# Ressourcen zu den einzelnen Lektionen im Kurs
Hier findest du alle wichtigen Links und zusätzliche Informationen zum Online-Kurs *"Asynchrone & Parallele Programmierung mit C# in .NET (Core)"*. Sofern eine Lektion hier nicht aufgeführt ist, gibt es zu dieser auch keine zusätzlichen Ressourcen.

**Wichtig:** Auch wenn ich bereits einiges an guten Materialien gefunden habe und hier verlinke bzw. bereitstelle, wird es noch viele tolle Artikel, Übungen, ... geben die ich noch nicht gefunden habe. Wenn du etwas kennst was in diese Material-/Linksammlung aufgenommen werden sollte, würde ich mich sehr über einen Hinweis von dir freuen. Gerne kannst du direkt den Link an der passenden Stelle einfügen und mir die Änderung über einen PullRequest zur Verfügung stellen. Bist du dir nicht sicher, dann erstelle einfach ein Issue mit dem Link und ich werde es dann selber an der passenden Stelle einfügen.

## Kapitel 1 - Intro & Einrichtung
### Lektion 1.2 - Vorstellung des GitHub-Projektes
*ToDo: Links zu den wichtigsten Bereichen des Projektes einfügen!*

## Kapitel 2 - Async/await: Warten auf I/O-Operationen ohne zu blockieren
### Lektion 2.2 - Blockierende Aufrufe mit async/await vermeiden
### Lektion 2.3 - Was passiert bei einem await-Aufruf (in einer WPF-Anwendung)?
### Lektion 2.4 - Eine erste eigene Async-Methode erstellen
### Lektion 2.5 - Musterlösung zur Übung - Async zieht sich durch alle Aufrufe
### Lektion 2.6 - Verwende kein Task.Result oder Task.Wait anstelle von await

### Lektion 2.7 - Debugging von async Anwendungen Teil I
#### Links
 - [Debug a parallel application - Walkthrough](https://docs.microsoft.com/de-de/visualstudio/debugger/walkthrough-debugging-a-parallel-application?view=vs-2019) Obwohl es in diesem *Walkthrough* um parallele Programmierung geht (welche wir erst im nächsten Kapitel im Detail anschauen), kannst du hier schon mal die Verwendung vom [Aufgaben-Fenster](https://docs.microsoft.com/de-de/visualstudio/debugger/walkthrough-debugging-a-parallel-application?view=vs-2019#to-restart-the-application-until-the-first-breakpoint-is-hit) üben.
 - [Debugging Managed Async Code in Visual Studio 2019 - Video von Leslie Richardson](https://www.youtube.com/watch?v=aVEug50YpaM) - Basierend auf dem [Debug a parallel application - Walkthrough](https://docs.microsoft.com/de-de/visualstudio/debugger/walkthrough-debugging-a-parallel-application?view=vs-2019) zeigt Leslie hier nochmals die wichtigsten Punkte im *Aufgaben-Fenster* und *Parallel-Stack-Fenster*. 
 - [Verwenden des Fensters "Aufgaben" - Microsoft Docs](https://docs.microsoft.com/de-de/visualstudio/debugger/using-the-tasks-window?view=vs-2019)
 - [How do I debug async code in Visual Studio - Leslie Richardson](https://devblogs.microsoft.com/visualstudio/how-do-i-debug-async-code-in-visual-studio/) - Artikel von 2020 der einen schnellen Überblick zu den Themen *Aufgaben-Fenster*, *Exceptions* und *Parallel Stack Fenster* gibt.

### Lektion 2.8 - Debugging von async Anwendungen Teil II
#### Links
 - [Verwenden des Fensters "Parallel Stack" - Microsoft Docs](https://docs.microsoft.com/de-de/visualstudio/debugger/using-the-parallel-stacks-window?view=vs-2019)

### Lektion 2.9 - Die Klasse Task im Rahmen von I/O-Operationen
#### Links
 - Stephen Cleary (MVP): [A Tour of Task - Artikel](https://blog.stephencleary.com/2014/04/a-tour-of-task-part-0-overview.html), [Übersicht der Aktivitäten bei StackOverflow](https://stackoverflow.com/users/263693/stephen-cleary), [Projekte auf GitHub](https://github.com/StephenCleary)
 - Stephen Toub (Entwickler bei Microsoft): [Blog bei Microsoft](https://devblogs.microsoft.com/dotnet/author/toub/), [Projekte auf GitHub](https://github.com/stephentoub), [Parallel Programming with .NET - Buch](https://books.google.de/books/about/PARALLEL_PROGRAMMING_WITH_MICROSOFT_NET.html?id=dL30ygAACAAJ&redir_esc=y)

#### Zusätzliches Material
Hier das Zustandsdiagramm für den *"Promise"-Task:*



### Lektion 2.9 - Exceptions, Delay und WhenAny - Die Zutaten für ein Timeout im Crawler
