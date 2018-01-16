using System;
using System.Collections.Generic;

namespace AI_AUTH_JR.Model
{
    public partial class Objects
    {
        public Objects()
        {
            ActionLogin = new HashSet<ActionLogin>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Enabled { get; set; }
        public int? NumberOfObjects { get; set; }

        public ICollection<ActionLogin> ActionLogin { get; set; }
    }
}
