using System;
using System.Windows.Forms;
using GymManagementSystem.Database;
using GymManagementSystem.Forms;

namespace GymManagementSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                DatabaseHelper.InitializeDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("FULL ERROR:\n\n" + ex.ToString());
            }

            Application.Run(new LoginForm());
        }
    }
}