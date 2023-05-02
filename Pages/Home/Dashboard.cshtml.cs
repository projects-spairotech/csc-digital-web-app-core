using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace csc_digital_web_app.Pages.Home
{
    public class DashboardModel : PageModel
    {
        private readonly ILogger<DashboardModel> _logger;
        public DashboardModel(ILogger<DashboardModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }

        /*
       public async Task<IActionResult> Index()
       {
           List<Reservation> reservationList = new List<Reservation>();
           using (var httpClient = new HttpClient())
           {
               using (var response = await httpClient.GetAsync("https://localhost:44324/api/Reservation"))
               {
                   string apiResponse = await response.Content.ReadAsStringAsync();
                   reservationList = JsonConvert.DeserializeObject<List<Reservation>>(apiResponse);
               }
           }
           return View(reservationList);
       }

       public async Task<IActionResult> UpdateReservation(int id)
       {
           Reservation reservation = new Reservation();
           using (var httpClient = new HttpClient())
           {
               using (var response = await httpClient.GetAsync("https://localhost:44324/api/Reservation/" + id))
               {
                   string apiResponse = await response.Content.ReadAsStringAsync();
                   reservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
               }
           }
           return View(reservation);
       }

       [HttpPost]
       public async Task<IActionResult> UpdateReservation(Reservation reservation)
       {
           Reservation receivedReservation = new Reservation();
           using (var httpClient = new HttpClient())
           {
               var content = new MultipartFormDataContent();
               content.Add(new StringContent(reservation.Id.ToString()), "Id");
               content.Add(new StringContent(reservation.Name), "Name");
               content.Add(new StringContent(reservation.StartLocation), "StartLocation");
               content.Add(new StringContent(reservation.EndLocation), "EndLocation");

               using (var response = await httpClient.PutAsync("https://localhost:44324/api/Reservation", content))
               {
                   string apiResponse = await response.Content.ReadAsStringAsync();
                   ViewBag.Result = "Success";
                   receivedReservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
               }
           }
           return View(receivedReservation);
       }

       [HttpPost]
       public async Task<IActionResult> GetReservation(int id)
       {
           Reservation reservation = new Reservation();
           using (var httpClient = new HttpClient())
           {
               using (var response = await httpClient.GetAsync("https://localhost:44324/api/Reservation/" + id))
               {
                   if (response.StatusCode == System.Net.HttpStatusCode.OK)
                   {
                       string apiResponse = await response.Content.ReadAsStringAsync();
                       reservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
                   }
                   else
                       ViewBag.StatusCode = response.StatusCode;
               }
           }
           return View(reservation);
       }

       [HttpPost]
       public async Task<IActionResult> AddReservation(Reservation reservation)
       {
           Reservation receivedReservation = new Reservation();
           using (var httpClient = new HttpClient())
           {
               StringContent content = new StringContent(JsonConvert.SerializeObject(reservation), Encoding.UTF8, "application/json");

               using (var response = await httpClient.PostAsync("https://localhost:44324/api/Reservation", content))
               {
                   string apiResponse = await response.Content.ReadAsStringAsync();
                   receivedReservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
               }
           }
           return View(receivedReservation);
       }

       public async Task<IActionResult> UpdateReservationPatch(int id)
       {
           Reservation reservation = new Reservation();
           using (var httpClient = new HttpClient())
           {
               using (var response = await httpClient.GetAsync("https://localhost:44324/api/Reservation/" + id))
               {
                   string apiResponse = await response.Content.ReadAsStringAsync();
                   reservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
               }
           }
           return View(reservation);
       }

       [HttpPost]
       public async Task<IActionResult> UpdateReservationPatch(int id, Reservation reservation)
       {
           using (var httpClient = new HttpClient())
           {
               var request = new HttpRequestMessage
               {
                   RequestUri = new Uri("https://localhost:44324/api/Reservation/" + id),
                   Method = new HttpMethod("Patch"),
                   Content = new StringContent("[{ \"op\": \"replace\", \"path\": \"Name\", \"value\": \"" + reservation.Name + "\"},{ \"op\": \"replace\", \"path\": \"StartLocation\", \"value\": \"" + reservation.StartLocation + "\"}]", Encoding.UTF8, "application/json")
               };

               var response = await httpClient.SendAsync(request);
           }
           return RedirectToAction("Index");
       }

       [HttpPost]
       public async Task<IActionResult> DeleteReservation(int ReservationId)
       {
           using (var httpClient = new HttpClient())
           {
               using (var response = await httpClient.DeleteAsync("https://localhost:44324/api/Reservation/" + ReservationId))
               {
                   string apiResponse = await response.Content.ReadAsStringAsync();
               }
           }

           return RedirectToAction("Index");
       }

       [HttpPost]
       public async Task<IActionResult> AddReservation(Reservation reservation)
       {
           Reservation receivedReservation = new Reservation();
           using (var httpClient = new HttpClient())
           {
               httpClient.DefaultRequestHeaders.Add("Key", "Secret@123");
               StringContent content = new StringContent(JsonConvert.SerializeObject(reservation), Encoding.UTF8, "application/json");

               using (var response = await httpClient.PostAsync("https://localhost:44324/api/Reservation", content))
               {
                   string apiResponse = await response.Content.ReadAsStringAsync();

                   if (response.StatusCode == System.Net.HttpStatusCode.OK)
                       receivedReservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
                   else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                   {
                       ViewBag.Result = apiResponse;
                       return View();
                   }
               }
           }
           return View(receivedReservation);
       }

       [HttpPost("UploadFile")]
       public async Task<string> UploadFile([FromForm] IFormFile file)
       {
           string path = Path.Combine(webHostEnvironment.WebRootPath, "Images/" + file.FileName);
           using (var stream = new FileStream(path, FileMode.Create))
           {
               await file.CopyToAsync(stream);
           }
           return "https://localhost:44324/Images/" + file.FileName;
       }

       [HttpPost]
       public async Task<IActionResult> AddFile(IFormFile file)
       {
           string apiResponse = "";
           using (var httpClient = new HttpClient())
           {
               var form = new MultipartFormDataContent();
               using (var fileStream = file.OpenReadStream())
               {
                   form.Add(new StreamContent(fileStream), "file", file.FileName);
                   using (var response = await httpClient.PostAsync("https://localhost:44324/api/Reservation/UploadFile", form))
                   {
                       response.EnsureSuccessStatusCode();
                       apiResponse = await response.Content.ReadAsStringAsync();
                   }
               }
           }
           return View((object)apiResponse);
       }

       private static List<CustomerModel> SearchCustomers(string name)
       {
           List<CustomerModel> customers = new List<CustomerModel>();
           string apiUrl = "https://localhost:44318/api/CustomerAPI";

           HttpClient client = new HttpClient();
           HttpResponseMessage response = client.GetAsync(apiUrl + string.Format("/GetCustomers?name={0}", name)).Result;
           if (response.IsSuccessStatusCode)
           {
               customers = JsonConvert.DeserializeObject<List<CustomerModel>>(response.Content.ReadAsStringAsync().Result);
           }

           return customers;
       }

       public async Task<JsonResult> OnGetIncidentsAsync()
       {
           List<Car> incidents = new List<Car>();
           using (var httpClient = new HttpClient())
           {
               using (HttpResponseMessage response = await httpClient.GetAsync("https://localhost:44300/api/Car"))
               {
                   string apiResponse = await response.Content.ReadAsStringAsync();
                   incidents = JsonConvert.DeserializeObject<List<Car>>(apiResponse);
               }
           }
           return new JsonResult(incidents);
       }

       public async Task<JsonResult> OnGetIncidentsAsync()
       {
           List<IncidentModel> incidents = new List<IncidentModel>();
           using (var httpClient = new HttpClient())
           {
               using (HttpResponseMessage response = await httpClient.GetAsync("https://localhost:52189/api/incident/"))
               {
                   string apiResponse = await response.Content.ReadAsStringAsync();
                   incidents = JsonConvert.DeserializeObject<List<IncidentModel>>(apiResponse);
               }
           }
           return new JsonResult(incidents);
       }
       */

    }

    /*public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Doors { get; set; }
        public string Colour { get; set; }
        public decimal Price { get; set; }
    }*/
}
