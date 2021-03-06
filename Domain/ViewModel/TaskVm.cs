﻿using System;

namespace Domain.ViewModel
{
    public class TaskVm
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public bool IsComplete { get; set; }
        public Guid? AssignedMemberId { get; set; }

        public virtual MemberVm AssignedMember { get; set; }
    }
}
