using CRMAplication.Interfaces;
using System;

namespace CRMAplication.Models
{
    public class Car : IBasicEntity
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Registrationnumber { get; set; }
        public bool Activity { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime Modificationdate { get; set; }
        public string RecordAuthor { get; set; }
        public string RecordModificationAuthor { get; set; }        
    }
}