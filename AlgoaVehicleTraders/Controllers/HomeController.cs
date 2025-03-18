using AlgoaVehicleTraders.Models.Cars;
using AlgoaVehicleTraders.Models.All;

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using AlgoaVehicleTraders.Data;
using Microsoft.EntityFrameworkCore;

using System.Net;
using System.Net.Mail;
using AlgoaVehicleTraders.Models.Bikes;
using AlgoaVehicleTraders.Models.Boats;
using AlgoaVehicleTraders.Models.Caravans;
using AlgoaVehicleTraders.Models.Trailers;

namespace AlgoaVehicleTraders.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        public string ConnString = @"";

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, ApplicationDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            ConnString = _configuration.GetConnectionString("DefaultConnection")!;
            _context = context;
        }

        public IActionResult Index()
        {
            // Perform join operations to retrieve the necessary related data (Car, Brand, FuelType, Transmission, and CarAdditional)
            var currentDate = DateTime.Now;
            var cars = from car in _context.Car
                       where car.Status == 1 ||
                                (car.Status == 3 && car.StatusChangeDate.HasValue &&
                                EF.Functions.DateDiffDay(car.StatusChangeDate.Value, currentDate) <= 7)

                       join brand in _context.Brand on car.Brand equals brand.ID
                       join fuelType in _context.FuelType on car.FuelType equals fuelType.ID
                       join transmission in _context.Transmission on car.Transmission equals transmission.ID
                       join additional in _context.CarAdditional on car.ID equals additional.CarID into carGroup
                       from additional in carGroup.DefaultIfEmpty()  // Left join to include cars with no CarAdditional data
                       join drivetrain in _context.DriveTrain on car.DriveTrain equals drivetrain.ID
                       join cartype in _context.Type on car.Type equals cartype.ID
                       select new CarViewModel
                       {
                           Car = car,
                           Additional = additional,  // Include CarAdditional data
                           Brand = brand.BrandName,
                           FuelType = fuelType.FuelTypeName,
                           Transmission = transmission.TransmissionName,
                           DriveTrain = drivetrain.DriveTrainName,
                           CarType = cartype.TypeName
                       };

            // Convert the result to a list and pass it to the view
            return View(cars.ToList());
        }




        public IActionResult ViewMore(int id)
        {
            // Fetch the car and related data using the provided ID
            var carViewModel = (from car in _context.Car
                                join brand in _context.Brand on car.Brand equals brand.ID
                                join fuelType in _context.FuelType on car.FuelType equals fuelType.ID
                                join transmission in _context.Transmission on car.Transmission equals transmission.ID
                                join type in _context.Type on car.Type equals type.ID
                                join additional in _context.CarAdditional on car.ID equals additional.CarID into carGroup
                                from additional in carGroup.DefaultIfEmpty()
                                join drivetrain in _context.DriveTrain on car.DriveTrain equals drivetrain.ID
                                where car.ID == id
                                select new CarViewModel
                                {
                                    Car = car,
                                    Additional = additional,
                                    Brand = brand.BrandName,
                                    FuelType = fuelType.FuelTypeName,
                                    Transmission = transmission.TransmissionName,
                                    DriveTrain = drivetrain.DriveTrainName,
                                    CarType = type.TypeName
                                }).FirstOrDefault();

            if (carViewModel == null)
            {
                return NotFound();
            }

            return View(carViewModel);
        }

        public IActionResult BikeIndex()
        {
            var currentDate = DateTime.Now;

            var bikes = from bike in _context.Bike
                       where bike.Status == 1 ||
                                (bike.Status == 3 && bike.StatusChangeDate.HasValue &&
                                EF.Functions.DateDiffDay(bike.StatusChangeDate.Value, currentDate) <= 7)

                       join brand in _context.BikeBrand on bike.Brand equals brand.ID
                       join fuelType in _context.FuelType on bike.FuelType equals fuelType.ID
                       join transmission in _context.Transmission on bike.Transmission equals transmission.ID
                       join additional in _context.BikeAdditional on bike.ID equals additional.BikeID into bikeGroup
                       from additional in bikeGroup.DefaultIfEmpty()  // Left join to include cars with no CarAdditional data
                       select new BikeViewModel
                       {
                           Bike = bike,
                           Additional = additional,
                           Brand = brand.BrandName,
                           FuelType = fuelType.FuelTypeName,
                           Transmission = transmission.TransmissionName
                       };

            return View(bikes.ToList());
        }

        public IActionResult BikeViewMore(int id)
        {
            // Fetch the car and related data using the provided ID
            var bikeViewModel = (from bike in _context.Bike
                                join brand in _context.BikeBrand on bike.Brand equals brand.ID
                                join fuelType in _context.FuelType on bike.FuelType equals fuelType.ID
                                join transmission in _context.Transmission on bike.Transmission equals transmission.ID
                                join additional in _context.BikeAdditional on bike.ID equals additional.BikeID into bikeGroup
                                from additional in bikeGroup.DefaultIfEmpty()
                                where bike.ID == id
                                select new BikeViewModel
                                {
                                    Bike = bike,
                                    Additional = additional,
                                    Brand = brand.BrandName,
                                    FuelType = fuelType.FuelTypeName,
                                    Transmission = transmission.TransmissionName
                                }).FirstOrDefault();

            if (bikeViewModel == null)
            {
                return NotFound();
            }

            return View(bikeViewModel);
        }

        public IActionResult BoatIndex()
        {
            // Perform join operations to retrieve the necessary related data (Car, Brand, FuelType, Transmission, and CarAdditional)
            var currentDate = DateTime.Now;
            var boats = from boat in _context.Boat
                       where boat.Status == 1 ||
                                (boat.Status == 3 && boat.StatusChangeDate.HasValue &&
                                EF.Functions.DateDiffDay(boat.StatusChangeDate.Value, currentDate) <= 7)

                       join brand in _context.BoatBrand on boat.Brand equals brand.ID
                       join fuelType in _context.FuelType on boat.FuelType equals fuelType.ID
                       join additional in _context.BoatAdditional on boat.ID equals additional.BoatID into boatGroup
                       from additional in boatGroup.DefaultIfEmpty()  // Left join to include cars with no CarAdditional data
                       select new BoatViewModel
                       {
                           Boat = boat,
                           Additional = additional,  // Include CarAdditional data
                           Brand = brand.BrandName,
                           FuelType = fuelType.FuelTypeName,
                       };

            // Convert the result to a list and pass it to the view
            return View(boats.ToList());
        }

        public IActionResult BoatViewMore(int id)
        {
            // Fetch the car and related data using the provided ID
            var boatViewModel = (from boat in _context.Boat
                                 join brand in _context.BikeBrand on boat.Brand equals brand.ID
                                 join fuelType in _context.FuelType on boat.FuelType equals fuelType.ID
                                 join additional in _context.BoatAdditional on boat.ID equals additional.BoatID into boatGroup
                                 from additional in boatGroup.DefaultIfEmpty()
                                 join waterdepth in _context.WaterDepth on additional.WaterDepth equals waterdepth.ID 
                                 join boattype in _context.BoatType on boat.Type equals boattype.ID
                                 where boat.ID == id
                                 select new BoatViewModel
                                 {
                                     Boat = boat,
                                     Additional = additional,
                                     Brand = brand.BrandName,
                                     FuelType = fuelType.FuelTypeName,
                                     WaterDepth = waterdepth.WaterDepthName,
                                     BoatType = boattype.BoatTypeName
                                 }).FirstOrDefault();

            if (boatViewModel == null)
            {
                return NotFound();
            }

            return View(boatViewModel);
        }

        public IActionResult CaravanIndex()
        {
            // Perform join operations to retrieve the necessary related data (Car, Brand, FuelType, Transmission, and CarAdditional)
            var currentDate = DateTime.Now;
            var caravans = from caravan in _context.Caravan
                        where caravan.Status == 1 ||
                                 (caravan.Status == 3 && caravan.StatusChangeDate.HasValue &&
                                 EF.Functions.DateDiffDay(caravan.StatusChangeDate.Value, currentDate) <= 7)

                        join brand in _context.CaravanBrand on caravan.Brand equals brand.ID
                        join type in _context.CaravanType on caravan.Type equals type.ID
                        join additional in _context.CaravanAdditional on caravan.ID equals additional.CaravanID into caravanGroup
                        from additional in caravanGroup.DefaultIfEmpty()  // Left join to include cars with no CarAdditional data
                        select new CaravanViewModel
                        {
                            Caravan = caravan,
                            Additional = additional,  // Include CarAdditional data
                            Brand = brand.BrandName,
                            Type = type.CaravanTypeName
                        };

            // Convert the result to a list and pass it to the view
            return View(caravans.ToList());
        }

        public IActionResult CaravanViewMore(int id)
        {
            // Fetch the car and related data using the provided ID
            var caravanViewModel = (from caravan in _context.Caravan
                                 join brand in _context.CaravanBrand on caravan.Brand equals brand.ID
                                 join type in _context.CaravanType on caravan.Type equals type.ID
                                 join additional in _context.CaravanAdditional on caravan.ID equals additional.CaravanID into caravanGroup
                                 from additional in caravanGroup.DefaultIfEmpty()
                                 where caravan.ID == id
                                 select new CaravanViewModel
                                 {
                                     Caravan = caravan,
                                     Additional = additional,
                                     Brand = brand.BrandName,
                                     Type = type.CaravanTypeName,                                   
                                 }).FirstOrDefault();

            if (caravanViewModel == null)
            {
                return NotFound();
            }

            return View(caravanViewModel);
        }

        public IActionResult TrailerIndex()
        {

            var currentDate = DateTime.Now;
            var trailers = from trailer in _context.Trailer
                           where trailer.Status == 1 ||
                                    (trailer.Status == 3 && trailer.StatusChangeDate.HasValue &&
                                    EF.Functions.DateDiffDay(trailer.StatusChangeDate.Value, currentDate) <= 7)

                           join brand in _context.TrailerBrand on trailer.Brand equals brand.ID
                           join type in _context.TrailerType on trailer.Type equals type.ID
                           join axle in _context.AxleType on trailer.AxleType equals axle.ID
                           join braked in _context.BrakedAxle on trailer.BrakedAxle equals braked.ID

                           join camptrailer in _context.CampTrailer on trailer.ID equals camptrailer.TrailerID into camptrailerGroup
                           from camptrailer in camptrailerGroup.DefaultIfEmpty()
                           select new TrailerViewModel
                           {
                               Trailer = trailer,
                               CampTrailer = camptrailer,
                               Brand = brand.BrandName,
                               Type = type.TypeName,
                               AxleType = axle.AxleName,
                               BrakedAxle = braked.BrakedAxleName
                           };

            return View(trailers.ToList());
        }

        [HttpGet]
        public IActionResult TrailerViewMoreSelect(int id, int type)
        {
            if (type == 1)
            {
                return RedirectToAction("CampTrailerViewMore", new {id});
            }
            else if (type == 2)
            {
                return RedirectToAction("LuggageTrailerViewMore", new {id});
            }
            else

            return RedirectToAction("TrailerIndex");
        }

        public IActionResult LuggageTrailerViewMore(int id)
        {
            // Fetch the car and related data using the provided ID
            var trailerViewModel = (from trailer in _context.Trailer
                                    join brand in _context.TrailerBrand on trailer.Brand equals brand.ID
                                    join type in _context.TrailerType on trailer.Type equals type.ID
                                    join axle in _context.AxleType on trailer.AxleType equals axle.ID
                                    join braked in _context.BrakedAxle on trailer.BrakedAxle equals braked.ID

                                    join camptrailer in _context.CampTrailer on trailer.ID equals camptrailer.TrailerID into trailerGroup
                                    from camptrailer in trailerGroup.DefaultIfEmpty()
                                    where trailer.ID == id
                                    select new TrailerViewModel
                                    {
                                        Trailer = trailer,
                                        CampTrailer = camptrailer,
                                        Brand = brand.BrandName,
                                        Type = type.TypeName,
                                        AxleType = axle.AxleName,
                                        BrakedAxle = braked.BrakedAxleName
                                    }).FirstOrDefault();

            if (trailerViewModel == null)
            {
                return NotFound();
            }

            return View(trailerViewModel);
        }

        public IActionResult CampTrailerViewMore(int id)
        {
            // Fetch the car and related data using the provided ID
            var trailerViewModel = (from trailer in _context.Trailer
                                    join brand in _context.TrailerBrand on trailer.Brand equals brand.ID
                                    join type in _context.TrailerType on trailer.Type equals type.ID
                                    join braked in _context.BrakedAxle on trailer.BrakedAxle equals braked.ID
                                    join axle in _context.AxleType on trailer.AxleType equals axle.ID


                                    join camptrailer in _context.CampTrailer on trailer.ID equals camptrailer.TrailerID into trailerGroup
                                    from camptrailer in trailerGroup.DefaultIfEmpty()
                                    where trailer.ID == id
                                    select new TrailerViewModel
                                    {
                                        Trailer = trailer,
                                        CampTrailer = camptrailer,
                                        Brand = brand.BrandName,
                                        Type = type.TypeName,
                                        AxleType = axle.AxleName,
                                        BrakedAxle = braked.BrakedAxleName
                                    }).FirstOrDefault();

            if (trailerViewModel == null)
            {
                return NotFound();
            }

            return View(trailerViewModel);
        }


        #region navbar options
        public ActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ContactUs(string contactDetails, string userMessage)
        {
            if (string.IsNullOrEmpty(userMessage) || string.IsNullOrEmpty(contactDetails))
            {
                ModelState.AddModelError("", "Contact details and message cannot be empty");
                return RedirectToAction("AboutUs");
            }

            string subject = "Customer general query.";
            var body = $"Message from customer (general query): {contactDetails}\n" +
                        $"\n{userMessage}";
            var companyEmail = (from company in _context.CompanyDetails
                                select company.CompanyEmail).FirstOrDefault();

            try
            {
                if (!string.IsNullOrEmpty(contactDetails))
                {
                    SendEmail("danielgibson.pe@gmail.com", subject, body);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }

            TempData["SuccessMessage"] = "Your inquiry has been sent successfully!";

            return RedirectToAction("AboutUs");

        }

        public IActionResult Sell()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }
        #endregion





        //Email Code

        [HttpPost]
        public IActionResult Emails(int ID, string category, string VehicleName, string userEmail, string userMessage)
        {
            if (string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(userMessage))
            {
                ModelState.AddModelError("", "Email and message cannot be empty.");
                return RedirectToAction("ViewMore", new { id = ID });
            }

            var subject = $"Customer {category} query: {VehicleName}";
            var body = $"Email from customer: {userEmail}" + "\n" +
                       "\nMessage:" + "\n" +
                       $"{userMessage}" + "\n";

            var companyEmail = (from company in _context.CompanyDetails
                                select company.CompanyEmail).FirstOrDefault();

            var subject2 = "Vehicle query sent";
            var body2 = $"Your email has been sent regarding the {category}: {VehicleName}.\n" +
                        "Someone will get back to you shortly.";

            //send email to company
            try
            {
                if (!string.IsNullOrEmpty(companyEmail))
                {
                    SendEmail("danielgibson.pe@gmail.com", subject, body);

                    //SendEmail(companyEmail, subject, body);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }

            //send email to user
            try
            {
                SendEmail(userEmail, subject2, body2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }


            TempData["SuccessMessage"] = "Your inquiry has been sent successfully!";

            if (category == "Car")
                return RedirectToAction("ViewMore", new { id = ID });
            else if (category == "Bike")
                return RedirectToAction("BikeViewMore", new { id = ID });
            else if (category == "Boat")
                return RedirectToAction("BoatViewMore", new { id = ID });
            else if (category == "Caravan")
                return RedirectToAction("CaravanViewMore", new { id = ID });
            else if (category == "Luggage Trailer")
                return RedirectToAction("LuggageTrailerViewMore", new { id = ID });
            else if (category == "Luggage Trailer")
                return RedirectToAction("CampTrailerViewMore", new { id = ID });
            else
                return RedirectToAction("ViewMore", new { id = ID });
        }

        //public IActionResult SellEmail(string fullname, string fromDetails, string reason, string vehicle)
        //{
        //    if (string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(fromDetails) || string.IsNullOrEmpty(vehicle))
        //    {
        //        ModelState.AddModelError("", "Fill all required fields");
        //        return RedirectToAction("ViewMore");
        //    }
        //}



        private void SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                var smtpServer = _configuration["Gmail:SmtpServer"];
                var port = int.Parse(_configuration["Gmail:Port"]!);
                var fromEmail = _configuration["Gmail:Username"];
                var password = _configuration["Gmail:Password"];

                using (var client = new SmtpClient(smtpServer, port))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(fromEmail, password);

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(fromEmail!),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = false,
                    };
                    mailMessage.To.Add(toEmail);
                    mailMessage.Headers.Add("X-Priority", "3");          // 3 = Normal priority
                    mailMessage.Headers.Add("X-MSMail-Priority", "Normal");
                    mailMessage.Headers.Add("Importance", "Normal");

                    client.Send(mailMessage);
                }
            }
            catch (SmtpException ex)
            {
                Console.WriteLine("SMTP Error: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
            }

            catch (Exception ex)
            {
                // Handle any other exceptions
                Console.WriteLine("General Error: " + ex.Message);
            }
        }


        


    }
}
