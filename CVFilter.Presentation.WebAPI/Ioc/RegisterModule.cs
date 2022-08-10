using Autofac;
using CVFilter.Application.Abstract;
using CVFilter.Application.Concrete;
using CVFilter.Application.Dto;
using CVFilter.Domain.Cross_Cutting_Concerns;
using CVFilter.Presentation.WebAPI.Validation;
using FluentValidation;
using CVFilter.Infrastructure.UnitOfWork;
using CVFilter.Infrastructure.UnitOfWork.Base;
using CVFilter.Infrastructure.EntityRepository;
using CVFilter.Infrastructure.EntityRepository.Base;
using CVFilter.Domain.Entities;

namespace CVFilter.Presentation.WebAPI.Ioc
{
    public class RegisterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicantService>().As<IApplicantService>().SingleInstance();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
            builder.RegisterType<EntityRepository<Applicant>>().As<IEntityRepository<Applicant>>().SingleInstance();
            builder.RegisterType<EntityRepository<ApplicantEducationRelation>>().As<IEntityRepository<ApplicantEducationRelation>>().SingleInstance();
            builder.RegisterType<EntityRepository<ApplicantLanguageRelation>>().As<IEntityRepository<ApplicantLanguageRelation>>().SingleInstance();
            builder.RegisterType<EntityRepository<Log>>().As<IEntityRepository<Log>>().SingleInstance();
            builder.RegisterType<CVService>().As<ICVService>().SingleInstance();
            builder.RegisterType<CreateApplicantCommandRequestDtoValidation>().As<IValidator<CreateApplicantCommandRequestDto>>().InstancePerDependency();
            builder.RegisterType<CVWorkerRequestDtoValidation>().As<IValidator<CVWorkerRequestDto>>().InstancePerDependency();
            builder.RegisterType<DeleteApplicantCommandRequestDtoValidation>().As<IValidator<DeleteApplicantCommandRequestDto>>().InstancePerDependency();
            builder.RegisterType<GetAllApplicantQueryRequestDtoValidation>().As<IValidator<GetAllApplicantQueryRequestDto>>().InstancePerDependency();
            builder.RegisterType<GetApplicantQueryRequestDtoValidation>().As<IValidator<GetApplicantQueryRequestDto>>().InstancePerDependency();
            builder.RegisterType<UpdateApplicantCommandRequestDtoValidation>().As<IValidator<UpdateApplicantCommandRequestDto>>().InstancePerDependency();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
            builder.RegisterType<MemoryCache>().SingleInstance();
            //base.Load(builder);
        }
    }
}
