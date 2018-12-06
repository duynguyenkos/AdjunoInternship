using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL_Layer.BLL.Interface;
using DomainModel.Models;
using System.Data.Entity;
using DTOs;
using DatabaseRepo;
using Unity;
using DAL_Layer.DAL.DBContext;

namespace BLL_Layer.BLL.Implements
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private IPODBContext db;

        public PurchaseOrderRepository()
        {

        }

        public PurchaseOrderRepository(IPODBContext db)
        {
            this.db = db;
        }

        public void Add(OrderDTO orderDTO)
        {
            OrderModel orderModel = new OrderModel();

            orderModel.Id = orderDTO.Id;
            orderModel.OrderDate = orderDTO.OrderDate;
            orderModel.Buyer = orderDTO.Buyer;
            orderModel.Currency = orderDTO.Currency;
            orderModel.Season = orderDTO.Season;
            orderModel.Department = orderDTO.Department;
            orderModel.Vendor = orderDTO.Vendor;
            orderModel.Company = orderDTO.Company;
            orderModel.Origin = orderDTO.Origin;
            orderModel.PortOfLoading = orderDTO.PortOfLoading;
            orderModel.PortOfDelivery = orderDTO.PortOfDelivery;
            orderModel.OrderType = orderDTO.OrderType;
            orderModel.Factory = orderDTO.Factory;
            orderModel.Mode = orderDTO.Mode;
            orderModel.ShipDate = orderDTO.ShipDate;
            orderModel.LatestShipDate = orderDTO.LatestShipDate;
            orderModel.DeliveryDate = orderDTO.DeliveryDate;
            orderModel.Status = orderDTO.Status;

            orderModel.POQuantity = 0;
            if (orderDTO.PODetails != null)
            {
                foreach (var i in orderDTO.PODetails)
                {
                    orderModel.POQuantity += i.Quantity;
                }
            }

            orderModel.Supplier = "";

            //PODBContext test = db;

            db.GetDB().Orders.Add(orderModel);
            db.GetDB().SaveChanges();
        }

        public void Edit(int Id, OrderDTO newOrder)
        {
            //db.GetDB().Orders.Find(Id).
        }

        public OrderDTO Find(int Id)
        {
            OrderDTO orderDTO = new OrderDTO();
            /*OrderModel orderModel= db.GetDB().Orders.Find(Id);
            orderDTO.Id = orderModel.Id; //mapping data*/
            return orderDTO;
        }
        
    }
}