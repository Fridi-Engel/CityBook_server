using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BL.Converters
{
    class ChildrenConverter
    {
        public static Children ConvertChildren(ChildrenDTO childrenDTO)
        {
            Children children = new Children();
            children.Name = childrenDTO.Name;
            children.IDnumber = childrenDTO.IDnumber;
            children.DateOfBirth = childrenDTO.DateOfBirth;
            return children;
        }
    }
}
