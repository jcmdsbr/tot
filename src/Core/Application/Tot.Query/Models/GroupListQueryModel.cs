using System.Collections;
using System.Collections.Generic;
using Tot.Shared.Queries;

namespace Tot.Query.Models
{
    public class GroupListQueryModel : IEnumerable<GroupViewQueryModel>, IQueryModel
    {
        private readonly List<GroupViewQueryModel> _groups;

        public GroupListQueryModel(List<GroupViewQueryModel> groups)
        {
            _groups = groups;
        }

        public IEnumerator<GroupViewQueryModel> GetEnumerator()
        {
            return _groups.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _groups.GetEnumerator();
        }
    }
}