using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCproject.Models
{
    public class EmpScore
    {

        public int ID { get; set; }

        public int EmpID { get; set; }

        public string EmpName { get; set; }

        public DateTime ExamDate { get; set; }

        public int ExamScore { get; set; }
    }
}
