using TimeZoneConverter;

namespace TestServer.Utils
{
    public static class TimeUtil
    {
        private static readonly TimeZoneInfo _vnTimeZone;

        static TimeUtil()
        {
            // Fix IANA ↔ Windows timezone mismatch
            // Railway = Linux = IANA
            // Local Windows = Windows IDs
            try
            {
                _vnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Ho_Chi_Minh");
            }
            catch
            {
                // Windows fallback
                var windowsId = TZConvert.IanaToWindows("Asia/Ho_Chi_Minh");
                _vnTimeZone = TimeZoneInfo.FindSystemTimeZoneById(windowsId);
            }
        }

        public static DateTime VNNow()
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _vnTimeZone);
        }

        public static string VNNowFormat(string format = "yyyyMMddHHmmss")
        {
            return VNNow().ToString(format);
        }
    }
}