//using Microsoft.AspNetCore.Mvc;
//using SRMS.Models;
//using System.Runtime.Intrinsics.Arm;

//namespace SRMS.Controllers
//{
//    public class StudentController : Controller
//    {
//        private readonly StudentDbContext stdDb;

//        public StudentController(StudentDbContext stdDb )
//        {
//            this.stdDb = stdDb;
//        }
//        public IActionResult StudentIndex()
//        {
//            var stdData = stdDb.Students.ToList();
//            return View(stdData);
//        }
//        public IActionResult AddStudent()
//        {
//            return View();
//        }
//        [HttpPost]
//        public async Task<IActionResult> AddStudent(StudentModel StdM)
//        {
//            if (ModelState.IsValid)
//            {
//                await stdDb.Students.AddAsync(StdM);
//                await stdDb.SaveChangesAsync();
//                TempData["SuccessMessage"] = "Record Create successfully!";
//                ModelState.Clear();
//             return RedirectToAction("StudentIndex");
//            }
//            return View();
//        }
//        [Route("/Student/EditStudent/{RollNo}")]
//        public IActionResult StudentDetails(int? RollNo)
//        {
//            // Fetch the student from the database based on the provided RollNo
//            var student = stdDb.Students.FirstOrDefault(s => s.RollNo == RollNo);

//            // Check if the student is found
//            if (student == null)
//            {
//                return NotFound(); // Or handle the case where the student is not found
//            }

//            return View(student); // Pass the student data to the view
//        }
//        public async Task<IActionResult> UpdateStudent(int RollNo)
//        {
//            if (RollNo == null || stdDb.Students == null)
//            {
//                return NotFound();
//            }

//            var stdData = await stdDb.Students.FindAsync(RollNo);
//            if(stdData == null)
//            {
//                return NotFound();
//            }
//            return View(stdData);
//        }
//        [HttpPost]
//        public async Task<IActionResult>UpdateStudent(int rollNo,StudentModel std)
//        {
//            if (rollNo ! == std.RollNo)
//            {
//                return NotFound();
//            }
//            if (ModelState.IsValid)
//            {
//                stdDb.Students.Update(std);
//                await stdDb.SaveChangesAsync();
//                return RedirectToAction("StudentIndex");
//            }
//            return View(std); 
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using SRMS.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SRMS.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext stdDb;

        public StudentController(StudentDbContext stdDb)
        {
            this.stdDb = stdDb;
        }

        public IActionResult StudentIndex()
        {
            var stdData = stdDb.Students.ToList();
            return View(stdData);
        }


        [HttpGet("/Student/StudentDetails/{RollNo}")]
        public IActionResult StudentDetails(int? RollNo)
        {
            if (RollNo == null)
            {
                return NotFound();
            }

            var stdData = stdDb.Students.FirstOrDefault(s => s.RollNo == RollNo);

            if (stdData == null)
            {
                return NotFound();
            }

            return View(stdData);
        }



        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentModel StdM)
        {
            if (ModelState.IsValid)
            {
                await stdDb.Students.AddAsync(StdM);
                await stdDb.SaveChangesAsync();
                TempData["SuccessMessage"] = "Record created successfully!";
                ModelState.Clear();
                return RedirectToAction("StudentIndex");
            }
            return View();
        }

        [HttpGet("/Student/UpdateStudent/{RollNo}")]
        public IActionResult UpdateStudent(int? RollNo)
        {
            if (RollNo == null)
            {
                return NotFound();
            }

            var stdData = stdDb.Students.FirstOrDefault(s => s.RollNo == RollNo);

            if (stdData == null)
            {
                return NotFound();
            }

            return View(stdData);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStudent(int rollNo, StudentModel std)
        {
            if (rollNo != std.RollNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                stdDb.Students.Update(std);
                await stdDb.SaveChangesAsync();
                return RedirectToAction("StudentIndex");
            }

            return View(std);
        }
    }
}
