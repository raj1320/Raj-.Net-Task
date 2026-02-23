using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTMS.Repository.Entities
{
    public class Score
    {
        public int Id { get; set; }
        public int ScoreValue {  get; set; }
        
        public int TrainingProgramId { get; set; }
        public int EnrolledEmployeeId { get; set; }

        public TrainingProgram trainingProgram { get; set; } = null!;

        public EnrolledEmployee enrolledEmployee { get; set; } = null!;
    }
}
