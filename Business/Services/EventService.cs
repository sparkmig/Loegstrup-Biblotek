using Storage.Context;
using Storage.Models.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class EventService
    {
        public Event GetEvent(int id)
        {
            using (var ctx = new LibaryContext())
            {
                return ctx.Events.Find(id);
            }
        }

        public Event[] GetEvents()
        {
            using (var ctx = new LibaryContext())
            {
                return ctx.Events.ToArray();
            }
        }
    }
}
