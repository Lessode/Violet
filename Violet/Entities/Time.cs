using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Violet.Entities
{
    public class Time
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimeId { get; set; }
        public long Remain { get; set; }
        public long Used { get; set; }
    }
}
