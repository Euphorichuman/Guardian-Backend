# GUARDIAN BACKEND SERVICE

## Resources

Base url: `/api/v1`

### Services

| URL           | Method | Body    | Description                                  |
| ------------- | ------ | ------- | -------------------------------------------- |
| `/Heroes`     | GET    | `empty` | Get all heroes in the system                 |
| `/Villains`   | GET    | `empty` | Get all villains in the system               |

## Database relational model diagram  

![Diseño de bd  diagrama](https://user-images.githubusercontent.com/55267781/204887281-34f6c540-9da7-4eac-a2ac-d3e717adf27f.png)  

#### Create database

1. Start a MySQL client (_Recomended: [Workbench](https://www.mysql.com/products/workbench/)_)
2. Run the following script to create the database and tables:

```
CREATE DATABASE guardian;
USE guardian;

CREATE TABLE heroes
(
  Id VARCHAR(36) NOT NULL,
  Name VARCHAR(128) NOT NULL,
  Age INT NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE villains
(
  Id VARCHAR(36) NOT NULL,
  Name VARCHAR(128) NOT NULL,
  Age INT NOT NULL,
  Origin VARCHAR(128) NOT NULL,
  Power VARCHAR(128) NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE skills
(
  Id CHAR(36) NOT NULL,
  Name VARCHAR(128) NOT NULL,
  Description VARCHAR(512) NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE weaknesses
(
  Id VARCHAR(36) NOT NULL,
  Name VARCHAR(128) NOT NULL,
  Description VARCHAR(512) NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE personalrelationships
(
  Id INT NOT NULL,
  Name VARCHAR(128) NOT NULL,
  Description VARCHAR(512) NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE schedules
(
  Id INT NOT NULL,
  Name VARCHAR(128) NOT NULL,
  Description VARCHAR(512) NOT NULL,
  CronExpression VARCHAR(128) NOT NULL,
  HeroId VARCHAR(36) NOT NULL,
  PRIMARY KEY (Id),
  FOREIGN KEY (HeroId) REFERENCES heroes(Id)
);

CREATE TABLE sponsors
(
  Id INT NOT NULL,
  Name INT NOT NULL,
  Age INT NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE sponsorsheroes
(
  Amount FLOAT NOT NULL,
  MoneySource VARCHAR(512) NOT NULL,
  HeroId VARCHAR(36) NOT NULL,
  SponsorId INT NOT NULL,
  FOREIGN KEY (HeroId) REFERENCES heroes(Id),
  FOREIGN KEY (SponsorId) REFERENCES sponsors(Id),
  UNIQUE (HeroId),
  UNIQUE (SponsorId)
);

CREATE TABLE villainsheroes
(
  Winner VARCHAR(24) NOT NULL,
  HeroId VARCHAR(36) NOT NULL,
  VillainId VARCHAR(36) NOT NULL,
  FOREIGN KEY (HeroId) REFERENCES heroes(Id),
  FOREIGN KEY (VillainId) REFERENCES villains(Id),
  UNIQUE (HeroId),
  UNIQUE (VillainId)
);

CREATE TABLE personalrelationshipsheroes
(
  HeroId VARCHAR(36) NOT NULL,
  PersonalrelationshipId INT NOT NULL,
  FOREIGN KEY (HeroId) REFERENCES heroes(Id),
  FOREIGN KEY (PersonalrelationshipId) REFERENCES personalrelationships(Id),
  UNIQUE (HeroId),
  UNIQUE (PersonalrelationshipId)
);

CREATE TABLE skillsheroes
(
  HeroId VARCHAR(36) NOT NULL,
  SkillId CHAR(36) NOT NULL,
  FOREIGN KEY (HeroId) REFERENCES heroes(Id),
  FOREIGN KEY (SkillId) REFERENCES skills(Id),
  UNIQUE (HeroId),
  UNIQUE (SkillId)
);

CREATE TABLE weaknessesvillains
(
  VillianId VARCHAR(36) NOT NULL,
  WeaknessesId VARCHAR(36) NOT NULL,
  FOREIGN KEY (VillianId) REFERENCES villains(Id),
  FOREIGN KEY (WeaknessesId) REFERENCES weaknesses(Id),
  UNIQUE (VillianId),
  UNIQUE (WeaknessesId)
);

CREATE TABLE weaknessesheroes
(
  HeroId VARCHAR(36) NOT NULL,
  WeaknessesId VARCHAR(36) NOT NULL,
  FOREIGN KEY (HeroId) REFERENCES heroes(Id),
  FOREIGN KEY (WeaknessesId) REFERENCES weaknesses(Id),
  UNIQUE (HeroId),
  UNIQUE (WeaknessesId)
);
```

2. Run the following script to populate the heroes table:
```
USE guardian;

insert into heroes (Id, Name, Age) values ('cfc4f3ea-a7a5-49cb-8efe-6d87353c6ff9', 'Andrei', 125);
insert into heroes (Id, Name, Age) values ('1941bb03-c267-4bf6-bd22-f648fa87237e', 'Gardener', 848);
insert into heroes (Id, Name, Age) values ('602fa496-aca7-46f8-84f5-88e123671b44', 'Ole', 677);
insert into heroes (Id, Name, Age) values ('e784ff1f-0a83-43b6-87ca-e7170797a999', 'Curran', 297);
insert into heroes (Id, Name, Age) values ('0ee9d8d6-2bd0-4986-be52-afff60f46b76', 'Rutledge', 151);
insert into heroes (Id, Name, Age) values ('e7f0ed49-a1c4-4b13-a5f5-0def3d1ac868', 'Ardene', 300);
insert into heroes (Id, Name, Age) values ('e0555ce2-9e96-469f-a380-a3c23705c339', 'Ivar', 191);
insert into heroes (Id, Name, Age) values ('bb816be5-4828-4c69-b41e-3eb2a473f1bb', 'Carlita', 586);
insert into heroes (Id, Name, Age) values ('bde305af-2d90-4201-8fc2-e86e61479d80', 'Merrill', 146);
insert into heroes (Id, Name, Age) values ('ea8f8f3a-6316-4fb4-b806-2979e1774fdb', 'Tull', 219);
insert into heroes (Id, Name, Age) values ('99acf788-e178-4a9e-8375-53497e8ab92b', 'Pippa', 918);
insert into heroes (Id, Name, Age) values ('1ecd5e77-603e-4309-99fc-7ab2e857dfc1', 'Ronnie', 220);
insert into heroes (Id, Name, Age) values ('44a55c44-e1a4-4a7a-ae55-1e38ebfbdf63', 'Westleigh', 539);
insert into heroes (Id, Name, Age) values ('2d0e939a-9633-493b-96d7-4e5ecc736080', 'Alan', 46);
insert into heroes (Id, Name, Age) values ('1acd7655-da0c-4281-89b8-6d7e1544c9b0', 'Caddric', 63);
insert into heroes (Id, Name, Age) values ('e70067cf-8a31-4482-8878-1530fe6e134d', 'Lelah', 392);
insert into heroes (Id, Name, Age) values ('f4c4a4db-9984-4dae-98aa-5870e0a825f7', 'Gavin', 674);
insert into heroes (Id, Name, Age) values ('166a7192-9733-4026-b736-5473e337f49a', 'Salmon', 439);
insert into heroes (Id, Name, Age) values ('9ca31a1a-472f-46da-893c-e60983275971', 'Heida', 438);
insert into heroes (Id, Name, Age) values ('3256ee32-5fea-4c63-b877-40aa69e9cdc1', 'Webb', 237);
insert into heroes (Id, Name, Age) values ('e96afeaa-9ac6-4dd3-94d2-b7f9a9932f2d', 'Aeriela', 873);
insert into heroes (Id, Name, Age) values ('60cc804c-e5f4-4611-bbf4-f62a7575e76c', 'Charity', 55);
insert into heroes (Id, Name, Age) values ('3d724816-9cd6-4f87-a2c1-33b02486fa47', 'Davidde', 265);
insert into heroes (Id, Name, Age) values ('b35f04a1-0d09-4acf-9aa7-b58dec3b55b2', 'Luz', 271);
insert into heroes (Id, Name, Age) values ('ab81f9c8-dce6-4bac-84db-635114b2c34f', 'Anatollo', 518);
insert into heroes (Id, Name, Age) values ('65abb3e2-2907-4cdd-9dcb-a1a724528e4e', 'Adela', 742);
insert into heroes (Id, Name, Age) values ('08a01f2b-4973-49f5-b606-e5f1749e153b', 'Shay', 106);
insert into heroes (Id, Name, Age) values ('da447c36-ec05-402a-b301-4f74fa8df019', 'Pattin', 65);
insert into heroes (Id, Name, Age) values ('08366a92-c9bd-48ca-b376-76e14835e6de', 'Brannon', 258);
insert into heroes (Id, Name, Age) values ('532aadcf-5e40-4acf-bc9e-1f9a08bd0504', 'Ada', 426);
insert into heroes (Id, Name, Age) values ('4f2c1a96-5a28-4fbf-a12b-478797c8079c', 'Harrietta', 896);
insert into heroes (Id, Name, Age) values ('50b4d64e-ed41-45fd-a59b-9f6dcaaa60c7', 'Arleyne', 268);
insert into heroes (Id, Name, Age) values ('5fb9054e-8af2-4d25-a99a-c5eed2c97d9f', 'Crystie', 590);
insert into heroes (Id, Name, Age) values ('282529c5-dbcd-4c47-a8f5-e6fca0348caa', 'Gussi', 597);
insert into heroes (Id, Name, Age) values ('7a02f5ae-970e-45d8-82fc-f60ddfb1bfa7', 'Rayner', 488);
insert into heroes (Id, Name, Age) values ('7611c801-65f3-4150-9377-d6817c967ffc', 'Valaria', 107);
insert into heroes (Id, Name, Age) values ('8c0ec77c-60a6-4178-b3d1-ba3c1d3ac797', 'Chrystel', 700);
insert into heroes (Id, Name, Age) values ('4976d13b-6062-4834-9d61-8186d28aab73', 'Clarey', 106);
insert into heroes (Id, Name, Age) values ('036e9d1a-12c0-4f6f-97d6-710ce5a99064', 'Montague', 286);
insert into heroes (Id, Name, Age) values ('1062edc0-b454-41b4-9883-ade078f0e56b', 'Geneva', 138);
insert into heroes (Id, Name, Age) values ('98f848f9-8e79-4851-a12c-8d795c66c18e', 'Hali', 529);
insert into heroes (Id, Name, Age) values ('a3ad9f53-1436-41e7-b667-f7166762e644', 'Rodrique', 447);
insert into heroes (Id, Name, Age) values ('ef32713f-cca0-4cb0-8418-fd1c2c47c0a8', 'Marcy', 47);
insert into heroes (Id, Name, Age) values ('b4273eff-d1b5-4b6d-90c2-345af48b5f8c', 'Cecilio', 925);
insert into heroes (Id, Name, Age) values ('3f8c8377-9b3c-4865-bbb3-9a8d2f32a541', 'Dev', 490);
insert into heroes (Id, Name, Age) values ('286ae563-3cfe-47ba-bca7-87bb0e9ffd62', 'Reba', 706);
insert into heroes (Id, Name, Age) values ('71d821a9-b9cf-462f-a0b9-97ad85906d90', 'Marlyn', 969);
insert into heroes (Id, Name, Age) values ('875b780c-3460-422c-833d-6d3144008539', 'Yetta', 175);
insert into heroes (Id, Name, Age) values ('7ad7a949-c504-4da8-aca9-22b497bba85f', 'Seamus', 62);
insert into heroes (Id, Name, Age) values ('93f82228-bc9e-4ea4-b5ae-dba3d31c96b7', 'Olag', 114);
insert into heroes (Id, Name, Age) values ('a9e085a2-a83e-4cdf-af06-604fab281ce2', 'May', 17);
insert into heroes (Id, Name, Age) values ('49964705-b4c4-4769-835a-607b5e2ffc44', 'Loralyn', 477);
insert into heroes (Id, Name, Age) values ('3720cb7d-5d65-4416-952f-ca1df0a8a3de', 'Linn', 244);
insert into heroes (Id, Name, Age) values ('fa2c1b8a-b0d8-48d7-a2fe-6eae6cc89a1d', 'Dunstan', 607);
insert into heroes (Id, Name, Age) values ('b0d38457-0b02-4a6d-8cc3-2596851c15a7', 'Ethelda', 254);
insert into heroes (Id, Name, Age) values ('24019194-ad7b-4b53-9561-6d93e0d4a35c', 'Raffaello', 444);
insert into heroes (Id, Name, Age) values ('d2b81d15-b03e-4a36-929f-f5a6a89aa5ac', 'Josy', 967);
insert into heroes (Id, Name, Age) values ('09bd4989-81dd-49ce-a1e3-2853d77ce915', 'Abel', 88);
insert into heroes (Id, Name, Age) values ('f14e6690-124b-4765-bb39-5562febc0428', 'Honey', 92);
insert into heroes (Id, Name, Age) values ('6fbf395f-70d5-4411-ba64-45bebeb9427b', 'Darby', 908);
insert into heroes (Id, Name, Age) values ('b0eddfa9-2d47-4477-b960-13c3bb970eaf', 'Judie', 710);
insert into heroes (Id, Name, Age) values ('2cd7d427-f92c-4657-a8b2-57f244cee274', 'Kendre', 466);
insert into heroes (Id, Name, Age) values ('9796507e-35c9-40de-acd8-e27c69b825e8', 'Collen', 175);
insert into heroes (Id, Name, Age) values ('494cb161-321a-492e-bb8e-9a1989b2da96', 'Tiphani', 914);
insert into heroes (Id, Name, Age) values ('de07d38f-6b1b-43a1-a3aa-239ce2fc7169', 'Janenna', 24);
insert into heroes (Id, Name, Age) values ('c1658e0b-f1b5-4482-ad40-b72472d3f4e5', 'Dasie', 602);
insert into heroes (Id, Name, Age) values ('445d59fb-4c0f-41b2-a399-da998cff4917', 'Aimil', 957);
insert into heroes (Id, Name, Age) values ('84b04896-44c9-4a08-a44d-bf4b0a1b9064', 'Ophelie', 825);
insert into heroes (Id, Name, Age) values ('5c8c218c-13b3-47b5-b60f-e85a28937b20', 'Giff', 467);
insert into heroes (Id, Name, Age) values ('0af711ba-9492-4695-9a56-a2b4900ec2d5', 'Vicki', 781);
insert into heroes (Id, Name, Age) values ('ff0dd8d6-0ea1-488c-9f28-c63fbd103a30', 'Frasco', 267);
insert into heroes (Id, Name, Age) values ('61f1cd65-0f6f-45c1-bad1-23ca4c32fb0a', 'Marna', 115);
insert into heroes (Id, Name, Age) values ('c6441d21-c2c9-4e7d-bd68-05f7b9276238', 'Giacopo', 715);
insert into heroes (Id, Name, Age) values ('ba7a38ac-29ff-4046-b1c6-e0beea0655c4', 'Wally', 65);
insert into heroes (Id, Name, Age) values ('abfc12c6-e7c4-40db-a88b-f1b6b8fb8588', 'Elisabeth', 110);
insert into heroes (Id, Name, Age) values ('9c1a0c8f-ab19-4526-8197-904297e8fb5c', 'Danyelle', 675);
insert into heroes (Id, Name, Age) values ('a9407204-5953-475b-900d-76bf5940f072', 'Kym', 668);
insert into heroes (Id, Name, Age) values ('09da2ba3-fa92-4b27-a84b-2ccd936eb9e5', 'Filippo', 176);
insert into heroes (Id, Name, Age) values ('29bf71ee-66b0-4e15-adc5-f6e8b9461fb8', 'Kristina', 87);
insert into heroes (Id, Name, Age) values ('40411d1e-77a3-47fb-b995-1a4eb960aeea', 'Rivkah', 323);
insert into heroes (Id, Name, Age) values ('bf5b97fc-38e1-43e9-86a6-9f0e4650534a', 'Finn', 234);
insert into heroes (Id, Name, Age) values ('0e932192-37a3-4137-aa64-f43edb3e4976', 'Felisha', 568);
insert into heroes (Id, Name, Age) values ('ea22341e-6fe1-4000-a344-953f6ad1c477', 'Shannon', 447);
insert into heroes (Id, Name, Age) values ('6d33ffe0-8e54-4c78-9be6-c265959672d9', 'Tod', 475);
insert into heroes (Id, Name, Age) values ('0904c5a7-c55a-4c5f-a2bd-8f6790d69be2', 'Micheil', 764);
insert into heroes (Id, Name, Age) values ('5636fd30-7417-4b7d-98ea-514f9841c604', 'Lina', 441);
insert into heroes (Id, Name, Age) values ('cbe2da51-b827-49af-9e8e-cfed00014e30', 'Hyacintha', 50);
insert into heroes (Id, Name, Age) values ('5867c037-cb07-4d3b-94d7-2067eab2a8e4', 'Cash', 725);
insert into heroes (Id, Name, Age) values ('e5f39978-2262-4020-834f-0c050f33d79a', 'Evelyn', 782);
insert into heroes (Id, Name, Age) values ('62161eef-c0cd-4cc8-ad6f-a43a5e0ce452', 'Jackie', 546);
insert into heroes (Id, Name, Age) values ('5f87f0f0-2fb5-4af6-a15a-0684728359cf', 'Pincas', 535);
insert into heroes (Id, Name, Age) values ('eceb26d6-3967-4cf2-9801-db86fcf45ae3', 'Bancroft', 619);
insert into heroes (Id, Name, Age) values ('b95a2662-e9ce-4261-9b87-9be528cf49e4', 'Merlina', 61);
insert into heroes (Id, Name, Age) values ('7e4a7242-46ed-4925-9167-81028c4ad455', 'Wolf', 202);
insert into heroes (Id, Name, Age) values ('b5a21794-cb72-447e-80c2-9da8f1593c98', 'Phaedra', 186);
insert into heroes (Id, Name, Age) values ('ae094e44-5272-44a5-b5a6-7eaa290cad97', 'Englebert', 407);
insert into heroes (Id, Name, Age) values ('53b03d48-9e96-4377-91c7-fbf6b2db8d27', 'Dale', 810);
insert into heroes (Id, Name, Age) values ('26772b3c-c02b-43f5-8b9e-06392ff86aab', 'Charlean', 232);
insert into heroes (Id, Name, Age) values ('08e051d5-4005-4d36-a67b-945c8a9bfd54', 'Bobbe', 205);
insert into heroes (Id, Name, Age) values ('4dbec5d4-9c56-412c-9319-dcaacb9c7e0b', 'Harbert', 994);
```

3. Run the following script to populate the villains table:
```
USE guardian;

insert into villains (Id, Name, Age, Origin, Power) values ('f30e0f20-0f54-4b49-a8fa-a044cad7dc82', 'Tiff', 803, 'Eriogonum strictum Benth.', 'intermediate');
insert into villains (Id, Name, Age, Origin, Power) values ('3e0a4e7a-7004-4a80-999f-8107d931c6ee', 'Chelsie', 242, 'Andropogon glaucopsis Elliott', '3rd generation');
insert into villains (Id, Name, Age, Origin, Power) values ('40f7851b-5665-4666-bef3-f19f90cd1507', 'Bette-ann', 914, 'Solidago missouriensis Nutt. var. fasciculata Holz.', 'global');
insert into villains (Id, Name, Age, Origin, Power) values ('ffdd0a91-61a6-46e4-ba45-8be07b767e45', 'Shannah', 388, 'Brassica L.', 'explicit');
insert into villains (Id, Name, Age, Origin, Power) values ('962ac91a-78c3-479f-825c-6c858e7e5efd', 'Rudolph', 533, 'Agalinis linifolia (Nutt.) Britton', 'access');
insert into villains (Id, Name, Age, Origin, Power) values ('0925c37c-f902-477f-bf89-2e5a3fa52a2c', 'Timothee', 123, 'Physostegia virginiana (L.) Benth. ssp. praemorsa (Shinners) Cantino', 'flexibility');
insert into villains (Id, Name, Age, Origin, Power) values ('57649aff-3a29-41b7-ba8c-84c71818fb77', 'Chloe', 15, 'Viola lanceolata L. ssp. occidentalis (A. Gray) N.H. Russell', 'bi-directional');
insert into villains (Id, Name, Age, Origin, Power) values ('02eb1434-3160-4fed-bc0a-eae2afe3b11c', 'Berkly', 950, 'Elymus californicus (Bol. ex Thurb.) Gould', 'projection');
insert into villains (Id, Name, Age, Origin, Power) values ('6af68071-80b8-4324-a257-6787eabdf8fa', 'Teena', 237, 'Lygodium Sw.', 'bottom-line');
insert into villains (Id, Name, Age, Origin, Power) values ('a6a611d4-8e50-43be-93e6-c97eb46bbe17', 'Jacqui', 129, 'Cryptantha clevelandii Greene var. dissita (I.M. Johnst.) Jeps. & Hoover', 'fault-tolerant');
insert into villains (Id, Name, Age, Origin, Power) values ('da9aad0b-2e95-491f-9528-04aaabf91977', 'Jaimie', 506, 'Calothamnus Labill.', 'Reduced');
insert into villains (Id, Name, Age, Origin, Power) values ('098b2c52-5225-412f-bc55-b31534b50dfd', 'Meade', 348, 'Ionactis linariifolius (L.) Greene', 'content-based');
insert into villains (Id, Name, Age, Origin, Power) values ('008a019c-3c6e-4dd3-bc36-ae4fdb03cec5', 'Christen', 871, 'Solanum carolinense L. var. carolinense', 'website');
insert into villains (Id, Name, Age, Origin, Power) values ('ec1d3a7e-ec9f-4586-9ff6-5a7a296a2fb1', 'Kassey', 672, 'Carphephorus Cass.', 'Reverse-engineered');
insert into villains (Id, Name, Age, Origin, Power) values ('253e25c0-d037-4ece-8774-dbaf1ee3fab4', 'Sydelle', 776, 'Corethrogyne filaginifolia (Hook. & Arn.) Nutt. var. filaginifolia', 'Function-based');
insert into villains (Id, Name, Age, Origin, Power) values ('64323883-dbe9-4c29-b392-cbad73e6944f', 'Martie', 960, 'Clarkia speciosa F.H. Lewis & M.E. Lewis ssp. speciosa', 'Ergonomic');
insert into villains (Id, Name, Age, Origin, Power) values ('7baa7e4e-f017-4ca7-80ec-743598dd7faa', 'Janette', 208, 'Gamochaeta Weddell', 'zero administration');
insert into villains (Id, Name, Age, Origin, Power) values ('e071054f-ec9d-4552-9aa8-2c7313c3a8f7', 'Ham', 267, 'Urtica dioica L. ssp. dioica', 'eco-centric');
insert into villains (Id, Name, Age, Origin, Power) values ('644d8fd0-05ec-42a4-a29d-251afbcad40b', 'Lanette', 801, 'Jacquinia L.', 'Customizable');
insert into villains (Id, Name, Age, Origin, Power) values ('45a57825-6eec-40bf-a489-43f4a738b55a', 'Rennie', 964, 'Rhexophyllum subnigrum (Mitt.) Thér. ex Hilp.', 'regional');
insert into villains (Id, Name, Age, Origin, Power) values ('8c0a7a68-9217-4f53-94db-1353151c009a', 'Ciro', 679, 'Euclidium syriacum (L.) W.T. Aiton', 'data-warehouse');
insert into villains (Id, Name, Age, Origin, Power) values ('a37514a5-42e2-4ff9-9be4-2b06a6ff5615', 'Orbadiah', 557, 'Penstemon linarioides A. Gray ssp. coloradoensis (A. Nelson) D.D. Keck', 'middleware');
insert into villains (Id, Name, Age, Origin, Power) values ('be4b67e2-75d7-4373-bca5-8f02bc12833d', 'Willis', 759, 'Casearia nitida Jacq.', 'structure');
insert into villains (Id, Name, Age, Origin, Power) values ('a62a75e2-41f2-4e27-8777-843f886ef135', 'Merry', 422, 'Silene rectiramea B.L. Rob.', 'Open-source');
insert into villains (Id, Name, Age, Origin, Power) values ('20120208-fd2b-4d03-a672-77ae955f4187', 'Ezri', 139, 'Heliotropium L.', 'Open-source');
insert into villains (Id, Name, Age, Origin, Power) values ('3e130c0b-485d-42cd-b2a0-3537c2b0915f', 'Lucio', 541, 'Bartonia Muhl. ex Willd.', 'Assimilated');
insert into villains (Id, Name, Age, Origin, Power) values ('6b39a71c-a54e-4779-ad9a-3d1a23ff3f6e', 'Chad', 635, 'Bryoria spiralifera Brodo & D. Hawksw.', 'service-desk');
insert into villains (Id, Name, Age, Origin, Power) values ('e84844b3-f747-49c9-bb59-0c8fbeb1e726', 'Koral', 486, 'Viola douglasii Steud.', 'Mandatory');
insert into villains (Id, Name, Age, Origin, Power) values ('9e8c2028-6976-4768-aac2-e6254f0e5ee4', 'Gavrielle', 308, 'Fouquieria splendens Engelm.', 'product');
insert into villains (Id, Name, Age, Origin, Power) values ('d0647229-7001-4354-b663-70bcdc6877a1', 'Penrod', 77, 'Lomatium nevadense (S. Watson) J.M. Coult. & Rose var. parishii (J.M. Coult. & Rose) Jeps.', 'approach');
insert into villains (Id, Name, Age, Origin, Power) values ('3ec90c4c-8091-4c5a-b007-ede14a15a368', 'Carlie', 85, 'Lepanthes eltoroensis Stimson', 'bottom-line');
insert into villains (Id, Name, Age, Origin, Power) values ('9d7554d9-39b3-4832-aa34-6629d3aeaaac', 'Maryanne', 774, 'Callistemon R. Br.', 'client-server');
insert into villains (Id, Name, Age, Origin, Power) values ('a1969b9a-ab80-4237-a185-37da40a3bd4a', 'Catlaina', 168, 'Thermopsis rhombifolia (Nutt. ex Pursh) Nutt. ex Richardson', 'Object-based');
insert into villains (Id, Name, Age, Origin, Power) values ('98eda398-e540-4b1d-b73e-601daa809211', 'Cullin', 60, 'Cyphomeris Standl.', 'strategy');
insert into villains (Id, Name, Age, Origin, Power) values ('98451f4c-edc5-4192-8396-267c64b598c6', 'Hebert', 483, 'Dendrophthora Eichl.', 'Business-focused');
insert into villains (Id, Name, Age, Origin, Power) values ('a2b2552a-183e-46cb-8d13-12536073a3a8', 'Land', 19, 'Stylosanthes hamata (L.) Taubert', 'Reactive');
insert into villains (Id, Name, Age, Origin, Power) values ('374168d0-8440-45be-a567-af3d2d9bebe1', 'Bronny', 76, 'Sagittaria lancifolia L. ssp. lancifolia', 'zero defect');
insert into villains (Id, Name, Age, Origin, Power) values ('b77bfd6f-3f75-4bed-a8ba-849f3c2fda9c', 'Silvain', 912, 'Trichomanes punctatum Poir. ssp. floridanum W. Boer', 'help-desk');
insert into villains (Id, Name, Age, Origin, Power) values ('a9681d6f-9ded-4095-a1d2-81bf137d5f50', 'Iseabal', 773, 'Lepechinia hastata (A. Gray) Epling', 'framework');
insert into villains (Id, Name, Age, Origin, Power) values ('d8f8a881-47b4-4038-b1b9-d5f63b186b8f', 'Barry', 613, 'Blighia K.D. Koenig', 'well-modulated');
insert into villains (Id, Name, Age, Origin, Power) values ('cd6a57b3-8133-41d3-a4d6-8ba59e0686cc', 'Nicolina', 321, 'Gaura sinuata Nutt. ex Ser.', 'multi-state');
insert into villains (Id, Name, Age, Origin, Power) values ('35daeb2b-11a9-4eb6-a2bd-a8ce9527ddab', 'Dar', 627, 'Achillea millefolium L. var. occidentalis DC.', 'Visionary');
insert into villains (Id, Name, Age, Origin, Power) values ('f32fdc5c-1fa5-4da2-afcb-4485aa9964b4', 'Archibaldo', 977, 'Dalea laniceps Barneby', 'leverage');
insert into villains (Id, Name, Age, Origin, Power) values ('3fe30ae0-bdfb-4c58-88ab-f7914253b3b1', 'Raimund', 77, 'Crataegus dallasiana Sarg.', 'Operative');
insert into villains (Id, Name, Age, Origin, Power) values ('c9ea9e82-09e6-4172-ad58-5d4427c861ae', 'Cynthia', 588, 'Arthonia perminuta Willey', 'Switchable');
insert into villains (Id, Name, Age, Origin, Power) values ('4581b154-40be-4bc6-8fa5-84516c25f5bf', 'Melesa', 753, 'Chelone L.', 'impactful');
insert into villains (Id, Name, Age, Origin, Power) values ('010af38b-141b-42ae-9a4c-82e9cd9e4d8e', 'Mercy', 470, 'Bupleurum odontites L.', 'Decentralized');
insert into villains (Id, Name, Age, Origin, Power) values ('7f53cc2f-5a65-4f99-9ccc-e2e73310c979', 'Jemimah', 159, 'Taxodium mucronatum Ten.', 'adapter');
insert into villains (Id, Name, Age, Origin, Power) values ('d7383242-d1c6-4d16-aac8-bfe37103ae31', 'Kamila', 11, 'Lopadium dodgei Herre', 'Business-focused');
insert into villains (Id, Name, Age, Origin, Power) values ('268aa88f-c049-4465-82a0-fc755a3b4172', 'Harriette', 157, 'Anthracothecium varians R.C. Harris', 'Upgradable');
insert into villains (Id, Name, Age, Origin, Power) values ('480e2374-c7e7-4651-bc44-cc0cd36ae44c', 'Juan', 383, 'Marsilea crenata C. Presl', 'explicit');
insert into villains (Id, Name, Age, Origin, Power) values ('85f218c9-8e9b-41cf-ba59-b0cad38d530f', 'Ellyn', 927, 'Miconia tetrastoma Naud.', 'moderator');
insert into villains (Id, Name, Age, Origin, Power) values ('afc864f1-1ce3-4153-98cf-aef0fe3862b5', 'Sophie', 140, 'Brazoria truncata (Benth.) Engelm. & A. Gray', 'mobile');
insert into villains (Id, Name, Age, Origin, Power) values ('a48f41e6-e94a-46b5-be2c-1154ce6e08a8', 'Wernher', 780, 'Celtis L.', 'Synchronised');
insert into villains (Id, Name, Age, Origin, Power) values ('1046023e-1a2c-4886-9c77-479fbf4d0d56', 'Horst', 310, 'Pedicularis L.', 'policy');
insert into villains (Id, Name, Age, Origin, Power) values ('212e8f7b-48d7-40e8-8eda-ee74694a4595', 'Anitra', 214, 'Eremochloa leersioides (Munro) Hack.', 'application');
insert into villains (Id, Name, Age, Origin, Power) values ('b91e69b9-7b83-438e-8b3f-cc37cb6e225a', 'Porter', 544, 'Cynoglossum L.', 'Fully-configurable');
insert into villains (Id, Name, Age, Origin, Power) values ('44b37d65-e649-4d73-957b-4014f58fb0d7', 'Lotte', 749, 'Erigeron algidus Jeps.', 'logistical');
insert into villains (Id, Name, Age, Origin, Power) values ('265f65d2-ce3e-47af-87cf-fbab36cc7d08', 'Matilda', 490, 'Cuscuta pentagona Engelm. var. pubescens (Engelm.) Yunck.', 'asynchronous');
insert into villains (Id, Name, Age, Origin, Power) values ('1814c8e8-9cdc-4859-a00d-db5eaf2206a2', 'Nada', 409, 'Caloplaca cirrochroa (Ach.) Th. Fr.', 'Compatible');
insert into villains (Id, Name, Age, Origin, Power) values ('166ffa1a-554f-41a4-8781-4819c03e9026', 'Karlene', 829, 'Persea palustris (Raf.) Sarg.', 'model');
insert into villains (Id, Name, Age, Origin, Power) values ('8269295c-3a2b-4919-8176-0c7f2e2b675f', 'Lindsey', 872, 'Reutealis trisperma (Blanco) Airy Shaw', 'parallelism');
insert into villains (Id, Name, Age, Origin, Power) values ('b2ae0117-cacf-4e0d-8f0f-4ff2190a00d8', 'Julieta', 382, 'Acacia ampliceps Maslin', 'zero defect');
insert into villains (Id, Name, Age, Origin, Power) values ('350e77ed-7c4d-47ef-8880-eaf77bbb3283', 'Bogart', 84, 'Cleomella longipes Torr.', 'Switchable');
insert into villains (Id, Name, Age, Origin, Power) values ('b4810bfa-34a6-4a00-bfec-597f99433648', 'Twyla', 702, 'Rosa villosa L.', 'multimedia');
insert into villains (Id, Name, Age, Origin, Power) values ('2ac3e5fe-f098-426c-a630-c09aa7b33f7d', 'Theobald', 89, 'Calamagrostis epigeios (L.) Roth ssp. epigeios', 'User-centric');
insert into villains (Id, Name, Age, Origin, Power) values ('749ee6b6-af3e-4ac8-945d-173cf2b2e48d', 'Matti', 894, 'Copernicia alba Morong ex Morong & Britton', 'capacity');
insert into villains (Id, Name, Age, Origin, Power) values ('c1935c23-361a-454d-a06b-578c934cc179', 'Olav', 816, 'Rhamnus cathartica L.', 'instruction set');
insert into villains (Id, Name, Age, Origin, Power) values ('7dd3b3e6-3064-4e78-be7d-0e404f155bd0', 'Reuven', 234, 'Spartina patens (Aiton) Muhl.', 'Reverse-engineered');
insert into villains (Id, Name, Age, Origin, Power) values ('d30a35d3-8147-4df5-8a43-ff747a4211a2', 'Inglis', 420, 'Graphis poitaeoides Nyl.', 'global');
insert into villains (Id, Name, Age, Origin, Power) values ('bc199375-a155-46a5-b463-95ea6a6fb733', 'Samantha', 97, 'Carex bullata Schkuhr ex Willd.', 'methodology');
insert into villains (Id, Name, Age, Origin, Power) values ('31aafea1-e67e-4c3d-a93f-60131529e87d', 'Marsha', 612, 'Voitia hyperborea Grev. & Arn.', '4th generation');
insert into villains (Id, Name, Age, Origin, Power) values ('aa605a7f-d2f0-4ef6-9185-8d25b5062945', 'Retha', 381, 'Opuntia ammophila Small', 'service-desk');
insert into villains (Id, Name, Age, Origin, Power) values ('d1a948be-b033-4695-aef7-e16ec1411014', 'Henrieta', 212, 'Galanthus L.', 'systematic');
insert into villains (Id, Name, Age, Origin, Power) values ('d5fa7db2-dec7-42d9-819d-a6aa94969b31', 'Stu', 894, 'Euphrasia subarctica Raup', 'focus group');
insert into villains (Id, Name, Age, Origin, Power) values ('1846ef22-56d3-445f-b3e6-4717212201db', 'Carlo', 989, 'Aureolaria pedicularia (L.) Raf. var. austromontana Pennell', 'website');
insert into villains (Id, Name, Age, Origin, Power) values ('162bd152-b057-4aa5-afc8-fa7307352f96', 'Fabio', 803, 'Hydrocotyle verticillata Thunb.', 'secondary');
insert into villains (Id, Name, Age, Origin, Power) values ('dee30574-f818-4969-a4ec-ba762b357cb7', 'Ruth', 15, 'Leptogium chloromelum (Sw. ex Ach.) Nyl.', 'foreground');
insert into villains (Id, Name, Age, Origin, Power) values ('ee4cb181-aca5-4e44-b4c7-749933239113', 'Goddart', 818, 'Phlox peckii Wherry, nom. inq.', 'even-keeled');
insert into villains (Id, Name, Age, Origin, Power) values ('ac22ef32-b721-4536-93e1-5074e5de4f9d', 'Alano', 724, 'Atriplex argentea Nutt. ssp. argentea', 'Enterprise-wide');
insert into villains (Id, Name, Age, Origin, Power) values ('6434bd3d-882d-4334-9f4c-c559c48e009f', 'Brit', 656, 'Phacelia linearis (Pursh) Holz.', 'regional');
insert into villains (Id, Name, Age, Origin, Power) values ('18615d0d-0629-40e9-9d24-be82bb08a066', 'Dov', 689, 'Leptospermum glabrescens Wakef.', 'artificial intelligence');
insert into villains (Id, Name, Age, Origin, Power) values ('902441a1-145a-491e-94da-a097ce71bdbe', 'Vyky', 873, 'Trachyxiphium heteroicum (Cardot) W.R. Buck', 'Implemented');
insert into villains (Id, Name, Age, Origin, Power) values ('323c467f-327d-4c70-b2b4-378ea4770a82', 'Nance', 519, 'Arctium minus Bernh.', 'executive');
insert into villains (Id, Name, Age, Origin, Power) values ('15fef2c2-80d1-4088-b011-561c5179ba03', 'Hamnet', 727, 'Setaria setosa (Sw.) P. Beauv. var. setosa', 'clear-thinking');
insert into villains (Id, Name, Age, Origin, Power) values ('80c5e908-f420-4445-bf91-4a448d99ac4e', 'Spencer', 522, 'Labordia venosa Sherff', 'Profit-focused');
insert into villains (Id, Name, Age, Origin, Power) values ('a77946d4-7bd2-4640-acb8-8905a4a92bc2', 'Britt', 807, 'Cyperus pallidicolor (Kük.) G. Tucker', 'Organized');
insert into villains (Id, Name, Age, Origin, Power) values ('2e35b6af-080c-4a71-8508-036f8bb8a746', 'Otto', 336, 'Psorothamnus fremontii (Torr. ex A. Gray) Barneby', 'static');
insert into villains (Id, Name, Age, Origin, Power) values ('c492daf7-9853-4239-9fef-d53456f1bcbd', 'Kellen', 242, 'Tibouchina urvilleana (DC.) Cogn.', 'attitude-oriented');
insert into villains (Id, Name, Age, Origin, Power) values ('94e1d671-405b-4122-a570-4b2094c06c95', 'Harrie', 283, 'Allionia incarnata L. var. villosa (Standl.) B.L. Turner', 'neutral');
insert into villains (Id, Name, Age, Origin, Power) values ('489daa60-cbed-4c62-86b8-a52edf18b7bb', 'Bree', 984, 'Vulpia microstachys (Nutt.) Munro var. ciliata (Beal) Lonard & Gould', 'Phased');
insert into villains (Id, Name, Age, Origin, Power) values ('f7df0742-25c1-4350-b619-a52fcc6b620e', 'Lucienne', 874, 'Wilkesia gymnoxiphium A. Gray', 'Monitored');
insert into villains (Id, Name, Age, Origin, Power) values ('a2205db5-e6e3-4499-a557-244767bf348c', 'Gradey', 99, 'Hydrophyllum macrophyllum Nutt.', 'methodology');
insert into villains (Id, Name, Age, Origin, Power) values ('e8a5c652-6fa9-4c73-8177-09a9c50a11b5', 'Olivero', 567, 'Carex L.', 'empowering');
insert into villains (Id, Name, Age, Origin, Power) values ('f402ba9a-f56a-4aad-8467-2a6c58f89093', 'Judd', 432, 'Lomatium nevadense (S. Watson) J.M. Coult. & Rose', 'full-range');
insert into villains (Id, Name, Age, Origin, Power) values ('60b6c3cf-b2e2-48c3-b5e1-8572bfb681c7', 'Cordy', 408, 'Sphagnum flexuosum Dozy & Molk.', 'Triple-buffered');
insert into villains (Id, Name, Age, Origin, Power) values ('d82df37e-65e3-43a4-812d-5905fceeb118', 'Starlene', 676, 'Carex raymondii Calder', 'interface');
insert into villains (Id, Name, Age, Origin, Power) values ('f2e71d95-73b3-46ba-a661-a0034d54063d', 'Wren', 711, 'Lonchitis hirsuta L.', 'framework');
insert into villains (Id, Name, Age, Origin, Power) values ('fa652e75-47a9-4749-a190-f6d542a9b77f', 'Kippar', 822, 'Spergularia platensis (Camb.) Fenzl', 'Organized');
insert into villains (Id, Name, Age, Origin, Power) values ('41b1eee4-1b06-46a2-9b3d-8c345ac0e5e1', 'Gabbey', 710, 'Cryptantha stricta (Osterh.) Payson', 'impactful');
```
