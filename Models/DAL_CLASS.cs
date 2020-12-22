using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCproject.Models
{
    public interface IDAL
    {
        List<Test> GetAllExams();
        List<Test> GetExamsToday();

        void AddExam(Test a);
       

    }
    public class DAL_CLASS : IDAL
    {
        static private List<Test> Exams { get; set; }

        public DAL_CLASS()
        {
            Exams = new List<Test>();
            Exams.Add(new Test { Name = "Math", TimeGiven = "2hours", Date = DateTime.Today, Maxscore = 35 });
            Exams.Add(new Test { Name = "Phy", TimeGiven = "2hours", Date = DateTime.Today.AddDays(1), Maxscore = 35 });
            Exams.Add(new Test { Name = "Chem", TimeGiven = "3hours", Date = DateTime.Today.AddDays(2), Maxscore = 35 });
            Exams.Add(new Test { Name = "Electronics", TimeGiven = "2hours", Date = DateTime.Today.AddDays(3), Maxscore = 35 });
         
        }

        public List<Test> GetAllExams()
        {
            return Exams;
        }

        public List<Test> GetExamsToday()
        {
            IEnumerable<Test> exaams = Exams.Where(x => x.Date == DateTime.Today);
            return Exams.ToList();
        }

        public void AddExam(Test a)
        {
            Exams.Add(a);
        }


    }

     
}
