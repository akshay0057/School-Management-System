namespace SMSAPIProject.Helper
{
    public static class GenerateIdHelper
    {
        public static string GenerateNewRollNo(string lastRollNo)
        {
            if(string.IsNullOrEmpty(lastRollNo))
            {
                return "1";
            }
            return (Convert.ToInt32(lastRollNo)+1).ToString();
        }
    }
}
