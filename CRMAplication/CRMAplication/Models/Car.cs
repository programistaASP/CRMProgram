﻿using System;

namespace CRMAplication.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string RegistryNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime Modificationdate { get; set; }
        public string RecordAuthor { get; set; }
        public string RecordModificationAuthor { get; set; }
    }
}