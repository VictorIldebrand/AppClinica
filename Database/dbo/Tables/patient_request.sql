CREATE TABLE [patient_request] (
  [id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [date_solicitation] date,
  [date_treatment] date,
  [status] varchar(10) NOT NULL CHECK (status IN('cancelado','atendido','avaliado')),
  [id_student] integer,
  [new_patient] bit,
  [procedure] varchar(512),
  [note] varchar(512),
  [active] bit
)