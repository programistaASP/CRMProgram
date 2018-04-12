using System;
using CRMAplication.Models.Enums;

namespace CRMAplication.Interfaces

{
    public interface IBasicEntity
    {
        Capacity capacity { get; set; }
        Brand Brand { get; set; }
        CarType CarType { get; set; }
        DateTime DateCreate { get; set; }
        DateTime Modificationdate { get; set; }
        string RecordAuthor { get; set; }
        string RecordModificationAuthor { get; set; }
        bool Activity { get; set; }
    }
}