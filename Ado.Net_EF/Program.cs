using Ado.Net_EF.DAL;
using Ado.Net_EF.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Ado.Net_EF
{
    class Program
    {
        private static string connectionString = @"Data Source = DESKTOP-NH7SON4\SQLEXPRESS; Initial Catalog = AP204; Integrated Security = SSPI";
        static void Main(string[] args)
        {
            #region Ado.Net
            //Console.WriteLine("Please enter student's Id");
            //int id;
            //bool result = int.TryParse(Console.ReadLine(), out id);
            //if (result)
            //{
            //    //Console.Clear();
            //    GetStudentInfo(id);
            //}
            //else
            //{
            //    Console.WriteLine("Please enter valid id");
            //}
            //GetStudentsInfo();
            //CreateStudent();
            #endregion

            #region EntityFramework
            //createStudentEF();
            //getStudentEF();
            //getStudentsEF();

            //updateStudentEF();

            //Student stu = deleteStudentEF();
            //createDeletedStudentEF(stu);
            //Console.WriteLine(stu);
            #endregion

        }

        #region Ado.Net
        //public static void GetStudentInfo(int id)
        //{
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        con.Open();
        //        string query = $"Select Soyad from Students where Id = {id}";
        //        try
        //        {
        //            using (SqlCommand comm = new SqlCommand(query, con))
        //            {
        //                string name = comm.ExecuteScalar().ToString();
        //                Console.WriteLine(name);
        //            }
        //        }
        //        catch (Exception e)
        //        {

        //            Console.WriteLine(e.Message);
        //        }
        //    }
        //}

        //public static void GetStudentsInfo()
        //{
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        con.Open();
        //        string query = "select * from Students where Id = 2";

        //        using (SqlCommand comm = new SqlCommand(query, con))
        //        {
        //            SqlDataReader infos = comm.ExecuteReader();
        //            if (infos.HasRows)
        //            {
        //                while (infos.Read())
        //                {
        //                    Console.WriteLine(infos.GetString(1));
        //                }

        //            }
        //        }
        //    }
        //}

        //public static void CreateStudent()
        //{
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        con.Open();
        //        string query = $"insert into Students values('{9}','Hasanzade','AP204',{80},'Fatima')";

        //        using (SqlCommand comm = new SqlCommand(query, con))
        //        {
        //            int infos = comm.ExecuteNonQuery();

        //            if (infos > 0)
        //            {
        //                Console.WriteLine("Fatima added");
        //            }
        //            else
        //            {
        //                Console.WriteLine("Error occured");
        //            }

        //        }
        //    }
        //}
        #endregion

        #region EntityFramework
        public static void createStudentEF()
        {
            using (AppDbContext context = new AppDbContext())
            {
                Student student = new Student { Name = "Vahid", Surname = "Salimov", Group = "AP204" };
                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        public static void createDeletedStudentEF(Student stu)
        {
            using (AppDbContext context = new AppDbContext())
            {
                DeletedStudent deletedStudent = new DeletedStudent
                {
                    Name = stu.Name,
                    Surname = stu.Surname,
                    Group = stu.Group
                };
                context.DeletedStudents.Add(deletedStudent);
                context.SaveChanges();
            }
        }

        public static void getStudentEF()
        {
            using (AppDbContext context = new AppDbContext())
            {
                Student student = context.Students.FirstOrDefault(s => s.Id == 2);
                if (student == null)
                {
                    Console.WriteLine("There is no student");
                }
                else
                {
                    Console.WriteLine(student.Surname);
                }
            }
        }

        public static void getStudentsEF()
        {
            using (AppDbContext context = new AppDbContext())
            {
                List<Student> students = context.Students.ToList();
                foreach (Student stu in students)
                {
                    Console.WriteLine(stu);
                }
            }
        }

        public static void updateStudentEF()
        {
            using (AppDbContext context = new AppDbContext())
            {
                Student student = context.Students.FirstOrDefault(s => s.Id == 1);

                if (student != null)
                {
                    student.Surname = "Yusubov";
                    context.SaveChanges();
                }

            }
        }

        public static Student deleteStudentEF()
        {
            using (AppDbContext context = new AppDbContext())
            {
                Student student = context.Students.Find(4);

                if (student != null)
                {
                    context.Students.Remove(student);
                    context.SaveChanges();
                }
                return student;
            }
        }
        #endregion
    }
}
