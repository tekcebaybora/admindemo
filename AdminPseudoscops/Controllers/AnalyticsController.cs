﻿using System;
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

namespace AdminPseudoscops.Controllers
{
    [Authorize]
    public class AnalyticsController : Controller
    {
        private AzureDbContext db = new AzureDbContext();

        public ActionResult EventHistory()
        {
            return View();
        }
        
        public ActionResult EventHistory_Read([DataSourceRequest]DataSourceRequest request)
        {
           

                var Eventhistory = db.EventHistory

                    .Include(e =>e.Devices)
                    .Include(e => e.GateAccessUser).ToList();
                return Json(Eventhistory.ToDataSourceResult(request,o => new GateAccessViewModel
                {
                    UserId = o.UserId,
                    DeviceId = o.DeviceId,
                    Location = o.Devices.Location,
                    Id = o.Id,
                    Name = o.GateAccessUser.Name,
                    Surname = o.GateAccessUser.Surname,
                    IsInside = (o.IsInside == 1 ? "İçeride" : "Dışarıda"),
                    EventTime = o.EventTime
                }), JsonRequestBehavior.AllowGet);


        }

        public ActionResult EventHistoryBasedonLocation()
        {
            return View();
        }
        //TODO
        public ActionResult EventHistoryBasedonLocation_Read([DataSourceRequest]DataSourceRequest request)
        {


            var EventHistoryBasedonLocation = db.EventHistory

                .Include(e => e.Devices)
                .Include(e => e.GateAccessUser).ToList();
            return Json(EventHistoryBasedonLocation.ToDataSourceResult(request, o => new GateAccessViewModel
            {
                UserId = o.UserId,
                DeviceId = o.DeviceId,
                Location = o.Devices.Location,
                Id = o.Id,
                Name = o.GateAccessUser.Name,
                Surname=o.GateAccessUser.Surname,
                IsInside = (o.IsInside == 1 ? "İçeride" : "Dışarıda"),
                EventTime = o.EventTime
            }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EventHistoryBasedonDevice()
        {
            return View();
        }

        public ActionResult EventHistoryBasedonDevice_Read([DataSourceRequest]DataSourceRequest request)
        {


            var EventHistoryBasedonDevice = db.EventHistory

                .Include(e => e.Devices)
                .Include(e => e.GateAccessUser).Where(o=>o.IsInside==1).ToList();
            return Json(EventHistoryBasedonDevice.ToDataSourceResult(request, o => new GateAccessViewModel
            {
               
                DeviceId = o.DeviceId,
                UserId = o.UserId,
                UserFullName=o.GateAccessUser.Name+o.GateAccessUser.Surname,
                IsInside = (o.IsInside == 1 ? "İçeride" : "Dışarıda"),
                EventTime = o.EventTime
            }), JsonRequestBehavior.AllowGet);
        }
        //TODO
        public ActionResult EventHistoryBasedonVisitor()
        {
            return View();
        }

       
        public ActionResult EventHistoryBasedonVisitor_Read([DataSourceRequest]DataSourceRequest request)
        {


            var EventHistoryBasedonVisitor = db.EventHistory
                .Include(e => e.Devices)
                .Include(e => e.GateAccessUser).ToList();
            return Json(EventHistoryBasedonVisitor.ToDataSourceResult(request, o => new GateAccessViewModel
            {
                UserId = o.UserId,
                DeviceId = o.DeviceId,
                Id = o.Id,
                //IsInside = o.IsInside,
                EventTime = o.EventTime
            }), JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserAnalytics()
        {
            return View();
        }

        public ActionResult UserAnalytics_Read([DataSourceRequest]DataSourceRequest request)
        {

#pragma warning disable JustCode_ExplicitTypedVariableDeclarationMisused // Not explicitly typed local variable
            var UserAccess = db.GateAccessUser.Include(e =>e.UserNFCTags).ToList();
#pragma warning restore JustCode_ExplicitTypedVariableDeclarationMisused // Not explicitly typed local variable
              
            return Json(UserAccess.ToDataSourceResult(request, o => new GateAccessViewModel
            {
                UserId = o.UserId,
                Name = o.Name,
                Surname = o.Surname,
                PhysicalTag = o.UserNFCTags.PhysicalTag,
                VirtualTag = o.UserNFCTags.VirtualTag,
                Mail = o.Mail,
                Info=o.Info
            }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeviceAnalytics()
        {
            return View();
        }

        public ActionResult DeviceAnalytics_Read([DataSourceRequest]DataSourceRequest request)
        {

            var DeviceAnalytics = db.Devices.ToList();

             
            return Json(DeviceAnalytics.ToDataSourceResult(request, o => new GateAccessViewModel
            {
                DeviceId = o.DeviceId,
                DeviceKey = o.DeviceKey,
                Location = o.Location,
                IsActive = (o.IsActive == 1 ? "Aktif" : "Pasif"),

            }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult InInsideUserAnalytics()
        {
            return View();
        }

        public ActionResult InInsideUserAnalytics_Read([DataSourceRequest]DataSourceRequest request)
        {
            var InInsideUserAnalytics = db.EventHistory
          .Include(e => e.Devices)
          .Include(e => e.GateAccessUser).GroupBy(t => t.UserId).Select(s => s.OrderByDescending(o => o.EventTime).FirstOrDefault()).Where(o => o.IsInside == 1).ToList();


            return Json(InInsideUserAnalytics.ToDataSourceResult(request, o => new GateAccessViewModel
            {

                UserId = o.UserId,
                Location = o.Devices.Location,
                Id = o.Id,
                Name = o.GateAccessUser.Name,
                Surname = o.GateAccessUser.Surname,
                EventTime = o.EventTime

            }), JsonRequestBehavior.AllowGet);
        }
    }
}
