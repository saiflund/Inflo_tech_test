using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using MyApp.Models;

namespace MyApp.Data
{
    public class DataContext
    {
        public DataContext()
        {
            Users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Forename = "Grant",
                    Surname = "Cooper",
                    IsActive = false,
                    DateOfBirth = new DateTime(1968, 2, 12),
                    DataLogs = new List<DataLogger>
                    {
                        new DataLogger
                        {
                            Id = 1,
                            UserId = 1,
                            LogTime = DateTime.Now,
                            LogAction = DataLogAction.Add
                        }
                    }
                },
                new User 
                {
                    Id = 2, 
                    Forename = "Tom",
                    Surname = "Gathercole", 
                    IsActive = true, 
                    DateOfBirth = new DateTime(1972, 1, 2 ),
                    DataLogs = new List<DataLogger>
                    {
                        new DataLogger
                        {
                            Id = 2,
                            UserId = 2,
                            LogTime = DateTime.Now,
                            LogAction = DataLogAction.Add
                        }
                    }                
                },
                new User
                { 
                    Id = 3,
                    Forename = "Mark",
                    Surname = "Edmondson", 
                    IsActive = true, 
                    DateOfBirth = new DateTime(1992, 11, 12),
                    DataLogs = new List<DataLogger>
                    {
                        new DataLogger
                        {
                            Id = 3,
                            UserId = 3,
                            LogTime = DateTime.Now,
                            LogAction = DataLogAction.Add
                        }
                    }                
                },
                new User
                {
                    Id = 4,
                    Forename = "Graham",
                    Surname = "Clark",
                    IsActive = false,
                    DateOfBirth = new DateTime(1990, 8, 15),
                    DataLogs = new List<DataLogger>
                    {
                        new DataLogger
                        {
                            Id = 4,
                            UserId = 4,
                            LogTime = DateTime.Now,
                            LogAction = DataLogAction.Add
                        }
                    }
                }
            };
        }

        private List<User> Users { get; set; }

        public List<TEntity> Set<TEntity>() where TEntity : class 
        {
            var propertyInfo = PropertyInfos.FirstOrDefault(p => p.PropertyType == typeof(List<TEntity>));


            if (propertyInfo != null)
            {
                // Get the List<T> from 'this' Context instance
                var x = propertyInfo.GetValue(this, null) as List<TEntity>;

                return x;
            }

            throw new Exception("Type collection not found");
        }


        private IEnumerable<PropertyInfo> _propertyInfos;
        private IEnumerable<PropertyInfo> PropertyInfos
        {
            get
            {
                return _propertyInfos ??
                        (_propertyInfos = GetType()
                                            .GetProperties(BindingFlags.Instance | BindingFlags.NonPublic)
                                            .Where(p => p.PropertyType.IsGenericType &&
                                                        p.PropertyType.GetGenericTypeDefinition() == typeof(List<>)));
            }
        }

    }
}
