using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlogDatalayer.Configuration
{
    public class ConfigurationBinder
    {
        public static void Bind(DbModelBuilder modelBuilder)
        {
            var types = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x =>
                    x.BaseType != null
                    && x.BaseType.IsGenericType
                    && x.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)
                );

            foreach (var type in types)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
        }
    }
}
