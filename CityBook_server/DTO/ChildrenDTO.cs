using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChildrenDTO
    {
        public string IDnumber { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public int Id { get; set; }
    }
}
