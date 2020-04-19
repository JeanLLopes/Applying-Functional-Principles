using CustomerManagement.Logic.Common;

namespace CustomerManagement.Logic.Model
{
    public interface IEmailGateway
    {
        CSharpFunctionalExtensions.Result SendPromotionNotification(string email, CustomerStatus newStatus);
    }
}
