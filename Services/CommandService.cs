using Atlassian.Jira;
using Issue = JiraAutomation.Models.Issue;

namespace JiraAutomation.Services
{
    public class CommandService
    {
        private readonly int SubTasksTotal = 6;

        public async Task CreateSubTasksCommandAsync(Issue issue, Jira jira, string subTaskId, string resource, string name)
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
