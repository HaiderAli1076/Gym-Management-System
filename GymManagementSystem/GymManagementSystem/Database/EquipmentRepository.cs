using GymManagementSystem.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GymManagementSystem.Database
{
    public class EquipmentRepository
    {
        public static List<Equipment> GetAllEquipment(string search = "")
        {
            List<Equipment> list = new List<Equipment>();
            using (SqliteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Equipment WHERE EquipmentName LIKE @search";
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Equipment
                            {
                                Id            = Convert.ToInt32(reader["Id"]),
                                EquipmentName = reader["EquipmentName"].ToString(),
                                Category      = reader["Category"].ToString(),
                                FeePerSession = Convert.ToDecimal(reader["FeePerSession"]),
                                Status        = reader["Status"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public static bool AddEquipment(Equipment e)
        {
            try
            {
                using (SqliteConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"INSERT INTO Equipment (EquipmentName, Category, FeePerSession, Status)
                                   VALUES (@name, @cat, @fee, @status)";
                    using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name",   e.EquipmentName);
                        cmd.Parameters.AddWithValue("@cat",    e.Category);
                        cmd.Parameters.AddWithValue("@fee",    e.FeePerSession);
                        cmd.Parameters.AddWithValue("@status", e.Status);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add equipment error: " + ex.Message);
                return false;
            }
        }

        public static bool UpdateEquipment(Equipment e)
        {
            try
            {
                using (SqliteConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"UPDATE Equipment
                                   SET EquipmentName=@name, Category=@cat,
                                       FeePerSession=@fee, Status=@status
                                   WHERE Id=@id";
                    using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name",   e.EquipmentName);
                        cmd.Parameters.AddWithValue("@cat",    e.Category);
                        cmd.Parameters.AddWithValue("@fee",    e.FeePerSession);
                        cmd.Parameters.AddWithValue("@status", e.Status);
                        cmd.Parameters.AddWithValue("@id",     e.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update equipment error: " + ex.Message);
                return false;
            }
        }

        // FIX: Removed extra closing brace that caused compile error
        public static bool DeleteEquipment(int id)
        {
            try
            {
                using (SqliteConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM Equipment WHERE Id=@id";
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
                MessageBox.Show("Delete equipment error: " + ex.Message);
                return false;
            }
        }
    }
}
