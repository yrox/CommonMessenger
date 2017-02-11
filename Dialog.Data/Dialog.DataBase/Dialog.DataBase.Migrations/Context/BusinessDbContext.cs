namespace DataBase.Context
{
    public class BusinessDbContext : Data.Business.EntitFramework.BusinessDbContext
    {
        public BusinessDbContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
    }
}
