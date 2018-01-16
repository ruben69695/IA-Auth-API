using System;
using System.Collections.Generic;

namespace AI_AUTH_JR.Model
{
    public partial class Emotions
    {
        public Emotions()
        {
            ActionLogin = new HashSet<ActionLogin>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Enabled { get; set; }
        public int? NumberOfEmotions { get; set; }

        public ICollection<ActionLogin> ActionLogin { get; set; }
    }
}
