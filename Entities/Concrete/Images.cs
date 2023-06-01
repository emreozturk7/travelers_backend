using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Images : IEntity
    {
        public int Id { get; set; }
        public int AreasId { get; set; }
        public IFormFile Url { get; set; }
    }
}
