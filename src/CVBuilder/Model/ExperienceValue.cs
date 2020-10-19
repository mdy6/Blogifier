using System;

namespace CVBuilder.Model
{
    public class ExperienceValue : IZoneValue
    {
        public string Content { get; set; } = string.Empty;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
