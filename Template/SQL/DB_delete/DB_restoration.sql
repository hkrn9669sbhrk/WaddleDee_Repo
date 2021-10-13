/******************************************************************************/

EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'[削除するDB名]'
GO
USE [master]
GO
DROP DATABASE [削除するDB名]
GO

/******************************************************************************/