namespace WebApplication1.Model
{
    public class Person
    {
        public string Name { get; set; }
        public string Phone {  get; set; }
        public string Email { get; set; }
        public Role PersonRole { get; set; }
        public enum Role
        {
            Student,
            Professor
        }
    }
}
