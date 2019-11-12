GO

Delete
From "Overview"

GO

Delete
From "OverviewType"

GO

Delete
From "CharacterGameXRef"

GO

Delete
From "Game"

GO

Delete
From "Character"

Go


Delete
From "Client"

GO

INSERT INTO "Client"
("ClientID", "Email", "UserName")
VALUES
('518B9A19-BD55-4497-A01F-2E48F23D8D30', 'DNDRULEZ@Gmail.com', 'DNDRULEZ1')
,('01EEC648-89C6-4324-A732-165ADCD430C6','PicardFan1995@Gmail.com', 'PicardFan')

       
GO       
       
INSERT INTO "Character"
("ClientID", "CharacterID","FirstName","LastName")
Values
('518B9A19-BD55-4497-A01F-2E48F23D8D30', '8368fb55-0b5d-4e8a-9201-87b9126a7e78', 'Oldman', 'Mangos')
,('518B9A19-BD55-4497-A01F-2E48F23D8D30', 'fbc5e704-8d54-4c92-ab30-4a606c8c8f41', 'Oldlady', 'Limes')
,('01EEC648-89C6-4324-A732-165ADCD430C6', '3721b0b2-c236-44f4-ba84-75f37d990487', 'Oldboy', 'Bananas')
,('01EEC648-89C6-4324-A732-165ADCD430C6', '3753fdee-b5ac-4492-bbbe-de01b9813d23', 'Oldgirl', 'Grapes')

GO

Insert INTO "Game"
("ClientID", "GameID", "GameName")
Values
('518B9A19-BD55-4497-A01F-2E48F23D8D30','d8f93c66-4110-4289-a92b-102025b9c604','Konohagakure')
,('01EEC648-89C6-4324-A732-165ADCD430C6','21795fe2-6492-43f1-8747-2b7cc14cdd95','Takumi')

GO

Insert INTO "CharacterGameXRef"
("CharacterID", "GameID")
Values
('8368fb55-0b5d-4e8a-9201-87b9126a7e78', 'd8f93c66-4110-4289-a92b-102025b9c604')
,('fbc5e704-8d54-4c92-ab30-4a606c8c8f41', 'd8f93c66-4110-4289-a92b-102025b9c604')
,('3721b0b2-c236-44f4-ba84-75f37d990487','21795fe2-6492-43f1-8747-2b7cc14cdd95')
,('3753fdee-b5ac-4492-bbbe-de01b9813d23','21795fe2-6492-43f1-8747-2b7cc14cdd95')

GO

Insert INTO "OverviewType"
("TypeID")
Values
('64bf856e-9431-42f1-9aff-bd18265f6fdb')
,('5923c14a-fc21-45da-87f3-beae1a65f84b')
,('7bab5a30-de38-491a-a310-dbfdf7a2bc7a')
,('0ff6b782-5688-492c-a5ac-c238a357b369')

GO

Insert INTO "Overview"
("TypeID", "GameID", "OverviewID")
Values
('64bf856e-9431-42f1-9aff-bd18265f6fdb', 'd8f93c66-4110-4289-a92b-102025b9c604', 'af398a52-3652-4030-8cc5-09678aae82b8')
,('5923c14a-fc21-45da-87f3-beae1a65f84b', 'd8f93c66-4110-4289-a92b-102025b9c604', '419d835a-0f01-4d2a-a678-762a57b4278a')
,('7bab5a30-de38-491a-a310-dbfdf7a2bc7a','21795fe2-6492-43f1-8747-2b7cc14cdd95', 'e854376c-4f40-4d84-bfce-d5bb14fc0be7')
,('0ff6b782-5688-492c-a5ac-c238a357b369','21795fe2-6492-43f1-8747-2b7cc14cdd95', 'e7506a67-bca0-4b0f-86a6-614209747ce0')

