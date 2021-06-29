using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net;



namespace DAL
{
    public class UserDAL
    {
        public string AddUser(User user, Children[] children)
        {
            try
            {
                using (CityBookEntities entities = new CityBookEntities())
                {
                    //string id = entities.User.FirstOrDefault(x => x.IDnumber == user.IDnumber).IDnumber;
                    //if (id==user.IDnumber)
                    //    return "There is a user with the same ID, please try again";
                    entities.User.Add(user);
                    entities.SaveChanges();
                    int id1 = entities.User.FirstOrDefault(x => x.IDnumber == user.IDnumber).Id;
                    if (children != null)
                    {
                        foreach (var item in children)
                        {
                            item.ParentId = id1;
                            entities.Children.Add(item);
                        }
                    }
                    entities.SaveChanges();
                   // CreateExcel(user);
                    return "User saved successfully";
                }
            }
            catch (Exception)
            {


                throw;
            }
        }

       
    }
}
