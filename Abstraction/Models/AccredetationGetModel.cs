using Abstraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Models
{
    public class AccredetationGetModel
    {
        int Id { get; set; }
        public Status Status { get; set; }

        public DateOnly Expires { get; set; }
    }
}
