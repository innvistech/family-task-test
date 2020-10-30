using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataModels = Domain.DataModels;

namespace Core.Abstractions.Repositories
{
    public interface ITaskRepository : IBaseRepository<Guid, DataModels.Task, ITaskRepository>
    {
        /// <summary>
        /// Returns a list of <see cref="DataModels.Task"/> with <see cref="DataModels.Member"/> based on the current query.
        /// </summary>
        /// <returns><see cref="DataModels.Task"/></returns>
        Task<List<DataModels.Task>> GetAllTasksWithMemberAsync(CancellationToken cancellationToken = default);
    }
}
