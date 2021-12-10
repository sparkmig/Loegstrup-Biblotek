using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblotek.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            var events = new EventService().GetEvents();
            return View(events);
        }
        public IActionResult Details(int id)
        {
            var @event = new EventService().GetEvent(id);
            return View(@event);
        }
    }
}
