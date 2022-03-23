namespace Models
{
    public class Employee
    {

        public string Name { get; set; }
        public int ID { get; set; }
        public bool isManager { get; set; }
        /*
            Name, Assigned ID, Manager?
        */

        public Employee()
        {
            Name = "Name";
            ID = 0;
            isManager = false;
        }
    }
}