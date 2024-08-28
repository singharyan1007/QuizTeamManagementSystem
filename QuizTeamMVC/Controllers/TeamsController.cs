using Microsoft.AspNetCore.Mvc;
using TeamManagement.Domain.Repository;

namespace QuizTeamMVC.Controllers
{
    public class TeamsController : Controller
    {
        private readonly HttpClient client=new HttpClient();
        
       
        public TeamsController(ITeamRepository teamRepo, IMemberRepository memberRepo)
        {
            string BaseUri = "https://localhost:44371";
            client.BaseAddress=new Uri(BaseUri);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
