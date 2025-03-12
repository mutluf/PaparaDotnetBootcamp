using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class EnumSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type.IsEnum)
        {
            var enumValues = Enum.GetValues(context.Type).Cast<Enum>();
            schema.Enum = enumValues.Select(v => (IOpenApiAny)new OpenApiString(v.ToString())).ToList();
        }
    }
}
