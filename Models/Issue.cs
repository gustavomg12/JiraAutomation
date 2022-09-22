namespace JiraAutomation.Models
{
    public class Issue
    {
        public string Self { get; set; }

        public int Id { get; set; }

        public string Key { get; set; }

        public Fields Fields { get; set; }
    }
}
