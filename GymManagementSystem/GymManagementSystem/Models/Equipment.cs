using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string EquipmentName { get; set; }
        public string Category { get; set; }
        public decimal FeePerSession { get; set; }
        public string Status { get; set; }
    }
}