using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.Entity {
    public class Instrument : BaseEntity {
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
