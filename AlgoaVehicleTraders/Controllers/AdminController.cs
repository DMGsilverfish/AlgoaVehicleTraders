using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AlgoaVehicleTraders.Models.All;
using SQLitePCL;
using Microsoft.AspNetCore.Identity;
using AlgoaVehicleTraders.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using AlgoaVehicleTraders.Models.Cars;
using AlgoaVehicleTraders.Models.Bikes;
using AlgoaVehicleTraders.Models.Boats;
using AlgoaVehicleTraders.Models.Caravans;
using AlgoaVehicleTraders.Models.Trailers;


using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace AlgoaVehicleTraders.Controllers
{
    public class AdminController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AdminController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public string? ConnString = @"";
        public AdminController(SignInManager<IdentityUser> signInManager, ILogger<AdminController> logger, IConfiguration configuration, ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _logger = logger;
            _configuration = configuration;
            _context = context;
            ConnString = _configuration.GetConnectionString("DefaultConnection");

        }
        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult AddVehicle()
        {

            var brands = _context.Brand.OrderBy(b => b.BrandName).ToList();
            var types = _context.Type.OrderBy(t => t.TypeName).ToList();
            var fuelTypes = _context.FuelType.OrderBy(f => f.FuelTypeName).ToList();
            var transmission = _context.Transmission.OrderBy(t => t.TransmissionName).ToList();
            var drivetrain = _context.DriveTrain.OrderBy(dt => dt.DriveTrainName).ToList();

            var viewModel = new AddVehicleViewModel
            {
                Brands = brands.Select(b => new SelectListItem
                {
                    Value = b.ID.ToString(), // Assuming Id is the primary key
                    Text = b.BrandName
                }),
                Types = types.Select(t => new SelectListItem
                {
                    Value = t.ID.ToString(), // Assuming Id is the primary key
                    Text = t.TypeName
                }),
                FuelTypes = fuelTypes.Select(f => new SelectListItem
                {
                    Value = f.ID.ToString(),
                    Text = f.FuelTypeName
                }),
                Transmissions = transmission.Select(t => new SelectListItem
                {
                    Value = t.ID.ToString(),
                    Text = t.TransmissionName
                }),
                DriveTrains = drivetrain.Select(d => new SelectListItem
                {
                    Value = d.ID.ToString(),
                    Text = d.DriveTrainName
                })

            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVehicle(AddVehicleViewModel viewModel, IFormFile[] exteriorImages, IFormFile[] interiorImages, IFormFile[] otherImages)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert into Car table (as before)
                    var car = new Car
                    {
                        Model = viewModel.Model!,
                        Brand = viewModel.Brand,
                        Type = viewModel.Type,
                        Price = viewModel.Price,
                        Mileage = viewModel.Mileage,
                        Year = viewModel.Year,
                        FuelType = viewModel.FuelType,
                        Transmission = viewModel.Transmission,
                        DriveTrain = viewModel.DriveTrain,
                        Colour = viewModel.Colour!,
                        Condition = viewModel.Condition!,
                        EngineSize = viewModel.EngineSize!,
                        Status = viewModel.Status,
                        StatusChangeDate = viewModel.StatusChangeDate,
                    };

                    _context.Car.Add(car);
                    await _context.SaveChangesAsync();

                    // If Car ID is auto-generated, fetch it
                    var carId = car.ID;



                    // Prepare the CarAdditional object for image data
                    var carAdditional = new CarAdditional
                    {
                        CarID = carId,
                        LeatherSeats = viewModel.LeatherSeats,
                        TowBar = viewModel.TowBar,
                        PowerSteering = viewModel.PowerSteering,
                        CentralLocking = viewModel.CentralLocking,
                        MultiFunctionSteerWheel = viewModel.MultiFunctionSteerWheel,
                        ReverseCamera = viewModel.ReverseCamera,
                        Alarm = viewModel.Alarm,
                        Radio = viewModel.Radio,
                        SpeedControl = viewModel.SpeedControl,
                        ParkDistanceControl = viewModel.ParkDistanceControl,
                        HeatedSeats = viewModel.HeatedSeats,
                        SpareKey = viewModel.SpareKey,
                        ElectricMirrors = viewModel.ElectricMirrors,
                        NumberSeats = viewModel.NumberSeats,
                        NumberDoors = viewModel.NumberDoors,
                        ElectricWindows = viewModel.ElectricWindows,
                        AC = viewModel.AC,
                        Sunroof = viewModel.Sunroof,
                        FullServiceHistory = viewModel.FullServiceHistory
                    };



                    // Process exterior images
                    if (exteriorImages != null && exteriorImages.Length > 0)
                    {
                        for (int i = 0; i < exteriorImages.Length && i < 6; i++)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await exteriorImages[i].CopyToAsync(memoryStream);
                                var imageBytes = memoryStream.ToArray();
                                // Assign to corresponding exterior field
                                switch (i)
                                {
                                    case 0: carAdditional.Exterior1 = imageBytes; break;
                                    case 1: carAdditional.Exterior2 = imageBytes; break;
                                    case 2: carAdditional.Exterior3 = imageBytes; break;
                                    case 3: carAdditional.Exterior4 = imageBytes; break;
                                    case 4: carAdditional.Exterior5 = imageBytes; break;
                                    case 5: carAdditional.Exterior6 = imageBytes; break;
                                }
                            }
                        }
                    }

                    // Process interior images
                    if (interiorImages != null && interiorImages.Length > 0)
                    {
                        for (int i = 0; i < interiorImages.Length && i < 4; i++)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await interiorImages[i].CopyToAsync(memoryStream);
                                var imageBytes = memoryStream.ToArray();
                                // Assign to corresponding interior field
                                switch (i)
                                {
                                    case 0: carAdditional.Interior1 = imageBytes; break;
                                    case 1: carAdditional.Interior2 = imageBytes; break;
                                    case 2: carAdditional.Interior3 = imageBytes; break;
                                    case 3: carAdditional.Interior4 = imageBytes; break;
                                }
                            }
                        }
                    }

                    // Process other images
                    if (otherImages != null && otherImages.Length > 0)
                    {
                        for (int i = 0; i < otherImages.Length && i < 2; i++)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await otherImages[i].CopyToAsync(memoryStream);
                                var imageBytes = memoryStream.ToArray();
                                // Assign to corresponding other field
                                switch (i)
                                {
                                    case 0: carAdditional.Other1 = imageBytes; break;
                                    case 1: carAdditional.Other2 = imageBytes; break;
                                }
                            }
                        }
                    }



                    // Save the images into the CarAdditional table
                    _context.CarAdditional.Add(carAdditional);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Vehicle added successfully with images!";
                    return RedirectToAction("AddVehicle");
                }
                catch (Exception ex)
                {
                    // Log the error
                    _logger.LogError(ex, "Error adding vehicle with images");
                    ModelState.AddModelError("", "An error occurred while adding the vehicle. Please try again.");
                }
            }
            #region load dropdowns
            // If validation fails, reload dropdowns and return the view
            viewModel.Brands = _context.Brand.Select(b => new SelectListItem
            {
                Value = b.ID.ToString(),
                Text = b.BrandName
            });

            viewModel.Types = _context.Type.Select(t => new SelectListItem
            {
                Value = t.ID.ToString(),
                Text = t.TypeName
            });

            viewModel.FuelTypes = _context.FuelType.Select(f => new SelectListItem
            {
                Value = f.ID.ToString(),
                Text = f.FuelTypeName
            });

            viewModel.Transmissions = _context.Transmission.Select(t => new SelectListItem
            {
                Value = t.ID.ToString(),
                Text = t.TransmissionName
            });
            #endregion


            return View(viewModel);
        }


        public IActionResult VehicleDetailsList()
        {
            var vehicles = (from car in _context.Car
                            join brand in _context.Brand on car.Brand equals brand.ID
                            join additional in _context.CarAdditional on car.ID equals additional.CarID
                            select new EditCarListViewModel
                            {
                                ID = car.ID,
                                BrandName = brand.BrandName, // Retrieve the brand name
                                Model = car.Model,
                                Year = car.Year,
                                Price = car.Price,
                                Mileage = car.Mileage,
                                ExteriorImage1Base64 = additional.Exterior1 != null
                                    ? "data:image/jpeg;base64," + Convert.ToBase64String(additional.Exterior1)
                                    : null!
                            }).ToList();

            return View(vehicles);
        }

        [HttpGet]
        public IActionResult VehicleDetails(int ID)

        {
            // Fetch the vehicle and its additional details
            var vehicle = (from car in _context.Car
                           join additional in _context.CarAdditional on car.ID equals additional.CarID
                           where car.ID == ID
                           select new { car, additional }).FirstOrDefault();



            if (vehicle == null)
            {
                return NotFound(); // Return a 404 if the vehicle is not found
            }

            // Convert byte arrays to base64 strings
            Func<byte[]?, string> toBase64 = bytes => bytes != null ? $"data:image/jpeg;base64,{Convert.ToBase64String(bytes)}" : null!;

            // Populate the view model
            var viewModel = new AddVehicleViewModel
            {
                // Car details
                Id = vehicle.car.ID,
                Brand = vehicle.car.Brand,
                Model = vehicle.car.Model,
                Year = vehicle.car.Year,
                Mileage = vehicle.car.Mileage,
                Price = vehicle.car.Price,
                EngineSize = vehicle.car.EngineSize,
                FuelType = vehicle.car.FuelType,
                Transmission = vehicle.car.Transmission,
                DriveTrain = vehicle.car.DriveTrain,
                Condition = vehicle.car.Condition,
                Type = vehicle.car.Type,
                Colour = vehicle.car.Colour,
                Status = vehicle.car.Status,
                StatusChangeDate = vehicle.car.StatusChangeDate,
                NumberDoors = vehicle.additional?.NumberDoors ?? 0,
                NumberSeats = vehicle.additional?.NumberSeats ?? 0,
                ElectricWindows = vehicle.additional?.ElectricWindows ?? 0,

                AC = vehicle.additional!.AC,
                Alarm = vehicle.additional.Alarm,
                CentralLocking = vehicle.additional.CentralLocking,
                ElectricMirrors = vehicle.additional.ElectricMirrors,
                HeatedSeats = vehicle.additional.HeatedSeats,
                LeatherSeats = vehicle.additional.LeatherSeats,
                MultiFunctionSteerWheel = vehicle.additional.MultiFunctionSteerWheel,
                ParkDistanceControl = vehicle.additional.ParkDistanceControl,
                PowerSteering = vehicle.additional.PowerSteering,
                ReverseCamera = vehicle.additional.ReverseCamera,
                SpareKey = vehicle.additional.SpareKey,
                Sunroof = vehicle.additional.Sunroof,
                SpeedControl = vehicle.additional.SpeedControl,
                TowBar = vehicle.additional.TowBar,
                Radio = vehicle.additional.Radio,
                FullServiceHistory = vehicle.additional.FullServiceHistory,

                // Existing images as base64 strings
                ExteriorImageBase64 = new[]
                {
                    vehicle.additional.Exterior1, vehicle.additional.Exterior2,
                    vehicle.additional.Exterior3, vehicle.additional.Exterior4,
                    vehicle.additional.Exterior5, vehicle.additional.Exterior6
                }.Where(img => img != null).Select(toBase64).ToArray(),

                InteriorImageBase64 = new[]
                {
                    vehicle.additional.Interior1, vehicle.additional.Interior2,
                    vehicle.additional.Interior3, vehicle.additional.Interior4
                }.Where(img => img != null).Select(toBase64).ToArray(),

                OtherImageBase64 = new[]
                {
                    vehicle.additional.Other1, vehicle.additional.Other2
                }.Where(img => img != null).Select(toBase64).ToArray(),

                // Dropdowns
                Brands = new SelectList(_context.Brand.OrderBy(b => b.BrandName), "ID", "BrandName"),
                Types = new SelectList(_context.Type.OrderBy(t => t.TypeName), "ID", "TypeName"),
                FuelTypes = new SelectList(_context.FuelType.OrderBy(f => f.FuelTypeName), "ID", "FuelTypeName"),
                Transmissions = new SelectList(_context.Transmission.OrderBy(t => t.TransmissionName), "ID", "TransmissionName"),
                DriveTrains = new SelectList(_context.DriveTrain.OrderBy(dt => dt.DriveTrainName), "ID", "DriveTrainName"),
                Statuss = new SelectList(_context.Status, "ID", "StatusName")

            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VehicleDetails(int ID,
          [Bind("ID,Model,Brand,Type,Price,Mileage,Year,FuelType,Transmission,DriveTrain,Colour,Condition,EngineSize,Status,StatusChangeDate")] Car car,
          [Bind("ID,CarID,AC,ElectricWindows,Sunroof,ReverseCamera,LeatherSeats,TowBar,PowerSteering,CentralLocking,MultiFunctionSteerWheel,Alarm,Radio,SpeedControl,ParkDistanceControl,HeatedSeats,SpareKey,ElectricMirrors,FullServiceHistory,NumberSeats,NumberDoors")] CarAdditional carAdditional,
          int OldStatus,
          IFormFile[]? ExteriorImages, string ExteriorImagesUpdated,
          IFormFile[]? InteriorImages, string InteriorImagesUpdated,
          IFormFile[]? OtherImages, string OtherImagesUpdated)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (car.Status != OldStatus)
                    {
                        car.StatusChangeDate = DateTime.Now;
                    }
                    // Ensure Car.ID matches the ID passed
                    car.ID = ID;
                    _context.Update(car);
                    _context.SaveChanges();

                    var existingAdditional = _context.CarAdditional.FirstOrDefault(ca => ca.CarID == car.ID);
                    if (existingAdditional != null)
                    {
                        if (ExteriorImagesUpdated == "true" && ExteriorImages?.Any() == true)
                        {
                            UpdateImages(existingAdditional, "Exterior", ExteriorImages);
                        }

                        if (InteriorImagesUpdated == "true" && InteriorImages?.Any() == true)
                        {
                            UpdateImages(existingAdditional, "Interior", InteriorImages);
                        }

                        if (OtherImagesUpdated == "true" && OtherImages?.Any() == true)
                        {
                            UpdateImages(existingAdditional, "Other", OtherImages);
                        }

                        existingAdditional.AC = carAdditional.AC;
                        existingAdditional.ElectricWindows = carAdditional.ElectricWindows;
                        existingAdditional.Sunroof = carAdditional.Sunroof;
                        existingAdditional.ReverseCamera = carAdditional.ReverseCamera;
                        existingAdditional.LeatherSeats = carAdditional.LeatherSeats;
                        existingAdditional.TowBar = carAdditional.TowBar;
                        existingAdditional.PowerSteering = carAdditional.PowerSteering;
                        existingAdditional.CentralLocking = carAdditional.CentralLocking;
                        existingAdditional.MultiFunctionSteerWheel = carAdditional.MultiFunctionSteerWheel;
                        existingAdditional.Alarm = carAdditional.Alarm;
                        existingAdditional.Radio = carAdditional.Radio;
                        existingAdditional.SpeedControl = carAdditional.SpeedControl;
                        existingAdditional.ParkDistanceControl = carAdditional.ParkDistanceControl;
                        existingAdditional.HeatedSeats = carAdditional.HeatedSeats;
                        existingAdditional.SpareKey = carAdditional.SpareKey;
                        existingAdditional.ElectricMirrors = carAdditional.ElectricMirrors;
                        existingAdditional.NumberSeats = carAdditional.NumberSeats;
                        existingAdditional.NumberDoors = carAdditional.NumberDoors;
                        existingAdditional.FullServiceHistory = carAdditional.FullServiceHistory;



                        _context.Entry(existingAdditional).State = EntityState.Modified;
                        _context.SaveChanges();
                    }

                    return RedirectToAction("VehicleDetailsList");
                }
                catch (Exception ex)
                {
                    // Log the error for debugging (optional)
                    ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                }

            }
            #region Reloading viewmodel
            // Recreate the view model to avoid type mismatch errors
            var viewModel = new AddVehicleViewModel
            {
                Id = car.ID,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                Mileage = car.Mileage,
                Price = car.Price,
                EngineSize = car.EngineSize,
                FuelType = car.FuelType,
                Transmission = car.Transmission,
                DriveTrain = car.DriveTrain,
                Condition = car.Condition,
                Type = car.Type,
                Colour = car.Colour,
                NumberDoors = carAdditional.NumberDoors,
                NumberSeats = carAdditional.NumberSeats,
                Status = car.Status,
                StatusChangeDate = car.StatusChangeDate,

                AC = carAdditional.AC,
                Alarm = carAdditional.Alarm,
                CentralLocking = carAdditional.CentralLocking,
                ElectricMirrors = carAdditional.ElectricMirrors,
                HeatedSeats = carAdditional.HeatedSeats,
                LeatherSeats = carAdditional.LeatherSeats,
                MultiFunctionSteerWheel = carAdditional.MultiFunctionSteerWheel,
                ParkDistanceControl = carAdditional.ParkDistanceControl,
                PowerSteering = carAdditional.PowerSteering,
                ReverseCamera = carAdditional.ReverseCamera,
                Radio = carAdditional.Radio,
                SpareKey = carAdditional.SpareKey,
                Sunroof = carAdditional.Sunroof,
                SpeedControl = carAdditional.SpeedControl,
                TowBar = carAdditional.TowBar,
                FullServiceHistory = carAdditional.FullServiceHistory,

                Brands = new SelectList(_context.Brand.OrderBy(b => b.BrandName), "ID", "BrandName"),
                Types = new SelectList(_context.Type.OrderBy(t => t.TypeName), "ID", "TypeName"),
                FuelTypes = new SelectList(_context.FuelType.OrderBy(f => f.FuelTypeName), "ID", "FuelTypeName"),
                Transmissions = new SelectList(_context.Transmission.OrderBy(t => t.TransmissionName), "ID", "TransmissionName"),
                DriveTrains = new SelectList(_context.DriveTrain.OrderBy(dt => dt.DriveTrainName), "ID", "DriveTrainName"),
            };
            #endregion

            // Return the view with the current data if validation fails
            return View(viewModel);
        }




        private void UpdateImages(CarAdditional carAdditional, string category, IFormFile[]? uploadedImages)
        {
            if (uploadedImages == null || uploadedImages.Length == 0)
                return; // If no new images are uploaded, skip updating


            switch (category)
            {
                case "Exterior":
                    for (int i = 1; i <= 6; i++)
                    {
                        var exteriorProperty = carAdditional.GetType().GetProperty($"Exterior{i}");
                        exteriorProperty?.SetValue(carAdditional, null);
                    }
                    break;

                case "Interior":
                    for (int i = 1; i <= 4; i++)
                    {
                        var interiorProperty = carAdditional.GetType().GetProperty($"Interior{i}");
                        interiorProperty?.SetValue(carAdditional, null);
                    }
                    break;

                case "Other":
                    for (int i = 1; i <= 2; i++)
                    {
                        var otherProperty = carAdditional.GetType().GetProperty($"Other{i}");
                        otherProperty?.SetValue(carAdditional, null);
                    }
                    break;
            }

            for (int i = 0; i < uploadedImages.Length; i++)
            {
                using var memoryStream = new MemoryStream();
                uploadedImages[i].CopyTo(memoryStream);
                var imageBytes = memoryStream.ToArray();



                switch (category)
                {
                    case "Exterior":
                        if (i < 6) // Ensure we don't exceed the max fields
                        {
                            // Only update if the image is not null (i.e., a new image is uploaded)
                            var exteriorProperty = carAdditional.GetType().GetProperty($"Exterior{i + 1}");
                            if (exteriorProperty != null && imageBytes != null)
                            {
                                exteriorProperty.SetValue(carAdditional, imageBytes);
                            }
                        }
                        break;

                    case "Interior":
                        if (i < 4) // Ensure we don't exceed the max fields
                        {
                            var interiorProperty = carAdditional.GetType().GetProperty($"Interior{i + 1}");
                            if (interiorProperty != null && imageBytes != null)
                            {
                                interiorProperty.SetValue(carAdditional, imageBytes);
                            }
                        }
                        break;

                    case "Other":
                        if (i < 2) // Ensure we don't exceed the max fields
                        {
                            var otherProperty = carAdditional.GetType().GetProperty($"Other{i + 1}");
                            if (otherProperty != null && imageBytes != null)
                            {
                                otherProperty.SetValue(carAdditional, imageBytes);
                            }
                        }
                        break;
                }
            }
        }

        private void UpdateImagesBike(BikeAdditional carAdditional, string category, IFormFile[]? uploadedImages)
        {
            if (uploadedImages == null || uploadedImages.Length == 0)
                return; // If no new images are uploaded, skip updating


            switch (category)
            {
                case "Exterior":
                    for (int i = 1; i <= 6; i++)
                    {
                        var exteriorProperty = carAdditional.GetType().GetProperty($"Exterior{i}");
                        exteriorProperty?.SetValue(carAdditional, null);
                    }
                    break;

                case "Interior":
                    for (int i = 1; i <= 4; i++)
                    {
                        var interiorProperty = carAdditional.GetType().GetProperty($"Interior{i}");
                        interiorProperty?.SetValue(carAdditional, null);
                    }
                    break;

                case "Other":
                    for (int i = 1; i <= 2; i++)
                    {
                        var otherProperty = carAdditional.GetType().GetProperty($"Other{i}");
                        otherProperty?.SetValue(carAdditional, null);
                    }
                    break;
            }

            for (int i = 0; i < uploadedImages.Length; i++)
            {
                using var memoryStream = new MemoryStream();
                uploadedImages[i].CopyTo(memoryStream);
                var imageBytes = memoryStream.ToArray();



                switch (category)
                {
                    case "Exterior":
                        if (i < 6) // Ensure we don't exceed the max fields
                        {
                            // Only update if the image is not null (i.e., a new image is uploaded)
                            var exteriorProperty = carAdditional.GetType().GetProperty($"Exterior{i + 1}");
                            if (exteriorProperty != null && imageBytes != null)
                            {
                                exteriorProperty.SetValue(carAdditional, imageBytes);
                            }
                        }
                        break;

                    case "Interior":
                        if (i < 4) // Ensure we don't exceed the max fields
                        {
                            var interiorProperty = carAdditional.GetType().GetProperty($"Interior{i + 1}");
                            if (interiorProperty != null && imageBytes != null)
                            {
                                interiorProperty.SetValue(carAdditional, imageBytes);
                            }
                        }
                        break;

                    case "Other":
                        if (i < 2) // Ensure we don't exceed the max fields
                        {
                            var otherProperty = carAdditional.GetType().GetProperty($"Other{i + 1}");
                            if (otherProperty != null && imageBytes != null)
                            {
                                otherProperty.SetValue(carAdditional, imageBytes);
                            }
                        }
                        break;
                }
            }
        }

        private void UpdateImagesBoat(BoatAdditional boatAdditional, string category, IFormFile[]? uploadedImages)
        {
            if (uploadedImages == null || uploadedImages.Length == 0)
                return; // If no new images are uploaded, skip updating


            switch (category)
            {
                case "Exterior":
                    for (int i = 1; i <= 6; i++)
                    {
                        var exteriorProperty = boatAdditional.GetType().GetProperty($"Exterior{i}");
                        exteriorProperty?.SetValue(boatAdditional, null);
                    }
                    break;

                case "Interior":
                    for (int i = 1; i <= 4; i++)
                    {
                        var interiorProperty = boatAdditional.GetType().GetProperty($"Interior{i}");
                        interiorProperty?.SetValue(boatAdditional, null);
                    }
                    break;

                case "Other":
                    for (int i = 1; i <= 2; i++)
                    {
                        var otherProperty = boatAdditional.GetType().GetProperty($"Other{i}");
                        otherProperty?.SetValue(boatAdditional, null);
                    }
                    break;
            }

            for (int i = 0; i < uploadedImages.Length; i++)
            {
                using var memoryStream = new MemoryStream();
                uploadedImages[i].CopyTo(memoryStream);
                var imageBytes = memoryStream.ToArray();



                switch (category)
                {
                    case "Exterior":
                        if (i < 6) // Ensure we don't exceed the max fields
                        {
                            // Only update if the image is not null (i.e., a new image is uploaded)
                            var exteriorProperty = boatAdditional.GetType().GetProperty($"Exterior{i + 1}");
                            if (exteriorProperty != null && imageBytes != null)
                            {
                                exteriorProperty.SetValue(boatAdditional, imageBytes);
                            }
                        }
                        break;

                    case "Interior":
                        if (i < 4) // Ensure we don't exceed the max fields
                        {
                            var interiorProperty = boatAdditional.GetType().GetProperty($"Interior{i + 1}");
                            if (interiorProperty != null && imageBytes != null)
                            {
                                interiorProperty.SetValue(boatAdditional, imageBytes);
                            }
                        }
                        break;

                    case "Other":
                        if (i < 2) // Ensure we don't exceed the max fields
                        {
                            var otherProperty = boatAdditional.GetType().GetProperty($"Other{i + 1}");
                            if (otherProperty != null && imageBytes != null)
                            {
                                otherProperty.SetValue(boatAdditional, imageBytes);
                            }
                        }
                        break;
                }
            }
        }

        private void UpdateImagesCaravan(CaravanAdditional caravanAdditional, string category, IFormFile[]? uploadedImages)
        {
            if (uploadedImages == null || uploadedImages.Length == 0)
                return; // If no new images are uploaded, skip updating


            switch (category)
            {
                case "Exterior":
                    for (int i = 1; i <= 6; i++)
                    {
                        var exteriorProperty = caravanAdditional.GetType().GetProperty($"Exterior{i}");
                        exteriorProperty?.SetValue(caravanAdditional, null);
                    }
                    break;

                case "Interior":
                    for (int i = 1; i <= 4; i++)
                    {
                        var interiorProperty = caravanAdditional.GetType().GetProperty($"Interior{i}");
                        interiorProperty?.SetValue(caravanAdditional, null);
                    }
                    break;

                case "Other":
                    for (int i = 1; i <= 2; i++)
                    {
                        var otherProperty = caravanAdditional.GetType().GetProperty($"Other{i}");
                        otherProperty?.SetValue(caravanAdditional, null);
                    }
                    break;
            }

            for (int i = 0; i < uploadedImages.Length; i++)
            {
                using var memoryStream = new MemoryStream();
                uploadedImages[i].CopyTo(memoryStream);
                var imageBytes = memoryStream.ToArray();



                switch (category)
                {
                    case "Exterior":
                        if (i < 6) // Ensure we don't exceed the max fields
                        {
                            // Only update if the image is not null (i.e., a new image is uploaded)
                            var exteriorProperty = caravanAdditional.GetType().GetProperty($"Exterior{i + 1}");
                            if (exteriorProperty != null && imageBytes != null)
                            {
                                exteriorProperty.SetValue(caravanAdditional, imageBytes);
                            }
                        }
                        break;

                    case "Interior":
                        if (i < 4) // Ensure we don't exceed the max fields
                        {
                            var interiorProperty = caravanAdditional.GetType().GetProperty($"Interior{i + 1}");
                            if (interiorProperty != null && imageBytes != null)
                            {
                                interiorProperty.SetValue(caravanAdditional, imageBytes);
                            }
                        }
                        break;

                    case "Other":
                        if (i < 2) // Ensure we don't exceed the max fields
                        {
                            var otherProperty = caravanAdditional.GetType().GetProperty($"Other{i + 1}");
                            if (otherProperty != null && imageBytes != null)
                            {
                                otherProperty.SetValue(caravanAdditional, imageBytes);
                            }
                        }
                        break;
                }
            }
        }

        private void UpdateImagesTrailer(Trailer trailer, string category, IFormFile[]? uploadedImages)
        {
            if (uploadedImages == null || uploadedImages.Length == 0)
                return; // If no new images are uploaded, skip updating


            switch (category)
            {
                case "Exterior":
                    for (int i = 1; i <= 6; i++)
                    {
                        var exteriorProperty = trailer.GetType().GetProperty($"Exterior{i}");
                        exteriorProperty?.SetValue(trailer, null);
                    }
                    break;

                case "Interior":
                    for (int i = 1; i <= 6; i++)
                    {
                        var interiorProperty = trailer.GetType().GetProperty($"Interior{i}");
                        interiorProperty?.SetValue(trailer, null);
                    }
                    break;

                case "Other":
                    for (int i = 1; i <= 2; i++)
                    {
                        var otherProperty = trailer.GetType().GetProperty($"Other{i}");
                        otherProperty?.SetValue(trailer, null);
                    }
                    break;
            }

            for (int i = 0; i < uploadedImages.Length; i++)
            {
                using var memoryStream = new MemoryStream();
                uploadedImages[i].CopyTo(memoryStream);
                var imageBytes = memoryStream.ToArray();



                switch (category)
                {
                    case "Exterior":
                        if (i < 6) // Ensure we don't exceed the max fields
                        {
                            // Only update if the image is not null (i.e., a new image is uploaded)
                            var exteriorProperty = trailer.GetType().GetProperty($"Exterior{i + 1}");
                            if (exteriorProperty != null && imageBytes != null)
                            {
                                exteriorProperty.SetValue(trailer, imageBytes);
                            }
                        }
                        break;

                    case "Interior":
                        if (i < 6) // Ensure we don't exceed the max fields
                        {
                            var interiorProperty = trailer.GetType().GetProperty($"Interior{i + 1}");
                            if (interiorProperty != null && imageBytes != null)
                            {
                                interiorProperty.SetValue(trailer, imageBytes);
                            }
                        }
                        break;

                    case "Other":
                        if (i < 2) // Ensure we don't exceed the max fields
                        {
                            var otherProperty = trailer.GetType().GetProperty($"Other{i + 1}");
                            if (otherProperty != null && imageBytes != null)
                            {
                                otherProperty.SetValue(trailer, imageBytes);
                            }
                        }
                        break;
                }
            }
        }



        public IActionResult EditCompanyDetails()
        {
            var companyDetails = _context.CompanyDetails.FirstOrDefault();
            if (companyDetails == null)
            {
                companyDetails = new CompanyDetails();
                _context.CompanyDetails.Add(companyDetails);
                _context.SaveChanges();
            }

            return View(companyDetails);
        }

        [HttpPost]
        public IActionResult EditCompanyDetails([Bind("ID,CompanyName,CompanyEmail,CompanyPhone,Address,LocationLink,VATNumber,AccountNumber,FacebookLink,InstagramLink,DeveloperEmail")] CompanyDetails model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var existingCompanyDetails = _context.CompanyDetails.FirstOrDefault();
            if (existingCompanyDetails != null)
            {
                existingCompanyDetails.CompanyName = model.CompanyName;
                existingCompanyDetails.CompanyEmail = model.CompanyEmail;
                existingCompanyDetails.CompanyPhone = model.CompanyPhone;
                existingCompanyDetails.Address = model.Address;
                existingCompanyDetails.LocationLink = model.LocationLink;
                existingCompanyDetails.VATNumber = model.VATNumber;
                existingCompanyDetails.AccountNumber = model.AccountNumber;
                existingCompanyDetails.FacebookLink = model.FacebookLink;
                existingCompanyDetails.InstagramLink = model.InstagramLink;
                existingCompanyDetails.DeveloperEmail = model.DeveloperEmail;

                _context.CompanyDetails.Update(existingCompanyDetails);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Company details updated successfully";
            }
            return RedirectToAction("EditCompanyDetails");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync(); // Signs the user out
            return RedirectToAction("Index", "Home"); // Redirect to the home page or another page
        }



        public IActionResult AddVehicleBike()
        {
            var brands = _context.BikeBrand.OrderBy(b => b.BrandName).ToList();
            var types = _context.BikeType.OrderBy(t => t.BikeTypeName).ToList();
            var fuelTypes = _context.FuelType.OrderBy(f => f.FuelTypeName).ToList();
            var transmission = _context.Transmission.OrderBy(t => t.TransmissionName).ToList();


            var viewModel = new AddVehicleBikeViewModel
            {
                Brands = brands.Select(b => new SelectListItem
                {
                    Value = b.ID.ToString(), // Assuming Id is the primary key
                    Text = b.BrandName
                }),
                Types = types.Select(t => new SelectListItem
                {
                    Value = t.ID.ToString(), // Assuming Id is the primary key
                    Text = t.BikeTypeName
                }),
                FuelTypes = fuelTypes.Select(f => new SelectListItem
                {
                    Value = f.ID.ToString(),
                    Text = f.FuelTypeName
                }),
                Transmissions = transmission.Select(t => new SelectListItem
                {
                    Value = t.ID.ToString(),
                    Text = t.TransmissionName
                })

            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVehicleBike(AddVehicleBikeViewModel viewModel, IFormFile[] exteriorImages, IFormFile[] interiorImages, IFormFile[] otherImages)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var bike = new Bike
                    {
                        Brand = viewModel.Brand,
                        Model = viewModel.Model!,
                        Type = viewModel.Type,
                        Price = viewModel.Price,
                        Mileage = viewModel.Mileage,
                        Year = viewModel.Year,
                        FuelType = viewModel.FuelType,
                        Transmission = viewModel.Transmission,
                        Colour = viewModel.Colour!,
                        Condition = viewModel.Condition!,
                        EngineSize = viewModel.EngineSize!,
                        Status = viewModel.Status,
                        StatusChangeDate = viewModel.StatusChangeDate

                    };

                    _context.Bike.Add(bike);
                    await _context.SaveChangesAsync();

                    var bikeID = bike.ID;
                    var bikeAdditional = new BikeAdditional
                    {
                        BikeID = bikeID,
                        CenterStand = viewModel.CenterStand,
                        TopBox = viewModel.TopBox,
                        Panniers = viewModel.Panniers,
                        RaisedScreen = viewModel.RaisedScreen,
                        HeatedGrips = viewModel.HeatedGrips,
                        OffRoadCapable = viewModel.OffRoadCapable
                    };

                    // Process exterior images
                    if (exteriorImages != null && exteriorImages.Length > 0)
                    {
                        for (int i = 0; i < exteriorImages.Length && i < 6; i++)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await exteriorImages[i].CopyToAsync(memoryStream);
                                var imageBytes = memoryStream.ToArray();
                                // Assign to corresponding exterior field
                                switch (i)
                                {
                                    case 0: bikeAdditional.Exterior1 = imageBytes; break;
                                    case 1: bikeAdditional.Exterior2 = imageBytes; break;
                                    case 2: bikeAdditional.Exterior3 = imageBytes; break;
                                    case 3: bikeAdditional.Exterior4 = imageBytes; break;
                                    case 4: bikeAdditional.Exterior5 = imageBytes; break;
                                    case 5: bikeAdditional.Exterior6 = imageBytes; break;
                                }
                            }
                        }
                    }

                    // Process interior images
                    if (interiorImages != null && interiorImages.Length > 0)
                    {
                        for (int i = 0; i < interiorImages.Length && i < 4; i++)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await interiorImages[i].CopyToAsync(memoryStream);
                                var imageBytes = memoryStream.ToArray();
                                // Assign to corresponding interior field
                                switch (i)
                                {
                                    case 0: bikeAdditional.Interior1 = imageBytes; break;
                                    case 1: bikeAdditional.Interior2 = imageBytes; break;
                                    case 2: bikeAdditional.Interior3 = imageBytes; break;
                                    case 3: bikeAdditional.Interior4 = imageBytes; break;
                                }
                            }
                        }
                    }

                    // Process other images
                    if (otherImages != null && otherImages.Length > 0)
                    {
                        for (int i = 0; i < otherImages.Length && i < 2; i++)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await otherImages[i].CopyToAsync(memoryStream);
                                var imageBytes = memoryStream.ToArray();
                                // Assign to corresponding other field
                                switch (i)
                                {
                                    case 0: bikeAdditional.Other1 = imageBytes; break;
                                    case 1: bikeAdditional.Other2 = imageBytes; break;
                                }
                            }
                        }
                    }

                    // Save the images into the CarAdditional table
                    _context.BikeAdditional.Add(bikeAdditional);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Vehicle added successfully with images!";
                    return RedirectToAction("AddVehicleBike");
                }
                catch (Exception ex)
                {
                    // Log the error
                    _logger.LogError(ex, "Error adding vehicle with images");
                    ModelState.AddModelError("", "An error occurred while adding the vehicle. Please try again.");
                }
            }

            return RedirectToAction("AddVehicleBike");
        }

        public IActionResult VehicleBikeDetailsList()
        {
            var vehicles = (from bike in _context.Bike
                            join brand in _context.Brand on bike.Brand equals brand.ID
                            join additional in _context.BikeAdditional on bike.ID equals additional.BikeID
                            select new EditCarListViewModel
                            {
                                ID = bike.ID,
                                BrandName = brand.BrandName, // Retrieve the brand name
                                Model = bike.Model,
                                Year = bike.Year,
                                Price = bike.Price,
                                Mileage = bike.Mileage,
                                ExteriorImage1Base64 = additional.Exterior1 != null
                                    ? "data:image/jpeg;base64," + Convert.ToBase64String(additional.Exterior1)
                                    : null!
                            }).ToList();

            return View(vehicles);
        }

        [HttpGet]
        public IActionResult VehicleDetailsBike(int ID)
        {

            // Fetch the vehicle and its additional details
            var vehicle = (from bike in _context.Bike
                           join additional in _context.BikeAdditional on bike.ID equals additional.BikeID
                           where bike.ID == ID
                           select new { bike, additional }).FirstOrDefault();

            if (vehicle == null)
            {
                return NotFound(); // Return a 404 if the vehicle is not found
            }
            // Convert byte arrays to base64 strings
            Func<byte[]?, string> toBase64 = bytes => bytes != null ? $"data:image/jpeg;base64,{Convert.ToBase64String(bytes)}" : null!;

            var viewModel = new AddVehicleBikeViewModel
            {
                Id = vehicle.bike.ID,
                Brand = vehicle.bike.Brand,
                Model = vehicle.bike.Model,
                Type = vehicle.bike.Type,
                Colour = vehicle.bike.Colour,
                Mileage = vehicle.bike.Mileage,
                Year = vehicle.bike.Year,
                EngineSize = vehicle.bike.EngineSize,
                FuelType = vehicle.bike.FuelType,
                Transmission = vehicle.bike.Transmission,
                Price = vehicle.bike.Price,
                Condition = vehicle.bike.Condition,
                Status = vehicle.bike.Status,
                StatusChangeDate = vehicle.bike.StatusChangeDate,

                CenterStand = vehicle.additional.CenterStand,
                TopBox = vehicle.additional.TopBox,
                Panniers = vehicle.additional.Panniers,
                RaisedScreen = vehicle.additional.RaisedScreen,
                OffRoadCapable = vehicle.additional.OffRoadCapable,

                // Existing images as base64 strings
                ExteriorImageBase64 = new[]
                {
                    vehicle.additional.Exterior1, vehicle.additional.Exterior2,
                    vehicle.additional.Exterior3, vehicle.additional.Exterior4,
                    vehicle.additional.Exterior5, vehicle.additional.Exterior6
                }.Where(img => img != null).Select(toBase64).ToArray(),

                InteriorImageBase64 = new[]
                {
                    vehicle.additional.Interior1, vehicle.additional.Interior2,
                    vehicle.additional.Interior3, vehicle.additional.Interior4
                }.Where(img => img != null).Select(toBase64).ToArray(),

                OtherImageBase64 = new[]
                {
                    vehicle.additional.Other1, vehicle.additional.Other2
                }.Where(img => img != null).Select(toBase64).ToArray(),

                // Dropdowns
                Brands = new SelectList(_context.BikeBrand.OrderBy(b => b.BrandName), "ID", "BrandName"),
                Types = new SelectList(_context.BikeType.OrderBy(t => t.BikeTypeName), "ID", "BikeTypeName"),
                FuelTypes = new SelectList(_context.FuelType.OrderBy(f => f.FuelTypeName), "ID", "FuelTypeName"),
                Transmissions = new SelectList(_context.Transmission.OrderBy(t => t.TransmissionName), "ID", "TransmissionName"),
                Statuss = new SelectList(_context.Status, "ID", "StatusName")
            };


            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VehicleDetailsBike(int ID,
            [Bind("ID,Model,Brand,Type,Price,Mileage,Year,FuelType,Transmission,Status,StatusChangeDate,Colour,Condition,EngineSize")] Bike bike,
            [Bind("ID,BikeID,CenterStand,TopBox,Panniers,RaisedScreen,HeatedGrips,OffRoadCapable")] BikeAdditional bikeAdditional,
            int OldStatus,
            IFormFile[]? ExteriorImages, string ExteriorImagesUpdated,
            IFormFile[]? InteriorImages, string InteriorImagesUpdated,
            IFormFile[]? OtherImages, string OtherImagesUpdated)

        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (bike.Status != OldStatus)
                    {
                        bike.StatusChangeDate = DateTime.Now;
                    }

                    bike.ID = ID;
                    _context.Update(bike);
                    _context.SaveChanges();

                    var existingAdditional = _context.BikeAdditional.FirstOrDefault(bi => bi.BikeID == bike.ID);
                    if (existingAdditional != null)
                    {
                        if (ExteriorImagesUpdated == "true" && ExteriorImages?.Any() == true)
                        {
                            UpdateImagesBike(existingAdditional, "Exterior", ExteriorImages);
                        }

                        if (InteriorImagesUpdated == "true" && InteriorImages?.Any() == true)
                        {
                            UpdateImagesBike(existingAdditional, "Interior", InteriorImages);
                        }

                        if (OtherImagesUpdated == "true" && OtherImages?.Any() == true)
                        {
                            UpdateImagesBike(existingAdditional, "Other", OtherImages);
                        }

                        existingAdditional.CenterStand = bikeAdditional.CenterStand;
                        existingAdditional.HeatedGrips = bikeAdditional.HeatedGrips;
                        existingAdditional.Panniers = bikeAdditional.Panniers;
                        existingAdditional.RaisedScreen = bikeAdditional.RaisedScreen;
                        existingAdditional.TopBox = bikeAdditional.TopBox;

                        _context.Entry(existingAdditional).State = EntityState.Modified;
                        _context.SaveChanges();


                    }
                    return RedirectToAction("VehicleBikeDetailsList");
                }
                catch (Exception ex)
                {
                    // Log the error for debugging (optional)
                    ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                }
            }
            //reload viewmodel
            var viewModel = new AddVehicleBikeViewModel
            {
                Id = bike.ID,
                Brand = bike.Brand,
                Model = bike.Model,
                Type = bike.Type,
                Colour = bike.Colour,
                Mileage = bike.Mileage,
                Year = bike.Year,
                EngineSize = bike.EngineSize,
                FuelType = bike.FuelType,
                Transmission = bike.Transmission,
                Price = bike.Price,
                Condition = bike.Condition,
                Status = bike.Status,
                StatusChangeDate = bike.StatusChangeDate,

                CenterStand = bikeAdditional.CenterStand,
                TopBox = bikeAdditional.TopBox,
                Panniers = bikeAdditional.Panniers,
                RaisedScreen = bikeAdditional.RaisedScreen,
                HeatedGrips = bikeAdditional.HeatedGrips,
                OffRoadCapable = bikeAdditional.OffRoadCapable,

                Brands = new SelectList(_context.BikeBrand.OrderBy(b => b.BrandName), "ID", "BrandName"),
                Types = new SelectList(_context.BikeType.OrderBy(t => t.BikeTypeName), "ID", "BikeTypeName"),
                FuelTypes = new SelectList(_context.FuelType.OrderBy(f => f.FuelTypeName), "ID", "FuelTypeName"),
                Transmissions = new SelectList(_context.Transmission.OrderBy(t => t.TransmissionName), "ID", "TransmissionName")
            };

            return View(viewModel);
        }

        public IActionResult AddVehicleBoat()
        {
            var brands = _context.BoatBrand.OrderBy(b => b.BrandName).ToList();
            var types = _context.BoatType.OrderBy(t => t.BoatTypeName).ToList();
            var fuelTypes = _context.FuelType.OrderBy(f => f.FuelTypeName).ToList();
            var waterDepth = _context.WaterDepth.OrderBy(w => w.WaterDepthName).ToList();


            var viewModel = new AddVehicleBoatViewModel
            {
                Brands = brands.Select(b => new SelectListItem
                {
                    Value = b.ID.ToString(), // Assuming Id is the primary key
                    Text = b.BrandName
                }),
                Types = types.Select(t => new SelectListItem
                {
                    Value = t.ID.ToString(), // Assuming Id is the primary key
                    Text = t.BoatTypeName
                }),
                FuelTypes = fuelTypes.Select(f => new SelectListItem
                {
                    Value = f.ID.ToString(),
                    Text = f.FuelTypeName
                }),
                WaterDepths = waterDepth.Select(wd => new SelectListItem
                {
                    Value = wd.ID.ToString(),
                    Text = wd.WaterDepthName
                })

            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVehicleBoat(AddVehicleBoatViewModel viewModel, IFormFile[] exteriorImages, IFormFile[] interiorImages, IFormFile[] otherImages)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var boat = new Boat
                    {
                        Brand = viewModel.Brand,
                        Model = viewModel.Model!,
                        Type = viewModel.Type,
                        Price = viewModel.Price,
                        Mileage = viewModel.Mileage,
                        Year = viewModel.Year,
                        FuelType = viewModel.FuelType,
                        Colour = viewModel.Colour!,
                        Engine = viewModel.Engine!,
                        ConsoleLocation = viewModel.ConsoleLocation,
                        Status = viewModel.Status,
                        StatusChangeDate = viewModel.StatusChangeDate,
                        Condition = viewModel.Condition!

                    };
                    _context.Boat.Add(boat);
                    await _context.SaveChangesAsync();

                    var boatID = boat.ID;
                    var boatAdditional = new BoatAdditional
                    {
                        BoatID = boatID,
                        WaterDepth = viewModel.WaterDepth,
                        RegisteredTrailer = viewModel.RegisteredTrailer,
                        FishFinder = viewModel.FishFinder,
                        LifeJackets = viewModel.LifeJackets,
                        SafetyEquipment = viewModel.SafetyEquipment,
                        VhfRadio = viewModel.VhfRadio,
                        SkiTower = viewModel.SkiTower,
                        BuoyancyCertificate = viewModel.BuoyancyCertificate,
                        COF = viewModel.COF,
                        LiveWell = viewModel.LiveWell,
                    };

                    // Process exterior images
                    if (exteriorImages != null && exteriorImages.Length > 0)
                    {
                        for (int i = 0; i < exteriorImages.Length && i < 6; i++)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await exteriorImages[i].CopyToAsync(memoryStream);
                                var imageBytes = memoryStream.ToArray();
                                // Assign to corresponding exterior field
                                switch (i)
                                {
                                    case 0: boatAdditional.Exterior1 = imageBytes; break;
                                    case 1: boatAdditional.Exterior2 = imageBytes; break;
                                    case 2: boatAdditional.Exterior3 = imageBytes; break;
                                    case 3: boatAdditional.Exterior4 = imageBytes; break;
                                    case 4: boatAdditional.Exterior5 = imageBytes; break;
                                    case 5: boatAdditional.Exterior6 = imageBytes; break;
                                }
                            }
                        }
                    }

                    // Process interior images
                    if (interiorImages != null && interiorImages.Length > 0)
                    {
                        for (int i = 0; i < interiorImages.Length && i < 4; i++)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await interiorImages[i].CopyToAsync(memoryStream);
                                var imageBytes = memoryStream.ToArray();
                                // Assign to corresponding interior field
                                switch (i)
                                {
                                    case 0: boatAdditional.Interior1 = imageBytes; break;
                                    case 1: boatAdditional.Interior2 = imageBytes; break;
                                    case 2: boatAdditional.Interior3 = imageBytes; break;
                                    case 3: boatAdditional.Interior4 = imageBytes; break;
                                }
                            }
                        }
                    }

                    // Process other images
                    if (otherImages != null && otherImages.Length > 0)
                    {
                        for (int i = 0; i < otherImages.Length && i < 2; i++)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await otherImages[i].CopyToAsync(memoryStream);
                                var imageBytes = memoryStream.ToArray();
                                // Assign to corresponding other field
                                switch (i)
                                {
                                    case 0: boatAdditional.Other1 = imageBytes; break;
                                    case 1: boatAdditional.Other2 = imageBytes; break;
                                }
                            }
                        }
                    }

                    // Save the images into the CarAdditional table
                    _context.BoatAdditional.Add(boatAdditional);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Vehicle added successfully with images!";
                    return RedirectToAction("AddVehicleBoat");
                }
                catch (Exception ex)
                {
                    // Log the error
                    _logger.LogError(ex, "Error adding vehicle with images");
                    ModelState.AddModelError("", "An error occurred while adding the vehicle. Please try again.");
                }
            }

            return RedirectToAction("AddVehicleBoat");
        }

        public IActionResult VehicleBoatDetailsList()
        {
            var vehicles = (from boat in _context.Boat
                            join brand in _context.BoatBrand on boat.Brand equals brand.ID
                            join additional in _context.BoatAdditional on boat.ID equals additional.BoatID
                            select new EditCarListViewModel
                            {
                                ID = boat.ID,
                                BrandName = brand.BrandName, // Retrieve the brand name
                                Model = boat.Model,
                                Year = boat.Year,
                                Price = boat.Price,
                                Mileage = boat.Mileage,
                                ExteriorImage1Base64 = additional.Exterior1 != null
                                    ? "data:image/jpeg;base64," + Convert.ToBase64String(additional.Exterior1)
                                    : null!
                            }).ToList();

            return View(vehicles);
        }

        [HttpGet]
        public IActionResult VehicleDetailsBoat(int ID)
        {

            // Fetch the vehicle and its additional details
            var vehicle = (from boat in _context.Boat
                           join additional in _context.BoatAdditional on boat.ID equals additional.BoatID into additionalGroup
                           from additional in additionalGroup.DefaultIfEmpty()
                           where boat.ID == ID
                           select new { boat, additional }).FirstOrDefault();

            if (vehicle == null)
            {
                return NotFound(); // Return a 404 if the vehicle is not found
            }
            // Convert byte arrays to base64 strings
            Func<byte[]?, string> toBase64 = bytes => bytes != null ? $"data:image/jpeg;base64,{Convert.ToBase64String(bytes)}" : null!;


            var viewModel = new AddVehicleBoatViewModel
            {
                Id = vehicle.boat.ID,
                Model = vehicle.boat.Model,
                Brand = vehicle.boat.Brand,
                Type = vehicle.boat.Type,
                Colour = vehicle.boat.Colour,
                Mileage = vehicle.boat.Mileage,
                Year = vehicle.boat.Year,
                Condition = vehicle.boat.Condition,
                Engine = vehicle.boat.Engine,
                ConsoleLocation = vehicle.boat.ConsoleLocation,
                Price = vehicle.boat.Price,
                FuelType = vehicle.boat.FuelType,
                Status = vehicle.boat.Status,
                StatusChangeDate = vehicle.boat.StatusChangeDate,

                WaterDepth = vehicle.additional.WaterDepth,
                RegisteredTrailer = vehicle.additional.RegisteredTrailer,
                FishFinder = vehicle.additional.FishFinder,
                LifeJackets = vehicle.additional.LifeJackets,
                SafetyEquipment = vehicle.additional.SafetyEquipment,
                VhfRadio = vehicle.additional.VhfRadio,
                SkiTower = vehicle.additional.SkiTower,
                COF = vehicle.additional.COF,
                BuoyancyCertificate = vehicle.additional.BuoyancyCertificate,
                LiveWell = vehicle.additional.LiveWell,

                // Existing images as base64 strings
                ExteriorImageBase64 = new[]
                {
                    vehicle.additional.Exterior1, vehicle.additional.Exterior2,
                    vehicle.additional.Exterior3, vehicle.additional.Exterior4,
                    vehicle.additional.Exterior5, vehicle.additional.Exterior6
                }.Where(img => img != null).Select(toBase64).ToArray(),

                InteriorImageBase64 = new[]
                {
                    vehicle.additional.Interior1, vehicle.additional.Interior2,
                    vehicle.additional.Interior3, vehicle.additional.Interior4
                }.Where(img => img != null).Select(toBase64).ToArray(),

                OtherImageBase64 = new[]
                {
                    vehicle.additional.Other1, vehicle.additional.Other2
                }.Where(img => img != null).Select(toBase64).ToArray(),

                // Dropdowns
                Brands = new SelectList(_context.BoatBrand.OrderBy(b => b.BrandName), "ID", "BrandName"),
                Types = new SelectList(_context.BoatType.OrderBy(t => t.BoatTypeName), "ID", "BoatTypeName"),
                FuelTypes = new SelectList(_context.FuelType.OrderBy(f => f.FuelTypeName), "ID", "FuelTypeName"),
                Statuss = new SelectList(_context.Status, "ID", "StatusName"),
                WaterDepths = new SelectList(_context.WaterDepth.OrderBy(w => w.WaterDepthName), "ID", "WaterDepthName")
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VehicleDetailsBoat(int ID,
                                                [Bind("ID,Model,Brand,Type,Price,Mileage,Year,FuelType,Status,StatusChangeDate,Colour,Condition,Engine,ConsoleLocation")] Boat boat,
                                                [Bind("ID,BoatID,WaterDepth,RegisteredTrailer,FishFinder,LifeJackets,SafetyEquipment,VhfRadio,SkiTower,COF,BuoyancyCertificate,LiveWell")] BoatAdditional boatAdditional,
                                                int OldStatus,
                                                IFormFile[]? ExteriorImages, string ExteriorImagesUpdated,
                                                IFormFile[]? InteriorImages, string InteriorImagesUpdated,
                                                IFormFile[]? OtherImages, string OtherImagesUpdated)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (boat.Status != OldStatus)
                    {
                        boat.StatusChangeDate = DateTime.Now;
                    }
                    // Ensure Car.ID matches the ID passed
                    boat.ID = ID;
                    _context.Update(boat);
                    _context.SaveChanges();

                    var existingAdditional = _context.BoatAdditional.FirstOrDefault(ba => ba.BoatID == boat.ID);
                    if (existingAdditional != null)
                    {
                        if (ExteriorImagesUpdated == "true" && ExteriorImages?.Any() == true)
                        {
                            UpdateImagesBoat(existingAdditional, "Exterior", ExteriorImages);
                        }

                        if (InteriorImagesUpdated == "true" && InteriorImages?.Any() == true)
                        {
                            UpdateImagesBoat(existingAdditional, "Interior", InteriorImages);
                        }

                        if (OtherImagesUpdated == "true" && OtherImages?.Any() == true)
                        {
                            UpdateImagesBoat(existingAdditional, "Other", OtherImages);
                        }

                        existingAdditional.WaterDepth = boatAdditional.WaterDepth;
                        existingAdditional.RegisteredTrailer = boatAdditional.RegisteredTrailer;
                        existingAdditional.FishFinder = boatAdditional.FishFinder;
                        existingAdditional.LifeJackets = boatAdditional.LifeJackets;
                        existingAdditional.SafetyEquipment = boatAdditional.SafetyEquipment;
                        existingAdditional.VhfRadio = boatAdditional.VhfRadio;
                        existingAdditional.SkiTower = boatAdditional.SkiTower;
                        existingAdditional.COF = boatAdditional.COF;
                        existingAdditional.BuoyancyCertificate = boatAdditional.BuoyancyCertificate;
                        existingAdditional.LiveWell = boatAdditional.LiveWell;


                        _context.Entry(existingAdditional).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                    return RedirectToAction("VehicleBoatDetailsList");
                }
                catch (Exception ex)
                {
                    // Log the error for debugging (optional)
                    ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                }
            }
            var viewModel = new AddVehicleBoatViewModel
            {
                Id = boat.ID,
                Model = boat.Model,
                Brand = boat.Brand,
                Type = boat.Type,
                Colour = boat.Colour,
                Mileage = boat.Mileage,
                Year = boat.Year,
                Condition = boat.Condition,
                Engine = boat.Engine,
                ConsoleLocation = boat.ConsoleLocation,
                Price = boat.Price,
                FuelType = boat.FuelType,
                Status = boat.Status,
                StatusChangeDate = boat.StatusChangeDate,

                WaterDepth = boatAdditional.WaterDepth,
                RegisteredTrailer = boatAdditional.RegisteredTrailer,
                FishFinder = boatAdditional.FishFinder,
                LifeJackets = boatAdditional.LifeJackets,
                SafetyEquipment = boatAdditional.SafetyEquipment,
                VhfRadio = boatAdditional.VhfRadio,
                SkiTower = boatAdditional.SkiTower,
                COF = boatAdditional.COF,
                BuoyancyCertificate = boatAdditional.BuoyancyCertificate,
                LiveWell = boatAdditional.LiveWell,

                Brands = new SelectList(_context.BoatBrand.OrderBy(b => b.BrandName), "ID", "BrandName"),
                Types = new SelectList(_context.Type.OrderBy(t => t.TypeName), "ID", "BoatTypeName"),
                FuelTypes = new SelectList(_context.FuelType.OrderBy(f => f.FuelTypeName), "ID", "FuelTypeName"),
                Transmissions = new SelectList(_context.Transmission.OrderBy(t => t.TransmissionName), "ID", "TransmissionName")

            };

            return View(viewModel);
        }

        public IActionResult AddVehicleCaravan()
        {
            var brands = _context.CaravanBrand.OrderBy(b => b.BrandName).ToList();
            var types = _context.CaravanType.OrderBy(t => t.CaravanTypeName).ToList();


            var viewModel = new AddVehicleCaravanViewModel
            {
                Brands = brands.Select(b => new SelectListItem
                {
                    Value = b.ID.ToString(), // Assuming Id is the primary key
                    Text = b.BrandName
                }),
                Types = types.Select(t => new SelectListItem
                {
                    Value = t.ID.ToString(), // Assuming Id is the primary key
                    Text = t.CaravanTypeName
                })

            };


            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVehicleCaravan(AddVehicleCaravanViewModel viewModel, IFormFile[] exteriorImages, IFormFile[] interiorImages, IFormFile[] otherImages)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var caravan = new Caravan
                    {
                        Brand = viewModel.Brand,
                        Model = viewModel.Model!,
                        Type = viewModel.Type,
                        Berth = viewModel.Berth,
                        KitchenHas = viewModel.KitchenHas,
                        BathroomHas = viewModel.BathroomHas,
                        Colour = viewModel.Colour!,
                        Price = viewModel.Price,
                        Year = viewModel.Year,
                        Condition = viewModel.Condition!,
                        BedType = viewModel.BedType!,
                        Status = viewModel.Status,
                        StatusChangeDate = viewModel.StatusChangeDate

                    };
                    _context.Caravan.Add(caravan);
                    await _context.SaveChangesAsync();

                    var caravanID = caravan.ID;
                    var caravanAdditional = new CaravanAdditional
                    {
                        CaravanID = caravanID,
                        Add_A_Room = viewModel.Add_A_Room,
                        CaravanCover = viewModel.CaravanCover,
                        FullTent = viewModel.FullTent,
                        Geyser = viewModel.Geyser,
                        Movers = viewModel.Movers,
                        MultiRoom = viewModel.MultiRoom,
                        SpareKey = viewModel.SpareKey,
                        SpareTyre = viewModel.SpareTyre,
                        WaterTank = viewModel.WaterTank,
                        Awning = viewModel.Awning
                    };

                    // Process exterior images
                    if (exteriorImages != null && exteriorImages.Length > 0)
                    {
                        for (int i = 0; i < exteriorImages.Length && i < 6; i++)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await exteriorImages[i].CopyToAsync(memoryStream);
                                var imageBytes = memoryStream.ToArray();
                                // Assign to corresponding exterior field
                                switch (i)
                                {
                                    case 0: caravanAdditional.Exterior1 = imageBytes; break;
                                    case 1: caravanAdditional.Exterior2 = imageBytes; break;
                                    case 2: caravanAdditional.Exterior3 = imageBytes; break;
                                    case 3: caravanAdditional.Exterior4 = imageBytes; break;
                                    case 4: caravanAdditional.Exterior5 = imageBytes; break;
                                    case 5: caravanAdditional.Exterior6 = imageBytes; break;
                                }
                            }
                        }
                    }

                    // Process interior images
                    if (interiorImages != null && interiorImages.Length > 0)
                    {
                        for (int i = 0; i < interiorImages.Length && i < 4; i++)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await interiorImages[i].CopyToAsync(memoryStream);
                                var imageBytes = memoryStream.ToArray();
                                // Assign to corresponding interior field
                                switch (i)
                                {
                                    case 0: caravanAdditional.Interior1 = imageBytes; break;
                                    case 1: caravanAdditional.Interior2 = imageBytes; break;
                                    case 2: caravanAdditional.Interior3 = imageBytes; break;
                                    case 3: caravanAdditional.Interior4 = imageBytes; break;
                                }
                            }
                        }
                    }

                    // Process other images
                    if (otherImages != null && otherImages.Length > 0)
                    {
                        for (int i = 0; i < otherImages.Length && i < 2; i++)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await otherImages[i].CopyToAsync(memoryStream);
                                var imageBytes = memoryStream.ToArray();
                                // Assign to corresponding other field
                                switch (i)
                                {
                                    case 0: caravanAdditional.Other1 = imageBytes; break;
                                    case 1: caravanAdditional.Other2 = imageBytes; break;
                                }
                            }
                        }
                    }

                    // Save the images into the CarAdditional table
                    _context.CaravanAdditional.Add(caravanAdditional);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Vehicle added successfully with images!";
                    return RedirectToAction("AddVehicleCaravan");
                }
                catch (Exception ex)
                {
                    // Log the error
                    _logger.LogError(ex, "Error adding vehicle with images");
                    ModelState.AddModelError("", "An error occurred while adding the vehicle. Please try again.");
                }

            }



            return RedirectToAction("AddVehicleCaravan");
        }

        public IActionResult VehicleCaravanDetailsList()
        {
            var vehicles = (from caravan in _context.Caravan
                            join brand in _context.CaravanBrand on caravan.Brand equals brand.ID
                            join additional in _context.CaravanAdditional on caravan.ID equals additional.CaravanID
                            select new EditCaravanListViewModel
                            {
                                ID = caravan.ID,
                                BrandName = brand.BrandName, // Retrieve the brand name
                                Model = caravan.Model,
                                Year = caravan.Year,
                                Price = caravan.Price,
                                ExteriorImage1Base64 = additional.Exterior1 != null
                                    ? "data:image/jpeg;base64," + Convert.ToBase64String(additional.Exterior1)
                                    : null!
                            }).ToList();

            return View(vehicles);
        }

        [HttpGet]
        public IActionResult VehicleDetailsCaravan(int ID)
        {

            // Fetch the vehicle and its additional details
            var vehicle = (from caravan in _context.Caravan
                           join additional in _context.CaravanAdditional on caravan.ID equals additional.CaravanID
                           where caravan.ID == ID
                           select new { caravan, additional }).FirstOrDefault();



            if (vehicle == null)
            {
                return NotFound(); // Return a 404 if the vehicle is not found
            }

            // Convert byte arrays to base64 strings
            Func<byte[]?, string> toBase64 = bytes => bytes != null ? $"data:image/jpeg;base64,{Convert.ToBase64String(bytes)}" : null!;

            var viewModel = new AddVehicleCaravanViewModel
            {
                CaravanId = vehicle.caravan.ID,
                Brand = vehicle.caravan.Brand,
                Model = vehicle.caravan.Model,
                Type = vehicle.caravan.Type,
                Berth = vehicle.caravan.Berth,
                KitchenHas = vehicle.caravan.KitchenHas,
                BathroomHas = vehicle.caravan.BathroomHas,
                Colour = vehicle.caravan.Colour,
                Price = vehicle.caravan.Price,
                Year = vehicle.caravan.Year,
                BedType = vehicle.caravan.BedType,
                Status = vehicle.caravan.Status,
                StatusChangeDate = vehicle.caravan.StatusChangeDate,
                Condition = vehicle.caravan.Condition,

                Awning = vehicle.additional.Awning,
                WaterTank = vehicle.additional.WaterTank,
                Geyser = vehicle.additional.Geyser,
                Movers = vehicle.additional.Movers,
                MultiRoom = vehicle.additional.MultiRoom,
                CaravanCover = vehicle.additional.CaravanCover,
                Add_A_Room = vehicle.additional.Add_A_Room,
                SpareKey = vehicle.additional.SpareKey,
                SpareTyre = vehicle.additional.SpareTyre,
                FullTent = vehicle.additional.FullTent,

                // Existing images as base64 strings
                ExteriorImageBase64 = new[]
                {
                    vehicle.additional.Exterior1, vehicle.additional.Exterior2,
                    vehicle.additional.Exterior3, vehicle.additional.Exterior4,
                    vehicle.additional.Exterior5, vehicle.additional.Exterior6
                }.Where(img => img != null).Select(toBase64).ToArray(),

                InteriorImageBase64 = new[]
                {
                    vehicle.additional.Interior1, vehicle.additional.Interior2,
                    vehicle.additional.Interior3, vehicle.additional.Interior4
                }.Where(img => img != null).Select(toBase64).ToArray(),

                OtherImageBase64 = new[]
                {
                    vehicle.additional.Other1, vehicle.additional.Other2
                }.Where(img => img != null).Select(toBase64).ToArray(),

                // Dropdowns
                Brands = new SelectList(_context.CaravanBrand.OrderBy(b => b.BrandName), "ID", "BrandName"),
                Types = new SelectList(_context.CaravanType.OrderBy(t => t.CaravanTypeName), "ID", "CaravanTypeName"),
                Statuss = new SelectList(_context.Status, "ID", "StatusName")
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VehicleDetailsCaravan(
                            int ID,
                            [Bind("ID,Brand,Model,Type,Berth,KitchenHas,BathroomHas,Colour,Price,Year,Condition,BedType,Status,StatusChangeDate")] Caravan caravan,
                            [Bind("ID,CaravanID,Awning,WaterTank,Geyser,Movers,CaravanCover,Add_A_Room,MultiRoom,SpareKey,SpareTyre,FullTent")] CaravanAdditional caravanAdditional,
                            int OldStatus,
                            IFormFile[]? ExteriorImages, string ExteriorImagesUpdated,
                            IFormFile[]? InteriorImages, string InteriorImagesUpdated,
                            IFormFile[]? OtherImages, string OtherImagesUpdated)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if (caravan.Status != OldStatus)
                    {
                        caravan.StatusChangeDate = DateTime.Now;
                    }
                    // Ensure Car.ID matches the ID passed
                    caravan.ID = ID;
                    _context.Update(caravan);
                    _context.SaveChanges();

                    var existingAdditional = _context.CaravanAdditional.FirstOrDefault(ca => ca.CaravanID == caravan.ID);
                    if (existingAdditional != null)
                    {
                        if (ExteriorImagesUpdated == "true" && ExteriorImages?.Any() == true)
                        {
                            UpdateImagesCaravan(existingAdditional, "Exterior", ExteriorImages);
                        }

                        if (InteriorImagesUpdated == "true" && InteriorImages?.Any() == true)
                        {
                            UpdateImagesCaravan(existingAdditional, "Interior", InteriorImages);
                        }

                        if (OtherImagesUpdated == "true" && OtherImages?.Any() == true)
                        {
                            UpdateImagesCaravan(existingAdditional, "Other", OtherImages);
                        }

                        existingAdditional.Add_A_Room = caravanAdditional.Add_A_Room;
                        existingAdditional.Awning = caravanAdditional.Awning;
                        existingAdditional.CaravanCover = caravanAdditional.CaravanCover;
                        existingAdditional.FullTent = caravanAdditional.FullTent;
                        existingAdditional.Geyser = caravanAdditional.Geyser;
                        existingAdditional.Movers = caravanAdditional.Movers;
                        existingAdditional.MultiRoom = caravanAdditional.MultiRoom;
                        existingAdditional.SpareKey = caravanAdditional.SpareKey;
                        existingAdditional.SpareTyre = caravanAdditional.SpareTyre;
                        existingAdditional.WaterTank = caravanAdditional.WaterTank;

                        _context.Entry(existingAdditional).State = EntityState.Modified;
                        _context.SaveChanges();
                    }


                    return RedirectToAction("VehicleCaravanDetailsList");
                }
                catch (Exception ex)
                {
                    // Log the error for debugging (optional)
                    ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                }
                //reload viewmodel

            }
            var viewModel = new AddVehicleCaravanViewModel
            {
                CaravanId = caravan.ID,
                Brand = caravan.Brand,
                Model = caravan.Model,
                Type = caravan.Type,
                Berth = caravan.Berth,
                KitchenHas = caravan.KitchenHas,
                BathroomHas = caravan.BathroomHas,
                Colour = caravan.Colour,
                Price = caravan.Price,
                Year = caravan.Year,
                Condition = caravan.Condition,
                BedType = caravan.BedType,
                Status = caravan.Status,
                StatusChangeDate = caravan.StatusChangeDate,

                Awning = caravanAdditional.Awning,
                WaterTank = caravanAdditional.WaterTank,
                Geyser = caravanAdditional.Geyser,
                Movers = caravanAdditional.Movers,
                CaravanCover = caravanAdditional.CaravanCover,
                Add_A_Room = caravanAdditional.Add_A_Room,
                MultiRoom = caravanAdditional.MultiRoom,
                SpareKey = caravanAdditional.SpareKey,
                SpareTyre = caravanAdditional.SpareTyre,
                FullTent = caravanAdditional.FullTent,

                Brands = new SelectList(_context.Brand.OrderBy(b => b.BrandName), "ID", "BrandName"),
                Types = new SelectList(_context.Type.OrderBy(t => t.TypeName), "ID", "TypeName"),
                Statuss = new SelectList(_context.Status, "ID", "StatusName")
            };

            return View(viewModel);
        }

        //Adding of items --> Brands, Drive Trains, FuelTypes, Transmissions, WaterDepths, BedTypes, VehicleTypes //
        [HttpGet]
        public IActionResult AddDropdowns()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDropdowns(DropdownsViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool itemAdded = false;

                // All category
                if (!string.IsNullOrEmpty(model.FuelTypeName) && !_context.FuelType.Any(f => f.FuelTypeName == model.FuelTypeName))
                {
                    var fuelType = new FuelType { FuelTypeName = model.FuelTypeName };
                    _context.FuelType.Add(fuelType);
                    itemAdded = true;
                }
                else if (!string.IsNullOrEmpty(model.FuelTypeName))
                {
                    TempData["WarningMessage"] = $"Fuel Type '{model.FuelTypeName}' already exists.";
                }

                if (!string.IsNullOrEmpty(model.TransmissionName) && !_context.Transmission.Any(t => t.TransmissionName == model.TransmissionName))
                {
                    var transmission = new Transmission { TransmissionName = model.TransmissionName };
                    _context.Transmission.Add(transmission);
                    itemAdded = true;
                }
                else if (!string.IsNullOrEmpty(model.TransmissionName))
                {
                    TempData["WarningMessage"] = $"Transmission '{model.TransmissionName}' already exists.";
                }

                // Car category
                if (!string.IsNullOrEmpty(model.CarTypeName) && !_context.Type.Any(t => t.TypeName == model.CarTypeName))
                {
                    var carType = new AlgoaVehicleTraders.Models.All.Type { TypeName = model.CarTypeName };
                    _context.Type.Add(carType);
                    itemAdded = true;
                }
                else if (!string.IsNullOrEmpty(model.CarTypeName))
                {
                    TempData["WarningMessage"] = $"Car Type '{model.CarTypeName}' already exists.";
                }

                if (!string.IsNullOrEmpty(model.CarBrandName) && !_context.Brand.Any(b => b.BrandName == model.CarBrandName))
                {
                    var carBrand = new Brand { BrandName = model.CarBrandName };
                    _context.Brand.Add(carBrand);
                    itemAdded = true;
                }
                else if (!string.IsNullOrEmpty(model.CarBrandName))
                {
                    TempData["WarningMessage"] = $"Car Brand '{model.CarBrandName}' already exists.";
                }

                if (!string.IsNullOrEmpty(model.DriveTrainName) && !_context.DriveTrain.Any(d => d.DriveTrainName == model.DriveTrainName))
                {
                    var driveTrain = new DriveTrain { DriveTrainName = model.DriveTrainName };
                    _context.DriveTrain.Add(driveTrain);
                    itemAdded = true;
                }
                else if (!string.IsNullOrEmpty(model.DriveTrainName))
                {
                    TempData["WarningMessage"] = $"Drive Train '{model.DriveTrainName}' already exists.";
                }

                // Bike category
                if (!string.IsNullOrEmpty(model.BikeTypeName) && !_context.BikeType.Any(bt => bt.BikeTypeName == model.BikeTypeName))
                {
                    var bikeType = new BikeType { BikeTypeName = model.BikeTypeName };
                    _context.BikeType.Add(bikeType);
                    itemAdded = true;
                }
                else if (!string.IsNullOrEmpty(model.BikeTypeName))
                {
                    TempData["WarningMessage"] = $"Bike Type '{model.BikeTypeName}' already exists.";
                }

                if (!string.IsNullOrEmpty(model.BikeBrandName) && !_context.BikeBrand.Any(bb => bb.BrandName == model.BikeBrandName))
                {
                    var bikeBrand = new BikeBrand { BrandName = model.BikeBrandName };
                    _context.BikeBrand.Add(bikeBrand);
                    itemAdded = true;
                }
                else if (!string.IsNullOrEmpty(model.BikeBrandName))
                {
                    TempData["WarningMessage"] = $"Bike Brand '{model.BikeBrandName}' already exists.";
                }

                // Boat category
                if (!string.IsNullOrEmpty(model.BoatTypeName) && !_context.BoatType.Any(bt => bt.BoatTypeName == model.BoatTypeName))
                {
                    var boatType = new BoatType { BoatTypeName = model.BoatTypeName };
                    _context.BoatType.Add(boatType);
                    itemAdded = true;
                }
                else if (!string.IsNullOrEmpty(model.BoatTypeName))
                {
                    TempData["WarningMessage"] = $"Boat Type '{model.BoatTypeName}' already exists.";
                }

                if (!string.IsNullOrEmpty(model.BoatBrandName) && !_context.BoatBrand.Any(bb => bb.BrandName == model.BoatBrandName))
                {
                    var boatBrand = new BoatBrand { BrandName = model.BoatBrandName };
                    _context.BoatBrand.Add(boatBrand);
                    itemAdded = true;
                }
                else if (!string.IsNullOrEmpty(model.BoatBrandName))
                {
                    TempData["WarningMessage"] = $"Boat Brand '{model.BoatBrandName}' already exists.";
                }

                if (!string.IsNullOrEmpty(model.WaterDepthName) && !_context.WaterDepth.Any(wd => wd.WaterDepthName == model.WaterDepthName))
                {
                    var waterDepth = new WaterDepth { WaterDepthName = model.WaterDepthName };
                    _context.WaterDepth.Add(waterDepth);
                    itemAdded = true;
                }
                else if (!string.IsNullOrEmpty(model.WaterDepthName))
                {
                    TempData["WarningMessage"] = $"Water Depth '{model.WaterDepthName}' already exists.";
                }

                // Caravan category
                if (!string.IsNullOrEmpty(model.CaravanTypeName) && !_context.CaravanType.Any(ct => ct.CaravanTypeName == model.CaravanTypeName))
                {
                    var caravanType = new CaravanType { CaravanTypeName = model.CaravanTypeName };
                    _context.CaravanType.Add(caravanType);
                    itemAdded = true;
                }
                else if (!string.IsNullOrEmpty(model.CaravanTypeName))
                {
                    TempData["WarningMessage"] = $"Caravan Type '{model.CaravanTypeName}' already exists.";
                }

                if (!string.IsNullOrEmpty(model.CaravanBrandName) && !_context.CaravanBrand.Any(cb => cb.BrandName == model.CaravanBrandName))
                {
                    var caravanBrand = new CaravanBrand { BrandName = model.CaravanBrandName };
                    _context.CaravanBrand.Add(caravanBrand);
                    itemAdded = true;
                }
                else if (!string.IsNullOrEmpty(model.CaravanBrandName))
                {
                    TempData["WarningMessage"] = $"Caravan Brand '{model.CaravanBrandName}' already exists.";
                }

                // Trailer category
                if (!string.IsNullOrEmpty(model.TrailerBrandName) && !_context.TrailerBrand.Any(tb => tb.BrandName == model.TrailerBrandName))
                {
                    var trailerBrand = new TrailerBrand { BrandName = model.TrailerBrandName };
                    _context.TrailerBrand.Add(trailerBrand);
                    itemAdded = true;
                }
                else if (!string.IsNullOrEmpty(model.TrailerBrandName))
                {
                    TempData["WarningMessage"] = $"Trailer Brand '{model.TrailerBrandName}' already exists.";
                }

                if (!string.IsNullOrEmpty(model.AxleTypeName) && !_context.AxleType.Any(at => at.AxleName == model.AxleTypeName))
                {
                    var axleType = new AxleType { AxleName = model.AxleTypeName };
                    _context.AxleType.Add(axleType);
                    itemAdded = true;
                }
                else if (!string.IsNullOrEmpty(model.AxleTypeName))
                {
                    TempData["WarningMessage"] = $"Axle Type '{model.AxleTypeName}' already exists.";
                }

                if (!string.IsNullOrEmpty(model.BrakedAxleTypeName) && !_context.BrakedAxle.Any(ba => ba.BrakedAxleName == model.BrakedAxleTypeName))
                {
                    var brakedAxle = new BrakedAxle { BrakedAxleName = model.BrakedAxleTypeName };
                    _context.BrakedAxle.Add(brakedAxle);
                    itemAdded = true;
                }
                else if (!string.IsNullOrEmpty(model.BrakedAxleTypeName))
                {
                    TempData["WarningMessage"] = $"Braked Axle Type '{model.BrakedAxleTypeName}' already exists.";
                }

                if (itemAdded)
                {
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Items added successfully!";
                }

                return RedirectToAction("AddDropdowns");
            }

            return View(model);
        }


        //Editing of items --> Brands, Drive Trains, FuelTypes, Transmissions, WaterDepths, BedTypes, VehicleTypes //
        [HttpGet]
        public IActionResult EditDropdowns()
        {
            var model = new DropdownsEditViewModel
            {
                FuelTypes = _context.FuelType.OrderBy(f => f.FuelTypeName).ToList(),
                Transmissions = _context.Transmission.OrderBy(t => t.TransmissionName).ToList(),
                CarTypes = _context.Type.OrderBy(t => t.TypeName).ToList(),
                CarBrands = _context.Brand.OrderBy(b => b.BrandName).ToList(),
                DriveTrains = _context.DriveTrain.OrderBy(dt => dt.DriveTrainName).ToList(),
                BikeTypes = _context.BikeType.OrderBy(bt => bt.BikeTypeName).ToList(),
                BikeBrands = _context.BikeBrand.OrderBy(b => b.BrandName).ToList(),
                BoatTypes = _context.BoatType.OrderBy(t => t.BoatTypeName).ToList(),
                BoatBrands = _context.BoatBrand.OrderBy(b => b.BrandName).ToList(),
                WaterDepths = _context.WaterDepth.OrderBy(w => w.WaterDepthName).ToList(),
                CaravanTypes = _context.CaravanType.OrderBy(t => t.CaravanTypeName).ToList(),
                CaravanBrands = _context.CaravanBrand.OrderBy(b => b.BrandName).ToList(),
                TrailerBrands = _context.TrailerBrand.OrderBy(b => b.BrandName).ToList(),
                AxleTypes = _context.AxleType.OrderBy(a => a.AxleName).ToList(),
                BrakedAxleTypes = _context.BrakedAxle.OrderBy(ba => ba.BrakedAxleName).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditDropdowns(DropdownsEditViewModel model)
        {
            bool itemUpdated = false;
            bool duplicateName = false;

            // All category
            if (model.SelectedFuelTypeId.HasValue && !string.IsNullOrEmpty(model.FuelTypeName))
            {
                if (_context.FuelType.Any(f => f.FuelTypeName == model.FuelTypeName))
                {
                    TempData["WarningMessage"] = $"Fuel Type '{model.FuelTypeName}' already exists.";
                    duplicateName = true;
                }
                else
                {
                    var fuelType = _context.FuelType.Find(model.SelectedFuelTypeId.Value);
                    if (fuelType != null)
                    {
                        fuelType.FuelTypeName = model.FuelTypeName;
                        itemUpdated = true;
                    }
                }
            }

            if (model.SelectedTransmissionId.HasValue && !string.IsNullOrEmpty(model.TransmissionName))
            {
                if (_context.Transmission.Any(t => t.TransmissionName == model.TransmissionName))
                {
                    TempData["WarningMessage"] = $"Transmission '{model.TransmissionName}' already exists.";
                    duplicateName = true;
                }
                else
                {
                    var transmission = _context.Transmission.Find(model.SelectedTransmissionId.Value);
                    if (transmission != null)
                    {
                        transmission.TransmissionName = model.TransmissionName;
                        itemUpdated = true;
                    }
                }
            }

            // Car category
            if (model.SelectedCarTypeId.HasValue && !string.IsNullOrEmpty(model.CarTypeName))
            {
                if (_context.Type.Any(t => t.TypeName == model.CarTypeName))
                {
                    TempData["WarningMessage"] = $"Car Type '{model.CarTypeName}' already exists.";
                    duplicateName = true;
                }
                else
                {
                    var carType = _context.Type.Find(model.SelectedCarTypeId.Value);
                    if (carType != null)
                    {
                        carType.TypeName = model.CarTypeName;
                        itemUpdated = true;
                    }
                }
            }

            if (model.SelectedCarBrandId.HasValue && !string.IsNullOrEmpty(model.CarBrandName))
            {
                if (_context.Brand.Any(b => b.BrandName == model.CarBrandName))
                {
                    TempData["WarningMessage"] = $"Car Brand '{model.CarBrandName}' already exists.";
                    duplicateName = true;
                }
                else
                {
                    var carBrand = _context.Brand.Find(model.SelectedCarBrandId.Value);
                    if (carBrand != null)
                    {
                        carBrand.BrandName = model.CarBrandName;
                        itemUpdated = true;
                    }
                }
            }

            if (model.SelectedDriveTrainId.HasValue && !string.IsNullOrEmpty(model.DriveTrainName))
            {
                if (_context.DriveTrain.Any(d => d.DriveTrainName == model.DriveTrainName))
                {
                    TempData["WarningMessage"] = $"Drive Train '{model.DriveTrainName}' already exists.";
                    duplicateName = true;
                }
                else
                {
                    var driveTrain = _context.DriveTrain.Find(model.SelectedDriveTrainId.Value);
                    if (driveTrain != null)
                    {
                        driveTrain.DriveTrainName = model.DriveTrainName;
                        itemUpdated = true;
                    }
                }
            }

            // Bike category
            if (model.SelectedBikeTypeId.HasValue && !string.IsNullOrEmpty(model.BikeTypeName))
            {
                if (_context.BikeType.Any(bt => bt.BikeTypeName == model.BikeTypeName))
                {
                    TempData["WarningMessage"] = $"Bike Type '{model.BikeTypeName}' already exists.";
                    duplicateName = true;
                }
                else
                {
                    var bikeType = _context.BikeType.Find(model.SelectedBikeTypeId.Value);
                    if (bikeType != null)
                    {
                        bikeType.BikeTypeName = model.BikeTypeName;
                        itemUpdated = true;
                    }
                }
            }

            if (model.SelectedBikeBrandId.HasValue && !string.IsNullOrEmpty(model.BikeBrandName))
            {
                if (_context.BikeBrand.Any(bb => bb.BrandName == model.BikeBrandName))
                {
                    TempData["WarningMessage"] = $"Bike Brand '{model.BikeBrandName}' already exists.";
                    duplicateName = true;
                }
                else
                {
                    var bikeBrand = _context.BikeBrand.Find(model.SelectedBikeBrandId.Value);
                    if (bikeBrand != null)
                    {
                        bikeBrand.BrandName = model.BikeBrandName;
                        itemUpdated = true;
                    }
                }
            }

            // Boat category
            if (model.SelectedBoatTypeId.HasValue && !string.IsNullOrEmpty(model.BoatTypeName))
            {
                if (_context.BoatType.Any(bt => bt.BoatTypeName == model.BoatTypeName))
                {
                    TempData["WarningMessage"] = $"Boat Type '{model.BoatTypeName}' already exists.";
                    duplicateName = true;
                }
                else
                {
                    var boatType = _context.BoatType.Find(model.SelectedBoatTypeId.Value);
                    if (boatType != null)
                    {
                        boatType.BoatTypeName = model.BoatTypeName;
                        itemUpdated = true;
                    }
                }
            }

            if (model.SelectedBoatBrandId.HasValue && !string.IsNullOrEmpty(model.BoatBrandName))
            {
                if (_context.BoatBrand.Any(bb => bb.BrandName == model.BoatBrandName))
                {
                    TempData["WarningMessage"] = $"Boat Brand '{model.BoatBrandName}' already exists.";
                    duplicateName = true;
                }
                else
                {
                    var boatBrand = _context.BoatBrand.Find(model.SelectedBoatBrandId.Value);
                    if (boatBrand != null)
                    {
                        boatBrand.BrandName = model.BoatBrandName;
                        itemUpdated = true;
                    }
                }
            }

            if (model.SelectedWaterDepthId.HasValue && !string.IsNullOrEmpty(model.WaterDepthName))
            {
                if (_context.WaterDepth.Any(wd => wd.WaterDepthName == model.WaterDepthName))
                {
                    TempData["WarningMessage"] = $"Water Depth '{model.WaterDepthName}' already exists.";
                    duplicateName = true;
                }
                else
                {
                    var waterDepth = _context.WaterDepth.Find(model.SelectedWaterDepthId.Value);
                    if (waterDepth != null)
                    {
                        waterDepth.WaterDepthName = model.WaterDepthName;
                        itemUpdated = true;
                    }
                }
            }

            // Caravan category
            if (model.SelectedCaravanTypeId.HasValue && !string.IsNullOrEmpty(model.CaravanTypeName))
            {
                if (_context.CaravanType.Any(ct => ct.CaravanTypeName == model.CaravanTypeName))
                {
                    TempData["WarningMessage"] = $"Caravan Type '{model.CaravanTypeName}' already exists.";
                    duplicateName = true;
                }
                else
                {
                    var caravanType = _context.CaravanType.Find(model.SelectedCaravanTypeId.Value);
                    if (caravanType != null)
                    {
                        caravanType.CaravanTypeName = model.CaravanTypeName;
                        itemUpdated = true;
                    }
                }
            }

            if (model.SelectedCaravanBrandId.HasValue && !string.IsNullOrEmpty(model.CaravanBrandName))
            {
                if (_context.CaravanBrand.Any(cb => cb.BrandName == model.CaravanBrandName))
                {
                    TempData["WarningMessage"] = $"Caravan Brand '{model.CaravanBrandName}' already exists.";
                    duplicateName = true;
                }
                else
                {
                    var caravanBrand = _context.CaravanBrand.Find(model.SelectedCaravanBrandId.Value);
                    if (caravanBrand != null)
                    {
                        caravanBrand.BrandName = model.CaravanBrandName;
                        itemUpdated = true;
                    }
                }
            }

            // Trailer category
            if (model.SelectedAxleTypeId.HasValue && !string.IsNullOrEmpty(model.AxleTypeName))
            {
                if (_context.AxleType.Any(a => a.AxleName == model.AxleTypeName))
                {
                    TempData["WarningMessage"] = $"Axle Type '{model.AxleTypeName}' already exists.";
                    duplicateName = true;
                }
                else
                {
                    var axleType = _context.AxleType.Find(model.SelectedAxleTypeId.Value);
                    if (axleType != null)
                    {
                        axleType.AxleName = model.AxleTypeName;
                        itemUpdated = true;
                    }
                }
            }

            if (model.SelectedBrakedAxleTypeId.HasValue && !string.IsNullOrEmpty(model.BrakedAxleTypeName))
            {
                if (_context.BrakedAxle.Any(b => b.BrakedAxleName == model.BrakedAxleTypeName))
                {
                    TempData["WarningMessage"] = $"Braked Axle Type '{model.BrakedAxleTypeName}' already exists.";
                    duplicateName = true;
                }
                else
                {
                    var brakedAxle = _context.BrakedAxle.Find(model.SelectedBrakedAxleTypeId.Value);
                    if (brakedAxle != null)
                    {
                        brakedAxle.BrakedAxleName = model.BrakedAxleTypeName;
                        itemUpdated = true;
                    }
                }
            }

            if (model.SelectedTrailerBrandId.HasValue && !string.IsNullOrEmpty(model.TrailerBrandName))
            {
                if (_context.TrailerBrand.Any(tb => tb.BrandName == model.TrailerBrandName))
                {
                    TempData["WarningMessage"] = $"Trailer Brand '{model.TrailerBrandName}' already exists.";
                    duplicateName = true;
                }
                else
                {
                    var trailerBrand = _context.TrailerBrand.Find(model.SelectedTrailerBrandId.Value);
                    if (trailerBrand != null)
                    {
                        trailerBrand.BrandName = model.TrailerBrandName;
                        itemUpdated = true;
                    }
                }
            }

            if (itemUpdated && !duplicateName)
            {
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Items updated successfully!";
            }
            return RedirectToAction("EditDropdowns");
        }


        //Deleting of items --> Brands, Drive Trains, FuelTypes, Transmissions, WaterDepths, BedTypes, VehicleTypes //
        [HttpGet]
        public IActionResult DeleteDropdowns()
        {
            var model = new DropdownsDeleteViewModel
            {
                FuelTypes = _context.FuelType.OrderBy(f => f.FuelTypeName).ToList(),
                Transmissions = _context.Transmission.OrderBy(t => t.TransmissionName).ToList(),
                CarTypes = _context.Type.OrderBy(t => t.TypeName).ToList(),
                CarBrands = _context.Brand.OrderBy(b => b.BrandName).ToList(),
                DriveTrains = _context.DriveTrain.OrderBy(dt => dt.DriveTrainName).ToList(),
                BikeTypes = _context.BikeType.OrderBy(bt => bt.BikeTypeName).ToList(),
                BikeBrands = _context.BikeBrand.OrderBy(b => b.BrandName).ToList(),
                BoatTypes = _context.BoatType.OrderBy(t => t.BoatTypeName).ToList(),
                BoatBrands = _context.BoatBrand.OrderBy(b => b.BrandName).ToList(),
                WaterDepths = _context.WaterDepth.OrderBy(w => w.WaterDepthName).ToList(),
                CaravanTypes = _context.CaravanType.OrderBy(t => t.CaravanTypeName).ToList(),
                CaravanBrands = _context.CaravanBrand.OrderBy(b => b.BrandName).ToList(),
                TrailerBrands = _context.TrailerBrand.OrderBy(b => b.BrandName).ToList(),
                AxleTypes = _context.AxleType.OrderBy(a => a.AxleName).ToList(),
                BrakedAxleTypes = _context.BrakedAxle.OrderBy(ba => ba.BrakedAxleName).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteDropdowns(DropdownsDeleteViewModel model)
        {
            bool itemDeleted = false;
            bool itemInUse = false;

            // All category
            if (model.SelectedFuelTypeId.HasValue)
            {
                if (_context.Car.Any(c => c.FuelType == model.SelectedFuelTypeId) ||
                    _context.Bike.Any(b => b.FuelType == model.SelectedFuelTypeId) ||
                    _context.Boat.Any(bo => bo.FuelType == model.SelectedFuelTypeId))
                {
                    itemInUse = true;
                    TempData["WarningMessage"] = "Fuel Type is in use and cannot be deleted.";
                }
                else
                {
                    var fuelType = _context.FuelType.Find(model.SelectedFuelTypeId.Value);
                    if (fuelType != null)
                    {
                        _context.FuelType.Remove(fuelType);
                        itemDeleted = true;
                    }
                }
            }

            if (model.SelectedTransmissionId.HasValue)
            {
                if (_context.Car.Any(c => c.Transmission == model.SelectedTransmissionId) ||
                    _context.Bike.Any(b => b.Transmission == model.SelectedTransmissionId))
                {
                    itemInUse = true;
                    TempData["WarningMessage"] = "Transmission is in use and cannot be deleted.";
                }
                else
                {
                    var transmission = _context.Transmission.Find(model.SelectedTransmissionId.Value);
                    if (transmission != null)
                    {
                        _context.Transmission.Remove(transmission);
                        itemDeleted = true;
                    }
                }
            }

            // Car category
            if (model.SelectedCarTypeId.HasValue)
            {
                if (_context.Car.Any(c => c.Type == model.SelectedCarTypeId))
                {
                    itemInUse = true;
                    TempData["WarningMessage"] = "Car Type is in use and cannot be deleted.";
                }
                else
                {
                    var carType = _context.Type.Find(model.SelectedCarTypeId.Value);
                    if (carType != null)
                    {
                        _context.Type.Remove(carType);
                        itemDeleted = true;
                    }
                }
            }

            if (model.SelectedCarBrandId.HasValue)
            {
                if (_context.Car.Any(c => c.Brand == model.SelectedCarBrandId))
                {
                    itemInUse = true;
                    TempData["WarningMessage"] = "Car Brand is in use and cannot be deleted.";
                }
                else
                {
                    var carBrand = _context.Brand.Find(model.SelectedCarBrandId.Value);
                    if (carBrand != null)
                    {
                        _context.Brand.Remove(carBrand);
                        itemDeleted = true;
                    }
                }
            }

            if (model.SelectedDriveTrainId.HasValue)
            {
                if (_context.Car.Any(c => c.DriveTrain == model.SelectedDriveTrainId))
                {
                    itemInUse = true;
                    TempData["WarningMessage"] = "Drive Train is in use and cannot be deleted.";
                }
                else
                {
                    var driveTrain = _context.DriveTrain.Find(model.SelectedDriveTrainId.Value);
                    if (driveTrain != null)
                    {
                        _context.DriveTrain.Remove(driveTrain);
                        itemDeleted = true;
                    }
                }
            }

            // Bike category
            if (model.SelectedBikeTypeId.HasValue)
            {
                if (_context.Bike.Any(b => b.Type == model.SelectedBikeTypeId))
                {
                    itemInUse = true;
                    TempData["WarningMessage"] = "Bike Type is in use and cannot be deleted.";
                }
                else
                {
                    var bikeType = _context.BikeType.Find(model.SelectedBikeTypeId.Value);
                    if (bikeType != null)
                    {
                        _context.BikeType.Remove(bikeType);
                        itemDeleted = true;
                    }
                }
            }

            if (model.SelectedBikeBrandId.HasValue)
            {
                if (_context.Bike.Any(b => b.Brand == model.SelectedBikeBrandId))
                {
                    itemInUse = true;
                    TempData["WarningMessage"] = "Bike Brand is in use and cannot be deleted.";
                }
                else
                {
                    var bikeBrand = _context.BikeBrand.Find(model.SelectedBikeBrandId.Value);
                    if (bikeBrand != null)
                    {
                        _context.BikeBrand.Remove(bikeBrand);
                        itemDeleted = true;
                    }
                }
            }

            // Boat category
            if (model.SelectedBoatTypeId.HasValue)
            {
                if (_context.Boat.Any(b => b.Type == model.SelectedBoatTypeId))
                {
                    itemInUse = true;
                    TempData["WarningMessage"] = "Boat Type is in use and cannot be deleted.";
                }
                else
                {
                    var boatType = _context.BoatType.Find(model.SelectedBoatTypeId.Value);
                    if (boatType != null)
                    {
                        _context.BoatType.Remove(boatType);
                        itemDeleted = true;
                    }
                }
            }

            if (model.SelectedBoatBrandId.HasValue)
            {
                if (_context.Boat.Any(b => b.Brand == model.SelectedBoatBrandId))
                {
                    itemInUse = true;
                    TempData["WarningMessage"] = "Boat Brand is in use and cannot be deleted.";
                }
                else
                {
                    var boatBrand = _context.BoatBrand.Find(model.SelectedBoatBrandId.Value);
                    if (boatBrand != null)
                    {
                        _context.BoatBrand.Remove(boatBrand);
                        itemDeleted = true;
                    }
                }
            }

            if (model.SelectedWaterDepthId.HasValue)
            {
                if (_context.Boat.Any(b => b.ConsoleLocation == model.SelectedWaterDepthId))
                {
                    itemInUse = true;
                    TempData["WarningMessage"] = "Water Depth is in use and cannot be deleted.";
                }
                else
                {
                    var waterDepth = _context.WaterDepth.Find(model.SelectedWaterDepthId.Value);
                    if (waterDepth != null)
                    {
                        _context.WaterDepth.Remove(waterDepth);
                        itemDeleted = true;
                    }
                }
            }

            // Caravan category
            if (model.SelectedCaravanTypeId.HasValue)
            {
                if (_context.Caravan.Any(c => c.Type == model.SelectedCaravanTypeId))
                {
                    itemInUse = true;
                    TempData["WarningMessage"] = "Caravan Type is in use and cannot be deleted.";
                }
                else
                {
                    var caravanType = _context.CaravanType.Find(model.SelectedCaravanTypeId.Value);
                    if (caravanType != null)
                    {
                        _context.CaravanType.Remove(caravanType);
                        itemDeleted = true;
                    }
                }
            }

            if (model.SelectedCaravanBrandId.HasValue)
            {
                if (_context.Caravan.Any(c => c.Brand == model.SelectedCaravanBrandId))
                {
                    itemInUse = true;
                    TempData["WarningMessage"] = "Caravan Brand is in use and cannot be deleted.";
                }
                else
                {
                    var caravanBrand = _context.CaravanBrand.Find(model.SelectedCaravanBrandId.Value);
                    if (caravanBrand != null)
                    {
                        _context.CaravanBrand.Remove(caravanBrand);
                        itemDeleted = true;
                    }
                }
            }

            // Trailer category
            if (model.SelectedAxleTypeId.HasValue)
            {
                if (_context.Trailer.Any(t => t.ID == model.SelectedAxleTypeId))
                {
                    itemInUse = true;
                    TempData["WarningMessage"] = "Axle Type is in use and cannot be deleted.";
                }
                else
                {
                    var axleType = _context.AxleType.Find(model.SelectedAxleTypeId.Value);
                    if (axleType != null)
                    {
                        _context.AxleType.Remove(axleType);
                        itemDeleted = true;
                    }
                }
            }

            if (model.SelectedBrakedAxleTypeId.HasValue)
            {
                if (_context.Trailer.Any(t => t.ID == model.SelectedBrakedAxleTypeId))
                {
                    itemInUse = true;
                    TempData["WarningMessage"] = "Braked Axle Type is in use and cannot be deleted.";
                }
                else
                {
                    var brakedAxle = _context.BrakedAxle.Find(model.SelectedBrakedAxleTypeId.Value);
                    if (brakedAxle != null)
                    {
                        _context.BrakedAxle.Remove(brakedAxle);
                        itemDeleted = true;
                    }
                }
            }

            if (model.SelectedTrailerBrandId.HasValue)
            {
                if (_context.Trailer.Any(t => t.ID == model.SelectedTrailerBrandId))
                {
                    itemInUse = true;
                    TempData["WarningMessage"] = "Trailer Brand is in use and cannot be deleted.";
                }
                else
                {
                    var trailerBrand = _context.TrailerBrand.Find(model.SelectedTrailerBrandId.Value);
                    if (trailerBrand != null)
                    {
                        _context.TrailerBrand.Remove(trailerBrand);
                        itemDeleted = true;
                    }
                }
            }


            if (itemDeleted && !itemInUse)
            {
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Item deleted successfully!";
            }
            return RedirectToAction("DeleteDropdowns");
        }

        //trailer section
        [HttpGet]
        public IActionResult AddVehicleTrailer()
        {
            var viewModel = new AddVehicleTrailerViewModel
            {
                Brands = new SelectList(_context.TrailerBrand.OrderBy(b => b.BrandName), "ID", "BrandName"),
                Types = new SelectList(_context.TrailerType.OrderBy(t => t.TypeName), "ID", "TypeName"),
                AxleTypes = new SelectList(_context.AxleType.OrderBy(a => a.AxleName), "ID", "AxleName"),
                BrakedAxles = new SelectList(_context.BrakedAxle.OrderBy(ba => ba.BrakedAxleName), "ID", "BrakedAxleName"),
                CampTrailer = new CampTrailerViewModel()
            };

            return View(viewModel);
        }

        public IActionResult LoadCampTrailerPartial()
        {
            return PartialView("_CampTrailerFields", new CampTrailerViewModel());
        }

        public IActionResult LoadLuggageTrailerPartial()
        {
            return PartialView("_LuggageTrailerFields", new AddVehicleTrailerViewModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVehicleTrailer(AddVehicleTrailerViewModel viewModel, CampTrailerViewModel campViewModel, IFormFile[] exteriorImages, IFormFile[] interiorImages, IFormFile[] otherImages)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert into Trailer table
                    var trailer = new Trailer
                    {
                        Model = viewModel.Model!,
                        Brand = viewModel.Brand,
                        Type = viewModel.Type,
                        Price = viewModel.Price,
                        AxleType = viewModel.AxleType,
                        Year = viewModel.Year,
                        BrakedAxle = viewModel.BrakedAxle,
                        NumberAxle = viewModel.NumberAxle,
                        TyreSize = viewModel.TyreSize!,
                        Length = viewModel.Length!,
                        Status = viewModel.Status,
                        StatusChangeDate = viewModel.StatusChangeDate,
                        Comments = viewModel.Comments,
                        TailGate = viewModel.TailGate
                    };

                    _context.Trailer.Add(trailer);
                    await _context.SaveChangesAsync();

                    // If trailer type is "Camp" (Type = 1), create and save CampTrailer data
                    if (trailer.Type == 1)
                    {
                        var campTrailer = new CampTrailer
                        {
                            TrailerID = trailer.ID, // Link to the Trailer table
                            KitchenHas = campViewModel.KitchenHas!,
                            Sleeper = campViewModel.Sleeper!,
                            SpareTyre = campViewModel.SpareTyre,
                            Awning = campViewModel.Awning,
                            Tent = campViewModel.Tent,
                            Geyser = campViewModel.Geyser,
                            WaterTank = campViewModel.WaterTank,
                            WaterPump = campViewModel.WaterPump,
                            VoltPowerSupply_12 = campViewModel.VoltPowerSupply_12,
                            VoltPowerSupplt_220 = campViewModel.VoltPowerSupply_220,
                            Battery = campViewModel.Battery,
                            ChargeSystem = campViewModel.ChargeSystem,
                            Add_A_Room = campViewModel.Add_A_Room,
                            GasBottles = campViewModel.GasBottles
                        };

                        _context.CampTrailer.Add(campTrailer);
                        await _context.SaveChangesAsync();
                    }

                    // Handle image updates using UpdateImagesTrailer method
                    if (exteriorImages != null && exteriorImages.Length > 0)
                    {
                        UpdateImagesTrailer(trailer, "Exterior", exteriorImages);
                    }

                    if (interiorImages != null && interiorImages.Length > 0)
                    {
                        UpdateImagesTrailer(trailer, "Interior", interiorImages);
                    }

                    if (otherImages != null && otherImages.Length > 0)
                    {
                        UpdateImagesTrailer(trailer, "Other", otherImages);
                    }

                    // Save the trailer updates again to reflect image changes
                    _context.Trailer.Update(trailer);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    // Handle any exceptions
                    ModelState.AddModelError("", "An error occurred while saving the trailer.");
                    // Log the exception (you can add logging here if necessary)
                }
            }

            viewModel.Brands = new SelectList(_context.TrailerBrand.OrderBy(b => b.BrandName), "ID", "BrandName", viewModel.Brand);
            viewModel.Types = new SelectList(_context.TrailerType.OrderBy(t => t.TypeName), "ID", "TypeName", viewModel.Type);
            viewModel.AxleTypes = new SelectList(_context.AxleType.OrderBy(a => a.AxleName), "ID", "AxleName", viewModel.AxleType);
            viewModel.BrakedAxles = new SelectList(_context.BrakedAxle.OrderBy(ba => ba.BrakedAxleName), "ID", "BrakedAxleName", viewModel.BrakedAxle);
            viewModel.Statuss = new SelectList(_context.Status, "ID", "StatusName", viewModel.Status);

            // If the model is invalid, return the same view
            return View(viewModel);
        }




        public IActionResult VehicleTrailerDetailsList()
        {
            var vehicles = (from trailer in _context.Trailer
                            join brand in _context.TrailerBrand on trailer.Brand equals brand.ID
                            select new EditCaravanListViewModel
                            {
                                ID = trailer.ID,
                                BrandName = brand.BrandName, // Retrieve the brand name
                                Model = trailer.Model,
                                Year = trailer.Year,
                                Price = trailer.Price,
                                ExteriorImage1Base64 = trailer.Exterior1 != null
                                    ? "data:image/jpeg;base64," + Convert.ToBase64String(trailer.Exterior1)
                                    : null!
                            }).ToList();

            return View(vehicles);
        }

        [HttpGet]
        public IActionResult TrailerType(int ID)
        {
            var trailer = _context.Trailer.FirstOrDefault(t => t.ID == ID);
            var trailerType = trailer.Type;

            if (trailer == null)
            {
                return NotFound(); // Return a 404 if the trailer is not found
            }

            // Check the Type of the trailer (assuming 0 is Camp, adjust if needed)
            if (trailerType == 1)
            {
                return RedirectToAction("VehicleDetailsCampTrailer", new { ID });
            }
            else
            {
                return RedirectToAction("VehicleDetailsTrailer", new { ID });
            }
        }

        [HttpGet]
        public IActionResult VehicleDetailsTrailer(int ID)
        {
            // Fetch the trailer and its camp trailer details
            var vehicle = _context.Trailer
                .Where(trailer => trailer.ID == ID)
                .FirstOrDefault();

            if (vehicle == null)
            {
                return NotFound(); // Return a 404 if the trailer is not found
            }

            // Convert byte arrays to base64 strings
            Func<byte[]?, string> toBase64 = bytes => bytes != null ? $"data:image/jpeg;base64,{Convert.ToBase64String(bytes)}" : null!;

            // Populate the view model
            var viewModel = new AddVehicleTrailerViewModel
            {
                // Trailer details
                Id = vehicle.ID,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                Type = vehicle.Type,
                Year = vehicle.Year,
                Price = vehicle.Price,
                AxleType = vehicle.AxleType,
                BrakedAxle = vehicle.BrakedAxle,
                NumberAxle = vehicle.NumberAxle,
                TyreSize = vehicle.TyreSize,
                Length = vehicle.Length,
                Comments = vehicle.Comments,
                Status = vehicle.Status,
                StatusChangeDate = vehicle.StatusChangeDate,
                TailGate = vehicle.TailGate,

                // Existing images as base64 strings
                ExteriorImageBase64 = new[]
                {
                    vehicle.Exterior1, vehicle.Exterior2,
                    vehicle.Exterior3, vehicle.Exterior4,
                    vehicle.Exterior5, vehicle.Exterior6
                }.Where(img => img != null).Select(toBase64).ToArray(),

                InteriorImageBase64 = new[]
                {
                    vehicle.Interior1, vehicle.Interior2,
                    vehicle.Interior3, vehicle.Interior4,
                    vehicle.Interior5, vehicle.Interior6
                }.Where(img => img != null).Select(toBase64).ToArray(),

                OtherImageBase64 = new[]
                {
                    vehicle.Other1, vehicle.Other2
                }.Where(img => img != null).Select(toBase64).ToArray(),

                // Dropdowns
                Brands = new SelectList(_context.TrailerBrand.OrderBy(b => b.BrandName), "ID", "BrandName"),
                Types = new SelectList(_context.TrailerType.OrderBy(t => t.TypeName), "ID", "TypeName"),
                AxleTypes = new SelectList(_context.AxleType.OrderBy(a => a.AxleName), "ID", "AxleName"),
                BrakedAxles = new SelectList(_context.BrakedAxle.OrderBy(ba => ba.BrakedAxleName), "ID", "BrakedAxleName"),
                Statuss = new SelectList(_context.Status, "ID", "StatusName")
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult VehicleDetailsTrailer(int ID,
          [Bind("ID,Model,Brand,Type,Price,AxleType,BrakedAxle,NumberAxle,Year,TyreSize,Length,Comments,Status,StatusChangeDate,TailGate")] Trailer trailer,
          int OldStatus,
          IFormFile[]? ExteriorImages, string ExteriorImagesUpdated,
          IFormFile[]? InteriorImages, string InteriorImagesUpdated,
          IFormFile[]? OtherImages, string OtherImagesUpdated)
        {
            if (!ModelState.IsValid)
            {
                return View(trailer); // Return with validation errors
            }

            try
            {
                var existingTrailer = _context.Trailer.FirstOrDefault(t => t.ID == ID);
                if (existingTrailer == null)
                {
                    return NotFound();
                }

                // If status changed, update status change date
                if (trailer.Status != OldStatus)
                {
                    existingTrailer.StatusChangeDate = DateTime.Now;
                }

                // Update trailer details
                existingTrailer.Brand = trailer.Brand;
                existingTrailer.Model = trailer.Model;
                existingTrailer.Year = trailer.Year;
                existingTrailer.Price = trailer.Price;
                existingTrailer.AxleType = trailer.AxleType;
                existingTrailer.BrakedAxle = trailer.BrakedAxle;
                existingTrailer.NumberAxle = trailer.NumberAxle;
                existingTrailer.TyreSize = trailer.TyreSize;
                existingTrailer.Length = trailer.Length;
                existingTrailer.Comments = trailer.Comments;
                existingTrailer.Status = trailer.Status;
                existingTrailer.TailGate = trailer.TailGate;

                // Update images if new ones were uploaded
                if (ExteriorImagesUpdated == "true" && ExteriorImages?.Any() == true)
                {
                    UpdateImagesTrailer(existingTrailer, "Exterior", ExteriorImages);
                }
                if (InteriorImagesUpdated == "true" && InteriorImages?.Any() == true)
                {
                    UpdateImagesTrailer(existingTrailer, "Interior", InteriorImages);
                }
                if (OtherImagesUpdated == "true" && OtherImages?.Any() == true)
                {
                    UpdateImagesTrailer(existingTrailer, "Other", OtherImages);
                }

                _context.Update(existingTrailer);
                _context.SaveChanges();              

                return RedirectToAction("VehicleDetailsList");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return View(trailer);
            }
        }

        [HttpGet]
        public IActionResult VehicleDetailsCampTrailer(int ID)
        {
            // Fetch the trailer and its camp trailer details
            var vehicle = (from trailer in _context.Trailer
                           where trailer.ID == ID
                           select new
                           {
                               trailer,
                               campTrailer = _context.CampTrailer.FirstOrDefault(c => c.TrailerID == trailer.ID)
                           }).FirstOrDefault();

            if (vehicle == null)
            {
                return NotFound(); // Return a 404 if the trailer is not found
            }

            // Convert byte arrays to base64 strings
            Func<byte[]?, string> toBase64 = bytes => bytes != null ? $"data:image/jpeg;base64,{Convert.ToBase64String(bytes)}" : null!;

            // Populate the view model
            var viewModel = new AddVehicleTrailerViewModel
            {
                // Trailer details
                Id = vehicle.trailer.ID,
                Brand = vehicle.trailer.Brand,
                Model = vehicle.trailer.Model,
                Type = vehicle.trailer.Type,
                Year = vehicle.trailer.Year,
                Price = vehicle.trailer.Price,
                AxleType = vehicle.trailer.AxleType,
                BrakedAxle = vehicle.trailer.BrakedAxle,
                NumberAxle = vehicle.trailer.NumberAxle,
                TyreSize = vehicle.trailer.TyreSize,
                Length = vehicle.trailer.Length,
                Comments = vehicle.trailer.Comments,
                Status = vehicle.trailer.Status,
                StatusChangeDate = vehicle.trailer.StatusChangeDate,
                TailGate = false,

                // Existing images as base64 strings
                ExteriorImageBase64 = new[]
                {
                    vehicle.trailer.Exterior1, vehicle.trailer.Exterior2,
                    vehicle.trailer.Exterior3, vehicle.trailer.Exterior4,
                    vehicle.trailer.Exterior5, vehicle.trailer.Exterior6
                }.Where(img => img != null).Select(toBase64).ToArray(),

                InteriorImageBase64 = new[]
                {
                    vehicle.trailer.Interior1, vehicle.trailer.Interior2,
                    vehicle.trailer.Interior3, vehicle.trailer.Interior4,
                    vehicle.trailer.Interior5, vehicle.trailer.Interior6
                }.Where(img => img != null).Select(toBase64).ToArray(),

                OtherImageBase64 = new[]
                {
                    vehicle.trailer.Other1, vehicle.trailer.Other2
                }.Where(img => img != null).Select(toBase64).ToArray(),

                // Camp Trailer details (if applicable)
                CampTrailer = vehicle.campTrailer != null ? new CampTrailerViewModel
                {
                    TrailerID = vehicle.campTrailer.TrailerID,
                    KitchenHas = vehicle.campTrailer.KitchenHas,
                    Sleeper = vehicle.campTrailer.Sleeper,
                    SpareTyre = vehicle.campTrailer.SpareTyre,
                    Awning = vehicle.campTrailer.Awning,
                    Tent = vehicle.campTrailer.Tent,
                    Geyser = vehicle.campTrailer.Geyser,
                    WaterTank = vehicle.campTrailer.WaterTank,
                    WaterPump = vehicle.campTrailer.WaterPump,
                    VoltPowerSupply_12 = vehicle.campTrailer.VoltPowerSupply_12,
                    VoltPowerSupply_220 = vehicle.campTrailer.VoltPowerSupplt_220,
                    Battery = vehicle.campTrailer.Battery,
                    ChargeSystem = vehicle.campTrailer.ChargeSystem,
                    Add_A_Room = vehicle.campTrailer.Add_A_Room,
                    GasBottles = vehicle.campTrailer.GasBottles
                } : new CampTrailerViewModel(),

                // Dropdowns
                Brands = new SelectList(_context.TrailerBrand.OrderBy(b => b.BrandName), "ID", "BrandName"),
                Types = new SelectList(_context.TrailerType.OrderBy(t => t.TypeName), "ID", "TypeName"),
                AxleTypes = new SelectList(_context.AxleType.OrderBy(a => a.AxleName), "ID", "AxleName"),
                BrakedAxles = new SelectList(_context.BrakedAxle.OrderBy(ba => ba.BrakedAxleName), "ID", "BrakedAxleName"),
                Statuss = new SelectList(_context.Status, "ID", "StatusName")
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult VehicleDetailsCampTrailer(
            int ID,
            [Bind("ID,Model,Brand,Type,Price,AxleType,BrakedAxle,NumberAxle,Year,TyreSize,Length,Comments,Status,StatusChangeDate")] Trailer trailer,
            [Bind("ID,TrailerID,KitchenHas,Sleeper,SpareTyre,Awning,Tent,Geyser,WaterTank,WaterPump,VoltPowerSupply_12,VoltPowerSupplt_220,Battery,ChargeSystem,Add_A_Room,GasBottles")] CampTrailer campTrailer,
            int OldStatus,
            IFormFile[]? ExteriorImages, string ExteriorImagesUpdated,
            IFormFile[]? InteriorImages, string InteriorImagesUpdated,
            IFormFile[]? OtherImages, string OtherImagesUpdated)
        {
            if (!ModelState.IsValid)
            {
                return View(trailer); // Return with validation errors
            }

            try
            {
                var existingTrailer = _context.Trailer.FirstOrDefault(t => t.ID == ID);
                if (existingTrailer == null)
                {
                    return NotFound();
                }

                // If status changed, update status change date
                if (trailer.Status != OldStatus)
                {
                    existingTrailer.StatusChangeDate = DateTime.Now;
                }

                // Update trailer details
                existingTrailer.Brand = trailer.Brand;
                existingTrailer.Model = trailer.Model;
                existingTrailer.Year = trailer.Year;
                existingTrailer.Price = trailer.Price;
                existingTrailer.AxleType = trailer.AxleType;
                existingTrailer.BrakedAxle = trailer.BrakedAxle;
                existingTrailer.NumberAxle = trailer.NumberAxle;
                existingTrailer.TyreSize = trailer.TyreSize;
                existingTrailer.Length = trailer.Length;
                existingTrailer.Comments = trailer.Comments;
                existingTrailer.Status = trailer.Status;
                existingTrailer.TailGate = false;

                // Update images if new ones were uploaded
                if (ExteriorImagesUpdated == "true" && ExteriorImages?.Any() == true)
                {
                    UpdateImagesTrailer(existingTrailer, "Exterior", ExteriorImages);
                }
                if (InteriorImagesUpdated == "true" && InteriorImages?.Any() == true)
                {
                    UpdateImagesTrailer(existingTrailer, "Interior", InteriorImages);
                }
                if (OtherImagesUpdated == "true" && OtherImages?.Any() == true)
                {
                    UpdateImagesTrailer(existingTrailer, "Other", OtherImages);
                }

                _context.Update(existingTrailer);
                _context.SaveChanges();

                // Fetch existing CampTrailer entry
                var existingCampTrailer = _context.CampTrailer.FirstOrDefault(ct => ct.TrailerID == existingTrailer.ID);
                if (existingCampTrailer == null)
                {
                    return NotFound("CampTrailer entry not found for this Trailer.");
                }

                // Update CampTrailer details
                existingCampTrailer.KitchenHas = campTrailer.KitchenHas;
                existingCampTrailer.Sleeper = campTrailer.Sleeper;
                existingCampTrailer.SpareTyre = campTrailer.SpareTyre;
                existingCampTrailer.Awning = campTrailer.Awning;
                existingCampTrailer.Tent = campTrailer.Tent;
                existingCampTrailer.Geyser = campTrailer.Geyser;
                existingCampTrailer.WaterTank = campTrailer.WaterTank;
                existingCampTrailer.WaterPump = campTrailer.WaterPump;
                existingCampTrailer.VoltPowerSupply_12 = campTrailer.VoltPowerSupply_12;
                existingCampTrailer.VoltPowerSupplt_220 = campTrailer.VoltPowerSupplt_220;
                existingCampTrailer.Battery = campTrailer.Battery;
                existingCampTrailer.ChargeSystem = campTrailer.ChargeSystem;
                existingCampTrailer.Add_A_Room = campTrailer.Add_A_Room;
                existingCampTrailer.GasBottles = campTrailer.GasBottles;

                _context.Update(existingCampTrailer);
                _context.SaveChanges();

                return RedirectToAction("VehicleDetailsList");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return View(trailer);
            }
        }


    }
}
