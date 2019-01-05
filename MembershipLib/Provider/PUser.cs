using MembershipLib.BUS;

namespace MembershipLib.Provider
{
    public class PUser
    {
        static BUS<User> BUSUSER = Moudle<User>.INSTANCE.GetModel<BUS<User>>();
        static BUS<Role> BUSROLE = Moudle<User>.INSTANCE.GetModel<BUS<Role>>();

        public static bool Login(string name, string password)
        {

            User user = BUSUSER.FindByKey("name", name);
            if (user == null)
                return false;
            return user.Pass == password;
        }

        public static bool CheckPermission(string name, string role)
        {
            User user = BUSUSER.FindByKey("name", name);
            if (user == null)
                return false;
            Role _role = BUSROLE.FindByKey("ID", user.Role.ToString());
            if (_role == null)
                return false;
            if (!(user == null) && !(_role == null) && role.Contains(_role.Name))
                return true;
            return false;
        }

        public static bool CheckValidate(User u)
        {
            return BUSUSER.CheckValidate(u);
        }

    }
}