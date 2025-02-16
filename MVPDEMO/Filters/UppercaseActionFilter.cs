using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class UppercaseActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        
        foreach (var key in context.ActionArguments.Keys.ToList())
        {
            if (context.ActionArguments[key] is string strValue)
            {
                context.ActionArguments[key] = strValue.ToUpper();
            }
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        
        if (context.Result is ViewResult viewResult)
        {
           
            foreach (var key in viewResult.ViewData.Keys.ToList())
            {
                if (viewResult.ViewData[key] is string strValue)
                {
                    viewResult.ViewData[key] = strValue.ToUpper();
                }
            }

            
            var viewBagType = viewResult.ViewData.ModelMetadata.ContainerType;
            if (viewBagType != null)
            {
                var viewBagProperties = viewBagType.GetProperties()
                    .Where(p => p.PropertyType == typeof(string));

                foreach (var prop in viewBagProperties)
                {
                    var value = prop.GetValue(viewResult.ViewData.Model) as string;
                    if (value != null)
                    {
                        prop.SetValue(viewResult.ViewData.Model, value.ToUpper());
                    }
                }
            }
        }
    }
}
