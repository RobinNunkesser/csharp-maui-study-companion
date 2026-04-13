# Copilot Instructions for `csharp-maui-study-companion`

## Code-Duplikation mit `csharp-maui-isd-companion`

Dieses Repo teilt einen signifikanten Teil seines Codes mit
[`csharp-maui-isd-companion`](https://github.com/RobinNunkesser/csharp-maui-isd-companion).

Die Doppelung ist eine bewusste Architekturentscheidung: Nach der Entkopplung vom
eingebetteten Submodul werden beide Apps unabhängig gepflegt. Ein gemeinsames
NuGet-Paket für die Ports-Contracts ist der dokumentierte nächste Schritt, sobald
eine dritte App dazukommt.

### Betroffen sind insbesondere

- `StudyCompanion.Core/` — `MealCollection` und verwandte Core-Modelle
- `StudyCompanion.Core.Mock/` — alle Mock-Klassen
- `StudyCompanion/Tabs/Mensa/` — `MealQuery`, `MensaViewModel`, `PriceConverter`, `MensaPage`
- `StudyCompanion/Tabs/Courses/` — `CoursesPage`, `CoursesViewModel`
- `StudyCompanion/Tabs/Profs/` — `ProfsPage`, `ProfsViewModel`
- `StudyCompanion/Tabs/Settings/` — Additives, Allergens, Settings
- `StudyCompanion/Tabs/Quiz/` — `QuizPage`, `QuizViewModel`, `QuizStatisticsPage`

### Empfehlung bei Änderungen

Wenn du eine der oben genannten Dateien änderst, prüfe ob die entsprechende Datei in
`csharp-maui-isd-companion` von derselben Verbesserung profitieren kann. Das gilt
insbesondere für:

- Bugfixes in gemeinsamer Logik
- Namespace-Umbenennungen (z. B. NuGet-Paketpfade)
- Vereinheitlichung von MVVM-Patterns oder Converter-Implementierungen
