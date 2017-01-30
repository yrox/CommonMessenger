namespace Business.Interfaces
{
    public interface IAccount : IContacts
    {
        void Authorize(string code);
        void Authorize(string captcha, long sid);
        
    }
}
