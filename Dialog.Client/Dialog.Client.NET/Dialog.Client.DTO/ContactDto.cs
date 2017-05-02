namespace Dialog.Client.DTO
{
    public class ContactDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }

        public int MetaContactId { get; set; }
        public string MetaContactName { get; set; }
    }
}
