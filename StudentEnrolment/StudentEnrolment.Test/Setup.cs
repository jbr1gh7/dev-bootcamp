using Microsoft.EntityFrameworkCore;
using StudentEnrolment.Data;
using System;

namespace StudentEnrolment.Test
{
    public class Setup
    {
        public EnrolmentDbContext Context()
        {
            var options =
                new DbContextOptionsBuilder<EnrolmentDbContext>().UseMySql(
                    "Server = 127.0.0.1; Database = studentenrolment; Uid = devuser; Password = Deloitte.1;",
                    new MySqlServerVersion(new Version(8, 0, 11))
                ).Options;

            return new EnrolmentDbContext(options);
        }

    }
}
