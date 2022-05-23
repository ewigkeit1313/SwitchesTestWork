using Microsoft.AspNetCore.Mvc;
using SwitchTest.Models;
using SwitchTest.DAL;
using Microsoft.EntityFrameworkCore;

namespace SwitchTest.Controllers
{
    public class SwitchController : Controller
    {
        private readonly SwitchesDBContext _switchesDBContext;

        public SwitchController(SwitchesDBContext switchesDBContext) 
        { 
            _switchesDBContext = switchesDBContext; 
        }

        public IActionResult Index(SwitchSearchModel searchModel, int pageNum = 1) 
        {
            List<Switch> switches = GetItems(searchModel);

            const int pageSize = 5;
            if (pageNum < 1)
            {
                pageNum = 1;
            }
            int totalCount = switches.Count();
            var page = new Page(totalCount, pageNum, pageSize);
            int skipPages = (pageNum - 1) * pageSize;

            var data = switches.Skip(skipPages).Take(page.PageSize).ToList();
            this.ViewBag.Page = page;
            this.ViewBag.searchModel = searchModel;

            return this.View(data);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            Switch @switch = new Switch();
            return this.View(@switch);
        }

        [HttpPost]
        public IActionResult Create(Switch @switch) 
        {
            if (!ModelState.IsValid)
            {
                return View(@switch);
            }
            _switchesDBContext.Add(@switch);
            _switchesDBContext.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            Switch @switch = _switchesDBContext.Switches.Find(id);
            return this.View(@switch);
        }


        [HttpPost]
        public IActionResult Edit(Switch @switch) 
        {
            _switchesDBContext.Attach(@switch);
            _switchesDBContext.Entry(@switch).State = EntityState.Modified;
            _switchesDBContext.SaveChanges();
            return RedirectToAction("index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Switch @switch = _switchesDBContext.Switches.Find(id);
            return this.View(@switch);
        }

        [HttpPost]
        public IActionResult Delete(Switch @switch)
        {
            _switchesDBContext.Attach(@switch);
            _switchesDBContext.Entry(@switch).State = EntityState.Deleted;
            _switchesDBContext.SaveChanges();
            return RedirectToAction("index");
        }

        public List<Switch> GetItems(SwitchSearchModel searchModel) 
        {
            var searchSwitch = new SearchSwitch(_switchesDBContext);
            var switches = searchSwitch.GetSwithes(searchModel);

            return switches.ToList();
        }

    }
}
