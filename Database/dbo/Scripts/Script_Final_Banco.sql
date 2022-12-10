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
GO

CREATE TABLE [professor] (
  [id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [email] varchar(255),
  [password] varchar(255),
  [name] varchar(255),
  [rp] varchar(255),
  [phone] varchar(255),
  [active] bit
)
GO

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
GO

CREATE TABLE [patient] (
  [id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [email] varchar(255),
  [password] varchar(255),
  [num_folder] varchar(255),
  [name] varchar(255),
  [cpf] varchar(255),
  [phone] varchar(255),
  [active] bit
)
GO

CREATE TABLE [schedule] (
  [id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [name] varchar(255),
  [active] bit
)
GO

CREATE TABLE [appointment] (
  [id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [date] date,
  [status] integer NOT NULL CHECK (status IN('cancelado','confirmado','notificado')),
  [cancellation_reason] varchar(512),
  [id_schedule] integer,
  [id_patient] integer,
  [id_employee] integer,
  [id_student] integer,
  [new_patient] bit,
  [type] varchar(512),
  [note] varchar(512),
  [duration] varchar(30),
  [companion] BIT, 
  [location] VARCHAR(50)
)
GO

CREATE TABLE [patient_request] (
  [id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [date_solicitation] date,
  [date_treatment] date,
  [status] bit,
  [id_student] integer,
  [new_patient] bit,
  [procedure] varchar(512),
  [note] varchar(512),
  [active] bit
)
GO

CREATE TABLE [patient_order] (
  [id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [date_solicitation] date,
  [status] varchar(10) NOT NULL CHECK (status IN('concluido','aguardando')),
  [id_patient] integer,
  [specialty] varchar(512),
  [active] bit
)
GO

CREATE TABLE [schedule_professor] (
  [id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [id_schedule] integer,
  [id_professor] integer
)
GO

CREATE TABLE [notification] (
  [id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [id_appointment] integer,
  [id_patient_request] integer,
  [read] bit,
  [message] nvarchar(MAX)
)
GO

CREATE TABLE [dbo].[user]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
    [name] NVARCHAR(MAX) NOT NULL,
    [email] NVARCHAR(MAX) NOT NULL,
    [password] NVARCHAR(MAX) NOT NULL,
    [active] BIT NOT NULL
)
GO

ALTER TABLE [appointment] ADD FOREIGN KEY ([id_patient]) REFERENCES [patient] ([id])
GO

ALTER TABLE [appointment] ADD FOREIGN KEY ([id_schedule]) REFERENCES [schedule] ([id])
GO

ALTER TABLE [appointment] ADD FOREIGN KEY ([id_employee]) REFERENCES [employee] ([id])
GO

ALTER TABLE [appointment] ADD FOREIGN KEY ([id_student]) REFERENCES [student] ([id])
GO

ALTER TABLE [patient_request] ADD FOREIGN KEY ([id_student]) REFERENCES [student] ([id])
GO

ALTER TABLE [patient_request] ADD FOREIGN KEY ([id_schedule_professor]) REFERENCES [schedule_professor] ([id])
GO

ALTER TABLE [patient_order] ADD FOREIGN KEY ([id_patient]) REFERENCES [patient] ([id])
GO

ALTER TABLE [schedule_professor] ADD FOREIGN KEY ([id_schedule]) REFERENCES [schedule] ([id])
GO

ALTER TABLE [schedule_professor] ADD FOREIGN KEY ([id_professor]) REFERENCES [professor] ([id])
GO

ALTER TABLE [notification] ADD FOREIGN KEY ([id_appointment]) REFERENCES [appointment] ([id])
GO

ALTER TABLE [notification] ADD FOREIGN KEY ([id_patient_request]) REFERENCES [patient_request] ([id])
GO
