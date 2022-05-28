using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Domain.Entities.Base
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            IsActive = false;
            IsDeleted = false;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
