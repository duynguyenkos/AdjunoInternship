using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLL_Layer.BLL.Interface;
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
        }

        public ActionResult Index(int? id, int? method)
        {
            if ((id != null) && (method != null))
            {
                if (method == 1) ViewBag.Message = "The Purchase Order number " + id.ToString() + " is created successfully. Thank you.";
                if (method == 2) ViewBag.Message = "The Purchase Order number " + id.ToString() + " is edited successfully. Thank you.";
            }

            return View();
        }

        public ActionResult Create(int? id)
        {
            OrderDTO defaultModel = new OrderDTO();

            if (id != null)
            {
                int Id = id ?? default(int);
                defaultModel = PurchaseOrder.Find(Id);
                defaultModel.PONumber = 0;
            }

            defaultModel = SetDropDownList(defaultModel);

            return View(defaultModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PONumber,OrderDate,Buyer,Currency,Season,Department,Vendor,Company,Origin,PortOfLoading,PortOfDelivery,OrderType,Factory,Mode,ShipDate,LatestShipDate,DeliveryDate,Status")] OrderDTO addModel)
        {
            addModel = SetDropDownList(addModel);

            if (PurchaseOrder.UniquePONum(addModel.PONumber, 0))
            {
                if (ModelState.IsValid)
                {
                    PurchaseOrder.Add(addModel);

                    return RedirectToAction("Index", new { id = addModel.PONumber, method = 1 });
                }
            }
            else
            {
                ViewBag.ErrorMessage = "PO Number must be unique.";
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
        public ActionResult Edit(int? id, int? method)
        {
            if (method != null)
            {
                if (method == 1) ViewBag.Message = "New item is added successfully. Thank you.";
                if (method == 2) ViewBag.Message = "Item is edited successfully. Thank you.";
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int Id = id ?? default(int);
            OrderDTO addModel = PurchaseOrder.Find(Id);
            addModel = SetDropDownList(addModel);
            if (addModel == null)
            {
                return HttpNotFound();
            }

            return View(addModel);
        }

        // POST: PurchaseOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PONumber,OrderDate,Buyer,Currency,Season,Department,Vendor,Company,Origin,PortOfLoading,PortOfDelivery,OrderType,Factory,Mode,ShipDate,LatestShipDate,DeliveryDate,Status")] OrderDTO editModel)
        {
            editModel = SetDropDownList(editModel);

            if (PurchaseOrder.UniquePONum(editModel.PONumber, editModel.Id))
            {
                if (ModelState.IsValid)
                {
                    PurchaseOrder.Edit(editModel);

                    return RedirectToAction("Index", new { id = editModel.PONumber, method = 2 });
                }
            }
            else
            {
                ViewBag.ErrorMessage = "PO Number must be unique.";
            }
            return View(editModel);
        }

        public ActionResult CreateItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int Id = id ?? default(int);

            OrderDetailDTO defaultModel = new OrderDetailDTO();
            defaultModel.OrderId = Id;

            return View(defaultModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateItem([Bind(Include = "OrderId,ItemNumber,Description,Tariff,Quantity,Cartons,Cube,KGS,UnitPrice,RetailPrice,Warehouse,Size,Colour")] OrderDetailDTO addModel)
        {

            if (ModelState.IsValid)
            {
                PurchaseOrder.AddItem(addModel);

                return RedirectToAction("Edit", new { id = addModel.OrderId, method = 1 });
            }

            return View(addModel);
        }

        // GET: PurchaseOrder/Edit/5
        public ActionResult EditItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int Id = id ?? default(int);

            OrderDetailDTO editModel = PurchaseOrder.FindOrderDetail(Id);

            if (editModel == null)
            {
                return HttpNotFound();
            }

            return View(editModel);
        }

        // POST: PurchaseOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditItem([Bind(Include = "OrderId,ItemNumber,Description,Tariff,Quantity,Cartons,Cube,KGS,UnitPrice,RetailPrice,Warehouse,Size,Colour")] OrderDetailDTO editModel)
        {
            if (ModelState.IsValid)
            {
                PurchaseOrder.EditItem(editModel);

                return RedirectToAction("Edit", new { id = editModel.OrderId, method = 2 });
            }
            return View(editModel);
        }


        // GET: PurchaseOrder/Details/5
        /*public ActionResult Details(int? id)
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
