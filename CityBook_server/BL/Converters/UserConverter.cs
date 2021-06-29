using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BL.Converters
{
    class UserConverter
    {
        public static User ConvertUser(UserDTO userDTO)
        {
            User user = new User();
            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.IDnumber = userDTO.IDnumber;
            user.Min = userDTO.Min;
            user.HMO = userDTO.HMO;
            user.DateOfBirth = userDTO.DateOfBirth;
            return user;
        }
    }
}
