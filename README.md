## CI/CD

Repozytorium wykorzystuje GitHub Actions do sprawdzania jakości kodu, zarządzania wersjami oraz publikowania paczek.

### Continuous Integration

Workflow `ci.yml` uruchamia się dla pull requestów kierowanych do brancha `master` i wykonuje:

1. sprawdzenie tytułu PR zgodnie z Conventional Commits;
2. przywrócenie zależności NuGet;
3. weryfikację formatowania kodu;
4. zbudowanie rozwiązania w konfiguracji `Release`.

Przykładowe tytuły PR:

```text
feat(radio-browser): Add station search
fix(radio-browser): Handle invalid API response
docs(repository): Update documentation
```

### Wersjonowanie

Za wersjonowanie odpowiada Release Please.

* `.release-please-config.json` określa klientów, ich ścieżki oraz sposób tworzenia wydań;
* `.release-please-manifest.json` przechowuje aktualną wersję każdego klienta;
* `CHANGELOG.md` w katalogu klienta zawiera historię jego wydań.

Release Please przypisuje zmiany do klientów na podstawie ścieżek zmodyfikowanych plików. Scope, np. `radio-browser`, porządkuje historię zmian, ale nie decyduje o wyborze projektu.

Wpływ rodzaju zmiany na wersję:

| Typ                           | Przykład                      | Zmiana wersji      |
| ----------------------------- | ----------------------------- | ------------------ |
| `feat`                        | Nowa funkcjonalność           | minor              |
| `fix`                         | Poprawka błędu                | patch              |
| `feat!` lub `BREAKING CHANGE` | Zmiana niekompatybilna        | major              |
| `docs`, `chore`, `ci`         | Dokumentacja lub konfiguracja | bez nowego wydania |

### Proces wydania

Po scaleniu zmiany wymagającej wydania:

1. `release-please.yml` tworzy lub aktualizuje release PR;
2. release PR aktualizuje wersję, manifest oraz changelog;
3. `auto-merge-release-pr.yml` scala release PR po przejściu wymaganych kontroli;
4. Release Please tworzy tag i GitHub Release;
5. `publish-github-package.yml` wybiera projekt na podstawie taga;
6. projekt jest pakowany i publikowany w prywatnym GitHub Packages.

Przykładowy tag:

```text
RadioBrowser-v1.2.0
```

Na jego podstawie workflow odnajduje projekt:

```text
RadioBrowser/RadioBrowser/RadioBrowser.csproj
```

i tworzy paczkę:

```text
RadioBrowser.1.2.0.nupkg
```



### Pliki workflow

* `ci.yml` — walidacja PR, formatowanie i budowanie;
* `release-please.yml` — wersjonowanie, release PR, tagi i wydania;
* `auto-merge-release-pr.yml` — automatyczne scalanie release PR;
* `publish-github-package.yml` — tworzenie i publikowanie paczki.

### Dokumentacja

* [GitHub Actions](https://docs.github.com/actions)
* [Release Please](https://github.com/googleapis/release-please)
* [Manifest Release Please](https://github.com/googleapis/release-please/blob/main/docs/manifest-releaser.md)
* [GitHub Packages dla NuGet](https://docs.github.com/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry)
