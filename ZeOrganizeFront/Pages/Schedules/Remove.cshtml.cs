using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ZeOrganizeFront.Models;
using ZeOrganizeFront.Models.APIConnection;

namespace ZeOrganizeFront.Pages.Schedules
{
    [BindProperties]
    public class Remove : PageModel
    {
        public ScheduleModel Schedule { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var httpClient = new HttpClient();
            var url = $"{APIConnection.URL}/Schedules/{id}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            var schedule = JsonConvert.DeserializeObject<ScheduleModel>(content);

            Schedule = schedule!;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var httpClient = new HttpClient();
            var url = $"{APIConnection.URL}/Schedules/{id}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, url);

            var response = await httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Schedules/Index");
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, content);

                return Page();
            }
        }
    }
}
