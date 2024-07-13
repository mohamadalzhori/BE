using Lab_1.Models;
using System.Reflection;

namespace Lab_1.Common.Services
{
    public class ObjectMapperService : IObjectMapperService
    {
        public Person MapStudentToPerson(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            Person person = new Person();
            Type studentType = typeof(Student);
            Type personType = typeof(Person);

            PropertyInfo[] studentProperties = studentType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] personProperties = personType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo studentProperty in studentProperties)
            {
                PropertyInfo personProperty = Array.Find(personProperties,
                    prop => prop.Name == studentProperty.Name && prop.PropertyType == studentProperty.PropertyType);

                if (personProperty != null)
                {
                    personProperty.SetValue(person, studentProperty.GetValue(student));
                }
            }

            return person;
        }

        public TDestination Map<TSource, TDestination>(TSource source) where TDestination : new()
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            
            TDestination destination = new TDestination();
            Type sourceType = typeof(TSource);
            Type destinationType = typeof(TDestination);

            PropertyInfo[] sourceProperties = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] destinationProperties = destinationType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                PropertyInfo destinationProperty = destinationProperties.FirstOrDefault(destProp =>
                    destProp.Name == sourceProperty.Name &&
                    destProp.PropertyType == sourceProperty.PropertyType);

                if (destinationProperty != null)
                {
                    destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                }
            }

            return destination;
        }
    }
}
