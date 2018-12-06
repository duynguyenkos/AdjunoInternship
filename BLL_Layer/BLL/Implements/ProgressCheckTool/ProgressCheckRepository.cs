using BLL_Layer.BLL.Interface;
using DAL_Layer.DAL.DBContext;
using DomainModel.Models;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Layer.BLL.Implements
{
    public class ProgressCheckRepository : IProgressCheckRepository
    {
        private PODBContext db = new PODBContext();

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
            db.ProgressChecks.Add(progressCheckModel);
            db.SaveChanges();

        }

        public void Delete(ProgressCheckDTO progressCheckDTO)
        {
            
        }

        public void Edit(ProgressCheckDTO progressCheckDTO)
        {
           
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
            List<ProgressCheckModel> progressCheckModels = db.ProgressChecks.ToList();
            List<OrderModel> orders = db.Orders.ToList();
            
            foreach (var i in progressCheckModels)
            {
                OrderModel order = db.Orders.Find(i.OrderId);
                float POQuantity = 0;
                List<OrderDetailModel> orderDetailModels = db.OrderDetails.Where(p => p.OrderId == i.OrderId).ToList();
                foreach(var j in orderDetailModels)
                {
                    POQuantity += j.Quantity;
                }
                ProgressCheckDTO temp = new ProgressCheckDTO()
                {
                    Id=i.Id,
                    Factory=order.Factory,
                    PONumber=i.OrderId,
                    POCheckQuantity=i.EstQtyToShip,
                    ShipDate=order.ShipDate,
                    InspectionDate=i.InspectionDate,
                    IntendedShipDate=i.IntendedShipDate,
                    Complete=i.Complete,
                    POQuantity=POQuantity,
                    Supplier=order.Supplier,
                    ListOrderDetail=orderDetailModels

                };              
                progressCheckDTOs.Add(temp);               
           }
            return progressCheckDTOs;
            

        }
    }
}
