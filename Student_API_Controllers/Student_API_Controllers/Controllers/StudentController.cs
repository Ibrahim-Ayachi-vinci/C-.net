using Microsoft.AspNetCore.Mvc;

namespace Student_API_Controllers.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student { Id = 1, FirstName = "Paul", LastName = "Ochon", Birthdate = new DateTime(1950, 12, 1) },
            new Student { Id = 2, FirstName = "Daisy", LastName = "Drathey", Birthdate = new DateTime(1970, 12, 1) },
            new Student { Id = 3, FirstName = "Elie", LastName = "Coptaire", Birthdate = new DateTime(1980, 12, 1) }
        };

        [HttpGet]
        public ActionResult<List<Student>> GetAllStudent()
        {
            return Ok(_students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id) { 
            
            var student = _students.FirstOrDefault(x => x.Id == id);

            if (student == null) { 
                return NotFound();
            }
            return Ok(student);

        }

        [HttpPost]
        public ActionResult PostStudent(Student newStudent) {
            newStudent.Id = _students.Count() > 0 ? _students.Max(x => x.Id) + 1 : 1;

            _students.Add(newStudent);
            return Ok();
        }



    }
}
