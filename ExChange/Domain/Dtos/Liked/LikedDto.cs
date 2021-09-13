using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Liked
{
    public class LikedDto
    {
        public long UserId { get; set; }
        public long PostId { get; set; }
    }
}
