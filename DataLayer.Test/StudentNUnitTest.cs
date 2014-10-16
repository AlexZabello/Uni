using System;
using NUnit.Framework;
using Moq;
using DataLayer.Entity;
using DataLayer.Repository;
using Uni.Presenter;
using System.Collections.Generic;
using Uni.View;

namespace DataLayer.Test
{
    [TestFixture]
    public class StudentNUnitTest
    {
        [Test]
        public void CheckConstraintStudentToTeacher_Null()
        {
            var student = Mock.Of<Student>();
            student.Group = Mock.Of<Group>();

            
            Assert.IsNull(student.Group.Prof);

            //Assert.That(student.Group.Prof, Is.Not.Null);
        }

        [Test]
        public void CheckConstraintStudentToTeacher_NotNull()
        {
            var mGroup = Mock.Of<Group>();
            mGroup.Prof = Mock.Of<Teacher>();
            var student = Mock.Of<Student>();
            student.Group = mGroup;

            Assert.IsNotNull(student.Group.Prof);


            var gr = new Mock<Group>();
            var t = new Mock<Teacher>();
            var s = new Mock<Student>();
            gr.Object.Prof = t.Object;
            s.Object.Group = gr.Object;

            Assert.IsNotNull(s.Object.Group.Prof);

            //mGroup.Setup(g => g.Prof).Returns(new Teacher());

            
        }
        [Test]
        public void Check()
        {
            //var m = Mock.Of<IStudentView>(p => p.FirstName == "t");
            ////var mock = new Mock<IStudentView>();
            ////mock.FirstName = "T";

            //var mock = new Mock(StudentPresenter);
            //Mock.Get(mock).Setup(p => p.GetStudents()).Returns<List<Uni.Models.Student>>(r => new List<Uni.Models.Student>());

            //List<Uni.Models.Student> list = mock.GetStudents() as List<Uni.Models.Student>;
            ////Assert.AreEqual(, 2);
            //Assert.AreEqual(list.Count, 0);

        }
    }
}
