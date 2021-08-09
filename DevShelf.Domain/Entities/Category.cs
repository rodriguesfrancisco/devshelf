using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category(string description) 
        {
            Description = description;
        }
        protected Category() { }

        public string Description { get; private set; }
    }
}
