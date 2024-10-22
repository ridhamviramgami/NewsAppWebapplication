using Microsoft.EntityFrameworkCore;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Context
{
    public class Informia_Context : DbContext
    {
        public Informia_Context(DbContextOptions<Informia_Context> options) : base(options) { }
        public DbSet<UserMaster> usermaster { get; set; }
    }
}
