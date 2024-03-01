using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftT7
{
    internal class TeacherPupil
    {
        public int TId { get; set; }
        public Teacher Teacher { get; set; }

        public int PId { get; set; }
        public Pupil Pupil { get; set; }
    }
}
