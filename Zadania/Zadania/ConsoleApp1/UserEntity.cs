using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace ConsoleApp1
{
    [Table(Name = "Users")]
    public class UserEntity
    {
        [Column(IsPrimaryKey = true, Name = "Id", IsDbGenerated = true)]
        public long Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "Role")]
        public string Role { get; set; } // ADMIN, MODERATOR, TEACHER, STUDENT

        [Column(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [Column(Name = "RemovedAt")]
        public DateTime? RemovedAt { get; set; }
    }
}
