using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using LibraryApplicationWithAuth.Bll.Services;
using LibraryApplicationWIthAuth.Business.IServices;
using LibraryApplicationWIthAuth.Business.Services;

namespace LibraryApplicationWithAuth.Handlers
{
    public class AuthenticationHandler : DelegatingHandler
    {
        private readonly ICredentialCheckerService credentialCheckerService;
        public AuthenticationHandler()
        {
            credentialCheckerService = CommonServiceLocator.ServiceLocator.Current.GetInstance<ICredentialCheckerService>();
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Headers.Contains("Authorization"))
                {
                    var tokens = request.Headers.GetValues("Authorization").FirstOrDefault();
                    if (tokens != null)
                    {
                        string[] tokensValues = tokens.Split(',');

                        var ObjUser = credentialCheckerService.CheckCredential(tokensValues[0], tokensValues[1]);
                        if (ObjUser != null)
                        {
                            IPrincipal principal = new GenericPrincipal(new GenericIdentity(ObjUser.Name), ObjUser.UserRoles.Split(','));
                            Thread.CurrentPrincipal = principal;
                            HttpContext.Current.User = principal;
                        }
                        else
                        {
                            //The user is unauthorize and return 401 status  
                            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                            var tsc = new TaskCompletionSource<HttpResponseMessage>();
                            tsc.SetResult(response);
                            return tsc.Task;
                        }
                    }
                    else
                    {
                        //Bad Request request because Authentication header is set but value is null  
                        var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                        var tsc = new TaskCompletionSource<HttpResponseMessage>();
                        tsc.SetResult(response);
                        return tsc.Task;
                    }
                }
                return base.SendAsync(request, cancellationToken);
            }
            catch(Exception e)
            {
                //User did not set Authentication header  
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);
                return tsc.Task;
            }
        }

    }
}