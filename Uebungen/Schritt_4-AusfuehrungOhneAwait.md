# �bung: Was passiert bei einer `async Task` Methode ohne `await`?

> **Ziel:** Vertiefe dein Verst�ndnis bez�glich der Ausf�hrung von *asynchronem Code* UND �berpr�fe was du diesbez�glich bisher gelernt hast!

Bei dieser �bung geht es darum, dass du mithilfe des Debuggers oder anderer geeigneter Mittel herausfindest, warum *Visual Studio* eine Warnung anzeigt, wenn du in einer `async` Methode kein `await` verwendest. Bitte [erstelle daf�r ein neues Issue](https://github.com/LernMoment/LernMomentCrawler/issues/new) in dem du deine Antwort aufschreibst.

Es geht dabei insbesondere um diesen Quellcode:

```csharp
    private async void LoadWebSiteButton_Click(object sender, RoutedEventArgs e)
    {
        var einAndererTask = LoadLernMomentDe();
        // hier wird noch was anderes gemacht.
        // await einAndererTask; -> wurde vergessen!
    }
```

Wenn du mich in der Antwort mithilfe von @suchja erw�hnst, werde ich dir gerne R�ckmeldung zu deiner Antwort geben.