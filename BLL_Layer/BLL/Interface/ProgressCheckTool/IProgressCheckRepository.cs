using DTOs;
using System.Collections.Generic;
namespace BLL_Layer.BLL.Interface
{
    public interface IProgressCheckRepository
    {
        List<ProgressCheckDTO> GetAll();
        void Add(ProgressCheckDTO progressCheckDTO);
        GetSearchItemDTO SearchItem();
    }
}
