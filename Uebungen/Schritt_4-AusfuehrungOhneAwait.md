# Übung: Was passiert bei einer `async Task` Methode ohne `await`?

> **Ziel:** Vertiefe dein Verständnis bezüglich der Ausführung von *asynchronem Code* UND überprüfe was du diesbezüglich bisher gelernt hast!

Bei dieser Übung geht es darum, dass du mithilfe des Debuggers oder anderer geeigneter Mittel herausfindest, warum *Visual Studio* eine Warnung anzeigt, wenn du in einer `async` Methode kein `await` verwendest. Bitte [erstelle dafür ein neues Issue](https://github.com/LernMoment/LernMomentCrawler/issues/new) in dem du deine Antwort aufschreibst.

Es geht dabei insbesondere um diesen Quellcode:

```csharp
    private async void LoadWebSiteButton_Click(object sender, RoutedEventArgs e)
    {
        var einAndererTask = LoadLernMomentDe();
        // hier wird noch was anderes gemacht.
        // await einAndererTask; -> wurde vergessen!
    }
```

Wenn du mich in der Antwort mithilfe von @suchja erwähnst, werde ich dir gerne Rückmeldung zu deiner Antwort geben.