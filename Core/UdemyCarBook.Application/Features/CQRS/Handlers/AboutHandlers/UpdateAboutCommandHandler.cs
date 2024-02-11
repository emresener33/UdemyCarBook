using Udemy.CarBook.Domain.Entities;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Interfaces;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAboutCommand command)
        {
            var value = await _repository.GetByIdAsync(command.AboutId);
            value.Description = command.Description;
            value.Title = command.Title;
            value.ImageUrl = command.ImageUrl;
            await _repository.UpdateAsync(value);
        }
    }
}
