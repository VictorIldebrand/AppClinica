CREATE TABLE [employee] (
  [id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [email] varchar(255),
  [cpf] varchar(15),
  [password] varchar(255),
  [name] varchar(255),
  [phone] varchar(255),
  [active] bit,
  [is_admin] bit, 
)