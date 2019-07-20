namespace WebApiGuaxCore.Model
{
    public class UserReference
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Phone Phone { get; set; }
        public Adress Adress { get; set; }
    }
}
