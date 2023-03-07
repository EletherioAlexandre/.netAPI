using Course;

namespace ActionsCourse {
    static class CourseMethods {

        public static List<Student> StudentFolder { get; set; } = StudentFolder = new List<Student>();

        public static void Init(IConfiguration config) {
            var student = config.GetSection("Students").Get<List<Student>>();

            StudentFolder = student;
        }
        public static void Add(Student student) {

            StudentFolder.Add(student);
        }

        public static Student SearchStudent(string id) {
            return StudentFolder.FirstOrDefault((s) => s.Id == id);
        }

        public static void Delete(Student student) {

            StudentFolder.Remove(student);
        }
    }
}