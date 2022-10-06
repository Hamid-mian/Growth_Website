using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Growth_Website.Models.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using testing2.Models;

namespace Growth_Website.Models.Repository
{
    public class SignupRepository : depSignup
    {
       public string AddSignupData(Signup sp)
        {
            string message = null;
            Signup p = new Signup();
            if (sp.userName == null || sp.Email == null || sp.Age == 0 || sp.Password == null)
            {
                message = "bad request";
            }
            else
            {
                p.userName = sp.userName;
                p.Password = sp.Password;
                p.Email = sp.Email;
                p.Age = sp.Age;
                p.loginas = sp.loginas;
                var db = new DbContextClass();
                db.Signups.Add(p);
                db.SaveChangesAsync();
            }

            return message;
        }

        public string AddSignupDataAdmin(Signup sp)
        {
            string message = null;
            Signup p = new Signup();
            if (sp.userName == null || sp.Email == null || sp.Age == 0 || sp.Password == null)
            {
                message = "bad request";
            }
            else
            {
                p.userName = sp.userName;
                p.Password = sp.Password;
                p.Email = sp.Email;
                p.Age = sp.Age;
                p.loginas = sp.loginas;
                var db = new DbContextClass();
                db.Signups.Add(p);
                db.SaveChangesAsync();
            }

            return message;
        }



    }
}
