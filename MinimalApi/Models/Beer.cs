using System;
using System.Collections.Generic;

namespace MinimalApi.Models
{
    public partial class Beer
    {
        public int Id { get; set; }
        public string Company { get; set; } = null!;
        public int Alcohol { get; set; }
        public int Length { get; set; }
        public string Name { get; set; } = null!;
    }
}
