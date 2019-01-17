using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tot.Core.Entity;
using Tot.Query.Models;

namespace Tot.Query.Queries.Groups
{
    public class GetGroupListQueryHandler : IQueryHandler<GetGroupListQuery, GroupListQueryModel>
    {
        private readonly IReadOnlyRepository<Group> _readOnlyRepository;

        public GetGroupListQueryHandler(IReadOnlyRepository<Group> readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
        }

        public async Task<GroupListQueryModel> Handle(GetGroupListQuery request,
            CancellationToken cancellationToken)
        {
            //Todo add cache control

            var groups = await _readOnlyRepository.List();

            var views = groups.Select(x => new GroupViewQueryModel(x.Id, x.Description)).ToList();

            return new GroupListQueryModel(views);
        }
    }
}