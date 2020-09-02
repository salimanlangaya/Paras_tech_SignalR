using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Paras_tech_SignalR.Models
{
    [Table("Machine", Schema = "dbo")]
    public class Machine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MachineID { get; set; }
        public string MachineName { get; set; }
        public string Status { get; set; }
    }
}
