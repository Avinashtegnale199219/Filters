namespace FilterProject.Models
{
    public class LoggerService :ILoggerService
    {
        public void Log(string message)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Log", "Log.txt");
            //saving the data in a text file called Log.txt within the Log folder which must be
            //created at the Project root directory
            File.AppendAllText(filePath, message);
        }
    }
}
