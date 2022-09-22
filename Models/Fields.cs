using Microsoft.Extensions.FileSystemGlobbing;
using System;

namespace JiraAutomation.Models
{
    public class Fields
    {
        public IssueType Issuetype { get; set; }
        
        public string Description { get; set; }

        public Project Project { get; set; }

        public string Summary { get; set; }

        public Customfield10300 Customfield_10300 { get; set; }
    }
}
