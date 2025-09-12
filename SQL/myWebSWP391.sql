CREATE DATABASE ev_charging;
use ev_charging;
go

CREATE TABLE Drivers (
    ID int PRIMARY KEY,
    FullName nnvarchar(100) NOT NULL,
    --Email nnvarchar(100) UNIQUE NOT NULL,
    -- PhoneNumber nnvarchar(20),
    -- Password nvarchar(200) NOT NULL,
    -- CarModel nvarchar(100),
    -- LicensePlate nvarchar(20)
)
