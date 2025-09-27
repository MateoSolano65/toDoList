USE toDoList
GO

CREATE OR ALTER PROCEDURE UTask
  @id INT,
  @title NVARCHAR(255),
  @completed BIT
AS
BEGIN
  IF NOT EXISTS (SELECT *
  FROM tasks
  WHERE id = @id)
  BEGIN
    RAISERROR('Task not found', 16, 1);
    RETURN;
  END

  BEGIN TRY
    BEGIN TRANSACTION;
    
    UPDATE tasks
      SET title = @title, completed = @completed, createdAt = GETDATE()
    WHERE id = @id;
    
    COMMIT TRANSACTION;
  END TRY
  BEGIN CATCH
    IF @@TRANCOUNT > 0
      ROLLBACK TRANSACTION;
    
    THROW;
  END CATCH
END