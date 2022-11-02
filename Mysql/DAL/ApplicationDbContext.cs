using System;
using System.Xml.Xsl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Mysql.Models;
using ServerVersion = Microsoft.SqlServer.Management.Common.ServerVersion;
using Pomelo.EntityFrameworkCore.MySql;

namespace Mysql.DAL
{
    public class ApplicationDbContext: DbContext
    {
        protected readonly IConfiguration Configuration;
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration):base(options)
        {
            Configuration = configuration; 
            
        }
        
        
        public DbSet<test> test{get; set;}
    }
}