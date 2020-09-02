using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Paras_tech_SignalR.Models;

namespace Paras_tech_SignalR.Controllers
{
    public class MachineController : Controller
    {
        private readonly IHubContext<signalServer> context;
        private readonly MachineDBContext _machinedb;
        public MachineController(MachineDBContext _machinedb, IHubContext<signalServer> context)
        {
            this._machinedb = _machinedb;
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(_machinedb.Machines.ToList());
        }

        [HttpGet]
        public IActionResult GetMachines()
        {
            return Ok(_machinedb.Machines.ToList());
        }
        [HttpGet]
        public IActionResult EditStatus(int id)
        {
            return View(_machinedb.Machines.Find(id));
        }
        [HttpPost]
        public IActionResult EditStatus(Machine mch)
        {
            if (!ModelState.IsValid) return View(mch);
            Machine std = _machinedb.Machines.Where(x => x.MachineID == mch.MachineID).FirstOrDefault();
            std.MachineName = mch.MachineName;
            std.Status = mch.Status;
            _machinedb.SaveChanges();

            context.Clients.All.SendAsync("refreshMachine");
            return RedirectToAction("index");
        }

    }
}
