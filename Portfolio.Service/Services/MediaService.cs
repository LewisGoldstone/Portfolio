using Portfolio.Domain.Models;
using Portfolio.Domain.Repositories;
using Portfolio.Domain.Services;

namespace Portfolio.Service
{
    public class MediaService : IMediaService
    {
        private IRepository<Media> _mediaRepo;

        public MediaService(IRepository<Media> mediaRepo)
        {
            _mediaRepo = mediaRepo;
        }

        public Media GetMedia(int id)
        {
            return _mediaRepo.GetById(id);
        }
    }
}
