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
                PONumber=progressCheckDTO.PONumber,
                Complete=false,
                OnSchedule = progressCheckDTO.OnSchedule,
                IntendedShipDate = progressCheckDTO.IntendedShipDate,
                InspectionDate = progressCheckDTO.InspectionDate,
                OrderId = progressCheckDTO.OrderId
                

            };
            if (progressCheckDTO.POCheckQuantity == progressCheckDTO.POQuantity)
            {
                progressCheckModel.Complete = true;
            }
            
            db.GetDB().ProgressChecks.AddOrUpdate(progressCheckModel);
            db.GetDB().SaveChanges();

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
                if (progressCheckModel == null)
                {
                    progressCheckModel.Complete = false;
                    progressCheckModel.EstQtyToShip = 0;
                    progressCheckModel.InspectionDate = DateTime.Now.Date;
                    progressCheckModel.IntendedShipDate = DateTime.Now.Date;
                }
                ProgressCheckDTO temp = new ProgressCheckDTO()
                {
                    Id = i.Id,
                    Factory = order.Factory,
                    PONumber = order.PONumber,
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
