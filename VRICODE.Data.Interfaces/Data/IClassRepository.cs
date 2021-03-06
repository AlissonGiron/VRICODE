﻿using VRICODE.Models;

namespace VRICODE.Interfaces.Data
{
    public interface IClassRepository : IVRICODERepositoryBase<Class>
    {
        void CreateUserClass(UserClass AUserClass);
    }
}
