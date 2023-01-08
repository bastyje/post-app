# Projekt na przedmiot Programowanie Aplikacji Mobilnych i Webowych

## Uruchomienie aplikacji

1. Przed uruchomieniem programu należy do pliku `/etc/hosts` dodać jedną domenę:
```
10.0.0.3 postapp.pl
```
2. Następnie w korzeniu projektu należy wywołać komendę:
```
docker compose up
```
3. Aplikacja jest gotowa! Można z niej korzystać pod adresem `postapp.pl`
4. Po zamkończeniu procesu docker-compose warto uruchomić komendę
```
docker compose down
```
