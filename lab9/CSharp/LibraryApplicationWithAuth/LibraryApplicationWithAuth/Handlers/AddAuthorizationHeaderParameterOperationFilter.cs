using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace LibraryApplicationWithAuth.Handlers
{
    public class AddAuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
            {
                operation.parameters = new List<Parameter>();
            }
            operation.parameters.Add(new Parameter()
            {
                name = "Authorization",
                @in = "header",
                description = "admin,admin or student,student or both,both [user,password]",
                required = false,
                type = "string"
            });

        }
    }
}