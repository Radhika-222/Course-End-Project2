using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_EndProject2
{
    public class Program
    {
        static List<Teacher> teachers = new List<Teacher>();
        static string filePath = "E:\\Mphasis\\Course End_Project2\\teachers.txt";

        static void Main(string[] args)
        {
            LoadData();

            while (true)
            {
                Console.WriteLine("1. Add Teacher\n2. Update Teacher\n3. Display All Teachers\n 4. Exit");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddTeacher();
                        break;

                    case 2:
                        UpdateTeacher();
                        break;

                    case 3:
                        DisplayTeachers();
                        break;

                    case 4:
                        SaveData();
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void AddTeacher()
        {
            Teacher newTeacher = new Teacher();

            Console.Write("Enter ID: ");
            newTeacher.ID = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            newTeacher.Name = Console.ReadLine();

            Console.Write("Enter Class and section: ");
            newTeacher.ClassAndSection = Console.ReadLine();

            teachers.Add(newTeacher);
            Console.WriteLine("Teacher added successfully.");
        }

        static void UpdateTeacher()
        {
            Console.Write("Enter Teacher ID to update: ");
            int idToUpdate = int.Parse(Console.ReadLine());

            Teacher teacherToUpdate = teachers.Find(t => t.ID == idToUpdate);

            if (teacherToUpdate != null)
            {
                Console.Write("Enter updated Name: ");
                teacherToUpdate.Name = Console.ReadLine();

                Console.Write("Enter updated Class: ");
                teacherToUpdate.ClassAndSection = Console.ReadLine();



                Console.WriteLine("Teacher updated successfully.");
            }
            else
            {
                Console.WriteLine("Teacher not found.");
            }
        }

        static void DisplayTeachers()
        {
            Console.WriteLine("Teacher Data:");

            foreach (var teacher in teachers)
            {
                Console.WriteLine($"{teacher.ID} - {teacher.Name}, {teacher.ClassAndSection}");
            }
        }

        static void LoadData()
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    string[] values = line.Split(',');
                    Teacher teacher = new Teacher
                    {
                        ID = int.Parse(values[0]),
                        Name = values[1],
                        ClassAndSection = values[2],

                    };

                    teachers.Add(teacher);
                }
            }
        }

        static void SaveData()
        {
            List<string> lines = new List<string>();

            foreach (var teacher in teachers)
            {
                lines.Add(teacher.ToString());
            }

            File.WriteAllLines(filePath, lines);
        }
    }
}


