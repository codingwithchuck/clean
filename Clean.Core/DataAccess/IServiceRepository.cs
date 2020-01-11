﻿using System.Collections.Generic;
using Clean.Core.Domain;

namespace Clean.Core.DataAccess
{
    public interface IServiceRepository
    {
        IList<Service> Get();
    }
}