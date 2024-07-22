using musi_school.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using static musi_school.Configuration.MusicSchoolCofiguration;
namespace musi_school.Service
{
    internal static class MUsicSchoolService
    {
        public static void Leyzer()
        {
            Console.WriteLine("hhhhh");
        }
        public static void CreateXMLIfNotExists()
        {
            // אם הוא לא קיים
            if (!File.Exists(musicSchoolPath))
            {
                //בניה חדשה של קובץ xml
                XDocument document = new();
                //להכניס אלמנט 
                XElement musicSchool = new("music_school");
                //להוסיף לתוך אלמנט 
                document.Add(musicSchool);
                //לשמור את זה בנתיב שנתנו לו 
                document.Save(musicSchoolPath);
            }
        }
        public static void InsrtClassroom(string classRoomName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);

            XElement? musicSchool = document.Descendants("music_school")
                .FirstOrDefault();

            if (musicSchool == null)
            {
                return;
            }
            XElement classRoom = new(
                "class_room",
                new XAttribute("name", classRoomName)
                );
            musicSchool.Add(classRoom);
            document.Save(musicSchoolPath);
        }
        private static XElement ConverToTeacherElment(TeacherModel teacher) =>
            new XElement(
                "teacher-name",
                    new XAttribute("name", teacher.Name)
                );
        private static XElement ConverStudentToElment(Student student) =>
            new XElement(
                  "student-name",
                    new XAttribute("name", student.name),
                    new XElement("instument", student.instrument.Name)
                );
        public static void AddTeacher(string classRoom, string teacherName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);

            XElement? musicSchool = document.Descendants("class_room")
                .FirstOrDefault(room => room.Attribute("name")?.Value == classRoom);

            if (musicSchool != null)
            {
                XElement teacher = new(
                    "teacher-name",
                    new XAttribute("name", teacherName)
                    );
                musicSchool.Add(teacher);
                document.Save(musicSchoolPath);
            }
            return;
        }
        public static void Addtudent(string classRoomName, string studentName, string instrument)
        {
            XDocument document = XDocument.Load(musicSchoolPath);

            XElement? musicSchool = document.Descendants("class_room")
                .FirstOrDefault(room => room.Attribute("name")?.Value == classRoomName);
            if (musicSchool != null)
            {
                XElement student = new(
                    "student-name",
                    new XAttribute("name", studentName),
                    new XElement("instument", instrument)
                    );
                musicSchool.Add(student);
                document.Save(musicSchoolPath);
            }
            return;
        }
        
        public static void AddManyStudents(string classRoomName, params Student[] students)
        {
            XDocument document = XDocument.Load(musicSchoolPath);

            XElement? musicSchool = document.Descendants("class_room")
                .FirstOrDefault(room => room.Attribute("name")?.Value == classRoomName);
            if (musicSchool == null)
            {
                return;
                //(List<XElement> studentElement = students.Select(s => new XElement("student-name", new XAttribute"name", s.name), new XElement("instument", s.instrument))).Add(students);
            }
            List<XElement> studentElement = students.Select(ConverStudentToElment).ToList();
            musicSchool.Add(students);
            document.Save(musicSchoolPath);
        }

        public static void UpdatingEachStudentIsPlaying(string studentName, string instumentName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);

            XElement? studentNam = document.Descendants("class_room")
                .FirstOrDefault(room => room.Attribute("name")?.Value == studentName);
            if (studentNam == null)
            {
                return;
            }
            studentNam.SetAttributeValue("name", "elly");
            document.Save(musicSchoolPath);
        }


        public static void TeacherNameUpdate(string TeacherName) 
        {
            XDocument document = XDocument.Load(musicSchoolPath);

            XElement? teacherNam = document.Descendants("class_room")
                .FirstOrDefault(room => room.Attribute("name")?.Value == TeacherName);
            if (teacherNam == null)
            {
                return;
            }
            teacherNam.SetAttributeValue("student-name", TeacherName);
            document.Save(musicSchoolPath);


        }

    }
}
