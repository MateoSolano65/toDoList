USE toDoList
GO

CREATE OR ALTER PROCEDURE ITask
  @title NVARCHAR(255)
AS
BEGIN
  INSERT INTO tasks
    (title)
  VALUES
    (@title);
END