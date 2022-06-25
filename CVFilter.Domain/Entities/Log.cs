using System;
using System.Collections.Generic;
using System.Text;
using CVFilter.Domain.Entities.Base;

namespace CVFilter.Domain.Entities
{
    public class Log : BaseEntity
    {
        public string ErrorMessage  { get; set; }
    }
}
