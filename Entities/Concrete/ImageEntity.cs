using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ImageEntity : IEntity
    {
        public int Id { get; set; }
        public int AreasId { get; set; }
        public byte[] Url { get; set; }
    }
}
