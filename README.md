S32866 - APBD - Ćwiczenie 2

Uzasadnienie decyzji projektowych:
Model sprzętu rozwiązałem klasą abstrakcyjną Equipment.cs po której dziedziczą klasy Laptop.cs, Printer.cs i Serwer.cs.
Rozwiązania użyłem, ponieważ logika związana z zarządzaniem wynajmem (np. status wypożyczenia) jest obsługiwana w klasie abstrakcyjnej, a logika 
specyficzna dla typu sprzętu (np. specyficzne pola zawierające informacje o sprzęcie) rozwiązywane są w klasach dziedziczących.

Model użytkownika rozwiązałem enumem (klasa User.cs, enum decydujący o typie użytkownika, sprawdzenie typu użytkownika i limitów przy wynajmie).
Rozwiązania użyłem ze względu na większą skalowalność (możliwość łatwego dodania nowych typów użytkownika bez dużych zmian w kodzie) i 
dynamiczność (łatwe decydowanie o limitach w statycznej klasie globalnej).

Wypożyczenie - klasa Rental.cs - obsługuje logikę wyporzyczenia, posiada wszystkie informacje o danym wypożyczeniu, przy oddaniu obsługuje logikę naliczenia
kary finansowej (dane pobiera z łatwo dostępnej statycznej klasy globalnej).

Klasy serwisowe - Odpowiadają za logikę biznesową, posiadają statyczne metody obługujące błędy (zwracane w konsoli) oraz bo odpowiedniej walidacji wykonują działania
na obiektach. Istnieją trzy klasy serwisowe EquipmentServices.cs, RentalServices.cs, UserServices.cs, w celu szybkiego odszukania i ewentualnej modyfikacji odpowiednich metod.
Metody w klasach serwisowych są wykonywane przez klasę UI, która odpowiada za konsolowe menu.

Klasy globalne - GlobalSettings.cs, GlobalState.cs - statyczne klasy globalne przechowujące informacje o listach użytkowników i sprzętu, o logu wynajmów, oraz o wszystkich 
ustawieniach globalnych (maksymalna liczba wynajmów dla typów użytkowników, maksymalny czas wynajmów, kara dzienna za oddanie sprzętu po terminie). Ustawienia łatwo
zmieniać, ponieważ są w jednym miejscu. Z klas pobierane są aktualne informacje. Klasa GlobalSettings.cs przechowuje również informację o aktualnym dniu. Jest to rozwiązanie
na potrzeby zadania, nie sprawdziło by się w realnej implementacji, gdzie należy by użyć klasy sprawdzającej dzień. W realnej implementacji, klasy te powinny synchronizować się
również z zewnętrzną bazą danych z backupem.
