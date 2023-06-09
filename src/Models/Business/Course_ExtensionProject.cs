﻿using Models.Infrastructure;

namespace Models.Business
{
    public class Course_ExtensionProject : BaseEntity<int>
    {
        public int CourseId { get; set; }
        public int ExtensionProjectId { get; set; }

        public virtual Course Course { get; set; }
        public virtual ExtensionProject ExtensionProject { get; set; }
    }
}
