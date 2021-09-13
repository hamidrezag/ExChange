using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Post
{
    public class PostDto
    {
        public long UserId { get; set; }
        public string PostContent { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
