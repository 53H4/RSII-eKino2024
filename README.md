# eKino

## Kredencijali za prijavu

- Administrator (Desktop)

  ```
  Korisnicko ime: admin
  Password: admin
  ```
- Client (Mobile)

  ```
  Korisnicko ime: client
  Password: client
  ```

#### Kredencijali za placanje

  ```
  Broj kartice: 4242 4242 4242 4242
  ```

## Pokretanje aplikacija
1. Kloniranje repozitorija
  ```
  https://github.com/sehakespeare/RSII-eKino.git
  ```
2. Otvoriti klonirani repozitorij u konzoli
3. Pokretanje dokerizovanog API-ja i DB-a
  ```
  docker-compose build
  docker-compose up
  ```
4. Otvoriti eKino folder
  ```
  cd eKino
  ```
5. Otvoriti ekinomobile folder
  ```
  cd ekinomobile
  ```
6. Dohvatanje dependency-a
  ```
  flutter pub get
  ```
7. Prije pokretanja, otvoriti `lib\services\APIService.dart` i izmijeniti `apiAddress` na IP adresu vašeg internog Docker mrežnog adaptera:
  ```
  static String apiAddress = "172.19.144.1";
  ```
8. Pokretanje mobilne aplikacije
  ```
  flutter run
  ```
9. Pokretanje desktop aplikacije
  ```
  1. Otvoriti solution u Visual Studiu
  2. Postaviti `eKino.WinUI` kao startni projekat
  3. CTRL + F5
  ```
  