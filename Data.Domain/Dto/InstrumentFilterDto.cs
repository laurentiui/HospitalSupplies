using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.Dto {
    public class InstrumentFilterDto {
        public string FreeText { get; set; }
        public string NameContains { get; set; }
        public string ColorContains { get; set; }
    }
}
