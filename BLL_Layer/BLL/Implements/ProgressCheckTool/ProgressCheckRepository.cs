using BLL_Layer.BLL.Interface;
using DatabaseRepo;
using DomainModel.Models;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;

namespace BLL_Layer.BLL.Implements
{
    public class ProgressCheckRepository : IProgressCheckRepository
    {

        private IPODBContext db;

        public ProgressCheckRepository()
        {

        }

        public ProgressCheckRepository(IPODBContext db)
        {
            this.db = db;
        }

        public void Add(ProgressCheckDTO progressCheckDTO)
        {
            ProgressCheckModel progressCheckModel = new ProgressCheckModel()
            {
                Id = progressCheckDTO.Id,
                Complete = progressCheckDTO.Complete,
                OnSchedule = progressCheckDTO.OnSchedule,
                IntendedShipDate = progressCheckDTO.IntendedShipDate,
                EstQtyToShip = progressCheckDTO.POCheckQuantity,
                InspectionDate = progressCheckDTO.InspectionDate,
                OrderId = progressCheckDTO.OrderId

            };
            db.GetDB().ProgressChecks.AddOrUpdate(progressCheckModel);
            db.GetDB().SaveChanges();

        }

        public ProgressCheckDTO Find(int id)
        {
            //ProgressCheckModel progressCheckModel = db.GetDB().ProgressChecks.Find(id);
            //OrderModel order = db.GetDB().Orders.Find(progressCheckModel.OrderId);
            ProgressCheckDTO progressCheckDTO = new ProgressCheckDTO();
            //{
            //    Id=progressCheckModel.Id,
            //    Complete=progressCheckModel.Complete,
            //    OnSchedule=progressCheckModel.OnSchedule,
            //    IntendedShipDate=progressCheckModel.IntendedShipDate,
            //    POCheckQuantity=progressCheckModel.EstQtyToShip,
            //    InspectionDate=progressCheckModel.InspectionDate,
            //    ShipDate=order.ShipDate,
            //    PONumber=order.Id
            //};

            //progressCheckDTO.ListOrderDetail = db.GetDB().OrderDetails.Where(p => p.OrderId == progressCheckModel.OrderId).ToList();
            //foreach (var i in progressCheckDTO.ListOrderDetail)
            //{
            //    progressCheckDTO.POQuantity += i.Quantity;
            //}
            return progressCheckDTO;
        }

        public List<ProgressCheckDTO> GetAll()
        {
            List<ProgressCheckDTO> progressCheckDTOs = new List<ProgressCheckDTO>();
            List<ProgressCheckModel> progressCheckModels = db.GetDB().ProgressChecks.ToList();
            List<OrderModel> orders = db.GetDB().Orders.ToList();
            
            foreach (var i in orders)
            {
                OrderModel order = db.GetDB().Orders.Find(i.Id);
                float POQuantity = 0;
                List<OrderDetailModel> orderDetailModels = db.GetDB().OrderDetails.Where(p => p.OrderId == i.Id).ToList();
                foreach(var j in orderDetailModels)
                {
                    POQuantity += j.Quantity;
                }
                ProgressCheckModel progressCheckModel = db.GetDB().ProgressChecks.SingleOrDefault(p => p.OrderId == i.Id);
                if (progressCheckModel != null)
                {
                    ProgressCheckDTO temp = new ProgressCheckDTO()
                    {
                        Id = i.Id,
                        Factory = order.Factory,
                        //PONumber = progressCheckModel.OrderId,
                        POCheckQuantity = progressCheckModel.EstQtyToShip,
                        ShipDate = order.ShipDate,
                        InspectionDate = progressCheckModel.InspectionDate,
                        IntendedShipDate = progressCheckModel.IntendedShipDate,
                        Complete = progressCheckModel.Complete,
                        POQuantity = POQuantity,
                        Supplier = order.Supplier,
                        ListOrderDetail = orderDetailModels

                    };
                    progressCheckDTOs.Add(temp);
                }
                else
                {
                    ProgressCheckDTO temp = new ProgressCheckDTO()
                    {
                        Id = i.Id,
                        Factory = order.Factory,
                        //PONumber = progressCheckModel.OrderId,
                        //POCheckQuantity = progressCheckModel.EstQtyToShip,
                        ShipDate = order.ShipDate,
                        InspectionDate = DateTime.Now.Date,
                        IntendedShipDate = DateTime.Now.Date,
                        //Complete = progressCheckModel.Complete,
                        POQuantity = POQuantity,
                        Supplier = order.Supplier,
                        ListOrderDetail = orderDetailModels

                    };
                    progressCheckDTOs.Add(temp);
                }
                               
           }
            return progressCheckDTOs;
        }
        public GetSearchItemDTO SearchItem()
        {
            List<OrderModel> orderModels = db.GetDB().Orders.ToList();
            var suppliers = orderModels.Select(x => x.Supplier).Distinct();
            var origins = orderModels.Select(x => x.Origin).Distinct();
            var originports = orderModels.Select(x => x.PortOfLoading).Distinct();
            var factories = orderModels.Select(x => x.Factory).Distinct();
            var depts = orderModels.Select(x => x.Department).Distinct();
            GetSearchItemDTO getSearchItemDTO = new GetSearchItemDTO()
            {
                Suppliers = suppliers,
                Origins = origins,
                OriginPorts=originports,
                Factories=factories,
                Depts=depts
            };        
            return getSearchItemDTO;
        }    
    }
}
