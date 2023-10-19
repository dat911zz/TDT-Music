using TDT.Core.Models;

namespace TDT.Core.Helper.Firestore
{
    public static class Converter
    {
        public static UserIdentiyModel convertToUserDetailDTO(User user)
        {
            return new UserIdentiyModel
            {
                UserName = user.UserName,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Password = user.PasswordHash
            };
        }
    }
}
