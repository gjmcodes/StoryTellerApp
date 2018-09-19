using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoryCreator.Web.Interfaces.Services.Rooms;
using StoryCreator.Web.Models.Contents;
using StoryCreator.Web.Models.Rooms.Create;

namespace StoryCreator.Web.Controllers
{
    public class RoomsController : Controller
    {

        private readonly IRoomAppService _roomAppService;

        public RoomsController(IRoomAppService roomAppService)
        {
            _roomAppService = roomAppService;
        }

        // GET: Rooms
        public ActionResult Index()
        {
            return View();
        }

        // GET: Rooms/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rooms/Create
        public ActionResult Create()
        {
            return View(new CreateRoomVm());
        }

        // POST: Rooms/Create
        [HttpPost]
        public async Task<ActionResult> Create(CreateRoomVm model)
        {
            try
            {
                // TODO: Add insert logic here
                await _roomAppService.CreateRoomAsync(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Rooms/Create
        [HttpPost]
        public ActionResult CreateRoomAction(CreateRoomVm model)
        {
            try
            {
                model.RoomActions.Add(model.CreateRoomAction);
                // TODO: Add insert logic here

                return PartialView("_RoomActions", model);
            }
            catch
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult CreateRoomContent(CreateRoomVm model)
        {
            try
            {
                model.RoomContents.Add(model.CreateRoomContent);
                // TODO: Add insert logic here

                return PartialView("_RoomContents", model);
            }
            catch(Exception e)
            {
                return View();
            }

        }


        // GET: Rooms/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rooms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Rooms/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rooms/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}