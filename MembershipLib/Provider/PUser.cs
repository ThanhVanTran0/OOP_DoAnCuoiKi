using MembershipLib.BUS;

namespace MembershipLib.Provider
{
    public class PUser
    {
        static BUS<User> BUSUSER = Moudle.INSTANCE.GetModel<BUS<User>>();
        static BUS<Role> BUSROLE = Moudle.INSTANCE.GetModel<BUS<Role>>();

        public static bool Login(string name, string password)
        {

            User user = BUSUSER.FindByKey("name", name);
            return user.Password == password;
        }

        public static bool CheckPermission(string name, string role)
        {
            User user = BUSUSER.FindByKey("name", name);
            Role _role = BUSROLE.FindByKey("ID", user.Role.ToString());
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