CREATE TABLE [student] (
  [id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [name] varchar(255),
  [ra] varchar(255),
  [email] varchar(255),
  [password] varchar(255),
  [phone] varchar(255),
  [period] varchar(2),
  [active] bit
)