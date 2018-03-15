﻿namespace CleanBasicProject.UI.UseCases.Register
{
    using System;
    using System.Collections.Generic;
    using CleanBasicProject.UI.Model;

    public class Model
    {
        public Guid CustomerId { get; }
        public string Personnummer { get; }
        public string Name { get; }
        public List<AccountDetailsModel> Accounts { get; set; }

        public Model(
            Guid customerId,
            string perssonnummer,
            string name,
            List<AccountDetailsModel> accounts)
        {
            CustomerId = customerId;
            Personnummer = perssonnummer;
            Name = name;
            Accounts = accounts;
        }
    }
}
