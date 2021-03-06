﻿// <auto-generated />
using System;
using EntityFrameworkCodeFirst1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkCodeFirst1.Migrations
{
    [DbContext(typeof(TvShowsContext))]
    [Migration("20210304080556_favoritos")]
    partial class favoritos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityFrameworkCodeFirst1.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("URL");

                    b.Property<bool>("favoritos");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("EntityFrameworkCodeFirst1.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<int>("IdBlog");

                    b.Property<int?>("blogId");

                    b.HasKey("Id");

                    b.HasIndex("blogId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("EntityFrameworkCodeFirst1.Models.Post", b =>
                {
                    b.HasOne("EntityFrameworkCodeFirst1.Models.Blog", "blog")
                        .WithMany("Post")
                        .HasForeignKey("blogId");
                });
#pragma warning restore 612, 618
        }
    }
}
