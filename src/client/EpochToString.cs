namespace spotware
{
    public partial class Client
    {
        private static string EpochToString(long epoch)
        {
            return new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc).AddMilliseconds(epoch).ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
    }
}