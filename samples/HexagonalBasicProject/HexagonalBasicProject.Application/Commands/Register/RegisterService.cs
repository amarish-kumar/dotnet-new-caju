﻿namespace HexagonalBasicProject.Application.Commands.Register
{
    using System.Threading.Tasks;
    using HexagonalBasicProject.Application.Results;
    using HexagonalBasicProject.Domain.Customers;
    using HexagonalBasicProject.Domain.ValueObjects;
    using HexagonalBasicProject.Application.Repositories;
    using HexagonalBasicProject.Domain.Accounts;

    public class RegisterService : IRegisterService
    {
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;
        private readonly IResultConverter resultConverter;

        public RegisterService(
            ICustomerWriteOnlyRepository customerWriteOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository,
            IResultConverter resultConverter)
        {
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
            this.resultConverter = resultConverter;
        }

        public async Task<RegisterResult> Process(RegisterCommand command)
        {
            Customer customer = new Customer(
                new PIN(command.PIN),
                new Name(command.Name));

            Account account = new Account();
            Credit credit = new Credit(new Amount(command.InitialAmount));
            account.Deposit(credit);

            customer.Register(account.Id);

            await customerWriteOnlyRepository.Add(customer);
            await accountWriteOnlyRepository.Add(account);

            CustomerResult customerResult = resultConverter.Map<CustomerResult>(customer);
            AccountResult accountResult = resultConverter.Map<AccountResult>(account);
            RegisterResult result = new RegisterResult(customerResult, accountResult);

            return result;
        }
    }
}
