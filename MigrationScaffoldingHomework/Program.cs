using System;

namespace MigrationScaffoldingHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new ReadingClubContext())
            {
                context.Add(new Article { Name = "Моя статья 2", AuthorsId=default, CategoryId=default, CountOfPage = 3});
                context.SaveChanges();
            }
        }
    }
}
