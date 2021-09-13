using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Comment
{
    public class CommentDto
    {
        public long PostId { get; set; }
        public long UserId { get; set; }
        public string Context { get; set; }
    }
}
