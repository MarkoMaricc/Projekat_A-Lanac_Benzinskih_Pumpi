-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema benzinska_pumpa
-- -----------------------------------------------------
-- 
-- 

-- -----------------------------------------------------
-- Schema benzinska_pumpa
--
-- 
-- 
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `benzinska_pumpa` DEFAULT CHARACTER SET utf8 ;
USE `benzinska_pumpa` ;

-- -----------------------------------------------------
-- Table `benzinska_pumpa`.`BENZINSKE_STANICE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `benzinska_pumpa`.`BENZINSKE_STANICE` (
  `id` INT NOT NULL,
  `Adresa` VARCHAR(50) CHARACTER SET 'utf8' COLLATE 'utf8_general_ci' NOT NULL,
  `Grad` VARCHAR(50) CHARACTER SET 'utf8' COLLATE 'utf8_general_ci' NOT NULL,
  `Drzava` VARCHAR(50) CHARACTER SET 'utf8' COLLATE 'utf8_general_ci' NOT NULL,
  `Telefon` VARCHAR(20) CHARACTER SET 'utf8' COLLATE 'utf8_general_ci' NOT NULL,
  `email` VARCHAR(45) CHARACTER SET 'utf8' COLLATE 'utf8_general_ci' NOT NULL,
  `BrojParkingMjesta` INT NOT NULL,
  `Naziv` VARCHAR(45) CHARACTER SET 'utf8' COLLATE 'utf8_general_ci' NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `benzinska_pumpa`.`SKLADISTE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `benzinska_pumpa`.`SKLADISTE` (
  `id` INT NOT NULL,
  `BrojProizvoda` INT(11) NOT NULL,
  `ProtivPozarniSistem` TINYINT NULL,
  `Kapacitet` INT NOT NULL,
  `Vrsta` VARCHAR(50) CHARACTER SET 'utf8' COLLATE 'utf8_general_ci' NOT NULL,
  `Status` VARCHAR(45) CHARACTER SET 'utf8' COLLATE 'utf8_general_ci' NOT NULL,
  `idStanice` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_SKLADISTE_BENZINSKA_STANICA1_idx` (`idStanice` ASC) VISIBLE,
  CONSTRAINT `fk_SKLADISTE_BENZINSKA_STANICA1`
    FOREIGN KEY (`idStanice`)
    REFERENCES `benzinska_pumpa`.`BENZINSKE_STANICE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `benzinska_pumpa`.`PROIZVOD`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `benzinska_pumpa`.`PROIZVOD` (
  `Vrsta` VARCHAR(50) NOT NULL,
  `Cena` DECIMAL(6,2) NOT NULL,
  `idSkladista` INT NOT NULL,
  PRIMARY KEY (`Vrsta`),
  INDEX `fk_PROIZVOD_SKLADISTE1_idx` (`idSkladista` ASC) VISIBLE,
  CONSTRAINT `fk_PROIZVOD_SKLADISTE1`
    FOREIGN KEY (`idSkladista`)
    REFERENCES `benzinska_pumpa`.`SKLADISTE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `benzinska_pumpa`.`KASA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `benzinska_pumpa`.`KASA` (
  `id` INT(11) NOT NULL,
  `NacinPlacanja` VARCHAR(45) CHARACTER SET 'utf8' COLLATE 'utf8_general_ci' NOT NULL,
  `Vrsta` VARCHAR(45) CHARACTER SET 'utf8' COLLATE 'utf8_general_ci' NOT NULL,
  `idStanice` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_KASA_BENZINSKA_STANICA1_idx` (`idStanice` ASC) VISIBLE,
  CONSTRAINT `fk_KASA_BENZINSKA_STANICA1`
    FOREIGN KEY (`idStanice`)
    REFERENCES `benzinska_pumpa`.`BENZINSKE_STANICE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `benzinska_pumpa`.`RACUN`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `benzinska_pumpa`.`RACUN` (
  `id` INT NOT NULL,
  `Datum` DATETIME NOT NULL,
  `Cena` DECIMAL(6,2) NOT NULL,
  `idKase` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_RACUN_KASA1_idx` (`idKase` ASC) VISIBLE,
  CONSTRAINT `fk_RACUN_KASA1`
    FOREIGN KEY (`idKase`)
    REFERENCES `benzinska_pumpa`.`KASA` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `benzinska_pumpa`.`STAVKA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `benzinska_pumpa`.`STAVKA` (
  `id` INT NOT NULL,
  `Kolicina` INT NOT NULL,
  `Cena` DECIMAL(6,2) NOT NULL,
  `idRacuna` INT NOT NULL,
  `PROIZVOD_Vrsta` VARCHAR(50) CHARACTER SET 'utf8' COLLATE 'utf8_general_ci' NOT NULL,
  PRIMARY KEY (`id`, `idRacuna`, `PROIZVOD_Vrsta`),
  INDEX `fk_STAVKA_RACUN1_idx` (`idRacuna` ASC) VISIBLE,
  INDEX `fk_STAVKA_PROIZVOD1_idx` (`PROIZVOD_Vrsta` ASC) VISIBLE,
  CONSTRAINT `fk_STAVKA_RACUN1`
    FOREIGN KEY (`idRacuna`)
    REFERENCES `benzinska_pumpa`.`RACUN` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_STAVKA_PROIZVOD1`
    FOREIGN KEY (`PROIZVOD_Vrsta`)
    REFERENCES `benzinska_pumpa`.`PROIZVOD` (`Vrsta`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `benzinska_pumpa`.`RADNIK`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `benzinska_pumpa`.`RADNIK` (
  `id` INT NOT NULL,
  `JMBG` VARCHAR(13) CHARACTER SET 'utf8' COLLATE 'utf8_general_ci' NOT NULL,
  `Prezime` VARCHAR(50) CHARACTER SET 'utf8' COLLATE 'utf8_general_ci' NOT NULL,
  `Ime` VARCHAR(50) CHARACTER SET 'utf8' COLLATE 'utf8_general_ci' NOT NULL,
  `Uloga` VARCHAR(40) CHARACTER SET 'utf8' COLLATE 'utf8_general_ci' NOT NULL,
  `Plata` DECIMAL(6,2) NOT NULL,
  `PutniTroskovi` DECIMAL(6,2) NOT NULL,
  `BrojLicneKarte` VARCHAR(7) CHARACTER SET 'utf8' COLLATE 'utf8_general_ci' NOT NULL,
  `DatumRodjenja` DATETIME NOT NULL,
  `idStanice` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_RADNIK_BENZINSKA_STANICA1_idx` (`idStanice` ASC) VISIBLE,
  CONSTRAINT `fk_RADNIK_BENZINSKA_STANICA1`
    FOREIGN KEY (`idStanice`)
    REFERENCES `benzinska_pumpa`.`BENZINSKE_STANICE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `benzinska_pumpa`.`APARAT_ZA_GORIVO`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `benzinska_pumpa`.`APARAT_ZA_GORIVO` (
  `id` INT NOT NULL,
  `Vrsta` VARCHAR(45) CHARACTER SET 'utf8' COLLATE 'utf8_general_ci' NOT NULL,
  `Materijal` VARCHAR(45) CHARACTER SET 'utf8' COLLATE 'utf8_general_ci' NOT NULL,
  `Proizvodjac` VARCHAR(45) CHARACTER SET 'utf8' COLLATE 'utf8_general_ci' NOT NULL,
  `idStanice` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_APARAT_ZA_GORIVO_BENZINSKE_STANICE1_idx` (`idStanice` ASC) VISIBLE,
  CONSTRAINT `fk_APARAT_ZA_GORIVO_BENZINSKE_STANICE1`
    FOREIGN KEY (`idStanice`)
    REFERENCES `benzinska_pumpa`.`BENZINSKE_STANICE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `benzinska_pumpa`;

DELIMITER $$
USE `benzinska_pumpa`$$
CREATE DEFINER = CURRENT_USER TRIGGER `benzinska_pumpa`.`RACUN_AFTER_DELETE` AFTER DELETE ON `RACUN` FOR EACH ROW
BEGIN

END
$$


DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
