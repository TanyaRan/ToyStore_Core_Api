﻿// <auto-generated />
namespace ToyStore.Data.Migrations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    [DbContext(typeof(ToyStoreDbContext))]
    [Migration("20180131081802_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToyStore.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ToyStore.Data.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Email")
                        .HasMaxLength(150);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("ToyStore.Data.Models.Toy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Count");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000);

                    b.Property<int>("ManufacturerId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Toys");
                });

            modelBuilder.Entity("ToyStore.Data.Models.ToyCategory", b =>
                {
                    b.Property<int>("ToyId");

                    b.Property<int>("CategoryId");

                    b.HasKey("ToyId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ToyCategories");
                });

            modelBuilder.Entity("ToyStore.Data.Models.Toy", b =>
                {
                    b.HasOne("ToyStore.Data.Models.Manufacturer", "Manufacturer")
                        .WithMany("Toys")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ToyStore.Data.Models.ToyCategory", b =>
                {
                    b.HasOne("ToyStore.Data.Models.Category", "Category")
                        .WithMany("Toys")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ToyStore.Data.Models.Toy", "Toy")
                        .WithMany("Categories")
                        .HasForeignKey("ToyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
