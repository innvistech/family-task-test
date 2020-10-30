using Core.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataModels = Domain.DataModels;

namespace DataLayer.Repositories
{
    public class TaskRepository : BaseRepository<Guid, DataModels.Task, TaskRepository>, ITaskRepository
    {
        public TaskRepository(FamilyTaskContext context) : base(context)
        { }



        ITaskRepository IBaseRepository<Guid, DataModels.Task, ITaskRepository>.NoTrack()
        {
            return base.NoTrack();
        }

        ITaskRepository IBaseRepository<Guid, DataModels.Task, ITaskRepository>.Reset()
        {
            return base.Reset();
        }

        public async Task<List<DataModels.Task>> GetAllTasksWithMemberAsync(CancellationToken cancellationToken = default)
        {
            var result = await Query.Include(t => t.AssignedTo).ToListAsync(cancellationToken);
            return result;
        }
    }
}
