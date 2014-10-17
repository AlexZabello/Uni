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

        [Test]
        public void Check_ContantinationProfName()
        {
            string fn = "TestFN";
            string ln = "TestLN";

            Student stud = new Student();
            Subject subj = new Subject();
            stud.Subject = subj;
            Group group = new Group();
            Teacher teacher = new Teacher() { FirstName = fn, LastName = ln };
            stud.Group = group;
            group.Prof = teacher;

            List<Student> listSt = new List<Student>();
            listSt.Add(stud);

            var view = Mock.Of<IStudentView>(v => v.FirstName == "1" &&
                                            v.LastName == "1" &&
                                            v.IdGroup == 1 &&
                                            v.IdSubject == 1);

            var mStudentModel = new Mock<IStudentModel>();
            mStudentModel.Setup(s => s.GetStudents(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(listSt);

            var mPresenter = new Mock<StudentPresenter>(view, mStudentModel.Object);
            //var mStudRepository = new Mock<IStudentRepository>();
            //mStudRepository.Setup(ms => ms.SearchStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(listSt);
            
            //IStudentRepository repos = mStudRepository.Object;

            //var result = repos.SearchStudent("1","1",1,1);

            mPresenter.Object.StudentModel = mStudentModel.Object;

            List<Uni.Models.StudentViewModel> coll = mPresenter.Object.GetStudents() as List<Uni.Models.StudentViewModel>;

            //var result2 = mPresenter.Object.SearchStudent("1", "1", 1, 1);

            //Assert.AreEqual(result, listSt);
            Assert.AreEqual((coll as List<Uni.Models.StudentViewModel>).Count, 1);
            
            Assert.AreEqual(coll[0].ProfName, string.Format("{0} {1}", fn, ln));
        }
    }
}
