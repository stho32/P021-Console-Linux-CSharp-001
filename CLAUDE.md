# CLAUDE.md

## Projektbeschreibung

Externer IMAP-basierter Spam-Filter mit konfigurierbarer Rule-Engine.
Verbindet sich per IMAP mit einem Mailserver und wendet benutzerdefinierte Regeln an,
um E-Mails automatisch in Ordner zu verschieben oder zu loeschen.

## TechStack

- .NET 10.0 (C#)
- Architektur-Vorlage: dotnet-cli-tool
- MailKit fuer IMAP-Zugriff
- xUnit + AltCover fuer Tests und Coverage

## Projektstruktur

```
Source/spamfilter/
  spamfilter.console/       # CLI-Einstiegspunkt
  spamfilter.BL/             # Business Logic (Rules, Actions)
  spamfilter.Infrastructure/ # IMAP-Anbindung, Konfiguration
  spamfilter.Interfaces/     # Interfaces und Entities
  spamfilter.BL.Tests/       # Unit-Tests
```

## Build und Test

```bash
# Build
cd Source/spamfilter
dotnet build

# Tests ausfuehren
cd Source/spamfilter
dotnet test

# Tests mit Coverage
./update-coverage.sh
```

## Konventionen

- TreatWarningsAsErrors ist in allen Projekten aktiviert
- Nullable Reference Types sind aktiviert
- NuGet-Warnungen NU1902/NU1903 sind per NoWarn unterdrueckt (vorbestehende Abhaengigkeiten)
- Code folgt C#-Standardkonventionen (PascalCase fuer Typen/Methoden, _camelCase fuer private Felder)
