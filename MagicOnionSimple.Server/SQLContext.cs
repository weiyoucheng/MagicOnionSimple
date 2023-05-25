namespace MagicOnionSimple.Server {
    public class SQLContext:DbContextBase {
        public SQLContext() {
            //Create test data
            Employees = new List<Models.Employee>()
            {
                new Models.Employee(1,"Lady","11111111","11111111@outlook.com",  new DateTime(2023,5,1)),
                new Models.Employee(2,"Tracy","22222222","22222222@outlook.com", new DateTime(2023,5,2)),
                new Models.Employee(3,"Dante","33333333","33333333@outlook.com", new DateTime(2023, 5, 3)),
                new Models.Employee(4,"Mary","44444444","44444444@outlook.com",  new DateTime(2023, 5, 4)),
                new Models.Employee(5,"Nero","55555555","55555555@outlook.com",  new DateTime(2023, 5, 5))
            };
        }
    }
}
