namespace ProfileProjectV2.Model
{
    public class PasswordEntity
    {
        public PasswordEntity(string hash, byte[] salt)
        {
            Hash = hash;
            Salt = salt;
        }

        public string Hash { get; set; }
        public byte[] Salt { get; set; }
    }
}