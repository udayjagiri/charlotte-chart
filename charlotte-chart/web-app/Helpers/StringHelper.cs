namespace web_app.Helpers
{
    public class StringHelper   
    {
        public static bool IsDecimal(string input)
        {
            decimal val;
            decimal.TryParse(input, out val);
            return val > 0;
        }
    }
}