using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodeFirstMech_v2
{
    public partial class Meches
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Armore { get; set; }
        public string Weapon { get; set; }
        public string Engine { get; set; }
        public string Type { get; set; }
        public int SerialId { get; set; }
    }
}
