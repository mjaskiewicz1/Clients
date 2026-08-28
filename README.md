## Dodawanie klienta

Każdy klient API jest rozwijany jako niezależny projekt .NET i oddzielna paczka NuGet.

Schemat:

```text
Repozytorium
├── konfiguracja wspólna
├── automatyzacja CI/CD
└── KlientApi/
    ├── projekt .NET
    ├── dokumentacja
    └── historia zmian
```

Aby dodać kolejnego klienta:

1. utwórz osobny katalog i projekt .NET;
2. dodaj dokumentację klienta;
3. dołącz projekt do rozwiązania;
4. zarejestruj ścieżkę projektu w konfiguracji Release Please.

Wersjonowanie, tworzenie wydań i publikowanie paczek są realizowane niezależnie dla każdego klienta.
