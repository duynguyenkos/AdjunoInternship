using BLL_Layer.BLL.Interface;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Data.Entity.Migrations;
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

        public ActionResult Index(int? page,string PONumberSearch,string ItemSearch,string Suppliers,string Factories,string Origins,string OriginPorts,string Depts)
        {
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            GetSearchItemDTO getSearchItem = ProcheckRepository.SearchItem();
            ViewBag.Suppliers = getSearchItem.Suppliers;
            ViewBag.Origins = getSearchItem.Origins;
            ViewBag.OriginPorts = getSearchItem.OriginPorts;
            ViewBag.Factories = getSearchItem.Factories;
            ViewBag.Depts = getSearchItem.Depts;
            ViewBag.ErrorList = "No result match, please try again";


            List<ProgressCheckDTO> progressCheckDTOs = ProcheckRepository.GetAll();
            if(PONumberSearch!=null || ItemSearch != null)
            {
                progressCheckDTOs = progressCheckDTOs.Where(p => p.PONumber == PONumberSearch).ToList();                            
            }
            if(!String.IsNullOrEmpty(Suppliers)||!String.IsNullOrEmpty(Factories))
            {
                progressCheckDTOs = progressCheckDTOs.Where(p => p.Supplier==Suppliers || p.Factory==Factories).ToList();
                
            }          
            return View(progressCheckDTOs.ToPagedList(pageNumber,pageSize));
        }
        [HttpPost]
        public ActionResult Index(IEnumerable<ProgressCheckDTO> progressCheckDTOs)
        {
            for (int i = 1; i <= progressCheckDTOs.Count(); i++)
            {
                ProcheckRepository.Add(progressCheckDTOs.ElementAt(i));
            }
            return View("Index");
        }
    }
}
