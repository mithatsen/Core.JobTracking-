using Core.JobTracking.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.Entities.Concrete
{
    public class Priority : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Work> Works { get; set; }

    }
}
