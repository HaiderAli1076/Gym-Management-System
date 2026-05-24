using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string MembershipType { get; set; }  // Monthly, Quarterly, Yearly
        public decimal Fee { get; set; }
        public string JoinDate { get; set; }
        public string ExpiryDate { get; set; }
        public string Status { get; set; }
    }
}
