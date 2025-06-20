﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wisteria.Domain.Entities;

#nullable disable

namespace Wisteria.Migrations
{
    [DbContext(typeof(UserBase))]
    [Migration("20250526093347_ChangedPasswordLength")]
    partial class ChangedPasswordLength
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CommunitiesUser", b =>
                {
                    b.Property<int>("CommunitiesCommunity_Id")
                        .HasColumnType("int");

                    b.Property<int>("Community_MembersUser_ID")
                        .HasColumnType("int");

                    b.HasKey("CommunitiesCommunity_Id", "Community_MembersUser_ID");

                    b.HasIndex("Community_MembersUser_ID");

                    b.ToTable("CommunitiesUser");
                });

            modelBuilder.Entity("GroupChatUser", b =>
                {
                    b.Property<int>("groupChatsGroupChatID")
                        .HasColumnType("int");

                    b.Property<int>("usersUser_ID")
                        .HasColumnType("int");

                    b.HasKey("groupChatsGroupChatID", "usersUser_ID");

                    b.HasIndex("usersUser_ID");

                    b.ToTable("GroupChatUser");
                });

            modelBuilder.Entity("Wisteria.Domain.Entities.Chat", b =>
                {
                    b.Property<int>("Text_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Text_ID"));

                    b.Property<int?>("GroupChatID")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Text_ID");

                    b.HasIndex("GroupChatID");

                    b.ToTable("Chat");
                });

            modelBuilder.Entity("Wisteria.Domain.Entities.Comments", b =>
                {
                    b.Property<int>("comment_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("comment_Id"));

                    b.Property<int?>("PostsPost_ID")
                        .HasColumnType("int");

                    b.Property<int?>("User_ID")
                        .HasColumnType("int");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("comment_Id");

                    b.HasIndex("PostsPost_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Wisteria.Domain.Entities.Communities", b =>
                {
                    b.Property<int>("Community_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Community_Id"));

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Community_Id");

                    b.ToTable("Communities");
                });

            modelBuilder.Entity("Wisteria.Domain.Entities.GroupChat", b =>
                {
                    b.Property<int>("GroupChatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupChatID"));

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("GroupChatID");

                    b.ToTable("GroupChat");
                });

            modelBuilder.Entity("Wisteria.Domain.Entities.Notifications", b =>
                {
                    b.Property<int>("Notif_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Notif_ID"));

                    b.Property<int?>("User_ID")
                        .HasColumnType("int");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Notif_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Wisteria.Domain.Entities.Posts", b =>
                {
                    b.Property<int>("Post_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Post_ID"));

                    b.Property<string>("Bio")
                        .HasColumnType("varchar(300)");

                    b.Property<int?>("CommunitiesCommunity_Id")
                        .HasColumnType("int");

                    b.Property<string>("Img")
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Music_Track")
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Url")
                        .HasColumnType("varchar(500)");

                    b.Property<int?>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Post_ID");

                    b.HasIndex("CommunitiesCommunity_Id");

                    b.HasIndex("User_ID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Wisteria.Domain.Entities.User", b =>
                {
                    b.Property<int>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_ID"));

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("User_ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CommunitiesUser", b =>
                {
                    b.HasOne("Wisteria.Domain.Entities.Communities", null)
                        .WithMany()
                        .HasForeignKey("CommunitiesCommunity_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wisteria.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("Community_MembersUser_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupChatUser", b =>
                {
                    b.HasOne("Wisteria.Domain.Entities.GroupChat", null)
                        .WithMany()
                        .HasForeignKey("groupChatsGroupChatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wisteria.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("usersUser_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wisteria.Domain.Entities.Chat", b =>
                {
                    b.HasOne("Wisteria.Domain.Entities.GroupChat", null)
                        .WithMany("chats")
                        .HasForeignKey("GroupChatID");
                });

            modelBuilder.Entity("Wisteria.Domain.Entities.Comments", b =>
                {
                    b.HasOne("Wisteria.Domain.Entities.Posts", null)
                        .WithMany("Comments")
                        .HasForeignKey("PostsPost_ID");

                    b.HasOne("Wisteria.Domain.Entities.User", null)
                        .WithMany("User_Comments")
                        .HasForeignKey("User_ID");
                });

            modelBuilder.Entity("Wisteria.Domain.Entities.Notifications", b =>
                {
                    b.HasOne("Wisteria.Domain.Entities.User", null)
                        .WithMany("Notif")
                        .HasForeignKey("User_ID");
                });

            modelBuilder.Entity("Wisteria.Domain.Entities.Posts", b =>
                {
                    b.HasOne("Wisteria.Domain.Entities.Communities", null)
                        .WithMany("Community_Posts")
                        .HasForeignKey("CommunitiesCommunity_Id");

                    b.HasOne("Wisteria.Domain.Entities.User", null)
                        .WithMany("Posts")
                        .HasForeignKey("User_ID");
                });

            modelBuilder.Entity("Wisteria.Domain.Entities.Communities", b =>
                {
                    b.Navigation("Community_Posts");
                });

            modelBuilder.Entity("Wisteria.Domain.Entities.GroupChat", b =>
                {
                    b.Navigation("chats");
                });

            modelBuilder.Entity("Wisteria.Domain.Entities.Posts", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Wisteria.Domain.Entities.User", b =>
                {
                    b.Navigation("Notif");

                    b.Navigation("Posts");

                    b.Navigation("User_Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
