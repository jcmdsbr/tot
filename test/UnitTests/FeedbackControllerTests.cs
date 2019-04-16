using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tot.Api.Controllers;
using Tot.Infra.Bus;
using Tot.Query.Models;
using Tot.Query.Queries.Feedbacks;

namespace UnitTests
{
    public class FeedbackControllerTests
    {

        [Test]
        public async Task GetAllSucceeds()
        {
            // arrange
            var bus = new Mock<IMediatorHandler>();

            var expectedFeedbacks = new FeedbackListQueryModel(new List<FeedbackViewQueryModel>());
                       
            bus.Setup(x => x.ExecuteQuery(It.IsAny<GetFeedbackListQuery>()))
               .ReturnsAsync(expectedFeedbacks);

            var api = new FeedbackController(bus.Object);

            // act

            var feedbacksRetrieved = await api.List();

            //assert

            feedbacksRetrieved.Count().Should().Be(expectedFeedbacks.Count());
        }

    }
}
