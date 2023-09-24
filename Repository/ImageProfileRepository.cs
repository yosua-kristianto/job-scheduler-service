using etl_job_service.Config;
using etl_job_service.Entity.Img;

namespace etl_job_service.Repository
{
    public class ImageProfileRepository : BaseRepository, IImageProfileRepository
    {
        public ImageProfileRepository(DatabaseContext context) : base(context){}

        public List<ImageProfile> GetAll()
        {
            Console.WriteLine("This function has been called");
            return this._context.ImageProfile.ToList();
        }
    }
}
