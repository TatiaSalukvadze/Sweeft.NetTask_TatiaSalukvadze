using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftT7
{
    internal class Pupil
    {
        [Key]
        public int PId { get; set; }
        [Required]
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }
    }
}
