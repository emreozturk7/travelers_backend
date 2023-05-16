
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class ResetPassword : IEntity
    {
        public int Id { get; set; }
        [StringLength(6)]
        public string Code { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
    }
}
