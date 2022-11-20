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