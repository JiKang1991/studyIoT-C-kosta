using MVCWebTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCWebTest.Context
{
    public class MemberDAO : DbContext
    {
        public DbSet<Member> memberDBSet { get; set; }

        public MemberDAO() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Coding\WebTest\WebDB.mdf;Integrated Security=True;Connect Timeout=30")
        {

        }

    }
}