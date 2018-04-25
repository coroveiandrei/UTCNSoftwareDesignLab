using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApplicationWithAuth.Models.Models;

namespace LibraryApplicationWIthAuth.Business.IServices
{
    public interface ICredentialCheckerService
    {
        UserModel CheckCredential(string username, string password);
    }
}
