using System;
using System.Threading;
using System.Threading.Tasks;
using CVFilter.Application.Concrete;
using CVFilter.Application.Dto;
using CVFilter.Domain.Core.ServiceResponse;
using NUnit.Framework;
using Moq;
using MediatR;
namespace CVFilterUnitTest
{
    [TestFixture]
    class CVFilterTest
    {
        [TestCase("engineer,mühendis",3, "ingilizce,almanca", "C:\\Users\\orhan\\Desktop\\CVFilter", "html,css,javascript")]
        public async Task CVFilterTest_ReturnsTrue(string educationMatches, int experience, string languageMatches, string path, string requiredMatches )
        {
            var serviceResponse = new ServiceResponse<string>(500,false);
            var cvFilterTest = new CVWorkerRequestDto
            {
                Experience = experience,
                LanguageMatches = languageMatches,
                Path = path,
                RequiredMatches = requiredMatches,
                EducationMatches = educationMatches
            };

            var fakeMediator = new Mock<IMediator>();
            fakeMediator.Setup(x => x.Send(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync("");
            var cvService = new CVService(fakeMediator.Object);
            var data = await cvService.CVWorkerAsync(cvFilterTest);
            Assert.AreEqual(serviceResponse.HttpResponse, data.HttpResponse);
        }

        [TestCase("", 3, "", "C:\\Users\\orhan\\Desktop\\CVFilter", "html,css,javascript")]
        public async Task CVFilterTest_ReturnsFalse(string educationMatches, int experience, string languageMatches, string path, string requiredMatches)
        {
            var serviceResponse = new ServiceResponse<string>(400, false);
            var cvFilterTest = new CVWorkerRequestDto
            {
                Experience = experience,
                LanguageMatches = languageMatches,
                Path = path,
                RequiredMatches = requiredMatches,
                EducationMatches = educationMatches
            };

            var fakeMediator = new Mock<IMediator>();
            fakeMediator.Setup(x => x.Send(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync("");
            var cvService = new CVService(fakeMediator.Object);
            var data = await cvService.CVWorkerAsync(cvFilterTest);
            Assert.AreEqual(serviceResponse.HttpResponse, data.HttpResponse);
        }
    }
}
