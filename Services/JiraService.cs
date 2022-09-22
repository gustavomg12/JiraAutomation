using Atlassian.Jira;
using JiraAutomation.Models;
using Issue = JiraAutomation.Models.Issue;

namespace JiraAutomation.Services
{
    public class JiraService
    {
        public readonly string SubTaskId = "10004";

        private readonly CommandService _commandService;
        private readonly QueryService _queryService;
        private readonly ModalService _modalService;
        private readonly EmailService _emailService;

        public JiraService(CommandService commandService, QueryService queryService, ModalService modalService, EmailService emailService)
        {
            _commandService = commandService;
            _queryService = queryService;
            _modalService = modalService;
            _emailService = emailService;
        }

        public async Task GetIssueComponent(Issue issue)
        {
            var (resource, name) = GetResourceAndName(issue.Fields.Description);
            var componentType = issue.Fields.Customfield_10300.Value;
            var jira = JiraConnection();

            switch (componentType)
            {
                case "Command":
                    await _commandService.CreateSubTasksCommandAsync(issue, jira, SubTaskId, resource, name);
                    break;
                case "Query":
                    await _queryService.CreateSubTasksQueryAsync(issue, jira, SubTaskId, resource, name);
                    break;
                case "Modal":
                    await _modalService.CreateSubTasksModalAsync(issue, jira, SubTaskId, resource, name);
                    break;
                case "Email Template":
                    await _emailService.CreateSubTasksEmailAsync(issue, jira, SubTaskId, resource, name);
                    break;
                default:
                    return;
            }
        }

        private static (string resource, string name) GetResourceAndName(string description)
        {
            if (string.IsNullOrEmpty(description)) return (string.Empty, string.Empty);

            var text = description.Replace("\r", string.Empty).Split("----")[0].Split("\n");

            var resource = text[0].Replace("Resource: ", string.Empty);
            var name = text[1].Replace("Name: ", string.Empty);

            return (resource, name);
        }

        private Jira JiraConnection()
        {
            var jira = Jira.CreateRestClient("http://localhost:8080", "gustavo.gomes", "Golf.123");

            return jira;
        }
    }
}
