using System;

namespace CRMAplication.Interfaces

{
    public interface IBasicEntity
    {
        DateTime DateCreate { get; set; }
        DateTime Modificationdate { get; set; }
        string RecordAuthor { get; set; }
        string RecordModificationAuthor { get; set; }
        bool Activity { get; set; }
    }
}