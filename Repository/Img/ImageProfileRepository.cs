using etl_job_service.Config;
using etl_job_service.Entity.Img;

namespace etl_job_service.Repository.Img
{
    public class ImageProfileRepository : BaseRepository, IImageProfileRepository
    {
        public ImageProfileRepository(DatabaseContext context) : base(context) { }

        public ImageProfile Create(string originalName, string inServerName)
        {
            ImageProfile imageProfile = new ImageProfile();

            imageProfile.inServerName = inServerName;
            imageProfile.originalName = originalName;

            this._context.ImageProfile.Add(imageProfile);
            this._context.SaveChanges();

            return this.GetDataById(imageProfile.id);
        }

        public ImageProfile Create(string originalName, string inServerName, string expectedOutput)
        {
            ImageProfile imageProfile = this.Create(originalName, inServerName);
            imageProfile.expectedOutput = expectedOutput;

            this._context.SaveChanges();
            return this.GetDataById(imageProfile.id);
        }

        public List<ImageProfile> GetAll()
        {
            Console.WriteLine("This function has been called");
            return this._context.ImageProfile.ToList();
        }

        public ImageProfile GetDataById(string id)
        {
            return this._context.ImageProfile.FirstOrDefault(e => e.id == id);
        }
    }
}
