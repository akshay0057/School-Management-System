namespace SMSAPIProject.Helper
{
    public static class HeaderHelper
    {
        public static string GetHeaderValue(HttpRequest request, string headerName)
        {
            if (request.Headers.TryGetValue(headerName, out var value))
            {
                return value.ToString();
            }

            return string.Empty;
        }
    }
}
