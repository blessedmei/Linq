    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var employeeGroup = from employeee in Employee.GetAllEmployees()
                                group employeee by employeee.Department into eGroup
                                orderby eGroup.Key
                                select new
                                {
                                    Key = eGroup.Key,
                                    Employees = eGroup.OrderBy(x => x.Name)
                                };

            var employeGroup = Employee.GetAllEmployees().GroupBy(x => x.Department).OrderBy(x => x.Key).Select(c => new
            {
                Key = c.Key,
                Employees = c.OrderBy(c => c.Name)
            });


            foreach(var group in employeGroup)
            {
                Console.WriteLine("{0} - {1}", group.Key, group.Employees.Count());
                foreach(var employee in group.Employees)
                {
                    Console.WriteLine("{0} {1} {2}", employee.Name, employee.Gender, employee.Department);
                }
                Console.WriteLine("-----------------------");
            }
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Group by Multiple Keys");

            var employeeGroups = Employee.GetAllEmployees()
                .GroupBy(x => new { x.Department, x.Gender })
                .OrderBy(x => x.Key.Department).ThenBy(x => x.Key.Gender)
                .Select(c => new
                {
                    Department = c.Key.Department,
                    Gender = c.Key.Gender,
                    Employees = c.OrderBy(x => x.Name)
                });

            var employeeGroups1 = from employee in Employee.GetAllEmployees()
                                  group employee by new { employee.Department, employee.Gender } into eGroup
                                  orderby eGroup.Key.Department, eGroup.Key.Gender
                                  select new
                                  {
                                      Department = eGroup.Key.Department,
                                      Gender = eGroup.Key.Gender,
                                      Employees = eGroup.OrderBy(x => x.Name)
                                  };

            foreach(var group in employeeGroups1)
            {
                Console.WriteLine("Department is {0} -- Gender is {1}", group.Department, group.Gender);
                foreach(var employee in group.Employees)
                {
                    Console.WriteLine("{0} -- {1} -- {2}", employee.Name, employee.Department, employee.Gender);
                }
                Console.WriteLine("-----------------------");
            }
       }
}



    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }

        public static List<Employee> GetAllEmployees()
        {
            return new List<Employee>()
            {
            new Employee { ID = 1, Name = "Mark", Gender = "Male",
                                         Department = "IT" },
            new Employee { ID = 2, Name = "Steve", Gender = "Male",
                                         Department = "HR" },
            new Employee { ID = 3, Name = "Ben", Gender = "Male",
                                         Department = "IT" },
            new Employee { ID = 4, Name = "Philip", Gender = "Male",
                                         Department = "IT" },
            new Employee { ID = 5, Name = "Mary", Gender = "Female",
                                         Department = "HR" },
            new Employee { ID = 6, Name = "Valarie", Gender = "Female",
                                         Department = "HR" },
            new Employee { ID = 7, Name = "John", Gender = "Male",
                                         Department = "IT" },
            new Employee { ID = 8, Name = "Pam", Gender = "Female",
                                         Department = "IT" },
            new Employee { ID = 9, Name = "Stacey", Gender = "Female",
                                         Department = "HR" },
            new Employee { ID = 10, Name = "Andy", Gender = "Male",
                                         Department = "IT" },
        };
        }
        
        
        
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }

        public static List<Student> GetAllStudents()
        {
            return new List<Student>()
        {
            new Student { ID = 1, Name = "Mark", DepartmentID = 1 },
            new Student { ID = 2, Name = "Steve", DepartmentID = 2 },
            new Student { ID = 3, Name = "Ben", DepartmentID = 1 },
            new Student { ID = 4, Name = "Philip", DepartmentID = 1 },
            new Student { ID = 5, Name = "Mary", DepartmentID = 2 },
            new Student { ID = 6, Name = "Valarie", DepartmentID = 2 },
            new Student { ID = 7, Name = "John", DepartmentID = 1 },
            new Student { ID = 8, Name = "Pam", DepartmentID = 1 },
            new Student { ID = 9, Name = "Stacey", DepartmentID = 2 },
            new Student { ID = 10, Name = "Andy", DepartmentID = 1}
        };
        }
    }
    
    
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static List<Department> GetAllDepartments()
        {
            return new List<Department>()
        {
            new Department { ID = 1, Name = "IT"},
            new Department { ID = 2, Name = "HR"},
            new Department { ID = 3, Name = "Payroll"},
        };
        }
    }
