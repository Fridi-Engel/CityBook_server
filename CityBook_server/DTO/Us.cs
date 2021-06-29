using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Us
    {
        public UserDTO user { get; set; }
        public ChildrenDTO[] children { get; set; }
    }
}
