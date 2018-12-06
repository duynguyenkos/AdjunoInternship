using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using DTOs;

namespace BLL_Layer.BLL.Interface
{
    public interface IPurchaseOrderRepository 
    {
        void Add(OrderDTO order);
        void Edit(int Id, OrderDTO newOrder);
        OrderDTO Find(int Id);
    }
}
