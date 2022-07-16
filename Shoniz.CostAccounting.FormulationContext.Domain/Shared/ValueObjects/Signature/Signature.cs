using Shoniz.CostAccounting.FormulationContext.Domain.Shared.ValueObjects.Signature.Exceptions;

namespace Shoniz.CostAccounting.FormulationContext.Domain.Shared.ValueObjects.Signature
{
    public class Signature
    {
        public string UserId { get; private set; }
        public DateTime DateTime { get; private set; }

        public Signature() { }

        public Signature(string userId)
        {
            DateTime = DateTime.Now;
            SetUserId(userId);
        }
        public void MakeEmpty()
        {
            UserId = null;
            DateTime = default;
        }

        public bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(UserId);
        }

        private void SetUserId(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new UserIdCanNotBeNullException();
            }

            if (!userId.All(char.IsDigit))
            {
                throw new UserIdInvalidException();
            }

            if (userId.Length < 5)
            {
                throw new UserIdInvalidException();
            }

            if (userId.Length > 7)
            {
                throw new UserIdInvalidException();
            }

            UserId = userId;
        }
    }
}
