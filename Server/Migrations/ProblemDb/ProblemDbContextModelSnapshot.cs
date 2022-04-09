﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using codedash.Shared;

#nullable disable

namespace codedash.Server.Migrations.ProblemDb
{
    [DbContext(typeof(ProblemDbContext))]
    partial class ProblemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("codedash.Shared.Problem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Chunks")
                        .HasColumnType("TEXT");

                    b.Property<int>("Difficulty")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsUserMade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Output")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Problem");

                    b.HasData(
                        new
                        {
                            Id = "09bceebe-e9f4-4e2e-8d5e-121f9a32e642",
                            Chunks = "print(\"Hi\")\nprint(0-1\"Hello, World!\"113)0-1",
                            Difficulty = 0,
                            IsUserMade = false,
                            Output = "Hi\nHello, World!",
                            Title = "Sample 0"
                        },
                        new
                        {
                            Id = "f412592f-9669-4f66-99c9-3381710de524",
                            Chunks = "for i in range(6):\n    print(0-1\"ay\"16, end='')\nprint('9')\n\nprint('ay' * 64 + '9')0-1",
                            Difficulty = 0,
                            IsUserMade = false,
                            Output = "ayayayayayay9\nayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayay9",
                            Title = "Sample 1"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
