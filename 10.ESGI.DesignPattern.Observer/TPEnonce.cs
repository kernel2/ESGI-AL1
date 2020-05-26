using System;
using System.Collections.Generic;
using Xunit;

namespace _10.ESGI.DesignPattern.Observer
{
    public class TPEnonce
    {
        //[Fact]
        //public void _01_Creer_une_classe_Student_avec_une_propriete_State_et_une_methode_Update()
        //{
        //    Student student = new Student();

        //    Assert.Equal("listen", student.State);

        //    student.Update("break");

        //    Assert.Equal("break", student.State);
        //}

        //[Fact]
        //public void _02_Creer_une_classe_Teacher_avec_une_propriete_State_et_une_methode_Update()
        //{
        //    Teacher teacher = new Teacher();

        //    Assert.Equal("speak", teacher.State);

        //    teacher.Update("break");

        //    Assert.Equal("break", teacher.State);
        //}

        //[Fact]
        //public void _03_Creer_une_interface_IObserver_avec_une_propriete_get_State_et_une_methode_Update_pour_unitifer_Student_et_Teacher()
        //{
        //    IObserver student = new Student();

        //    Assert.Equal("listen", student.State);

        //    student.Update("break");

        //    Assert.Equal("break", student.State);

        //    IObserver teacher = new Teacher();

        //    Assert.Equal("speak", teacher.State);

        //    teacher.Update("break");

        //    Assert.Equal("break", teacher.State);
        //}

        //[Fact]
        //public void _04_Creer_une_classe_Break_avec_une_methode_Add()
        //{
        //    Break b = new Break(new DateTime(2020,05,26,13,00,00));

        //    Teacher teacher = new Teacher();
        //    Student student = new Student();

        //    b.Add(teacher);
        //    b.Add(student);
        //}

        //[Fact]
        //public void _05_Creer_une_methode_Notify_dans_Break()
        //{
        //    Break b = new Break(new DateTime(2020, 05, 26, 13, 00, 00));

        //    Teacher teacher = new Teacher();
        //    Student student = new Student();

        //    b.Add(teacher);
        //    b.Add(student);

        //    b.Notify(new DateTime(2020, 05, 26, 12, 00, 00));

        //    Assert.Equal("listen", student.State);
        //    Assert.Equal("speak", teacher.State);

        //    b.Notify(new DateTime(2020, 05, 26, 13, 00, 00));

        //    Assert.Equal("break", student.State);
        //    Assert.Equal("break", teacher.State);
        //}
    }
}
