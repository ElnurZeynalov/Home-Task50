namespace Corporate.Models
{
    public class ClientComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int ClientId { get; set; }
        public Client client { get; set; }
    }
}
