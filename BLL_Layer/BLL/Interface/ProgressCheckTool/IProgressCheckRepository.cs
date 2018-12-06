﻿using DTOs;
using System.Collections.Generic;
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
