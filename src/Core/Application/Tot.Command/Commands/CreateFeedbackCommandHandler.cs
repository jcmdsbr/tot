using System.Threading;
using System.Threading.Tasks;
using Tot.Shared;
using Tot.Shared.Models;
using Tot.Shared.Repositories;

namespace Tot.Command.Commands
{
    public class CreateFeedbackCommandHandler : ICommandHandler<CreateFeedbackCommand, CreateFeedbackCommandResult>
    {
        private readonly IFeedbackWriteOnlyRepository _feedbackWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateFeedbackCommandHandler(IFeedbackWriteOnlyRepository feedbackWriteOnlyRepository,
            IUnitOfWork unitOfWork)
        {
            _feedbackWriteOnlyRepository = feedbackWriteOnlyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateFeedbackCommandResult> Handle(CreateFeedbackCommand request,
            CancellationToken cancellationToken)
        {
            var feedback = Feedback.CreateNewFeedback(request.Description, request.GroupId);

            await _feedbackWriteOnlyRepository.AddAsync(feedback);

            var success = await _unitOfWork.Commit();

            return new CreateFeedbackCommandResult(success, string.Empty);
        }
    }
}