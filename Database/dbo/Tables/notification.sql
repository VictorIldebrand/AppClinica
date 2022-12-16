CREATE TABLE [notification] (
  [id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [id_appointment] integer,
  [id_patient_request] integer,
  [read] bit,
  [message] nvarchar(MAX)
)