CREATE TABLE [appointment] (
  [id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [date] date,
  [status] varchar(10) NOT NULL CHECK (status IN('cancelado','confirmado','notificado')),
  [cancellation_reason] varchar(512),
  [id_schedule] integer,
  [id_patient] integer,
  [id_employee] integer,
  [new_patient] bit,
  [type] varchar(512),
  [note] varchar(512)
)