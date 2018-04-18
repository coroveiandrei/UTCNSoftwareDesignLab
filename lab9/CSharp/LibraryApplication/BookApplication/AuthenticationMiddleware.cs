using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BookApplication.Bll.Services;
using BookApplication.Dao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BookApplication
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var request = context.Request;
                var tokens = request.Headers["Authorization"].FirstOrDefault();
                if (tokens != null)
                {
                    byte[] data = Convert.FromBase64String(tokens);
                    string decodedString = Encoding.UTF8.GetString(data);
                    string[] tokensValues = decodedString.Split(':');

                    UserModel ObjUser = new CredentialChecker().CheckCredential(tokensValues[0], tokensValues[1]);
                    if (ObjUser != null)
                    {
                        IPrincipal principal = new GenericPrincipal(new GenericIdentity(ObjUser.Name), ObjUser.UserRoles.Split(','));
                        Thread.CurrentPrincipal = principal;
                        //HttpContext.Current.User = principal;
                    }
                    else
                    {
                        //The user is unauthorize and return 401 status  
                        var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                        var tsc = new TaskCompletionSource<HttpResponseMessage>();
                        tsc.SetResult(response);
                        await tsc.Task;
                    }
                }
                else
                {
                    //Bad Request request because Authentication header is set but value is null  
                    var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                    var tsc = new TaskCompletionSource<HttpResponseMessage>();
                    tsc.SetResult(response);
                    await tsc.Task;
                }
            }
            catch
            {
                //User did not set Authentication header  
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);
                await tsc.Task;
            }
        }
    }
}
