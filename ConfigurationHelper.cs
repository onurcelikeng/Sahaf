using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Networking.Sockets;
using Windows.Security.Cryptography.Certificates;
using Windows.UI.Xaml.Controls;
using Windows.Web;

namespace Sahaf
{
    public partial class MainPage : Page
    {
        public Uri TryGetUri(string uriString)
        {
            Uri webSocketUri;
            if (!Uri.TryCreate(uriString.Trim(), UriKind.Absolute, out webSocketUri))
            {
                return null;
            }

            // Fragments are not allowed in WebSocket URIs.
            if (!String.IsNullOrEmpty(webSocketUri.Fragment))
            {
                return null;
            }

            // Uri.SchemeName returns the canonicalized scheme name so we can use case-sensitive, ordinal string
            // comparison.
            if ((webSocketUri.Scheme != "ws") && (webSocketUri.Scheme != "wss"))
            {
                return null;
            }

            return webSocketUri;
        }

        public static string BuildWebSocketError(Exception ex)
        {
            ex = ex.GetBaseException();

            if ((uint)ex.HResult == 0x800C000EU)
            {
                // INET_E_SECURITY_PROBLEM - our custom certificate validator rejected the request.
                return "Error: Rejected by custom certificate validation.";
            }

            WebErrorStatus status = WebSocketError.GetStatus(ex.HResult);

            // Normally we'd use the HResult and status to test for specific conditions we want to handle.
            // In this sample, we'll just output them for demonstration purposes.
            switch (status)
            {
                case WebErrorStatus.CannotConnect:
                case WebErrorStatus.NotFound:
                case WebErrorStatus.RequestTimeout:
                    return "Cannot connect to the server. Please make sure " +
                        "to run the server setup script before running the sample.";

                case WebErrorStatus.Unknown:
                    return "COM error: " + ex.HResult;

                default:
                    return "Error: " + status;
            }
        }

        static public async Task<bool> AreCertificateAndCertChainValidAsync(Certificate serverCert, IReadOnlyList<Certificate> certChain)
        {
            foreach (Certificate cert in certChain)
            {
                if (!await IsCertificateValidAsync(cert))
                {
                    return false;
                }
            }
            return await IsCertificateValidAsync(serverCert);
        }

        static async Task<bool> IsCertificateValidAsync(Certificate serverCert)
        {
            // This is a placeholder call to simulate long-running async calls. Note that this code runs synchronously as part
            // of the SSL/TLS handshake. Avoid performing lengthy operations here - else, the remote server may terminate the
            // connection abruptly.
            await Task.Delay(100);

            // In this sample, we check the issuer of the certificate - this is purely for illustration
            // purposes and should not be considered as a recommendation for certificate validation.
            return serverCert.Issuer == "www.fabrikam.com";
        }
    }

    public class Scenario
    {
        public string Title { get; set; }

        public Type ClassType { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
