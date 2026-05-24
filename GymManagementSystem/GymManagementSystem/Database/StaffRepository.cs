using GymManagementSystem.Database;
using GymManagementSystem.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagementSystem.Database
{
    public class StaffRepository
    {
        public static List<Staff> GetAllStaff(string search = "")
        {
            List<Staff> staffList = new List<Staff>();
            using (SqliteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Staff WHERE Name LIKE @search";
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            staffList.Add(new Staff
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Role = reader["Role"].ToString(),
                                Contact = reader["Contact"].ToString(),
                                Salary = Convert.ToDecimal(reader["Salary"]),
                                JoinDate = reader["JoinDate"].ToString()
                            });
                        }
                    }
                }
            }
            return staffList;
        }

        public static bool AddStaff(Staff s)
        {
            try
            {
                using (SqliteConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"INSERT INTO Staff (Name, Role, Contact, Salary, JoinDate)
                                   VALUES (@name, @role, @contact, @salary, @join)";
                    using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", s.Name);
                        cmd.Parameters.AddWithValue("@role", s.Role);
                        cmd.Parameters.AddWithValue("@contact", s.Contact);
                        cmd.Parameters.AddWithValue("@salary", s.Salary);
                        cmd.Parameters.AddWithValue("@join", s.JoinDate);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add staff error: " + ex.Message);
                return false;
            }
        }

        public static bool UpdateStaff(Staff s)
        {
            try
            {
                using (SqliteConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"UPDATE Staff
                                   SET Name=@name, Role=@role, Contact=@contact,
                                       Salary=@salary, JoinDate=@join
                                   WHERE Id=@id";
                    using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", s.Name);
                        cmd.Parameters.AddWithValue("@role", s.Role);
                        cmd.Parameters.AddWithValue("@contact", s.Contact);
                        cmd.Parameters.AddWithValue("@salary", s.Salary);
                        cmd.Parameters.AddWithValue("@join", s.JoinDate);
                        cmd.Parameters.AddWithValue("@id", s.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update staff error: " + ex.Message);
                return false;
            }
        }

        public static bool DeleteStaff(int id)
        {
            try
            {
                using (SqliteConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM Staff WHERE Id=@id";
                    using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete staff error: " + ex.Message);
                return false;
            }
        }

        public static int GetTotalStaff()
        {
            using (SqliteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Staff";
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                    return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}


