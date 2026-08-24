# Twitter-Klon1
# Twitter-Klon

## Beschreibung

Dieses Projekt ist ein einfacher Twitter-Klon, der mit **ASP.NET Core MVC, C#, Entity Framework Core und Microsoft SQL Server** entwickelt wurde.

Benutzer können sich registrieren und anmelden, Beiträge erstellen sowie Beiträge anderer Benutzer liken oder disliken.

Zusätzlich verfügt das Projekt über einen persönlichen Bereich für den angemeldeten Benutzer. Dort können die eigenen Beiträge verwaltet und wichtige Kennzahlen wie die Anzahl der Beiträge, Likes und Dislikes angezeigt werden.

Das Projekt verwendet **ASP.NET Core Identity** für die Benutzerverwaltung und **Entity Framework Core** für die Datenbankanbindung.

---

## Verwendete Technologien

- C#
- ASP.NET Core MVC
- Entity Framework Core
- Microsoft SQL Server
- ASP.NET Core Identity
- Razor Views
- HTML
- CSS
- Visual Studio

---

## Funktionen

### Benutzerverwaltung

- Registrierung eines Benutzers
- Login und Logout
- Anmeldung mit Benutzername oder E-Mail
- Passwort-Hashing durch ASP.NET Core Identity
- Authentifizierung der Benutzer
- Automatische Zuordnung von Beiträgen zum angemeldeten Benutzer

---

### Beiträge

- Beiträge erstellen
- Maximale Länge von 420 Zeichen
- Automatische Speicherung des Erstellungsdatums
- Automatische Zuordnung eines Beitrags zum angemeldeten Benutzer
- Anzeige aller Beiträge
- Sortierung nach Erstellungsdatum
- Neueste Beiträge werden zuerst angezeigt
- Bearbeiten eigener Beiträge
- Löschen eigener Beiträge
- Andere Benutzer können fremde Beiträge nicht bearbeiten oder löschen

---

### Likes

- Beiträge liken
- Like wieder entfernen (Unlike)
- Anzeige der Anzahl der Likes
- Ein Benutzer kann einen Beitrag nur einmal liken
- Ein Benutzer kann einen Beitrag nicht gleichzeitig liken und disliken
- Beim Setzen eines Likes wird ein vorhandener Dislike entfernt

---

### Dislikes

- Beiträge disliken
- Dislike wieder entfernen
- Anzeige der Anzahl der Dislikes
- Ein Benutzer kann einen Beitrag nicht mehrfach disliken
- Ein Benutzer kann einen Beitrag nicht gleichzeitig liken und disliken
- Beim Setzen eines Dislikes wird ein vorhandener Like entfernt

---

### Auswertungen

Auf der Beitragsübersicht werden die persönlichen Kennzahlen des angemeldeten Benutzers angezeigt.

Die Auswertung beinhaltet:

- Gesamtzahl der selbst verfassten Beiträge
- Gesamtzahl der Likes auf den eigenen Beiträgen
- Gesamtzahl der Dislikes auf den eigenen Beiträgen

Die Kennzahlen werden direkt auf der Beitragsseite angezeigt.

---

### Profil und eigene Beiträge

- Persönlicher Profilbereich
- Anzeige der eigenen Beiträge
- Verwaltung der eigenen Beiträge
- Bearbeiten eigener Beiträge
- Löschen eigener Beiträge
- Neueste eigene Beiträge zuerst
- Suche nach eigenen Beiträgen

---

### Berechtigungen

Das Projekt berücksichtigt die Benutzerrechte.

Ein Benutzer darf:

- eigene Beiträge bearbeiten
- eigene Beiträge löschen
- Beiträge anderer Benutzer ansehen
- Beiträge anderer Benutzer liken oder disliken

Ein Benutzer darf nicht:

- Beiträge anderer Benutzer bearbeiten
- Beiträge anderer Benutzer löschen

Die Berechtigungen werden sowohl in der Benutzeroberfläche als auch serverseitig im Controller überprüft.

---

## Datenbank

Für die Datenbank wird **Entity Framework Core** verwendet.

Die wichtigsten Entitäten sind:

- `IdentityUser`
- `Beitrag`
- `Like`
- `Dislike`

### Beziehungen

Ein `Beitrag` gehört zu einem Benutzer.

Ein `Like` gehört zu:

- genau einem Beitrag
- genau einem Benutzer

Ein `Dislike` gehört zu:

- genau einem Beitrag
- genau einem Benutzer

Dadurch können Likes und Dislikes eindeutig einem Benutzer und einem Beitrag zugeordnet werden.

---

## Datenbankregeln

Für Likes und Dislikes wird verhindert, dass ein Benutzer dieselbe Bewertung mehrfach für einen Beitrag speichern kann.

Ein Benutzer kann einen Beitrag entweder:

- liken
- disliken
- oder keine Bewertung abgeben

Ein gleichzeitiges Like und Dislike desselben Benutzers auf demselben Beitrag ist nicht möglich.

---

## Migrationen

Änderungen am Datenbankmodell werden mit **Entity Framework Core Migrations** verwaltet.

Eine neue Migration kann beispielsweise mit folgendem Befehl erstellt werden:

```Paket-Manger-konsole
Add-Migration AddDislikes
