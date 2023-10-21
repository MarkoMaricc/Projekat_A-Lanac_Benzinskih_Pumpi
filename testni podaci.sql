
INSERT INTO `benzinska_pumpa`.`benzinske_stanice` (`id`, `Adresa`, `Grad`, `Drzava`, `Telefon`, `email`, `BrojParkingMjesta`, `Naziv`) VALUES ('1', 'Ulica Marka Markovića 1', 'Beograd', 'Srbija', '+381 11 123456', 'info@benzinska1.com', '50', 'Benzinska Stanica Beograd');
INSERT INTO `benzinska_pumpa`.`benzinske_stanice` (`id`, `Adresa`, `Grad`, `Drzava`, `Telefon`, `email`, `BrojParkingMjesta`, `Naziv`) VALUES ('4', 'Kralja Petra prvog Karadjordjevica', 'Podgorica', 'Crna Gora', '+382 20 444444', 'info@benzinska4.me', '10', 'Benzinska Stanica Podgorica');
INSERT INTO `benzinska_pumpa`.`benzinske_stanice` (`id`, `Adresa`, `Grad`, `Drzava`, `Telefon`, `email`, `BrojParkingMjesta`, `Naziv`) VALUES ('5', 'Bulevar Makedonija 5', 'Skoplje', 'Severna Makedonija', '+389 2 333333', 'info@benzinska5.mk', '22', 'Benzinska Stanica Skoplje');

INSERT INTO `benzinska_pumpa`.`benzinske_stanice` (`id`, `Adresa`, `Grad`, `Drzava`, `Telefon`, `email`, `BrojParkingMjesta`, `Naziv`) VALUES ('2', 'Ulica Zivojina Misica 3', 'Ljubljana', 'Slovenija', '+386 1 555555', 'info@benzinska3.si', '5', 'Benzinska Stanica Ljubljana');
INSERT INTO `benzinska_pumpa`.`benzinske_stanice` (`id`, `Adresa`, `Grad`, `Drzava`, `Telefon`, `email`, `BrojParkingMjesta`, `Naziv`) VALUES ('3', 'Trg Bana Jelačića 2', 'Zagreb', 'Hrvatska', '+385 1 987654', 'info@benzinska2.hr', '30', 'Benzinska Stanica Zagreb');


INSERT INTO `benzinska_pumpa`.`aparat_za_gorivo` (`id`, `Vrsta`, `Materijal`, `Proizvodjac`, `idStanice`) VALUES ('1', 'MODEL M', 'Aluminijum', 'Agropartner', '1');
INSERT INTO `benzinska_pumpa`.`aparat_za_gorivo` (`id`, `Vrsta`, `Materijal`, `Proizvodjac`, `idStanice`) VALUES ('2', 'MODEL H', 'Aluminijum', 'Wayne', '2');

INSERT INTO `benzinska_pumpa`.`aparat_za_gorivo` (`id`, `Vrsta`, `Materijal`, `Proizvodjac`, `idStanice`)
VALUES ('3', 'MODEL X', 'Nehrđajući čelik', 'PetrolTech', '3');
INSERT INTO `benzinska_pumpa`.`aparat_za_gorivo` (`id`, `Vrsta`, `Materijal`, `Proizvodjac`, `idStanice`)
VALUES ('4', 'MODEL Z', 'Čelik', 'FuelMatic', '4');

INSERT INTO `benzinska_pumpa`.`aparat_za_gorivo` (`id`, `Vrsta`, `Materijal`, `Proizvodjac`, `idStanice`)
VALUES ('5', 'MODEL Y', 'Plastika', 'PetroLine', '5');

INSERT INTO `benzinska_pumpa`.`aparat_za_gorivo` (`id`, `Vrsta`, `Materijal`, `Proizvodjac`, `idStanice`)
VALUES ('6', 'MODEL A', 'Nehrđajući čelik', 'GasTech', '1');

INSERT INTO `benzinska_pumpa`.`aparat_za_gorivo` (`id`, `Vrsta`, `Materijal`, `Proizvodjac`, `idStanice`)
VALUES ('7', 'MODEL B', 'Aluminijum', 'FuelPro', '2');

INSERT INTO `benzinska_pumpa`.`kasa` (`id`, `NacinPlacanja`, `Vrsta`, `idStanice`) VALUES ('1', 'gotovina', 'brza-samousluzna', '1');
INSERT INTO `benzinska_pumpa`.`kasa` (`id`, `NacinPlacanja`, `Vrsta`, `idStanice`)
VALUES ('2', 'kartica', 'samousluzna', '2');
INSERT INTO `benzinska_pumpa`.`kasa` (`id`, `NacinPlacanja`, `Vrsta`, `idStanice`)
VALUES ('3', 'gotovina', 'kombinovana', '1');
INSERT INTO `benzinska_pumpa`.`kasa` (`id`, `NacinPlacanja`, `Vrsta`, `idStanice`)
VALUES ('4', 'kartica', 'obicna', '3');


INSERT INTO `benzinska_pumpa`.`skladiste` (`id`, `BrojProizvoda`, `ProtivPozarniSistem`, `Kapacitet`, `Vrsta`, `Status`, `idStanice`) VALUES ('1', '100', '1', '1000', 'Cisterne za skladištenje goriva', 'aktivan', '1');
INSERT INTO `benzinska_pumpa`.`skladiste` (`id`, `BrojProizvoda`, `ProtivPozarniSistem`, `Kapacitet`, `Vrsta`, `Status`, `idStanice`)
VALUES ('2', '80', '1', '800', 'Rezervoari za naftu', 'aktivan', '2');

INSERT INTO `benzinska_pumpa`.`skladiste` (`id`, `BrojProizvoda`, `ProtivPozarniSistem`, `Kapacitet`, `Vrsta`, `Status`, `idStanice`)
VALUES ('3', '50', '0', '500', 'Rezervoari za dizel', 'neaktivan', '3');

INSERT INTO `benzinska_pumpa`.`skladiste` (`id`, `BrojProizvoda`, `ProtivPozarniSistem`, `Kapacitet`, `Vrsta`, `Status`, `idStanice`)
VALUES ('4', '120', '1', '1200', 'Cisterne za gorivo i ulje', 'aktivan', '4');

INSERT INTO `benzinska_pumpa`.`skladiste` (`id`, `BrojProizvoda`, `ProtivPozarniSistem`, `Kapacitet`, `Vrsta`, `Status`, `idStanice`)
VALUES ('5', '70', '1', '700', 'Rezervoari za benzinske derivate', 'neaktivan', '5');


INSERT INTO `benzinska_pumpa`.`radnik` (`id`, `JMBG`, `Prezime`, `Ime`, `Uloga`, `Plata`, `PutniTroskovi`, `BrojLicneKarte`, `DatumRodjenja`, `idStanice`) VALUES ('1', '1988981191822', 'Maric', 'Marko', 'direktor', '2000.00', '100.00', '1234567', '1997-10-29', '1');
INSERT INTO `benzinska_pumpa`.`radnik` (`id`, `JMBG`, `Prezime`, `Ime`, `Uloga`, `Plata`, `PutniTroskovi`, `BrojLicneKarte`, `DatumRodjenja`, `idStanice`)
VALUES ('2', '1988765432100', 'Milic', 'Ana', 'referent', '1500.00', '50.00', '9876543', '1995-05-15', '2');

INSERT INTO `benzinska_pumpa`.`radnik` (`id`, `JMBG`, `Prezime`, `Ime`, `Uloga`, `Plata`, `PutniTroskovi`, `BrojLicneKarte`, `DatumRodjenja`, `idStanice`)
VALUES ('3', '1988877665533', 'Ivanić', 'Ivan', 'kasir', '1200.00', '30.00', '5678901', '1998-03-08', '3');

INSERT INTO `benzinska_pumpa`.`radnik` (`id`, `JMBG`, `Prezime`, `Ime`, `Uloga`, `Plata`, `PutniTroskovi`, `BrojLicneKarte`, `DatumRodjenja`, `idStanice`)
VALUES ('4', '1988777888999', 'Petrovic', 'Petar', 'cistac', '1100.00', '20.00', '3456789', '1994-07-21', '4');

INSERT INTO `benzinska_pumpa`.`radnik` (`id`, `JMBG`, `Prezime`, `Ime`, `Uloga`, `Plata`, `PutniTroskovi`, `BrojLicneKarte`, `DatumRodjenja`, `idStanice`)
VALUES ('5', '1988899887766', 'Lukić', 'Luka', 'serviser', '1600.00', '60.00', '2345678', '1996-12-10', '5');



INSERT INTO `benzinska_pumpa`.`racun` (`id`, `Datum`, `Cena`, `idKase`) VALUES ('1', '2022-01-01', '0040.10', '1');
INSERT INTO `benzinska_pumpa`.`racun` (`id`, `Datum`, `Cena`, `idKase`) VALUES ('2', '2022-01-02', '100.00', '1');
UPDATE `benzinska_pumpa`.`racun` SET `Datum` = '2022-01-01 12:22:00' WHERE (`id` = '1');
UPDATE `benzinska_pumpa`.`racun` SET `Datum` = '2022-01-02 01:15:34' WHERE (`id` = '2');
INSERT INTO `benzinska_pumpa`.`racun` (`id`, `Datum`, `Cena`, `idKase`) VALUES ('3', '2022-01-02 01:23:22', '20.00', '1');
INSERT INTO `benzinska_pumpa`.`racun` (`id`, `Datum`, `Cena`, `idKase`) VALUES ('4', '2022-01-03 23:22:12', '80.00', '1');
INSERT INTO `benzinska_pumpa`.`racun` (`id`, `Datum`, `Cena`, `idKase`) VALUES ('5', '2022-01-02 05:13:02', '55.00', '1');
INSERT INTO `benzinska_pumpa`.`racun` (`id`, `Datum`, `Cena`, `idKase`) VALUES ('6', '2022-05-01 08:22:19', '400.00', '2');
INSERT INTO `benzinska_pumpa`.`racun` (`id`, `Datum`, `Cena`, `idKase`) VALUES ('7', '2022-05-01 09:01:03', '80.00', '2');
INSERT INTO `benzinska_pumpa`.`racun` (`id`, `Datum`, `Cena`, `idKase`) VALUES ('8', '2022-05-01 22:00:42', '122.00', '2');
INSERT INTO `benzinska_pumpa`.`racun` (`id`, `Datum`, `Cena`, `idKase`) VALUES ('9', '2022-06-01 12:22:19', '60.00', '2');
INSERT INTO `benzinska_pumpa`.`racun` (`id`, `Datum`, `Cena`, `idKase`) VALUES ('10', '2022-07-01 23:12:12', '30.00', '3');
INSERT INTO `benzinska_pumpa`.`racun` (`id`, `Datum`, `Cena`, `idKase`) VALUES ('11', '2022-07-01 12:23:00', '95.00', '3');


INSERT INTO `benzinska_pumpa`.`proizvod` (`Vrsta`, `Cena`, `idSkladista`) VALUES ('benzin', '3.0', '1');
INSERT INTO `benzinska_pumpa`.`proizvod` (`Vrsta`, `Cena`, `idSkladista`) VALUES ('DIZEL BAS EN 590', '3.00', '2');
INSERT INTO `benzinska_pumpa`.`proizvod` (`Vrsta`, `Cena`, `idSkladista`) VALUES ('EURODIESEL BS ', '3.50', '2');
INSERT INTO `benzinska_pumpa`.`proizvod` (`Vrsta`, `Cena`, `idSkladista`) VALUES ('SUPER PLUS bezolovni benzin 98', '2.50', '1');
INSERT INTO `benzinska_pumpa`.`proizvod` (`Vrsta`, `Cena`, `idSkladista`) VALUES ('LPG tecni naftni gas', '1.50', '2');
INSERT INTO `benzinska_pumpa`.`proizvod` (`Vrsta`, `Cena`, `idSkladista`) VALUES ('prirodni plin (CNG)', '1.00', '2');
INSERT INTO `benzinska_pumpa`.`proizvod` (`Vrsta`, `Cena`, `idSkladista`) VALUES ('kesa', '0.10', '2');
INSERT INTO `benzinska_pumpa`.`proizvod` (`Vrsta`, `Cena`, `idSkladista`) VALUES ('plinska boca', '20.00', '2');
INSERT INTO `benzinska_pumpa`.`proizvod` (`Vrsta`, `Cena`, `idSkladista`) VALUES ('motorno ulje', '5.00', '2');


INSERT INTO `benzinska_pumpa`.`stavka` (`id`, `Kolicina`, `Cena`, `idRacuna`,`PROIZVOD_Vrsta`) VALUES ('1', '10', '30.00', '10','benzin');
INSERT INTO `benzinska_pumpa`.`stavka` (`id`, `Kolicina`, `Cena`, `idRacuna`, `PROIZVOD_Vrsta`) VALUES ('2', '5', '5.00', '1', 'prirodni plin (CNG)');
INSERT INTO `benzinska_pumpa`.`stavka` (`id`, `Kolicina`, `Cena`, `idRacuna`, `PROIZVOD_Vrsta`) VALUES ('3', '1', '20.00', '1', 'plinska boca');
INSERT INTO `benzinska_pumpa`.`stavka` (`id`, `Kolicina`, `Cena`, `idRacuna`, `PROIZVOD_Vrsta`) VALUES ('4', '3', '15.00', '1', 'motorno ulje');
INSERT INTO `benzinska_pumpa`.`stavka` (`id`, `Kolicina`, `Cena`, `idRacuna`, `PROIZVOD_Vrsta`) VALUES ('5', '1', '0.10', '1', 'kesa');
INSERT INTO `benzinska_pumpa`.`stavka` (`id`, `Kolicina`, `Cena`, `idRacuna`, `PROIZVOD_Vrsta`) VALUES ('6', '5', '100.00', '2', 'plinska boca');
INSERT INTO `benzinska_pumpa`.`stavka` (`id`, `Kolicina`, `Cena`, `idRacuna`, `PROIZVOD_Vrsta`) VALUES ('7', '7', '17.50', '3', 'SUPER PLUS bezolovni benzin 98');
INSERT INTO `benzinska_pumpa`.`stavka` (`id`, `Kolicina`, `Cena`, `idRacuna`, `PROIZVOD_Vrsta`) VALUES ('8', '1', '2.50', '3', 'SUPER PLUS bezolovni benzin 98');
INSERT INTO `benzinska_pumpa`.`stavka` (`id`, `Kolicina`, `Cena`, `idRacuna`, `PROIZVOD_Vrsta`) VALUES ('9', '20', '70', '4', 'EURODIESEL BS ');
INSERT INTO `benzinska_pumpa`.`stavka` (`id`, `Kolicina`, `Cena`, `idRacuna`, `PROIZVOD_Vrsta`) VALUES ('10', '2', '10.00', '4', 'motorno ulje');
INSERT INTO `benzinska_pumpa`.`stavka` (`id`, `Kolicina`, `Cena`, `idRacuna`, `PROIZVOD_Vrsta`) VALUES ('11', '55', '55.00', '5', 'prirodni plin (CNG)');
INSERT INTO `benzinska_pumpa`.`stavka` (`id`, `Kolicina`, `Cena`, `idRacuna`, `PROIZVOD_Vrsta`) VALUES ('12', '20', '400.00', '6', 'plinska boca');
INSERT INTO `benzinska_pumpa`.`stavka` (`id`, `Kolicina`, `Cena`, `idRacuna`, `PROIZVOD_Vrsta`) VALUES ('13', '32', '80.00', '7', 'SUPER PLUS bezolovni benzin 98');
INSERT INTO `benzinska_pumpa`.`stavka` (`id`, `Kolicina`, `Cena`, `idRacuna`, `PROIZVOD_Vrsta`) VALUES ('14', '40', '120', '8', 'DIZEL BAS EN 590');
INSERT INTO `benzinska_pumpa`.`stavka` (`id`, `Kolicina`, `Cena`, `idRacuna`, `PROIZVOD_Vrsta`) VALUES ('15', '2', '2.00', '8', 'prirodni plin (CNG)');
INSERT INTO `benzinska_pumpa`.`stavka` (`id`, `Kolicina`, `Cena`, `idRacuna`, `PROIZVOD_Vrsta`) VALUES ('16', '20', '60', '9', 'DIZEL BAS EN 590');
INSERT INTO `benzinska_pumpa`.`stavka` (`id`, `Kolicina`, `Cena`, `idRacuna`, `PROIZVOD_Vrsta`) VALUES ('17', '10', '30.00', '10', 'benzin');
INSERT INTO `benzinska_pumpa`.`stavka` (`id`, `Kolicina`, `Cena`, `idRacuna`, `PROIZVOD_Vrsta`) VALUES ('18', '30', '90.00', '11', 'DIZEL BAS EN 590');
INSERT INTO `benzinska_pumpa`.`stavka` (`id`, `Kolicina`, `Cena`, `idRacuna`, `PROIZVOD_Vrsta`) VALUES ('19', '1', '5.00', '11', 'motorno ulje');




