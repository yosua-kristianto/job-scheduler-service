using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace job_scheduler_service.Migrations
{
    /// <inheritdoc />
    public partial class JobSchedulerServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "img_tbl_image_profile",
                columns: table => new
                {
                    image_id = table.Column<string>(type: "varchar(36)", nullable: false, defaultValueSql: "(UUID())")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image_original_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image_server_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    expected_output = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "NOW()"),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_img_tbl_image_profile", x => x.image_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "job_map_image_profile_job_scheduler_mapper",
                columns: table => new
                {
                    job_id = table.Column<string>(type: "varchar(36)", nullable: false, defaultValueSql: "(UUID())")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    schedule_id = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image_id = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_map_image_profile_job_scheduler_mapper", x => x.job_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "job_tbl_job_scheduler",
                columns: table => new
                {
                    schedule_id = table.Column<string>(type: "varchar(36)", nullable: false, defaultValueSql: "(UUID())")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    schedule_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    is_synchronous = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: 0),
                    schedule_is_processed = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: 0),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_tbl_job_scheduler", x => x.schedule_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ocr_tbl_result_history",
                columns: table => new
                {
                    result_history_id = table.Column<string>(type: "varchar(36)", nullable: false, defaultValueSql: "(UUID())")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    job_id = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    extracted_text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cer = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "NOW()"),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ocr_tbl_result_history", x => x.result_history_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            // VIEW
            migrationBuilder.Sql(@"CREATE VIEW `job_view_get_progress_by_job` AS
	            SELECT 
		            A.job_id, 
		            CONCAT('BAT', '#', DATE_FORMAT(B.schedule_time, '%Y%m%d%H%i%s%f'), '#', B.schedule_id) AS `schedule_id`,
                    C.image_original_name AS `image_original_name`,
		            CASE 
			            WHEN B.schedule_is_processed = 1 THEN 'Done'
			            ELSE 'Not Done'
		            END AS `process_done`,
                    D.extracted_text AS `result`,
		            CASE 
			            WHEN D.cer IS NULL THEN -1
			            ELSE D.cer
                    END AS `cer`
	            FROM 
		            `job_map_image_profile_job_scheduler_mapper` A
		            LEFT JOIN `job_tbl_job_scheduler` AS B
			            ON A.schedule_id = B.schedule_id
		            LEFT JOIN `img_tbl_image_profile` AS C
			            ON A.image_id = C.image_id
		            LEFT JOIN `ocr_tbl_result_history` AS D
			            ON A.job_id = D.job_id
            ;");

            migrationBuilder.Sql(@"CREATE VIEW `ocr_view_image_result_recap` AS
	            SELECT 
		            C.image_original_name,
                    C.image_server_name AS `image_in_server_name`,
                    A.extracted_text AS `result`,
                    CASE 
			            WHEN A.cer IS NULL THEN 'Expected Output Not Available'
			            ELSE A.cer
                    END AS `cer_point`,
                    A.created_at `report_issued_date`
	            FROM
		            `ocr_tbl_result_history` AS A
		            LEFT JOIN `job_map_image_profile_job_scheduler_mapper` AS B
			            ON A.job_id = B.job_id
		            LEFT JOIN `img_tbl_image_profile` AS C
			            ON B.image_id = C.image_id
            ;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "img_tbl_image_profile");

            migrationBuilder.DropTable(
                name: "job_map_image_profile_job_scheduler_mapper");

            migrationBuilder.DropTable(
                name: "job_tbl_job_scheduler");

            migrationBuilder.DropTable(
                name: "ocr_tbl_result_history");

            migrationBuilder.Sql("DROP VIEW `job_view_get_progress_by_job`;");
            migrationBuilder.Sql("DROP VIEW `ocr_view_image_result_recap`;");
        }
    }
}
