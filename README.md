# GUARDIAN BACKEND SERVICE

## Database relational model diagram  

![image](https://user-images.githubusercontent.com/55267781/204730494-e27462b5-2370-413d-9df5-4412cd25047c.png)

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
  Id VARCHAR(36) NOT NULL,
  Id VARCHAR(36) NOT NULL,
  FOREIGN KEY (Id) REFERENCES villains(Id),
  FOREIGN KEY (Id) REFERENCES weaknesses(Id),
  UNIQUE (Id),
  UNIQUE (Id)
);
```
