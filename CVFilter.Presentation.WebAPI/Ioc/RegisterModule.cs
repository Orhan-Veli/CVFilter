using Autofac;
using CVFilter.Application.Abstract;
using CVFilter.Application.Concrete;
using CVFilter.Application.Dto;
using CVFilter.Presentation.WebAPI.Validation;
using FluentValidation;

namespace CVFilter.Presentation.WebAPI.Ioc
{
    public class RegisterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicantService>().As<IApplicantService>().SingleInstance();
            builder.RegisterType<CreateApplicantCommandRequestDtoValidation>().As<IValidator<CreateApplicantCommandRequestDto>>().InstancePerDependency();
            builder.RegisterType<CVWorkerRequestDtoValidation>().As<IValidator<CVWorkerRequestDto>>().InstancePerDependency();
            builder.RegisterType<DeleteApplicantCommandRequestDtoValidation>().As<IValidator<DeleteApplicantCommandRequestDto>>().InstancePerDependency();
            builder.RegisterType<GetAllApplicantQueryRequestDtoValidation>().As<IValidator<GetAllApplicantQueryRequestDto>>().InstancePerDependency();
            builder.RegisterType<GetApplicantQueryRequestDtoValidation>().As<IValidator<GetApplicantQueryRequestDto>>().InstancePerDependency();
            builder.RegisterType<UpdateApplicantCommandRequestDtoValidation>().As<IValidator<UpdateApplicantCommandRequestDto>>().InstancePerDependency();
            //base.Load(builder);
        }
    }
}
