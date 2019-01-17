using NSubstitute;
using System.Threading;
using System.Threading.Tasks;
using Tot.Command.Commands;
using Tot.Core.Interfaces;
using Tot.Core.Repository;
using Xunit;

namespace Tot.Command.Test
{
    public class CreateFeedbackCommandHandlerTest
    {
        private readonly IFeedbackWriteOnlyRepository _feedbackWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CreateFeedbackCommandHandler _handler;
        public CreateFeedbackCommandHandlerTest()
        {
            _feedbackWriteOnlyRepository = Substitute.For<IFeedbackWriteOnlyRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _handler = Substitute.For<CreateFeedbackCommandHandler>(_feedbackWriteOnlyRepository, _unitOfWork);
        }

        [Fact]
        [Trait("Feedback", nameof(CreateFeedbackCommandHandler))]
        public async Task Return_Success_Result()
        {
            var command = CreateFeedbackCommand();

            _unitOfWork.Commit().Returns(true);

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.True(result.Success);
        }

        [Fact]
        [Trait("Feedback", nameof(CreateFeedbackCommandHandler))]
        public async Task Return_Failure_Result()
        {
            var command = CreateFeedbackCommand();

            _unitOfWork.Commit().Returns(false);

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.False(result.Success);
        }

        private CreateFeedbackCommand CreateFeedbackCommand()
        {
            return new CreateFeedbackCommand(new string('T', 280), 1);
        }
    }
}
