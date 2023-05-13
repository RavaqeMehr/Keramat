﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230513175356_addServicesEntities")]
    partial class addServicesEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Entities.AppSettings.AppSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Val")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppSettings");
                });

            modelBuilder.Entity("Entities.AppUsingLogs.AppSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DurationSeconds")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("EndDateD")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EndDateM")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EndDateY")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("StartDateD")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StartDateM")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StartDateY")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("AppSessions");
                });

            modelBuilder.Entity("Entities.AppUsingLogs.EntityChanges", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppSessionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChangeType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Changes")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("DateD")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DateM")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DateY")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EnitityType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EntityId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Root1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Root2Id")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Root3Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AppSessionId");

                    b.ToTable("EntityChanges");
                });

            modelBuilder.Entity("Entities.Kheyrat.Kheyr", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CashAndNotCashValues")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CashDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CashValue")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("DateD")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DateM")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DateY")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasCash")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasNotCash")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NikooKarId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NotCashDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NotCashValue")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("NikooKarId");

                    b.ToTable("Kheyrs");
                });

            modelBuilder.Entity("Entities.Kheyrat.NikooKar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("AddDateD")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddDateM")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddDateY")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("JobAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("JobPhone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("KheyratCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("NikooKars");
                });

            modelBuilder.Entity("Entities.Services.ServiceProvided", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("DateD")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DateM")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DateY")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ServiceSubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ServiceSubjectId");

                    b.ToTable("ServiceProvideds");
                });

            modelBuilder.Entity("Entities.Services.ServiceReciver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FamilyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServiceProvidedId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.HasIndex("ServiceProvidedId");

                    b.ToTable("ServiceRecivers");
                });

            modelBuilder.Entity("Entities.Services.ServiceSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ServiceSubjects");
                });

            modelBuilder.Entity("Entities.ValiNematan.Connector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Connectors");
                });

            modelBuilder.Entity("Entities.ValiNematan.Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("AddDateD")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddDateM")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddDateY")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ConnectorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContactPersonDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactPersonName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactPersonPhone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Finished")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LevelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ConnectorId");

                    b.HasIndex("LevelId");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("Entities.ValiNematan.FamilyLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FamilyLevels");
                });

            modelBuilder.Entity("Entities.ValiNematan.FamilyMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("BirthDateD")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BirthDateM")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BirthDateY")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DeathDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DeathDateD")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DeathDateM")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DeathDateY")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FamilyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FamilyMemberRelationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FathersName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImpreciseBirthDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImpreciseDeathDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("JobAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("JobPhone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LiveStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.HasIndex("FamilyMemberRelationId");

                    b.ToTable("FamilyMembers");
                });

            modelBuilder.Entity("Entities.ValiNematan.FamilyMemberNeed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("FamilyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FamilyMemberId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FamilyMemberNeedSubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.HasIndex("FamilyMemberId");

                    b.HasIndex("FamilyMemberNeedSubjectId");

                    b.ToTable("FamilyMemberNeeds");
                });

            modelBuilder.Entity("Entities.ValiNematan.FamilyMemberNeedSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FamilyMemberNeedSubjects");
                });

            modelBuilder.Entity("Entities.ValiNematan.FamilyMemberRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FamilyMemberRelations");
                });

            modelBuilder.Entity("Entities.ValiNematan.FamilyMemberSpecialDisease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("FamilyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FamilyMemberId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FamilyMemberSpecialDiseaseSubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.HasIndex("FamilyMemberId");

                    b.HasIndex("FamilyMemberSpecialDiseaseSubjectId");

                    b.ToTable("FamilyMemberSpecialDiseases");
                });

            modelBuilder.Entity("Entities.ValiNematan.FamilyMemberSpecialDiseaseSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FamilyMemberSpecialDiseaseSubjects");
                });

            modelBuilder.Entity("Entities.ValiNematan.FamilyNeed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("FamilyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FamilyNeedSubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.HasIndex("FamilyNeedSubjectId");

                    b.ToTable("FamilyNeeds");
                });

            modelBuilder.Entity("Entities.ValiNematan.FamilyNeedSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FamilyNeedSubjects");
                });

            modelBuilder.Entity("Entities.AppUsingLogs.EntityChanges", b =>
                {
                    b.HasOne("Entities.AppUsingLogs.AppSession", "AppSession")
                        .WithMany("ChangesList")
                        .HasForeignKey("AppSessionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AppSession");
                });

            modelBuilder.Entity("Entities.Kheyrat.Kheyr", b =>
                {
                    b.HasOne("Entities.Kheyrat.NikooKar", "NikooKar")
                        .WithMany("Kheyrat")
                        .HasForeignKey("NikooKarId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("NikooKar");
                });

            modelBuilder.Entity("Entities.Services.ServiceProvided", b =>
                {
                    b.HasOne("Entities.Services.ServiceSubject", "ServiceSubject")
                        .WithMany()
                        .HasForeignKey("ServiceSubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ServiceSubject");
                });

            modelBuilder.Entity("Entities.Services.ServiceReciver", b =>
                {
                    b.HasOne("Entities.ValiNematan.Family", "Family")
                        .WithMany()
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Services.ServiceProvided", "ServiceProvided")
                        .WithMany("Recivers")
                        .HasForeignKey("ServiceProvidedId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Family");

                    b.Navigation("ServiceProvided");
                });

            modelBuilder.Entity("Entities.ValiNematan.Family", b =>
                {
                    b.HasOne("Entities.ValiNematan.Connector", "Connector")
                        .WithMany("Families")
                        .HasForeignKey("ConnectorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.ValiNematan.FamilyLevel", "Level")
                        .WithMany()
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Connector");

                    b.Navigation("Level");
                });

            modelBuilder.Entity("Entities.ValiNematan.FamilyMember", b =>
                {
                    b.HasOne("Entities.ValiNematan.Family", "Family")
                        .WithMany("Members")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.ValiNematan.FamilyMemberRelation", "FamilyMemberRelation")
                        .WithMany()
                        .HasForeignKey("FamilyMemberRelationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Family");

                    b.Navigation("FamilyMemberRelation");
                });

            modelBuilder.Entity("Entities.ValiNematan.FamilyMemberNeed", b =>
                {
                    b.HasOne("Entities.ValiNematan.Family", "Family")
                        .WithMany()
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.ValiNematan.FamilyMember", "FamilyMember")
                        .WithMany("Needs")
                        .HasForeignKey("FamilyMemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.ValiNematan.FamilyMemberNeedSubject", "FamilyMemberNeedSubject")
                        .WithMany()
                        .HasForeignKey("FamilyMemberNeedSubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Family");

                    b.Navigation("FamilyMember");

                    b.Navigation("FamilyMemberNeedSubject");
                });

            modelBuilder.Entity("Entities.ValiNematan.FamilyMemberSpecialDisease", b =>
                {
                    b.HasOne("Entities.ValiNematan.Family", "Family")
                        .WithMany()
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.ValiNematan.FamilyMember", "FamilyMember")
                        .WithMany("SpecialDiseases")
                        .HasForeignKey("FamilyMemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.ValiNematan.FamilyMemberSpecialDiseaseSubject", "FamilyMemberSpecialDiseaseSubject")
                        .WithMany()
                        .HasForeignKey("FamilyMemberSpecialDiseaseSubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Family");

                    b.Navigation("FamilyMember");

                    b.Navigation("FamilyMemberSpecialDiseaseSubject");
                });

            modelBuilder.Entity("Entities.ValiNematan.FamilyNeed", b =>
                {
                    b.HasOne("Entities.ValiNematan.Family", "Family")
                        .WithMany("Needs")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.ValiNematan.FamilyNeedSubject", "FamilyNeedSubject")
                        .WithMany()
                        .HasForeignKey("FamilyNeedSubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Family");

                    b.Navigation("FamilyNeedSubject");
                });

            modelBuilder.Entity("Entities.AppUsingLogs.AppSession", b =>
                {
                    b.Navigation("ChangesList");
                });

            modelBuilder.Entity("Entities.Kheyrat.NikooKar", b =>
                {
                    b.Navigation("Kheyrat");
                });

            modelBuilder.Entity("Entities.Services.ServiceProvided", b =>
                {
                    b.Navigation("Recivers");
                });

            modelBuilder.Entity("Entities.ValiNematan.Connector", b =>
                {
                    b.Navigation("Families");
                });

            modelBuilder.Entity("Entities.ValiNematan.Family", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Needs");
                });

            modelBuilder.Entity("Entities.ValiNematan.FamilyMember", b =>
                {
                    b.Navigation("Needs");

                    b.Navigation("SpecialDiseases");
                });
#pragma warning restore 612, 618
        }
    }
}
