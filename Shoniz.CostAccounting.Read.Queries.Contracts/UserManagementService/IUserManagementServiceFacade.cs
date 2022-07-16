using Shoniz.CostAccounting.Read.Queries.Contracts.UserManagementService.Dtos;
using Shoniz.Framework.Read;

namespace Shoniz.CostAccounting.Read.Queries.Contracts.UserManagement
{
    public interface IUserManagementServiceFacade : IQueryFacade
    {
        Task<UserAccessInfoDto> GetUserAccessInfo(string programId);

    }
}
