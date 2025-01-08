namespace FilterProject.Models
{
    public class MyCustomModel
    {
        public string? Name { get; set; }
        public string? Address { get; set; }

        public void TransformData()
        {
            Name += " - Transformed";
            Address += " - Transformed";
        }
    }
}
