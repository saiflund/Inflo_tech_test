using System;
using System.Collections.Generic;

namespace MyApp.Models
{
    public class User : ModelBase
    {
        public string Forename { get; set; }

        public string Surname { get; set; }

        public bool IsActive { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<DataLogger> DataLogs { get; set; }
    }

    public class DataLogger
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime LogTime { get; set; }

        public DataLogAction LogAction { get; set; }
    }

    public enum DataLogAction
    {
        Add = 0,
        Edit = 1,
        Delete = 2
    }
}