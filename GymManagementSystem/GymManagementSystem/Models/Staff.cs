using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }     // Trainer, Receptionist, etc.
        public string Contact { get; set; }
        public string JoinDate { get; set; }
        public decimal Salary { get; set; }
    }
}
