using DomainModel.Models;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Layer.BLL.Interface
{
    public interface IProgressCheckRepository
    {
        List<ProgressCheckDTO> GetAll();
        void Add(ProgressCheckDTO progressCheckDTO);
        ProgressCheckDTO Find(int id);
        void Delete(ProgressCheckDTO progressCheckDTO);
        void Edit(ProgressCheckDTO progressCheckDTO);
    }
}
