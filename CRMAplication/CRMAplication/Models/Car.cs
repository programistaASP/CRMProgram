using CRMAplication.Interfaces;
using System;

namespace CRMAplication.Models
{
    public class Car : IBasicEntity
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string NumerRejestracyjny { get; set; }
        public bool Aktywność { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime Modificationdate { get; set; }
        public string RecordAuthor { get; set; }
        public string RecordModificationAuthor { get; set; }        
    }
}