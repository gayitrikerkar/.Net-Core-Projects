using ModelsBasic.Models;

namespace ModelsBasic.Repository
{
    public class StudentRepository : IStudent
    {
        public List<StudentModel> getAllStudents()
        {
            return Datasource();
        }

        public StudentModel getStudentById(int id)
        {
            return Datasource().Where(x => x.RollNo == id).FirstOrDefault();
        }
        private List<StudentModel> Datasource()
        {
            return new List<StudentModel>
            {   new StudentModel {RollNo=1,Name="Rucha",Standard=10} ,
              new StudentModel {RollNo=2,Name="Geet",Standard=11} ,
                new StudentModel {RollNo=3,Name="Prit",Standard=12} };

        }
    }
}
