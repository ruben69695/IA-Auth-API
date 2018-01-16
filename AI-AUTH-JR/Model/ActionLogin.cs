using System;
using System.Collections.Generic;

namespace AI_AUTH_JR.Model
{
    public partial class ActionLogin
    {
        public int Id { get; set; }
        public int? EmotionId { get; set; }
        public int? ObjectId { get; set; }
        public DateTime? Date { get; set; }

        public Emotions Emotion { get; set; }
        public Objects Object { get; set; }
    }
}
