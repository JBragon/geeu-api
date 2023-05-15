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
                new CourseConfiguration(),
                new ExtensionProjectConfiguration(),
                new ProjectStatusLogConfiguration(),
                new ReportConfiguration(),
            };

            return config;
        }
    }
}
