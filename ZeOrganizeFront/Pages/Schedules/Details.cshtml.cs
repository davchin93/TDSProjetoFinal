using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ZeOrganizeFront.Models;
using ZeOrganizeFront.Models.APIConnection;

namespace ZeOrganizeFront.Pages.Schedules
{
    public class Details : PageModel
    {
        [BindProperty]
        public List<ActivityModel> ActivitiesList { get; set; } = new();
        public int ScheduleId { get; set; } = new();


        public async Task<IActionResult> OnGetAsync(int id)
        {
            ScheduleId = id;

            var httpClient = new HttpClient();
            var url = $"{APIConnection.URL}/ActivitiesBySchedule/{id}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            var activitiesList = JsonConvert.DeserializeObject<List<ActivityModel>>(content);
            ActivitiesList = activitiesList!;

            return Page();
        }
    }
}
