using Persistence.User;
using Services.User;

namespace Test.Tools
{
    public static class UserFactory
    {
        private static string ConnectionString =>
            "Server = .; Initial Catalog = UserTestDb; Integrated Security = true;";

        public static UserAppService CreateService()
        {
            var repository = new EFUserRepository(ConnectionString);
            return new UserAppService(repository);
        }
    }
}