namespace Dialog.Client.DTO
{
    public class MessageDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Text { get; set; }
        public int MetaContactId { get; set; }
        public string MetaContactIName { get; set; }
    }
}
