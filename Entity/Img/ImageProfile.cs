using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace etl_job_service.Entity.Img
{
    /**
     * ImageProfile
     * 
     * @version 0.0.1
     * 
     * @todo Make this snake_case or try to serialize this as snake_case on response.
     */ 
    [Table("img_tbl_image_profile")]
    public class ImageProfile
    {
        [Column("image_id")]
        public string id { get; set; }

        [Column("image_original_name")]
        public string originalName { get; set; }

        [Column("image_server_name")]
        public string inServerName { get; set; }

        [Column("expected_output")]
        public string? expectedOutput { get; set; }

        [Column("created_at")]
        public DateTime createdAt { get; private set; }

        [Column("deleted_at")]
        public DateTime? deletedAt { get; private set; }
    }
}
