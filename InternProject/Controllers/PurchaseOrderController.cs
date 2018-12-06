using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLL_Layer.BLL.Interface;
using DomainModel.Models;
using DTOs;
using Unity;

namespace InternProject.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private IPurchaseOrderRepository PurchaseOrder;

        public PurchaseOrderController() { }

        public PurchaseOrderController(IPurchaseOrderRepository purchaseOrder)
        {
            this.PurchaseOrder = purchaseOrder;
            /*var container = new UnityContainer();
            container.RegisterInstance<IPurchaseOrderRepository>(this.PurchaseOrder);*/
        }
        public ActionResult Create()
        {
            OrderDTO defaultModel = new OrderDTO();

            defaultModel = SetDropDownList(defaultModel);

            return View(defaultModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderDate,Buyer,Currency,Season,Department,Vendor,Company,Origin,PortOfLoading,PortOfDelivery,OrderType,Factory,Mode,ShipDate,LatestShipDate,DeliveryDate,Status")] OrderDTO addModel)
        {
            addModel = SetDropDownList(addModel);

            if (ModelState.IsValid)
            {
                PurchaseOrder.Add(addModel);

                return RedirectToAction("Index");
            }

            return View(addModel);
        }

        private OrderDTO SetDropDownList(OrderDTO addModel)
        {
            OrderDTO init = new OrderDTO();
            init = addModel;

            init.Seasons = GetSelectListItems(SeasonList());
            init.Origins = GetSelectListItems(new List<string> { "HongKong", "Vietnam" });
            init.Ports = GetSelectListItems(new List<string> { "Port 1", "Port 2", "Port 3" });
            init.Modes = GetSelectListItems(new List<string> { "Road", "Sea", "Air" });

            return init;
        }

        private IEnumerable<string> SeasonList()
        {
            List<string> seasonList = new List<string>();
            for (int i = 2010; i <= 2020; i++)
            {
                seasonList.Add(i.ToString());
            }
            return seasonList;
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            var selectList = new List<SelectListItem>();

            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }

        // GET: PurchaseOrder/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //int Id = id ?? default(int);
            ////OrderModel addModel = PurchaseOrder.Find(Id);
            //if (addModel == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: PurchaseOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderDate,Buyer,Currency,Season,Department,Vendor,Company,Origin,PortOfLoading,PortOfDelivery,OrderType,Factory,Mode,ShipDate,LatestShipDate,DeliveryDate,Status")] OrderDTO addModel)
        {
            if (ModelState.IsValid)
            {
                /*db.Entry(addModel).State = EntityState.Modified;
                db.SaveChanges();*/
                return RedirectToAction("Index");
            }
            return View(addModel);
        }

        // GET: PurchaseOrder
        /*public ActionResult Index()
        {
            List<AddModel> addModels = new List<AddModel>();
            addModels = db.Orders.ToList();
            return View(db.AddModels.ToList());
        }

        // GET: PurchaseOrder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddModel addModel = db.Orders.Find(id);
            if (addModel == null)
            {
                return HttpNotFound();
            }
            return View(addModel);
        }

        // GET: PurchaseOrder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddModel addModel = db.AddModels.Find(id);
            if (addModel == null)
            {
                return HttpNotFound();
            }
            return View(addModel);
        }

        // POST: PurchaseOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddModel addModel = db.AddModels.Find(id);
            db.AddModels.Remove(addModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
