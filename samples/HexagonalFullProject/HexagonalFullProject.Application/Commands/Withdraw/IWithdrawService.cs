﻿namespace HexagonalFullProject.Application.Commands.Withdraw
{
    using System.Threading.Tasks;

    public interface IWithdrawService
    {
        Task<WithdrawResult> Process(WithdrawCommand message);
    }
}
