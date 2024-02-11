using Udemy.CarBook.Domain.Entities;
using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Interfaces;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class RemoveBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public RemoveBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBannerCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
