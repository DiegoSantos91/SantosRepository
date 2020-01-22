using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Status : BaseEntity
    {
        public string StatusName { get; set; }

        public StatusType StatusEnum { get; set; }

        public enum StatusType
        {
            Disponible = 1,

            [Display(Name = "No Disponible")]
            NoDisponible = 2,

        }
    }
}
