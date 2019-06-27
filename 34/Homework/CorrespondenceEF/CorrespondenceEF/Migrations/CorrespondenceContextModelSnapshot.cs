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

                    b.Property<int?>("CityId");

                    b.Property<string>("FullAddress");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CorrespondenceEF.Domain.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("CorrespondenceEF.Domain.Contractor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("PositionId");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Contractors");
                });

            modelBuilder.Entity("CorrespondenceEF.Domain.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("CorrespondenceEF.Domain.PostalItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfPages");

                    b.HasKey("Id");

                    b.ToTable("PostalItems");
                });

            modelBuilder.Entity("CorrespondenceEF.Domain.SendingStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PostalItemId");

                    b.Property<int?>("RecievingAddressId");

                    b.Property<int?>("RecievingContractorId");

                    b.Property<int?>("SendingAddressId");

                    b.Property<int?>("SendingContractorId");

                    b.Property<int?>("StatusId");

                    b.Property<DateTimeOffset>("UpdateStatusDateTime");

                    b.HasKey("Id");

                    b.HasIndex("PostalItemId");

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

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("CorrespondenceEF.Domain.Address", b =>
                {
                    b.HasOne("CorrespondenceEF.Domain.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("CorrespondenceEF.Domain.Contractor", b =>
                {
                    b.HasOne("CorrespondenceEF.Domain.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");
                });

            modelBuilder.Entity("CorrespondenceEF.Domain.SendingStatus", b =>
                {
                    b.HasOne("CorrespondenceEF.Domain.PostalItem", "PostalItem")
                        .WithMany()
                        .HasForeignKey("PostalItemId");

                    b.HasOne("CorrespondenceEF.Domain.Address", "RecievingAddress")
                        .WithMany()
                        .HasForeignKey("RecievingAddressId");

                    b.HasOne("CorrespondenceEF.Domain.Contractor", "RecievingContractor")
                        .WithMany()
                        .HasForeignKey("RecievingContractorId");

                    b.HasOne("CorrespondenceEF.Domain.Address", "SendingAddress")
                        .WithMany()
                        .HasForeignKey("SendingAddressId");

                    b.HasOne("CorrespondenceEF.Domain.Contractor", "SendingContractor")
                        .WithMany()
                        .HasForeignKey("SendingContractorId");

                    b.HasOne("CorrespondenceEF.Domain.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });
#pragma warning restore 612, 618
        }
    }
}
