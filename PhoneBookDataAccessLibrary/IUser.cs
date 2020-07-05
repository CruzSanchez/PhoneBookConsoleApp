namespace PhoneBookDataAccessLibrary
{
    public interface IUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public void SetUserName();
        public void SetUserPassword();
        public bool CheckUserPassword(string possiblePassword);
    }
}
