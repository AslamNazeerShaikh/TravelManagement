using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagement.Domain.Common.Interfaces
{
    public interface IDomainEventDispatcher
    {
        public Task DispatchAndClearEvents(IEnumerable<BaseEntity> entitiesWithEvents);
    }
}
