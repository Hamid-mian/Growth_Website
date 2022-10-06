using testing2.Models;

namespace Growth_Website.Models.Interface
{
    public interface depLogin
    {
        public Login CheckLoginInfo(Login sp);
        public Login CheckLoginInfoAdmin(Login sp);
    }
}
