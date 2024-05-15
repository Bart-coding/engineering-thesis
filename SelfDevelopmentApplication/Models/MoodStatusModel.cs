using System;

namespace SelfDevelopmentApplication.Models
{
    class MoodStatusModel
    {
        public int Id { get; set; }
        public short Gratitude { get; set; }
        public short Joy { get; set; }
        public short Stress { get; set; }
        public short Anger { get; set; }
        public DateTime Day { get; set; }

    }
}
