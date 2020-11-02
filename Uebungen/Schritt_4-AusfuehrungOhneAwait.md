# �bung: Was passiert bei einer `async Task` Methode ohne `await`?

> **Ziel:** Vertiefe dein Verst�ndnis bez�glich der Ausf�hrung von *asynchronem Code* UND �berpr�fe was du diesbez�glich bisher gelernt hast!

Bei dieser �bung geht es darum, dass du mithilfe des Debuggers oder anderer geeigneter Mittel herausfindest, warum *Visual Studio* eine Warnung anzeigt, wenn du in einer `async` Methode kein `await` verwendest. Es geht also um die Frage *Was passiert beim Aufruf einer `async`-Methode **ohne** `await`?*. �berlege dir dabei auch welche Probleme dabei entstehen k�nnen. Bitte [erstelle daf�r ein neues Issue](https://github.com/LernMoment/LernMomentCrawler/issues/new) in dem du deine Antwort aufschreibst. Du kannst dabei [diese Version des Quellcodes](https://github.com/LernMoment/LernMomentCrawler/releases/tag/uebung-schritt-4) verwenden.

Es geht dabei insbesondere um diesen Quellcode:

```csharp
    private async void LoadWebSiteButton_Click(object sender, RoutedEventArgs e)
    {
        var einAndererTask = LoadLernMomentDe();
        // hier wird noch was anderes gemacht.
        // await einAndererTask; -> wurde vergessen!
    }
```

**WICHTIG:** Bitte mache diese �bung unbedingt schriftlich! Durch das Aufschreiben solltest du sehr schnell merken welche Aspekte du verstanden hast und wo dir noch Verst�ndnis fehlt. Machst du diese �bung nur "m�ndlich", ist der Lerneffekt wesentlich geringer.

Wenn du mich in der Antwort mithilfe von @suchja erw�hnst, werde ich dir gerne R�ckmeldung zu deiner Antwort geben.