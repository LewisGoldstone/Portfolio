using Core.Models;
using Core.Repositories;
using Core.Services;

namespace Service
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
