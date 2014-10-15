using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.Core;
using DataLayer.Repository;
using DataLayer.Entity;
using System.Collections;
using System.Collections.Generic;

namespace DataLayer.Test
{
    [TestClass]
    public class StudentTest
    {
        private string con = @"Data Source=zabelloa7\alex_sql;Initial Catalog=Uni;Integrated Security=SSPI;";
        [TestMethod]
        public void Try_Get_Student()
        {
            StudentRepository rep = CreateRep();
            Student stud = rep.Get(1);

            Assert.AreEqual("TestFirstName", stud.FirstName);
        }

        [TestMethod]
        public void Try_Get_All_Student()
        {
            StudentRepository rep = CreateRep();
            IEnumerable<Student> l = rep.GetAll();

            
        }

        [TestMethod]
        public void Try_Add_Student()
        {
            StudentRepository rep = CreateRep();
            Student stud = new Student();
            stud.FirstName = "FN";
            stud.LastName = "LN";
            //stud.UserId = 1;
            Assert.AreEqual(true, rep.Insert(stud));

            rep.Get(stud.StudentId);

            Assert.AreEqual("FN", stud.FirstName);
            Assert.AreEqual("LN", stud.LastName);
        }

        [TestMethod]
        public void Try_Update_Stud()
        {
            StudentRepository rep = CreateRep();
            Student stud = rep.Get(1);
            stud.LastName = "LN";
            Assert.AreEqual(true, rep.Update(stud));
            stud = rep.Get(1);
            Assert.AreEqual("LN", stud.LastName);

        }

        private StudentRepository CreateRep()
        {
            App app = new App(con);
            StudentRepository rep = new StudentRepository(app);
            return rep;
        }

    }


}
