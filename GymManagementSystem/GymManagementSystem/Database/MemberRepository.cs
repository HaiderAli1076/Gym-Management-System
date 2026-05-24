using GymManagementSystem.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GymManagementSystem.Database
{
    public class MemberRepository
    {
        // FIX: reads 'Phone' and 'Status' — now matches the corrected DB schema
        public static List<Member> GetAllMembers(string search = "")
        {
            List<Member> list = new List<Member>();
            using (SqliteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Members WHERE Name LIKE @search";
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Member
                            {
                                Id             = Convert.ToInt32(reader["Id"]),
                                Name           = reader["Name"].ToString(),
                                Phone          = reader["Phone"].ToString(),
                                MembershipType = reader["MembershipType"].ToString(),
                                Fee            = Convert.ToDecimal(reader["Fee"]),
                                JoinDate       = reader["JoinDate"].ToString(),
                                ExpiryDate     = reader["ExpiryDate"].ToString(),
                                Status         = reader["Status"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public static bool AddMember(Member m)
        {
            try
            {
                using (SqliteConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"INSERT INTO Members
                                   (Name, Phone, MembershipType, Fee, JoinDate, ExpiryDate, Status)
                                   VALUES (@name, @phone, @type, @fee, @join, @expiry, @status)";
                    using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name",   m.Name);
                        cmd.Parameters.AddWithValue("@phone",  m.Phone);
                        cmd.Parameters.AddWithValue("@type",   m.MembershipType);
                        cmd.Parameters.AddWithValue("@fee",    m.Fee);
                        cmd.Parameters.AddWithValue("@join",   m.JoinDate);
                        cmd.Parameters.AddWithValue("@expiry", m.ExpiryDate);
                        cmd.Parameters.AddWithValue("@status", m.Status);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add member error: " + ex.Message);
                return false;
            }
        }

        public static bool UpdateMember(Member m)
        {
            try
            {
                using (SqliteConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"UPDATE Members
                                   SET Name=@name, Phone=@phone, MembershipType=@type,
                                       Fee=@fee, JoinDate=@join, ExpiryDate=@expiry, Status=@status
                                   WHERE Id=@id";
                    using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name",   m.Name);
                        cmd.Parameters.AddWithValue("@phone",  m.Phone);
                        cmd.Parameters.AddWithValue("@type",   m.MembershipType);
                        cmd.Parameters.AddWithValue("@fee",    m.Fee);
                        cmd.Parameters.AddWithValue("@join",   m.JoinDate);
                        cmd.Parameters.AddWithValue("@expiry", m.ExpiryDate);
                        cmd.Parameters.AddWithValue("@status", m.Status);
                        cmd.Parameters.AddWithValue("@id",     m.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update member error: " + ex.Message);
                return false;
            }
        }

        public static bool DeleteMember(int id)
        {
            try
            {
                using (SqliteConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM Members WHERE Id=@id";
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
                MessageBox.Show("Delete member error: " + ex.Message);
                return false;
            }
        }

        public static int GetTotalMembers()
        {
            using (SqliteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Members";
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                    return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static int GetActiveMembers()
        {
            using (SqliteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Members WHERE Status='Active'";
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                    return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
