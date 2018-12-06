using BLL_Layer.BLL.Interface;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace InternProject.Controllers
{
    public class ProgressCheckController : Controller
    {
        private IProgressCheckRepository ProcheckRepository;

        public ProgressCheckController() { }

        public ProgressCheckController(IProgressCheckRepository progressCheckRepository)
        {
            this.ProcheckRepository = progressCheckRepository;
        }
        // GET: ProgressCheck
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexTest()
        {
            List<ProgressCheckDTO> progressCheckDTOs = ProcheckRepository.GetAll();
            return View(progressCheckDTOs);
        }
        [HttpPost]
        public ActionResult IndexTest([Bind(Include = "InspectionDate,IntendedShipDate,Complete")]ProgressCheckDTO progressCheckDTO)
        {
            ProcheckRepository.Add(progressCheckDTO);

            return View(progressCheckDTO);
        }
        
    }
}
