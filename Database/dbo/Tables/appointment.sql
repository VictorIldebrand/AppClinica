CREATE TABLE [appointment] (
  [id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [date] date,
  [status] INT NOT NULL CHECK (status IN('cancelado','confirmado','notificado')),
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