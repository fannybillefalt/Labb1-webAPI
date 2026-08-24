using System.Collections.Generic;

namespace Labb1_webAPI.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Height { get; set; }
        public int Weight { get; set; }
        public List<string> Abilities { get; set; } = new List<string>();
        public List<string> Forms { get; set; } = new List<string>();
    }
}
