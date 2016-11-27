using System;
using System.Xml;

namespace VivaFund.DomainModels
{
    public class BaseModel
    {
        public DateTime InsertedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}
