using APTEKA_Software.Models;
using APTEKA_Software.Repositories.Contracts;
using APTEKA_Software.Services.Contracts;
using APTEKA_Software.Exeptions;

namespace APTEKA_Software.Services
{
    public class SalesService : ISalesService
    {
        private readonly IItemRepository itemRepository;
        private readonly IUserRepository userRepository;

        public SalesService(IItemRepository itemRepository, IUserRepository userRepository)
        {
            this.itemRepository = itemRepository;
            this.userRepository = userRepository;
        }

        public SaleResult MakeSale(int userId, int itemId, int quantity)
        {
            var user = userRepository.GetUser(userId);
            var item = itemRepository.GetById(itemId);

            if (user != null && item != null)
            {
                if (item.AvailableQuantity >= quantity)
                {
                    var totalSaleValue = quantity * item.SalePrice;

                    item.AvailableQuantity -= quantity;

                    itemRepository.Update(item);

                    return new SaleResult
                    {
                        Success = true,
                        TotalSaleValue = totalSaleValue,
                    };
                }
                else
                {
                    throw new EntityNotFoundException($"Недостатъчно количество на артикула {item}.");
                }
            }
            else
            {
                throw new EntityNotFoundException($"Невалиден потребител ({user}) или артикул ({item}).");
            }
        }
    }
}
