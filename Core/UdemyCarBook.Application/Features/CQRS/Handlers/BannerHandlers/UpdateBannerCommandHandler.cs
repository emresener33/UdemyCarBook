using Udemy.CarBook.Domain.Entities;
using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Interfaces;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBannerCommand command)
        {
            var value = await _repository.GetByIdAsync(command.BannerId);
            value.Description = command.Description;
            value.Title = command.Title;
            value.VideoUrl = command.VideoUrl;
            value.VideoDescription = command.VideoDescription;
            await _repository.UpdateAsync(value);
        }
    }
}
