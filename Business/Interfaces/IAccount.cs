namespace Business.Interfaces
{
    public interface IAccount : IContacts, IMessaging
    {
        void Authorize(string code);
        void Authorize(string captcha, long sid);
        
    }
}
