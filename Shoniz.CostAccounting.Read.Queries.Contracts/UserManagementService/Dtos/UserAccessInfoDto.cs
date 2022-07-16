namespace Shoniz.CostAccounting.Read.Queries.Contracts.UserManagementService.Dtos
{
    public class UserAccessInfoDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsPasswordValid { get; set; }
        public bool HasAccessToApplication { get; set; }
    }
}
