using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    public class Base_Dal
    {
        protected internal Context db;

        public Base_Dal()
        {
            db = new Context();
            db.Database.Log = Console.WriteLine;
        }

        public Base_Dal(Base_Dal bd)
        {
            db = bd.db;
        }

    
    }
}
