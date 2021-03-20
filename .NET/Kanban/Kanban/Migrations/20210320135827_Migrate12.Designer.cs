﻿// <auto-generated />
using System;
using Kanban.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kanban.Migrations
{
    [DbContext(typeof(KanbanContext))]
    [Migration("20210320135827_Migrate12")]
    partial class Migrate12
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kanban.Models.Column", b =>
                {
                    b.Property<int>("ColumnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("KanbanBoardKanbanId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ColumnId");

                    b.HasIndex("KanbanBoardKanbanId");

                    b.ToTable("Column");
                });

            modelBuilder.Entity("Kanban.Models.KanbanBoard", b =>
                {
                    b.Property<int>("KanbanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KanbanId");

                    b.ToTable("Kanban");
                });

            modelBuilder.Entity("Kanban.Models.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ColumnId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KanbanBoardKanbanId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("NoteId");

                    b.HasIndex("ColumnId");

                    b.HasIndex("KanbanBoardKanbanId");

                    b.HasIndex("PersonId");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("Kanban.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nick")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Kanban.Models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("emailAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Kanban.Models.Column", b =>
                {
                    b.HasOne("Kanban.Models.KanbanBoard", null)
                        .WithMany("Columns")
                        .HasForeignKey("KanbanBoardKanbanId");
                });

            modelBuilder.Entity("Kanban.Models.Note", b =>
                {
                    b.HasOne("Kanban.Models.Column", null)
                        .WithMany("Notes")
                        .HasForeignKey("ColumnId");

                    b.HasOne("Kanban.Models.KanbanBoard", null)
                        .WithMany("Notes")
                        .HasForeignKey("KanbanBoardKanbanId");

                    b.HasOne("Kanban.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
