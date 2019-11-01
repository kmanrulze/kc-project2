Delete
From "Client"

GO

Delete
From "Character"

Go

Delete
From "DungeonMaster"

Go

Delete
From "Game"

Delete
From "CharacterGameXRef"


INSERT INTO "Client"
("ClientID", "Email", "PasswordHash", "UserName")
VALUES
('518B9A19-BD55-4497-A01F-2E48F23D8D30', 'DNDRULEZ@Gmail.com','A1!bbbbbbb', 'DNDRULEZ1')
,('01EEC648-89C6-4324-A732-165ADCD430C6','Porky@Gmail.com', 'A1!bbbbbb', 'Porkyman')
 
INSERT INTO "DungeonMaster"
("ClientID", "DungeonMasterID")
Values
('518B9A19-BD55-4497-A01F-2E48F23D8D30', 'add72d1c-9a4a-48c6-9f2e-434ba115377c')
,('01EEC648-89C6-4324-A732-165ADCD430C6', 'b5fb10e0-a72b-469d-bf09-09541eb518d1')   
       
INSERT INTO "Character"
("ClientID", "CharacterID","FirstName","LastName")
Values
('518B9A19-BD55-4497-A01F-2E48F23D8D30', '8368fb55-0b5d-4e8a-9201-87b9126a7e78', 'Oldman', 'Mangos')
,('518B9A19-BD55-4497-A01F-2E48F23D8D30', 'fbc5e704-8d54-4c92-ab30-4a606c8c8f41', 'Oldlady', 'Limes')
,('01EEC648-89C6-4324-A732-165ADCD430C6', '3721b0b2-c236-44f4-ba84-75f37d990487', 'Oldboy', 'Bananas')
,('01EEC648-89C6-4324-A732-165ADCD430C6', '3753fdee-b5ac-4492-bbbe-de01b9813d23', 'Oldgirl', 'Grapes')

Insert INTO "Game"
("DungeonMasterID", "GameID", "GameName")
Values
('add72d1c-9a4a-48c6-9f2e-434ba115377c','d8f93c66-4110-4289-a92b-102025b9c604','Konohagakure')
,('b5fb10e0-a72b-469d-bf09-09541eb518d1','21795fe2-6492-43f1-8747-2b7cc14cdd95','Takumi')

Insert INTO "CharacterGameXRef"
("CharacterID", "GameID")
Values
('8368fb55-0b5d-4e8a-9201-87b9126a7e78', 'd8f93c66-4110-4289-a92b-102025b9c604')
,('fbc5e704-8d54-4c92-ab30-4a606c8c8f41', 'd8f93c66-4110-4289-a92b-102025b9c604')
,('3721b0b2-c236-44f4-ba84-75f37d990487','21795fe2-6492-43f1-8747-2b7cc14cdd95')
,('3753fdee-b5ac-4492-bbbe-de01b9813d23','21795fe2-6492-43f1-8747-2b7cc14cdd95')