using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterProject.Models
{
    public class CustomResultFilterAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            // This method is called before the result is executed.
            LogMessage("Executing custom result filter attribute before result execution.\n");
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            // This method is called after the result has been executed.
            LogMessage("Executing custom result filter attribute after result execution.\n");
        }
        private void LogMessage(string message)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Log", "Log.txt");
            //saving the data in a text file called Log.txt
            File.AppendAllText(filePath, message);
        }
    }
}
