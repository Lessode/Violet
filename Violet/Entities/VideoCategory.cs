using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Violet.Entities
{
    public class VideoCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VideoCategoryId { get; set; }
        public string Name { get; set; }
    }
}
