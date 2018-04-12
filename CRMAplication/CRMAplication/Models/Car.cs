using CRMAplication.Models.Enums;
using System;
using CRMAplication.Interfaces;

namespace CRMAplication.Models
{
    public class Car : IBasicEntity
    {
        public int Id { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public CarType CarType { get; set; }
        public Capacity capacity { get; set; }
        public string Registrationnumber { get; set; }
        public bool Activity { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime Modificationdate { get; set; }
        public string RecordAuthor { get; set; }
        public string RecordModificationAuthor { get; set; }      
        public string DescriptionOfProblem { get; set; }
    }
}