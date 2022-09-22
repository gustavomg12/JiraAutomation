using Atlassian.Jira;

namespace JiraAutomation.Models
{
    public class Project
    {
        public string Self { get; set; }

        public int Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public object Description { get; set; }
    }
}
