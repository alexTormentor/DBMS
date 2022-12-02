using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstMech_v2
{
    class MechDB : DbContext
    {
        public MechDB() : base("MechConnection") { }

        public DbSet<Mech> Mechas { get; set; }
    }
}
