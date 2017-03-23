﻿using System;
using System.Linq;
using System.Web.Http;
using SoaProject.Models;
namespace SoaProject.Controllers
{
    public class LoginController : ApiController
    {
        article007DataContext dc = new article007DataContext("Server=tcp:article007.database.windows.net,1433;Initial Catalog=article007;Persist Security Info=False;User ID=article007;Password=article_007;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        [Route("Login/get")]
        [HttpPost]
        public bool login([FromBody]LoginMaster l)
        {
            bool b = getAuthentication(l);
            return b;
        } 
        public bool getAuthentication(LoginMaster l)
        {
            try
            {
                var a = (from b in dc.GetTable<AuthorMaster>()
                         where b.mail == l.mail
                         where b.pass == l.pass
                         select b).SingleOrDefault();
                if (a != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
    }
}