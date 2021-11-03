﻿using System.Collections.Generic;

namespace Directory.Entities.Models
{
    public class Organization
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Subdivision> Subdivisions { get; set; } = new List<Subdivision>();
    }
}
