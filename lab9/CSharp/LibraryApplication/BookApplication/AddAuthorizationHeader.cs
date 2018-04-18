using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BookApplication
{
    public class AddAuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if(operation.Parameters == null)
            {
                operation.Parameters = new List<IParameter>();
            }
            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "Authorization",
                @In = "header",
                Description = "andrei,password",
                Required = false,
                Type = "string"
            });
            
        }
    }
}
