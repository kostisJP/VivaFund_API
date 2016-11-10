using System;

namespace VivaFund.DomainModels
{
    public class BaseModel
    {
        public DateTime InsertedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; }

        public bool IsActive { get; set; }
    }
}