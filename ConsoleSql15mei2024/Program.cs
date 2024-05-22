using Microsoft.EntityFrameworkCore;

namespace ConsoleSql15mei2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SQL oefeningen!");

            DatabaseDbContext dbContext = new DatabaseDbContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            dbContext.Database.ExecuteSqlRaw(@"CREATE TABLE flower
(
art_code int NOT NULL,  
name varchar(20) NOT NULL,
color varchar(10) NOT NULL,
CONSTRAINT pk_flower PRIMARY KEY (art_code)
);");

            dbContext.Database.ExecuteSqlRaw(@"-- kolom toevoegen 
ALTER TABLE flower
ADD price money NULL; ");

            // dbContext.Database.ExecuteSqlRaw(@"-- kolomdefinitie wijzigen
            //ALTER TABLE flower
            //ALTER COLUMN color varchar(30);");


            dbContext.Database.ExecuteSqlRaw(@"CREATE TABLE Course (
  Nr int NOT NULL,
  Title varchar(20) NOT NULL,
  PRIMARY KEY  (Nr)
);");


            dbContext.Database.ExecuteSqlRaw(@"CREATE TABLE Teacher (
  Nr int NOT NULL,
  Firstname varchar (20) NOT NULL,
  Lastname varchar (20) NOT NULL,
  Street varchar (20) NOT NULL,
  StreetNr varchar (6) NOT NULL,
  PostalCode char(4) NOT NULL,
  City varchar (20) NOT NULL,
  PRIMARY KEY  (Nr)
);");


            dbContext.Database.ExecuteSqlRaw(@"
-- creatie van tabel met FK 
CREATE TABLE Assignment
(
CourseNr int NOT NULL,
TeacherNr int NOT NULL,
PRIMARY KEY(CourseNr, TeacherNr),
FOREIGN KEY(CourseNr) REFERENCES Course(Nr),
FOREIGN KEY(TeacherNr) REFERENCES Teacher(Nr) 
);");


            dbContext.Database.ExecuteSqlRaw(@"
-- een UNIQUE INDEX laat toe om te zorgen dat een (niet-PK) kolom
-- unieke waarden moet bevatten
-- we willen dat alle planten een unieke naam krijgen
CREATE UNIQUE INDEX idx_unieke_plantennaam ON flower(name);

-- een INDEX laat toe om sneller op te zoeken en te sorteren
-- op bepaalde kolommen
CREATE INDEX idx_plantenkleur ON flower(color);
-- MAAR een index maakt dat het toevoegen, wijzigen, verwijderen
-- van records in de tabel trager gaat");


            dbContext.Database.ExecuteSqlRaw(@"-- alle gegevens (records) uit tabel flower opvragen
SELECT *   -- * => alle kolommen
FROM flower;");


            dbContext.Database.ExecuteSqlRaw(@"-- slide 67
select 200.00 + 1908.30 + 
170.00 - 1150.00 - 1128.30;  -- uitkomst:0");


            dbContext.Database.ExecuteSqlRaw(@"select cast(200.00 as float) + 1908.30 + 
170.00 - 1150.00 - 1128.30; -- uitkomst is niet nul");

            Console.ReadLine();
        }
    }
}
