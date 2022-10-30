CREATE TABLE [notification] (
  [id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [id_student] integer,
  [id_patient] integer,
  [status] integer,
  [message] nvarchar(MAX)
)