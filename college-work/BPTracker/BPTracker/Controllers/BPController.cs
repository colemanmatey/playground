using BPTracker.Models;
using BPTracker.Models.ViewModels;
using BPTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace BPTracker.Controllers
{
    public class BPController : Controller
    {
        private readonly IBPMeasurementService _bpmService;

        public BPController(IBPMeasurementService bPMeasurementService)
        {
            _bpmService = bPMeasurementService;
        }

        public IActionResult Index()
        {
            var bpViewModel = new BPViewModel();
            bpViewModel.BPReadings = _bpmService.GetBPReadings();

            return View(bpViewModel);
        }

        [HttpGet]
        public IActionResult AddNewBP()
        {
            var bpViewModel = new BPViewModel();
            bpViewModel.NewBPReading = new BloodPressure();
            return View("Add", bpViewModel);
        }

        [HttpPost]
        public IActionResult AddNewBP(BPViewModel bpViewModel)
        {
            if (ModelState.IsValid)
            {
                _bpmService.AddNewBPReading(bpViewModel.NewBPReading);

                TempData["Message"] = "New Blood Pressure reading added successfully!";
                return RedirectToAction("Index");
            }

            return View("Add", bpViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var bpViewModel = new BPViewModel();
            bpViewModel.NewBPReading = _bpmService.GetBPReadings().Find(bp => bp.Id == id);
            return View(bpViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, BPViewModel bpViewModel)
        {
            if (ModelState.IsValid)
            {
                _bpmService.UpdateBPReading(id, bpViewModel.NewBPReading);
                TempData["Message"] = "Blood Pressure reading updated successfully!";
                return RedirectToAction("Index");
            }

            return View(bpViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id, BPViewModel bPViewModel)
        { 
            return View("Delete");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _bpmService.DeleteBPReading(id);
            return RedirectToAction("Index");
        }
    }
}
