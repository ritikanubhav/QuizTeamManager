using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using QuizTeam.Domain.Entities;
using QuizTeam.Web.Models;
namespace QuizTeam.Web.Controllers
{
    public class TeamController : Controller
    {
        private readonly HttpClient client = new HttpClient();
        private string BaseUri;
        public TeamController()
        {
            //setting client for api call
            string BaseUri = "https://localhost:44388";
            client.BaseAddress = new Uri(BaseUri);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        }
        public IActionResult Index()
        {
            // getting data by calling apis to send to view
            try
            {
                //1. calling member api to get all members data
                var memberResponse = client.GetFromJsonAsync<List<Member>>($"{BaseUri}/api/Members").Result;
                ViewBag.members = memberResponse;

                //2.calling Team Api to get all team details
                var TeamResponse = client.GetFromJsonAsync<List<Team>>($"{BaseUri}/api/Teams").Result;

                return View(TeamResponse);
            }
            catch(Exception ex)
            {
                // Return a error view -- Created for my own debugging purpose
                return View("Error", new ErrorViewModel { ShowException=true, Message=ex.Message, exception=ex });
            }
        }

        public async Task<IActionResult> Add(int memberId,int teamId)
        {
            try
            {
                //1. calling member api to get  members data
                var member = client.GetFromJsonAsync<Member>($"{BaseUri}/api/Members/{memberId}").Result;
                //2. calling team api to get team
                var team= client.GetFromJsonAsync<Team>($"{BaseUri}/api/Teams/{teamId}").Result;

                if (team== null)
                {
                    TempData["Message"] = "No Team Selected";

                }
                else if (member==null) 
                {
                    TempData["Message"] = "No Member Selected";

                }
                // Check if the team has fewer than 3 members
                else if (team.Members.Count < 3)
                {
                    team.Members.Add(member);

                    // Serialize the team object to JSON
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(team), Encoding.UTF8, "application/json");

                    // Call the HTTP PUT API to update the team in the database
                    var response = await client.PatchAsync($"{BaseUri}/api/Teams?id={team.TeamId}", jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["Message"] = "Member added successfully!";
                    }
                    else
                    {
                        TempData["Message"] = "Failed to Add to the "+ team.Name+"*********"+member.Name+" "+response.ToString(); 
                    }
                }
                else
                {
                    TempData["Message"] = "Team size cannot exceed 3 members.";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Return an error view for debugging purposes
                return View("Error", new ErrorViewModel { ShowException = true, Message = ex.Message, exception = ex });
            }
        }
    }
}
