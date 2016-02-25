﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces.BLLModels;
using BLL.Interfaces.Interfaces;
using BLL.Mapping;
using DAL.Interfaces.Interfaces;

namespace BLL.Services
{
    public class ListService: IListService
    {
        private readonly IListRepository _listRep;
        private readonly IUnitOfWork _uow;

        public ListService(IListRepository listRep, IUnitOfWork uow)
        {
            _listRep = listRep;
            _uow = uow;
        }

        public IEnumerable<BllList> GetAllListsNames() => _listRep.GetAllListsNames().Select(Mapper.ToBllList);
        public async Task<IEnumerable<BllList>> GetAllLists() => (await _listRep.GetAll()).Select(Mapper.ToBllList);
        public async Task<IEnumerable<BllList>> GetUserLists(int id)
        {
            return (await _listRep.GetAll()).Where(t => t.OwnerId == id).Select(Mapper.ToBllList);
        }
    }
}
