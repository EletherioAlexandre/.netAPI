using Course;

namespace ActionsCourse {
    static class CourseMethods {

        public static List<Student> StudentFolder { get; set; }

        public static void Add(Student student) {

            if (StudentFolder == null)
                StudentFolder = new List<Student>();
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