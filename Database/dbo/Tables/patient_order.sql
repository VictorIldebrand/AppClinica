CREATE TABLE [patient_order] (
  [id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [date_solicitation] date,
  [status] varchar(10) NOT NULL CHECK (status IN('concluido','aguardando')),
  [id_patient] integer,
  [specialty] varchar(512),
  [active] bit
)