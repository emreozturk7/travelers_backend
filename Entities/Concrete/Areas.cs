using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Areas :IEntity
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int CategoryId { get; set; }
        public string City { get; set; }
        public int Star { get; set; }
        public string About { get; set; }
        public string Adress { get; set; }
        public string Title { get; set; }
    }
}
