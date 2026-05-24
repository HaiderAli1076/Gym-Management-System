using Microsoft.Data.Sqlite;
using System;
using System.Windows.Forms;
using BCrypt.Net;

namespace GymManagementSystem.Database
{
    public class DatabaseHelper
    {
        private static string dbPath = "gym.db";
        private static string connectionString = $"Data Source={dbPath}";

        public static void InitializeDatabase()
        {
            try
            {
                using (SqliteConnection conn = new SqliteConnection(connectionString))
                {
                    conn.Open();

                    string[] tables = {

                        // Users table
                        @"CREATE TABLE IF NOT EXISTS Users (
                            Id       INTEGER PRIMARY KEY AUTOINCREMENT,
                            Username TEXT NOT NULL UNIQUE,
                            Password TEXT NOT NULL
                        );",

                        // FIX 1: Renamed 'Contact' -> 'Phone', added missing 'Status' column
                        @"CREATE TABLE IF NOT EXISTS Members (
                            Id             INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name           TEXT NOT NULL,
                            Phone          TEXT,
                            MembershipType TEXT,
                            JoinDate       TEXT,
                            ExpiryDate     TEXT,
                            Fee            REAL DEFAULT 0,
                            Status         TEXT DEFAULT 'Active'
                        );",

                        // Staff table — correct, no changes needed
                        @"CREATE TABLE IF NOT EXISTS Staff (
                            Id      INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name    TEXT NOT NULL,
                            Role    TEXT,
                            Contact TEXT,
                            Salary  REAL DEFAULT 0,
                            JoinDate TEXT
                        );",

                        // Equipment table — correct, no changes needed
                        @"CREATE TABLE IF NOT EXISTS Equipment (
                            Id            INTEGER PRIMARY KEY AUTOINCREMENT,
                            EquipmentName TEXT NOT NULL,
                            Category      TEXT,
                            FeePerSession REAL DEFAULT 0,
                            Status        TEXT DEFAULT 'Available'
                        );"
                    };

                    foreach (string sql in tables)
                    {
                        using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                            cmd.ExecuteNonQuery();
                    }

                    // Seed default admin user
                    string checkAdmin = "SELECT COUNT(*) FROM Users WHERE Username='admin'";
                    using (SqliteCommand cmd = new SqliteCommand(checkAdmin, conn))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 0)
                        {
                            string hashed = BCrypt.Net.BCrypt.HashPassword("1234");
                            string insert = "INSERT INTO Users (Username, Password) VALUES ('admin', @pwd)";
                            using (SqliteCommand insertCmd = new SqliteCommand(insert, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@pwd", hashed);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FULL ERROR:\n\n" + ex.ToString());
            }
        }

        public static bool ValidateUser(string username, string password)
        {
            try
            {
                using (SqliteConnection conn = GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT Password FROM Users WHERE Username = @u";
                    using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        string hashedPassword = cmd.ExecuteScalar()?.ToString();

                        if (hashedPassword == null)
                            return false;

                        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static SqliteConnection GetConnection()
        {
            return new SqliteConnection(connectionString);
        }
    }
}
