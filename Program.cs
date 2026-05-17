using CAR_RENTAL_MANAGEMENT_SYSTEM.UI;
using System;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            RunMigrations();
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
            
            ApplicationConfiguration.Initialize();
            Application.Run(new frmLogin());
        }

        private static void RunMigrations()
        {
            try
            {
                using (var con = DAL.DBConnection.GetConnection())
                {
                    con.Open();
                    string script = @"
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'ImagePath' AND Object_ID = Object_ID(N'Cars'))
                        BEGIN
                            ALTER TABLE Cars ADD ImagePath NVARCHAR(255) NULL;
                        END

                        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Feedback]') AND type in (N'U'))
                        BEGIN
                            CREATE TABLE [dbo].[Feedback] (
                                [FeedbackID] INT IDENTITY(1,1) PRIMARY KEY,
                                [UserID] INT NOT NULL,
                                [Rating] INT CHECK (Rating >= 1 AND Rating <= 5),
                                [Comments] NVARCHAR(MAX),
                                [FeedbackDate] DATETIME DEFAULT GETDATE(),
                                FOREIGN KEY (UserID) REFERENCES Users(UserID)
                            );
                        END";
                    using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(script, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Ignore migration errors (e.g. DB not reachable yet, handled later)
                Console.WriteLine("Migration error: " + ex.Message);
            }
        }
    }
}