using DataAccess.Configurations;

namespace DataAccess
{
    public class DataAccessDataConfigurations
    {
        public static DataAccessDataConfigurations Instance { get; private set; } = new DataAccessDataConfigurations();

        private DataAccessDataConfigurations()
        {
        }

        public HashSet<dynamic> Configurations()
        {
            var config = new HashSet<dynamic>()
            {
                new Course_ExtensionProjectConfiguration(),
                new Course_UserConfiguration(),
                new CourseConfiguration(),
                new ExtensionProjectConfiguration(),
                new ProjectStatusLogConfiguration(),
                new ReportConfiguration(),
                new Student_ExtensionProjectConfiguration(),
                new Teacher_ExtensionProjectConfiguration(),
                new UserConfiguration(),
            };

            return config;
        }
    }
}
