using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.TransactionObjects.User
{
    public class UserFilterDto
    {
        public IEnumerable<FilterInfoDto> employees { get; set; }
        public IEnumerable<FilterInfoDto> professors { get; set; }
        public IEnumerable<FilterInfoDto> students { get; set; }
        public IEnumerable<FilterInfoDto> patients { get; set; }
    }
    public class FilterInfoDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
