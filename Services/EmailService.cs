using Atlassian.Jira;
using JiraAutomation.Models;
using Issue = JiraAutomation.Models.Issue;

namespace JiraAutomation.Services
{
    public class EmailService
    {
        private readonly int SubTasksTotal = 3;

        public async Task CreateSubTasksEmailAsync(Issue issue, Jira jira, string subTaskId, string resource, string name)
        {
            for (var i = 0; i < SubTasksTotal; i++)
            {
                var subTask = jira.CreateIssue(issue.Fields.Project.Key, issue.Key);
                subTask.Type = subTaskId;
                subTask.Summary = $"Sub-task {resource}";
                subTask.Description = $"Description {name}";

                await subTask.SaveChangesAsync();
            }
        }
    }
}
