using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.TransactionObjects.User
{
    public class UserFilterDto
    {
        public FilterInfoDto[] employees { get; set; }
        public FilterInfoDto[] professors { get; set; }
        public FilterInfoDto[] students { get; set; }
        public FilterInfoDto[] patients { get; set; }
    }
    public class FilterInfoDto 
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }

}
