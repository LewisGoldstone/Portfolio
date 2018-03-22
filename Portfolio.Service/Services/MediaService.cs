using Portfolio.Domain.Models;
using Portfolio.Domain.Repositories;
using Portfolio.Domain.Services;

namespace Portfolio.Service
{
    public class MediaService : IMediaService
    {
        private IMediaRepository _mediaRepo;

        public MediaService(IMediaRepository mediaRepo)
        {
            _mediaRepo = mediaRepo;
        }
    }
}
