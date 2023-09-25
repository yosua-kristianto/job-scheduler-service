﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using etl_job_service.Config;

#nullable disable

namespace etl_job_service.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("etl_job_service.Entity.Img.ImageProfile", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(36)")
                        .HasColumnName("image_id")
                        .HasDefaultValueSql("(UUID())")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("deleted_at");

                    b.Property<string>("expectedOutput")
                        .HasColumnType("longtext")
                        .HasColumnName("expected_output");

                    b.Property<string>("inServerName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("image_server_name");

                    b.Property<string>("originalName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("image_original_name");

                    b.HasKey("id");

                    b.ToTable("img_tbl_image_profile");
                });

            modelBuilder.Entity("etl_job_service.Entity.Job.JobScheduler", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(36)")
                        .HasColumnName("schedule_id")
                        .HasDefaultValueSql("(UUID())")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("NOW()");

                    b.Property<bool>("processOperation")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("schedule_is_processed")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("scheduleTime")
                        .HasColumnType("datetime")
                        .HasColumnName("schedule_time");

                    b.Property<bool>("synchronousOperation")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_synchronous")
                        .HasDefaultValue(0);

                    b.HasKey("id");

                    b.ToTable("job_tbl_job_scheduler");
                });

            modelBuilder.Entity("etl_job_service.Entity.Job.MapImageProfileJobScheduler", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(36)")
                        .HasColumnName("job_id")
                        .HasDefaultValueSql("(UUID())")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("imageId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("image_id");

                    b.Property<string>("scheduleId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("schedule_id");

                    b.HasKey("id");

                    b.ToTable("job_map_image_profile_job_scheduler_mapper");
                });

            modelBuilder.Entity("etl_job_service.Entity.Ocr.ResultHistory", b =>
                {
                    b.Property<string>("resultHistoryId")
                        .HasColumnType("varchar(36)")
                        .HasColumnName("result_history_id")
                        .HasDefaultValueSql("(UUID())")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("characterErrorRate")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("cer");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("NOW()")
                        ;

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("deleted_at");

                    b.Property<string>("extractedText")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("extracted_text");

                    b.Property<string>("jobId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("job_id");

                    b.Property<string>("notes")
                        .HasColumnType("longtext")
                        .HasColumnName("notes");

                    b.HasKey("resultHistoryId");

                    b.ToTable("ocr_tbl_result_history");
                });
#pragma warning restore 612, 618
        }
    }
}