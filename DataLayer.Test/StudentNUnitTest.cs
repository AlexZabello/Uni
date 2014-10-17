using System;
using NUnit.Framework;
using Moq;
using DataLayer.Entity;
using DataLayer.Repository;
using Uni.Presenter;
using System.Collections.Generic;
using Uni.View;
using Uni.Model;

namespace DataLayer.Test
{
    [TestFixture]
    public class StudentNUnitTest
    {
        [Test]
        public void CheckConstraintStudentToTeacher_Null()
        {
            var mockStudent = Mock.Of<Student>();
            mockStudent.Group = Mock.Of<Group>();

            Assert.IsNull(mockStudent.Group.Prof);
        }

        [Test]
        public void CheckConstraintStudentToTeacher_NotNull()
        {
            var mockGroup = Mock.Of<Group>();
            mockGroup.Prof = Mock.Of<Teacher>();
            var mockStudent = Mock.Of<Student>();
            mockStudent.Group = mockGroup;

            Assert.IsNotNull(mockStudent.Group.Prof);
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

        [Test]
        public void Check_ContantinationProfName()
        {
            string fisrtName = "TestFN";
            string lastName = "TestLN";
            Student student = new Student();
            Subject subject = new Subject();
            student.Subject = subject;
            Group group = new Group();
            Teacher teacher = new Teacher() 
            { 
                FirstName = fisrtName, 
                LastName = lastName 
            };
            student.Group = group;
            group.Prof = teacher;
            List<Student> studentCollection = new List<Student>();
            studentCollection.Add(student);
            var mockView = Mock.Of<IStudentView>(v => v.FirstName == "1" &&
                                            v.LastName == "1" &&
                                            v.IdGroup == 1 &&
                                            v.IdSubject == 1);
            var mockStudentModel = new Mock<IStudentModel>();
            mockStudentModel.Setup(s => s.GetStudents(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(studentCollection);
            var mockPresenter = new Mock<StudentPresenter>(mockView, mockStudentModel.Object);
            mockPresenter.Object.StudentModel = mockStudentModel.Object;
            
            List<Uni.Models.StudentViewModel> studentViewModelCollection = mockPresenter.Object.GetStudents() as List<Uni.Models.StudentViewModel>;
            
            Assert.AreEqual((studentViewModelCollection as List<Uni.Models.StudentViewModel>).Count, 1);
            Assert.AreEqual(studentViewModelCollection[0].ProfName, string.Format("{0} {1}", fisrtName, lastName));
        }
    }
}
