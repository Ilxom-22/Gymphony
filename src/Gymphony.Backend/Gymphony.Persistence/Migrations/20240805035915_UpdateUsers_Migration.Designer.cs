﻿// <auto-generated />
using System;
using Gymphony.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gymphony.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240805035915_UpdateUsers_Migration")]
    partial class UpdateUsers_Migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CourseScheduleStaff", b =>
                {
                    b.Property<Guid>("CourseSchedulesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("InstructorsId")
                        .HasColumnType("uuid");

                    b.HasKey("CourseSchedulesId", "InstructorsId");

                    b.HasIndex("InstructorsId");

                    b.ToTable("CourseScheduleStaff");
                });

            modelBuilder.Entity("CourseStaff", b =>
                {
                    b.Property<Guid>("CoursesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("InstructorsId")
                        .HasColumnType("uuid");

                    b.HasKey("CoursesId", "InstructorsId");

                    b.HasIndex("InstructorsId");

                    b.ToTable("CourseStaff");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.AccessToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("ExpiryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasIndex("Token")
                        .IsUnique();

                    b.ToTable("AccessTokens");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.CourseImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StorageFileId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StorageFileId")
                        .IsUnique();

                    b.ToTable("CourseImages");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.CourseSchedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreatedByUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Day")
                        .HasColumnType("integer");

                    b.Property<Guid?>("DeletedByUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedByUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("ModifiedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("DeletedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("CourseSchedules");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.CourseScheduleEnrollment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CourseScheduleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CourseSubscriptionId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateOnly>("EnrollmentDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("ExpiryDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CourseScheduleId");

                    b.HasIndex("CourseSubscriptionId");

                    b.HasIndex("MemberId");

                    b.ToTable("CourseScheduleEnrollments");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.NotificationHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ErrorMessage")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("ModifiedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("NotificationMethod")
                        .HasColumnType("integer");

                    b.Property<Guid>("RecipientId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("SentTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("TemplateId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.ToTable("NotificationHistories");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.NotificationTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("NotificationTemplates");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.PendingScheduleEnrollment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CourseScheduleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uuid");

                    b.Property<string>("StripeSessionId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("CourseScheduleId");

                    b.HasIndex("MemberId");

                    b.ToTable("PendingScheduleEnrollments");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly?>("ActivationDate")
                        .HasColumnType("date");

                    b.Property<Guid?>("CreatedByUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateOnly?>("DeactivationDate")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<int>("DurationCount")
                        .HasColumnType("integer");

                    b.Property<int>("DurationUnit")
                        .HasColumnType("integer");

                    b.Property<Guid?>("ModifiedByUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("ModifiedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Products");

                    b.HasDiscriminator<int>("Type");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("ExpiryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasIndex("Token")
                        .IsUnique();

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.StorageFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("StorageFiles");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.Subscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("LastSubscriptionPeriodId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uuid");

                    b.Property<string>("StripeSubscriptionId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LastSubscriptionPeriodId")
                        .IsUnique();

                    b.HasIndex("MemberId");

                    b.ToTable("Subscriptions");

                    b.HasDiscriminator<int>("Type");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.SubscriptionPeriod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("ExpiryDate")
                        .HasColumnType("date");

                    b.Property<Guid>("PaymentId")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<Guid>("SubscriptionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId")
                        .IsUnique();

                    b.HasIndex("SubscriptionId");

                    b.ToTable("SubscriptionPeriods");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AuthDataHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("AuthenticationProvider")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<DateTimeOffset?>("ModifiedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasDiscriminator<int>("Role");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.UserProfileImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("StorageFileId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StorageFileId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserProfileImages");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.VerificationToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("ExpiryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Token")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("VerificationTokens");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.Course", b =>
                {
                    b.HasBaseType("Gymphony.Domain.Entities.Product");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<int>("EnrollmentsCountPerWeek")
                        .HasColumnType("integer");

                    b.Property<int>("SessionDurationInMinutes")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.MembershipPlan", b =>
                {
                    b.HasBaseType("Gymphony.Domain.Entities.Product");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.CourseSubscription", b =>
                {
                    b.HasBaseType("Gymphony.Domain.Entities.Subscription");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uuid");

                    b.HasIndex("CourseId");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.MembershipPlanSubscription", b =>
                {
                    b.HasBaseType("Gymphony.Domain.Entities.Subscription");

                    b.Property<Guid>("MembershipPlanId")
                        .HasColumnType("uuid");

                    b.HasIndex("MembershipPlanId");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.Admin", b =>
                {
                    b.HasBaseType("Gymphony.Domain.Entities.User");

                    b.Property<Guid?>("CreatedByUserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("TemporaryPasswordChanged")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("boolean")
                        .HasColumnName("TemporaryPasswordChanged");

                    b.HasIndex("CreatedByUserId");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.Member", b =>
                {
                    b.HasBaseType("Gymphony.Domain.Entities.User");

                    b.Property<DateTimeOffset?>("BirthDay")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("StripeCustomerId")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.Staff", b =>
                {
                    b.HasBaseType("Gymphony.Domain.Entities.User");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<bool>("TemporaryPasswordChanged")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("boolean")
                        .HasColumnName("TemporaryPasswordChanged");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("CourseScheduleStaff", b =>
                {
                    b.HasOne("Gymphony.Domain.Entities.CourseSchedule", null)
                        .WithMany()
                        .HasForeignKey("CourseSchedulesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gymphony.Domain.Entities.Staff", null)
                        .WithMany()
                        .HasForeignKey("InstructorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseStaff", b =>
                {
                    b.HasOne("Gymphony.Domain.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gymphony.Domain.Entities.Staff", null)
                        .WithMany()
                        .HasForeignKey("InstructorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.AccessToken", b =>
                {
                    b.HasOne("Gymphony.Domain.Entities.User", "User")
                        .WithOne("AccessToken")
                        .HasForeignKey("Gymphony.Domain.Entities.AccessToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.CourseImage", b =>
                {
                    b.HasOne("Gymphony.Domain.Entities.Course", "Course")
                        .WithMany("CourseImages")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gymphony.Domain.Entities.StorageFile", "StorageFile")
                        .WithOne()
                        .HasForeignKey("Gymphony.Domain.Entities.CourseImage", "StorageFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("StorageFile");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.CourseSchedule", b =>
                {
                    b.HasOne("Gymphony.Domain.Entities.Course", "Course")
                        .WithMany("Schedules")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gymphony.Domain.Entities.Admin", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Gymphony.Domain.Entities.Admin", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedByUserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Gymphony.Domain.Entities.Admin", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Course");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.CourseScheduleEnrollment", b =>
                {
                    b.HasOne("Gymphony.Domain.Entities.CourseSchedule", "CourseSchedule")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gymphony.Domain.Entities.CourseSubscription", "CourseSubscription")
                        .WithMany()
                        .HasForeignKey("CourseSubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gymphony.Domain.Entities.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseSchedule");

                    b.Navigation("CourseSubscription");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.NotificationHistory", b =>
                {
                    b.HasOne("Gymphony.Domain.Entities.NotificationTemplate", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Template");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.Payment", b =>
                {
                    b.HasOne("Gymphony.Domain.Entities.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.PendingScheduleEnrollment", b =>
                {
                    b.HasOne("Gymphony.Domain.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gymphony.Domain.Entities.CourseSchedule", "CourseSchedule")
                        .WithMany("PendingEnrollments")
                        .HasForeignKey("CourseScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gymphony.Domain.Entities.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("CourseSchedule");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.Product", b =>
                {
                    b.HasOne("Gymphony.Domain.Entities.Admin", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Gymphony.Domain.Entities.Admin", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.OwnsOne("Gymphony.Domain.Entities.StripeDetails", "StripeDetails", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.Property<string>("PriceId")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("StripePriceId");

                            b1.Property<string>("ProductId")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("StripeProductId");

                            b1.HasKey("Id");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("Id");
                        });

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("StripeDetails");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Gymphony.Domain.Entities.User", "User")
                        .WithOne("RefreshToken")
                        .HasForeignKey("Gymphony.Domain.Entities.RefreshToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.Subscription", b =>
                {
                    b.HasOne("Gymphony.Domain.Entities.SubscriptionPeriod", "LastSubscriptionPeriod")
                        .WithOne()
                        .HasForeignKey("Gymphony.Domain.Entities.Subscription", "LastSubscriptionPeriodId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Gymphony.Domain.Entities.Member", "Member")
                        .WithMany("Subscriptions")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LastSubscriptionPeriod");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.SubscriptionPeriod", b =>
                {
                    b.HasOne("Gymphony.Domain.Entities.Payment", "Payment")
                        .WithOne("SubscriptionPeriod")
                        .HasForeignKey("Gymphony.Domain.Entities.SubscriptionPeriod", "PaymentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Gymphony.Domain.Entities.Subscription", "Subscription")
                        .WithMany("SubscriptionPeriods")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payment");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.UserProfileImage", b =>
                {
                    b.HasOne("Gymphony.Domain.Entities.StorageFile", "StorageFile")
                        .WithOne()
                        .HasForeignKey("Gymphony.Domain.Entities.UserProfileImage", "StorageFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gymphony.Domain.Entities.User", "User")
                        .WithOne("ProfileImage")
                        .HasForeignKey("Gymphony.Domain.Entities.UserProfileImage", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StorageFile");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.VerificationToken", b =>
                {
                    b.HasOne("Gymphony.Domain.Entities.User", "User")
                        .WithOne("VerificationToken")
                        .HasForeignKey("Gymphony.Domain.Entities.VerificationToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.CourseSubscription", b =>
                {
                    b.HasOne("Gymphony.Domain.Entities.Course", "Course")
                        .WithMany("Subscriptions")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.MembershipPlanSubscription", b =>
                {
                    b.HasOne("Gymphony.Domain.Entities.MembershipPlan", "MembershipPlan")
                        .WithMany("Subscriptions")
                        .HasForeignKey("MembershipPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MembershipPlan");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.Admin", b =>
                {
                    b.HasOne("Gymphony.Domain.Entities.Admin", null)
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.CourseSchedule", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("PendingEnrollments");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.Payment", b =>
                {
                    b.Navigation("SubscriptionPeriod");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.Subscription", b =>
                {
                    b.Navigation("SubscriptionPeriods");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.User", b =>
                {
                    b.Navigation("AccessToken");

                    b.Navigation("ProfileImage");

                    b.Navigation("RefreshToken");

                    b.Navigation("VerificationToken");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.Course", b =>
                {
                    b.Navigation("CourseImages");

                    b.Navigation("Schedules");

                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.MembershipPlan", b =>
                {
                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("Gymphony.Domain.Entities.Member", b =>
                {
                    b.Navigation("Subscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
