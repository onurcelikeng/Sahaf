using Facebook;
using System;
using Windows.ApplicationModel.Activation;
using Windows.Security.Authentication.Web;

namespace Sahaf.Helpers
{
    public class FaceBookHelper
    {
        readonly Uri _callbackUri = WebAuthenticationBroker.GetCurrentApplicationCallbackUri();
        private const string FacebookPermissions = "public_profile";
        private const string FacebookAppId = "1567847676843507";
        FacebookClient _fb = new FacebookClient();
        readonly Uri _loginUrl;


        public FaceBookHelper()
        {
            _loginUrl = _fb.GetLoginUrl(new
            {
                client_id = FacebookAppId,
                redirect_uri = _callbackUri.AbsoluteUri,
                scope = FacebookPermissions,
                display = "popup",
                response_type = "token"
            });
        }


        public string AccessToken
        {
            get { return _fb.AccessToken; }
        }

        public void LoginAndContinue()
        {
            WebAuthenticationBroker.AuthenticateAndContinue(_loginUrl);
        }

        private void ValidateAndProccessResult(WebAuthenticationResult result)
        {
            if (result.ResponseStatus == WebAuthenticationStatus.Success)
            {
                var responseUri = new Uri(result.ResponseData.ToString());
                var facebookOAuthResult = _fb.ParseOAuthCallbackUrl(responseUri);

                if (string.IsNullOrWhiteSpace(facebookOAuthResult.Error))
                    _fb.AccessToken = facebookOAuthResult.AccessToken;
                else
                {//error de acceso denegado por cancelación en página  
                }
            }
            else if (result.ResponseStatus == WebAuthenticationStatus.ErrorHttp)
            {// error de http  
            }
            else
            {
                _fb.AccessToken = null;//Keep null when user signout from facebook  
            }
        }

        public void ContinueAuthentication(WebAuthenticationBrokerContinuationEventArgs args)
        {
            ValidateAndProccessResult(args.WebAuthenticationResult);
        }
    }
}
