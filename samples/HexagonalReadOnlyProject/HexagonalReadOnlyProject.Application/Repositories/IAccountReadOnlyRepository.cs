﻿namespace HexagonalReadOnlyProject.Application.Repositories
{
    using HexagonalReadOnlyProject.Domain.Accounts;
    using System;
    using System.Threading.Tasks;

    public interface IAccountReadOnlyRepository
    {
        Task<Account> Get(Guid id);        
    }
}
