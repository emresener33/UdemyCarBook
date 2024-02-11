using Udemy.CarBook.Domain.Entities;
using UdemyCarBook.Application.Features.CQRS.Results.AboutResults;
using UdemyCarBook.Application.Interfaces;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAboutQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAboutQueryResult
            {
                AboutId = x.AboutId,
                Description = x.Description,
                Title = x.Title,
                ImageUrl = x.ImageUrl
            }).ToList();
        }
    }
}
