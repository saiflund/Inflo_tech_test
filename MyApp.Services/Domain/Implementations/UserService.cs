﻿using System;
using System.Collections.Generic;
using MyApp.Data;
using MyApp.Models;
using MyApp.Services.Domain.Implementations.Base;
using MyApp.Services.Domain.Interfaces;

namespace MyApp.Services.Domain.Implementations
{
    public class UserService : ServiceBase<User>, IUserService
    {
        public UserService(IDataAccess dataAccess) : base(dataAccess) 
        {
            DataAccess = dataAccess;
        }

        private IDataAccess DataAccess { get; }

        /// <summary>
        /// Return users by active state
        /// </summary>
        /// <param name="isActive"></param>
        /// <returns></returns>
        public IEnumerable<User> FilterByActive(bool isActive)
        {
            return DataAccess.GetUserByActive<User>(isActive);
        }
    }
}
