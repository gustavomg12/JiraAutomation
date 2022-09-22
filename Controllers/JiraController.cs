using JiraAutomation.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using Issue = JiraAutomation.Models.Issue;

namespace JiraAutomation.Controllers
{
    [ApiController]
    [Route("v1/JiraAutomation")]
    public class JiraController : Controller
    {
        private readonly JiraService _jiraService;

        public JiraController(JiraService jiraService)
        {
            _jiraService = jiraService;
        }

        [HttpPost]
        public async Task<IActionResult> WebHookReceiver([FromBody] JsonElement issue)
        {
            var jiraIssue = JsonConvert.DeserializeObject<Issue>(issue.ToString());

            if (jiraIssue?.Fields.Customfield_10300 == null) return NoContent();

            await _jiraService.GetIssueComponent(jiraIssue);

            return Ok();
        }
    }
}
