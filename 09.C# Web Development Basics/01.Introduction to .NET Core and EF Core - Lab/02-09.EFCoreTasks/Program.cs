namespace _02_09.EFCoreTasks
{
    using _02_09.EFCoreTasks.Model;

    public class Program
    {
        public static void Main()
        {
            //tasks N-2 to N-4
            using (var db=new MyDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }
    }
}