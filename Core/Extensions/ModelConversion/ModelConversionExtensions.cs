using Domain.ClientSideModels;
using Domain.Commands;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Extensions.ModelConversion
{
    public static class ModelConversionExtensions
    {
        public static CreateMemberCommand ToCreateMemberCommand(this MemberVm model)
        {
            var command = new CreateMemberCommand()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Roles = model.Roles,
                Avatar = model.Avatar,
                Email = model.Email
            };
            return command;
        }

        public static MenuItem[] ToMenuItems(this IEnumerable<MemberVm> models)
        {
            return models.Select(m => new MenuItem()
            {
                iconColor = m.Avatar,
                isActive = false,
                label = $"{m.LastName}, {m.FirstName}",
                referenceId = m.Id
            }).ToArray();
        }

        public static UpdateMemberCommand ToUpdateMemberCommand(this MemberVm model)
        {
            var command = new UpdateMemberCommand()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Roles = model.Roles,
                Avatar = model.Avatar,
                Email = model.Email
            };
            return command;
        }

        public static CreateTaskCommand ToCreateTaskCommand(this TaskVm model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var command = new CreateTaskCommand
            {
                Subject = model.Subject,
                AssignedMemberId = model.AssignedMember?.Id
            };

            return command;
        }

        public static AssignTaskCommand ToAssignTaskCommand(this TaskVm model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (model.AssignedMember?.Id == null)
            {
                throw new ArgumentException("No member was found to assign to.", nameof(TaskVm.AssignedMember.Id));
            }

            var command = new AssignTaskCommand
            {
                Id = model.Id,
                AssignedMemberId = model.AssignedMember.Id
            };

            return command;
        }

        public static CompleteTaskCommand ToCompleteTaskCommand(this TaskVm model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var command = new CompleteTaskCommand
            {
                Id = model.Id
            };

            return command;
        }
    }
}
