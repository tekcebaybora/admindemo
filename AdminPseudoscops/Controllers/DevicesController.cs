using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using AdminPseudoscops.Models.AppModel;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common.Exceptions;

namespace AdminPseudoscops.Controllers
{

    [Authorize]
    public class DevicesController : AsyncController
    {
        private static RegistryManager registryManager;

        private AzureDbContext db = new AzureDbContext();

        private static string connectionString = "HostName=PseduoIotHub.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=hhEwNQrLPpp8g/JJYPJerLG0LlSZ6V5N7kSH9KbMr2s=";

        public ActionResult Devices()
        {
            return View();
        }

        public ActionResult Devices_Read([DataSourceRequest]DataSourceRequest request)
        {
            using (AzureDbContext db = new AzureDbContext())
            {
                var Devices = db.Devices.ToList();
                return Json(Devices.ToDataSourceResult(request, o => new GateAccessViewModel
                {
                    DeviceId = o.DeviceId,
                    DeviceKey = o.DeviceKey,
                    Location = o.Location,
                    IsActive = (o.IsActive == 1 ? "Aktif" : "Pasif"),

                }), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Create()
        {
            
         
                return View();
            
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Devices model)
        {
            using (AzureDbContext db = new AzureDbContext())
            {
                var Device = new Devices();

                if (model.DeviceKey == null)
                {
                    model.DeviceKey = "WaitingAzure";
                }
                if (ModelState.IsValid)
                {
                    Device.DeviceId = model.DeviceId;
                    Device.Location = model.Location;
                    Device.IsActive = model.IsActive;
                    Device.DeviceKey = model.DeviceKey;
                    db.Devices.Add(Device);
                    db.SaveChanges();
                    //await GetAzureKey(Device);
                    return RedirectToAction("Devices", "Devices");

                }
                return RedirectToAction("Create", "Devices");
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Devices_Delete([Bind(Include = "DeviceId,Location,IsActive")]GateAccessViewModel device)
        {
            if (device.DeviceId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Devices _device = null;
            using (AzureDbContext db = new AzureDbContext())
            {

                _device = db.Devices.Where(u => u.DeviceId == device.DeviceId).SingleOrDefault();
                db.Devices.Remove(_device);
                db.SaveChanges();
             
                return Json(_device.DeviceId, JsonRequestBehavior.AllowGet);
            }
            //Todo Cloud to device sync
        }

        #region [ Cloud to Device Helper ]

        private static async Task GetAzureKey(Devices model)
        {

            string deviceId = model.DeviceId;
            Device NewDevice = new Device();
            try
            {
                NewDevice = await registryManager.AddDeviceAsync(new Device(deviceId));
            }
            catch (DeviceAlreadyExistsException)
            {
                NewDevice = await registryManager.GetDeviceAsync(deviceId);
            }
            using (AzureDbContext db = new AzureDbContext())
            {
                model.DeviceKey = NewDevice.Authentication.SymmetricKey.PrimaryKey;
                db.Devices.Attach(model);
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();

            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Devices model)
        {

            if (model.DeviceId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Devices Device = null;
            using (AzureDbContext db = new AzureDbContext())
            {
                Device = db.Devices.Where(u => u.DeviceId == model.DeviceId).SingleOrDefault();
                if (ModelState.IsValid)
                {
                    Device.DeviceId = model.DeviceId;
                    Device.Location = model.Location;
                    Device.IsActive = model.IsActive;
                    db.Devices.Add(Device);
                    db.SaveChanges();
                    await GetAzureKey(Device);

                }
                return RedirectToAction("Devices", "Devices");
            }
        }


        #endregion

    }
}
