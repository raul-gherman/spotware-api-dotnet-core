using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace spotware
{
    public partial class Connection
    {
        private bool ValidateServerCertificate(object sender,
                                               X509Certificate certificate,
                                               X509Chain chain,
                                               SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                return true;
            }

            _log.Error($"ValidateServerCertificate :: {sslPolicyErrors}");
            return false;
        }
    }
}