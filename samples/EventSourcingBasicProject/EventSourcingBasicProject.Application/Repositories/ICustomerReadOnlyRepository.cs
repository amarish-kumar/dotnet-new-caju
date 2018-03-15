﻿namespace EventSourcingBasicProject.Application.Repositories
{
    using EventSourcingBasicProject.Domain.Customers;
    using System;
    using System.Threading.Tasks;

    public interface ICustomerReadOnlyRepository
    {
        Task<Customer> Get(Guid id);
    }
}
