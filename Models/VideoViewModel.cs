using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Violet.Models
{
    public class VideoViewModel
    {
        public int VideoId { get; set; }
        public int VideoTypeId { get; set; }
        public virtual VideoType VideoType { get; set; }
        public int VideoCategoryId { get; set; }
        public virtual VideoCategory VideoCategory { get; set; }
    }
}
