using System;
using System.Data.SqlClient;
using System.Linq;
using HotelApi_;
using HotelApi_.Entities;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace TestDb
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection("Data Source =IASI-H5BP4G7;Initial Catalog=Bookings;User ID=sa;Password=1234%asd");
            using (var session = NHibernateHelper.OpenSession())
            {
                var query = session.Query<PersonEntity>()
                    .Where(x => x.Bookings.Any(p => Math.Abs(p.BookingDate.Year-x.RegisterDate.Year)>2))
                    .Select(x => x.FirstName);
                var persons = query.ToList();
                foreach (var pers in persons)
                {
                    Console.WriteLine(pers);
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
