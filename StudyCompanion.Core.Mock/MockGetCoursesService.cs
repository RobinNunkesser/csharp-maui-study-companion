using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Italbytz.Ports.Common;
using StudyCompanion.Ports;

namespace StudyCompanion.Core.Mock
{
    public class MockGetCoursesService : IGetCoursesService
    {
        public MockGetCoursesService()
        {
        }

        public Task<List<ICourseCollection>> Execute(string inDTO)
        {
            throw new NotImplementedException();
        }
    }
}

