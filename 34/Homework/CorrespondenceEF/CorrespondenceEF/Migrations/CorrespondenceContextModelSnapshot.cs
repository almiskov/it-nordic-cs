﻿// <auto-generated />
using System;
using CorrespondenceEF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CorrespondenceEF.Migrations
{
    [DbContext(typeof(CorrespondenceContext))]
    partial class CorrespondenceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CorrespondenceEF.Domain.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId");

                    b.Property<string>("FullAddress")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Address","dbo");
                });

            modelBuilder.Entity("CorrespondenceEF.Domain.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.HasKey("Id");

                    b.ToTable("City","dbo");
                });

            modelBuilder.Entity("CorrespondenceEF.Domain.Contractor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.Property<int>("PositionId");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Contractor","dbo");
                });

            modelBuilder.Entity("CorrespondenceEF.Domain.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.HasKey("Id");

                    b.ToTable("Position","dbo");
                });

            modelBuilder.Entity("CorrespondenceEF.Domain.PostalItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.Property<int>("NumberOfPages");

                    b.HasKey("Id");

                    b.ToTable("PostalItem","dbo");
                });

            modelBuilder.Entity("CorrespondenceEF.Domain.SendingStatus", b =>
                {
                    b.Property<int?>("PostalItemId");

                    b.Property<DateTimeOffset>("UpdateStatusDateTime");

                    b.Property<int?>("StatusId");

                    b.Property<int?>("SendingContractorId");

                    b.Property<int?>("SendingAddressId");

                    b.Property<int?>("RecievingContractorId");

                    b.Property<int?>("RecievingAddressId");

                    b.Property<int?>("PostalItemId1");

                    b.HasKey("PostalItemId", "UpdateStatusDateTime", "StatusId", "SendingContractorId", "SendingAddressId", "RecievingContractorId", "RecievingAddressId");

                    b.HasIndex("PostalItemId1");

                    b.HasIndex("RecievingAddressId");

                    b.HasIndex("RecievingContractorId");

                    b.HasIndex("SendingAddressId");

                    b.HasIndex("SendingContractorId");

                    b.HasIndex("StatusId");

                    b.ToTable("SendingStatuses");
                });

            modelBuilder.Entity("CorrespondenceEF.Domain.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.ToTable("Status","dbo");
                });

            modelBuilder.Entity("CorrespondenceEF.Domain.Address", b =>
                {
                    b.HasOne("CorrespondenceEF.Domain.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CorrespondenceEF.Domain.Contractor", b =>
                {
                    b.HasOne("CorrespondenceEF.Domain.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CorrespondenceEF.Domain.SendingStatus", b =>
                {
                    b.HasOne("CorrespondenceEF.Domain.PostalItem", "PostalItem")
                        .WithMany()
                        .HasForeignKey("PostalItemId1");

                    b.HasOne("CorrespondenceEF.Domain.Address", "RecievingAddress")
                        .WithMany()
                        .HasForeignKey("RecievingAddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CorrespondenceEF.Domain.Contractor", "RecievingContractor")
                        .WithMany()
                        .HasForeignKey("RecievingContractorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CorrespondenceEF.Domain.Address", "SendingAddress")
                        .WithMany()
                        .HasForeignKey("SendingAddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CorrespondenceEF.Domain.Contractor", "SendingContractor")
                        .WithMany()
                        .HasForeignKey("SendingContractorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CorrespondenceEF.Domain.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
