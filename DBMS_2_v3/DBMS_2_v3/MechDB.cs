using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_2_v3
{
    class MechDB : DbContext
    {
        public MechDB() : base("MechConnection") { }

        public DbSet<Mech> Mechas { get; set; }
    }
}