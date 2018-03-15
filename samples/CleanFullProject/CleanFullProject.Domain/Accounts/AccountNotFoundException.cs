﻿namespace CleanFullProject.Domain.Accounts
{
    public class AccountNotFoundException : DomainException
    {
        public AccountNotFoundException(string message)
            : base(message)
        { }
    }
}
