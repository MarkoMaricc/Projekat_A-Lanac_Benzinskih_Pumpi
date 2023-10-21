  
  ALTER DATABASE
    benzinska_pumpa
    CHARACTER SET = utf8mb4
    COLLATE = utf8mb4_unicode_ci;
  
  ALTER TABLE benzinska_pumpa.aparat_za_gorivo CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
    ALTER TABLE benzinska_pumpa.benzinske_stanice CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
    ALTER TABLE benzinska_pumpa.kasa CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
    
    ALTER TABLE benzinska_pumpa.stavka DROP FOREIGN KEY fk_STAVKA_PROIZVOD1;
    ALTER TABLE benzinska_pumpa.proizvod CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
    
    ALTER TABLE benzinska_pumpa.racun CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
    ALTER TABLE benzinska_pumpa.radnik CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
    ALTER TABLE benzinska_pumpa.skladiste CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
    
    
    ALTER TABLE benzinska_pumpa.stavka CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
    ALTER TABLE benzinska_pumpa.stavka ADD CONSTRAINT fk_STAVKA_PROIZVOD1 FOREIGN KEY (PROIZVOD_Vrsta) REFERENCES  benzinska_pumpa.proizvod(Vrsta);
    