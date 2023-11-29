using BeautySalon.Application.Repositories;
using BeautySalon.Contracts.Dtos;
using BeautySalon.Infrastructure;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly IMapper _mapper;

        public ReviewsController(IReviewRepository reviewRepo, IMapper mapper)
        {
            _reviewRepo = reviewRepo;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllReviews")]
        [Authorize(Roles = "admin, client, employee")]
        public async Task<IEnumerable<ReviewDTO>> GetAllAsync()
        {
            var list = await _reviewRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<ReviewDTO>>(list);
        }
        [HttpGet("{rate:int}", Name = "GetReviewByRate")]
        [Authorize(Roles = "admin, client, employee")]
        public async Task<IEnumerable<ReviewDTO>> GetByIdAsync(int rate)
        {
            var entity = await _reviewRepo.GetByRateAsync(rate);
            return _mapper.Map<IEnumerable<ReviewDTO>>(entity);
        }

        [HttpPost(Name = "AddReview")]
        [Authorize(Roles = "admin, client")]
        public async Task AddAsync(ReviewDTO entity)
        {
            var obj = _mapper.Map<Reviews>(entity);
            await _reviewRepo.InsertAsync(obj);
        }

        [HttpDelete(Name="DeleteReview")]
        [Authorize(Roles = "admin")]
        public async Task DeleteAsync(int id)
        {
            await _reviewRepo.DeleteAsync(id);

        }
    }
}
