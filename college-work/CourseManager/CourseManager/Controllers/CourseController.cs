using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseManager.Data;
using CourseManager.Entities;
using CourseManager.Models;
using CourseManager.Services;

namespace CourseManager.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseManagerDbContext context;
        private readonly IEmailService emailService;

        public CourseController(CourseManagerDbContext context, IEmailService emailService)
        {
            this.context = context;
            this.emailService = emailService;
        }
        public IActionResult Index()
        {
            var coursesViewModel = new CoursesViewModel();
            coursesViewModel.Courses = context.Courses.Include(c => c.Students).ToList();
            return View(coursesViewModel);
        }

        [HttpGet]
        [Route("Course/Create")]
        public IActionResult Create()
        {
            return View(new Course());
        }

        [HttpPost]
        [Route("Course/Create")]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                context.Courses.Add(course);
                context.SaveChanges();
                return RedirectToAction("Detail", new { id = course.CourseID });
            }
            return View(course);
        }

        [HttpGet]
        [Route("Course/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var course = context.Courses.Find(id);
            return View(course);
        }

        [HttpPost]
        [Route("Course/Edit/{id}")]
        public IActionResult Edit(int id, Course course)
        {
            if (ModelState.IsValid)
            {
                context.Courses.Update(course);
                context.SaveChanges();
                return RedirectToAction("Detail", new { id = course.CourseID });
            }
            return View(course);

        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            CoursesViewModel coursesViewModel = new CoursesViewModel();
            coursesViewModel.Course = context.Courses
                .Include(c => c.Students)
                .FirstOrDefault(c => c.CourseID == id);

            coursesViewModel.Student = new Student { CourseID = id };
            if (coursesViewModel.Course == null)
            {
                return NotFound();
            }

            ViewData["invitesNotSent"] = coursesViewModel.Course.Students.Count(s => s.Status == EnrolmentStatus.ConfirmationMessageNotSent);
            ViewData["invitesSent"] = coursesViewModel.Course.Students.Count(s => s.Status == EnrolmentStatus.ConfirmationMessageSent);
            ViewData["invitesConfirmed"] = coursesViewModel.Course.Students.Count(s => s.Status == EnrolmentStatus.EnrollmentConfirmed);
            ViewData["invitesDeclined"] = coursesViewModel.Course.Students.Count(s => s.Status == EnrolmentStatus.EnrollmentDeclined);


            return View(coursesViewModel);
        }

        [HttpPost]
        public IActionResult Detail(int id, EnrolmentStatus status)
        {
            Course course = context.Courses
                .Include(c => c.Students)
                .FirstOrDefault(c => c.CourseID == id);

            List<Student> students = course.Students
                .Where(s => s.Status == EnrolmentStatus.ConfirmationMessageNotSent)
                .ToList();

            // Update the status of the students
            foreach (var student in students)
            {
                student.Status = EnrolmentStatus.ConfirmationMessageSent;
                context.Students.Update(student);

            }
            context.SaveChanges();

            // Send the confirmation email

            foreach (var student in students)
            {
                string confirmUrl = Url.Action("Confirm", "Course", new { cId = course.CourseID, sId = student.StudentID }, Request.Scheme);

                string subject = $"Enrolment confirmation for {course.Name} required";
                string body = $"<p><strong>Hello {student.Name},</strong></p>";
                body += $"<p>Your request to enroll in the course: '{course.Name}' in room {course.RoomNumber} ";
                body += $"starting {course.StartDate} with instructor {course.Instructor} has been received</p>";
                body += $"<p>We are pleased to have you in the course so if you could ";
                body += $"<a href='{confirmUrl}'>confirm your enrolment</a> as soon as ";
                body += $"possible that would be appreciated!</p>";
                body += $"<p>Sincerely,</p><p>The Course Manager App.</p>";

                emailService.SendEmail(student.Email, subject, body);
            }

            return RedirectToAction("Detail", new { id = id });
        }


        [Route("Course/NewStudent/{id}")]
        public IActionResult NewStudent(int id, Student student)
        {
            if (ModelState.IsValid)
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
            return RedirectToAction("Detail", new { id = student.CourseID });
        }

        [Route("Course/{cid}/Confirm/{sid}")]
        [HttpGet]
        public IActionResult Confirm(int cid, int sid)
        {
            CoursesViewModel coursesViewModel = new CoursesViewModel();
            coursesViewModel.Course = context.Courses
                .Include(c => c.Students)
                .FirstOrDefault(c => c.CourseID == cid);

            coursesViewModel.Student = context.Students.Find(sid);
            return View(coursesViewModel);
        }

        [Route("Course/{cid}/Confirm/{sid}")]
        [HttpPost]
        public IActionResult Confirm(int cid, int sid, string choice)
        {
            CoursesViewModel coursesViewModel = new CoursesViewModel();
            coursesViewModel.Course = context.Courses
                .Include(c => c.Students)
                .FirstOrDefault(c => c.CourseID == cid);

            coursesViewModel.Student = context.Students.Find(sid);

            if (choice == "Yes")
            {
                coursesViewModel.Student.Status = EnrolmentStatus.EnrollmentConfirmed;
                context.Students.Update(coursesViewModel.Student);
                context.SaveChanges();
                return View("Thankyou", coursesViewModel);
            }
            else if (choice == "No")
            {
                coursesViewModel.Student.Status = EnrolmentStatus.EnrollmentDeclined;
                context.Students.Update(coursesViewModel.Student);
                context.SaveChanges();
                return View("Regret", coursesViewModel);
            }
            else
            {
                return View(coursesViewModel);
            }
        }
    }
}
