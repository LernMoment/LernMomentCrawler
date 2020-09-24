# LernMomentCrawler
Für den noch zu entwickelnden LernMomentBuddy-C#, eine Anwendung die Einsteigern hilft systematisch C# zu lernen, müssen alle veröffentlichten LernMoment-Ressourcen indiziert und kategorisiert werden. Das ist die Aufgabe des LernMomentCrawler. Außerdem ist es das Beispiel für den neuen Online-Kurs *"Asynchrone und parallele Programmierung in C#"*.

## Eine Einführung in den LernMoment Crawler
Ziel dieser Anwendung ist es alle Ressourcen von LernMoment (Artikel auf LernMoment.de, Übungen und Beispiele auf GitHub und natürlich Videobeschreibungen auf YouTube) nach einem bestimmten Thema zu durchsuchen. Dafür gibt es einen Client, die `LernMomentCrawlerUI`, und den `FakeLernMomentServer`.

### Die `LernMomentCrawlerUI` - eine WPF .NET Core Anwendung
Mithilfe dieser Anwendung kannst du alle Ressourcen von LernMoment nach einem spezifischen Thema durchsuchen. Die Anwendung ist mit .NET Core und WPF umgesetzt. Neben der eigentlichen Funktionalität zeigt sie dir insbesondere die Verwendung von `async/await`, der *Task Parallel Library (TPL)* und den Möglichkeiten der parallelen Datenverarbeitung (z.B. `Parallel.ForEach`) in C#.

### Der `FakeLernMomentServer` - ein ASP.NET Core Server
Nach den ersten Tests, ist mir schnell klar geworden, dass ich insbesondere für den Online-Kurs *Asychrone und parallele Programmierung in C#* mehr Kontrolle über die Antwortzeiten benötige. Außerdem möchte ich vermeiden, dass die eigentliche Seite LernMoment.de durch viele Crawls beeinträchtigt wird. Daher ist dieser kleine Server dafür verantwortlich, dass in einer Testumgebung (auch ohne Internetverbindung) wenigstens die Artikel von LernMoment.de lokal bereitgestellt werden.

### Die VisualStudio - Projektmappe
Damit du einfach mit den beiden Projekten arbeiten kannst ist die Projektmappe so konfiguriert, dass beide Projekte parallel gestartet werden. Das ist ntowendig, weil ohne den `FakeLernMomentServer` kann die `LernMomentCrawlerUI` nicht arbeiten. Du solltest daher bei Änderungen an den Projekten und Konfigurationen sicherstellen, dass beide Projekte gestartet werden.

Wenn du das Debugging startest, dann beachte bitte, dass nicht nur die Oberfläche läuft, sondern im Hintergrund auch der Server. Insbesondere beim Stoppen reicht es somit nicht aus nur die Oberfläche zu schließen. Vielmehr musst du auch den Debugger nochmals explizit stoppen damit auch der Server beendet wird.

## Zuordnung Lektionen & Quellcode (Schritte)
Hier findest du bald eine Zuordnung der Lektionen aus dem Online-Kurs zu den entsprechenden Commits und Releases.

| Lektion | Quellcode | Commits |
| --- | --- | --- |
| 1-1 Von Synchron zu asynchron - ein Beispiel | [Start](https://github.com/LernMoment/LernMomentCrawler/releases/tag/start-schritt-1)<br>[Lösung](https://github.com/LernMoment/LernMomentCrawler/releases/tag/loesung-schritt-1) | [edd5a2f](https://github.com/LernMoment/LernMomentCrawler/commit/edd5a2f709e779b8d0952f27d548bde97f5e8946) - synchron zu asynchron |

## Lösungen zu Rätseln und Übungen
Ein wichtiger Bestandteil eines jeden Online-Kurses sind für mich praktische Aufgaben. Im Kurs gebe ich immer wieder kleine Rätsel und Übungen. Nachfolgend findest du Links zu allen Lösungen (entweder als Commit oder als Link zur entsprechenden Beschreibung).
