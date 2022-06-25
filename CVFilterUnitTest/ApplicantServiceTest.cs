using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using Moq;
using MediatR;
using CVFilter.Application.Dto;
using System.Threading.Tasks;
using CVFilter.Application.Concrete;
using CVFilter.Domain.Core.ServiceResponse;
using CVFilter.Infrastructure.Command.Request;
using CVFilter.Infrastructure.Command.Response;
using CVFilter.Infrastructure.Query.Request;
using CVFilter.Infrastructure.Query.Response;

namespace CVFilterUnitTest
{
    [TestFixture]
    class ApplicantServiceTest
    {
        [TestCase("asdf", "ss")]
        public async Task CreateApplicantTest_ReturnsTrue(string path,string matches)
        {
            var serviceResponse = new ServiceResponse<CreateApplicantCommandResponse>(201,true);
            CreateApplicantCommandRequestDto request = new CreateApplicantCommandRequestDto
            {
               Path = path,
               Matches = matches
            };
            var fakeMediator = new Mock<IMediator>();
            fakeMediator.Setup(x => x.Send(It.IsAny<CreateApplicantCommandRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new CreateApplicantCommandResponse());
            var applicantService = new ApplicantService(fakeMediator.Object);
            var data = await applicantService.CreateAsync(request);
            Assert.AreEqual(serviceResponse.HttpResponse, data.HttpResponse
                );
        }

        [TestCase("ss", "")]
        [TestCase("", "ss")]
        public async Task CreateApplicantTest_ReturnsFalse(string path, string matches)
        {
            var serviceResponse = new ServiceResponse<CreateApplicantCommandResponse>(400, false);
            CreateApplicantCommandRequestDto request = new CreateApplicantCommandRequestDto
            {
                Path = path,
                Matches = matches
            };
            var fakeMediator = new Mock<IMediator>();
            fakeMediator.Setup(x => x.Send(It.IsAny<CreateApplicantCommandRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new CreateApplicantCommandResponse { ErrorMessage = "Create Applicant model is not valid" });
            var applicantService = new ApplicantService(fakeMediator.Object);
            var data = await applicantService.CreateAsync(request);
            Assert.AreEqual(serviceResponse.HttpResponse, data.HttpResponse);
        }

        [TestCase(1)]
        public async Task DeleteApplicantTest_ReturnsTrue(int id)
        {
            var serviceResponse = new ServiceResponse<DeleteApplicantCommandResponse>(500,false);
            DeleteApplicantCommandRequestDto request = new DeleteApplicantCommandRequestDto
            {
                Id = id,
            };
            var fakeMediator = new Mock<IMediator>();
            fakeMediator.Setup(x => x.Send(It.IsAny<DeleteApplicantCommandRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new DeleteApplicantCommandResponse());
            var applicantService = new ApplicantService(fakeMediator.Object);
            var data = await applicantService.DeleteAsync(request);
            Assert.AreEqual(serviceResponse.HttpResponse, data.HttpResponse);
        }

        [TestCase(0)]
        public async Task DeleteApplicantTest_ReturnsFalse(int id)
        {
            var serviceResponse = new ServiceResponse<DeleteApplicantCommandResponse>(400, false);
            DeleteApplicantCommandRequestDto request = new DeleteApplicantCommandRequestDto
            {
                Id = id,
            };
            var fakeMediator = new Mock<IMediator>();
            fakeMediator.Setup(x => x.Send(It.IsAny<DeleteApplicantCommandRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new DeleteApplicantCommandResponse());
            var applicantService = new ApplicantService(fakeMediator.Object);
            var data = await applicantService.DeleteAsync(request);
            Assert.AreEqual(serviceResponse.HttpResponse, data.HttpResponse);
        }

        [TestCase(1)]
        public async Task GetApplicantTest_ReturnsTrue(int id)
        {
            var serviceResponse = new ServiceResponse<GetApplicantQueryResponse>(200, false);
            GetApplicantQueryRequestDto request = new GetApplicantQueryRequestDto
            {
                Id = id,
            };
            var fakeMediator = new Mock<IMediator>();
            fakeMediator.Setup(x => x.Send(It.IsAny<GetApplicantQueryRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetApplicantQueryResponse());
            var applicantService = new ApplicantService(fakeMediator.Object);
            var data = await applicantService.GetAsync(request);
            Assert.AreEqual(serviceResponse.HttpResponse, data.HttpResponse);
        }

        [TestCase(0)]
        public async Task GetApplicantTest_ReturnsFalse(int id)
        {
            var serviceResponse = new ServiceResponse<GetApplicantQueryResponse>(400, false);
            GetApplicantQueryRequestDto request = new GetApplicantQueryRequestDto
            {
                Id = id,
            };
            var fakeMediator = new Mock<IMediator>();
            fakeMediator.Setup(x => x.Send(It.IsAny<GetApplicantQueryRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetApplicantQueryResponse());
            var applicantService = new ApplicantService(fakeMediator.Object);
            var data = await applicantService.GetAsync(request);
            Assert.AreEqual(serviceResponse.HttpResponse, data.HttpResponse);
        }

        [TestCase(1,"sadg","sadg","asd")]
        public async Task UpdateApplicantTest_ReturnsTrue(int id, string matches, string name, string path)
        {
            var serviceResponse = new ServiceResponse<GetApplicantQueryResponse>(200, false);
            UpdateApplicantCommandRequestDto request = new UpdateApplicantCommandRequestDto
            {
                Id = id,
                Matches = matches,
                Name = name,
                Path = path
            };
            var fakeMediator = new Mock<IMediator>();
            fakeMediator.Setup(x => x.Send(It.IsAny<UpdateApplicantCommandRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new UpdateApplicantCommandResponse());
            var applicantService = new ApplicantService(fakeMediator.Object);
            var data = await applicantService.UpdateAsync(request);
            Assert.AreEqual(serviceResponse.HttpResponse, data.HttpResponse);
        }

        [TestCase(1, "", "sadg", "asd")]
        public async Task UpdateApplicantTest_ReturnsFalse(int id, string matches, string name, string path)
        {
            var serviceResponse = new ServiceResponse<GetApplicantQueryResponse>(400, false);
            UpdateApplicantCommandRequestDto request = new UpdateApplicantCommandRequestDto
            {
                Id = id,
                Matches = matches,
                Name = name,
                Path = path
            };
            var fakeMediator = new Mock<IMediator>();
            fakeMediator.Setup(x => x.Send(It.IsAny<UpdateApplicantCommandRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new UpdateApplicantCommandResponse());
            var applicantService = new ApplicantService(fakeMediator.Object);
            var data = await applicantService.UpdateAsync(request);
            Assert.AreEqual(serviceResponse.HttpResponse, data.HttpResponse);
        }
    }
}
