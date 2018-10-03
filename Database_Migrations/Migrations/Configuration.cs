namespace Database_Migrations.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Model;

    internal sealed class Configuration : DbMigrationsConfiguration<Dal.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Dal.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (context.grade.Count<Grade>() == 0)
            {
                Grade grade = new Grade();
                grade.class_no = "1";
                grade.class_name = "clasename";

                context.grade.AddOrUpdate(grade);



                Person person = new Person();

                person.age = 1;
                person.class_no = "1";
                person.enrollment_time = DateTime.Now;
                person.memo = "memo";
                person.person_name = "name";
                person.person_no = "001";

                context.person.AddOrUpdate(person);

                Person person1 = new Person();
                person1.age = 2;
                person1.class_no = "1";
                person1.enrollment_time = DateTime.Now;
                person1.memo = "memo2";
                person1.person_name = "name2";
                person1.person_no = "002";
                context.person.AddOrUpdate(person1);
            }

            //var a = context.person.Any(s => s.memo2 == null);
            //List<Person> b = new List<Person>();
            //b = (from p in context.person.ToList<Person>()
            //     where p.memo2 == null
            //     select p).ToList();


            //foreach (Person p in b)
            //{
            //    p.memo2 = "memo2";
            //    context.person.AddOrUpdate(p);
            //}



        }
    }
}
