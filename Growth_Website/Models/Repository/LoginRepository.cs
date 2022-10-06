using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using testing2.Models;
using Growth_Website.Models.Interface;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Growth_Website.Models.Repository
{
   
    public class LoginRepository: depLogin
    {
        public Login CheckLoginInfo(Login sp)
        {
            Signup? p = new Signup();
            Login p2 = new Login();
           
            var db = new DbContextClass();
            db.Signups.Where(p=>p.userName == sp.LoginUserName && p.Password == sp.LoginPassword && p.loginas=="user").ToList().ForEach(p=>p2.Isavailable=true);
            p = db.Signups.Where(p => p.userName == sp.LoginUserName && p.Password == sp.LoginPassword && p.loginas == "user").FirstOrDefault();

            if (p != null)
            {
                p2.id = p.Id;
                p2.LoginUserName = p.userName;
            }




            return p2;
        }
        public Login CheckLoginInfoAdmin(Login sp)
        {
          
            Signup? p = new Signup();
            Login? p2 = new Login();

            var db = new DbContextClass();
            db.Signups.Where(p => p.userName == sp.LoginUserName && p.Password == sp.LoginPassword && p.loginas == "admin").ToList().ForEach(p => p2.Isavailable = true);
            p = db.Signups.Where(p => p.userName == sp.LoginUserName && p.Password == sp.LoginPassword && p.loginas == "admin").FirstOrDefault();

            if(p!=null)
            {
                p2.id = p.Id;
                p2.LoginUserName = p.userName;
            }







            return p2;
        }
    }
}
