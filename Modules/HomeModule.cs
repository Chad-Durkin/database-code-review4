using System;
using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace Bandtracker
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => {
                Dictionary<string, object> model = new Dictionary<string, object>{};
                model.Add("bands", Band.GetAll());
                model.Add("venues", Venue.GetAll());
                return View["index.cshtml", model];
            };
            Get["/band/add"] = _ => {
                return View["band_form.cshtml"];
            };
            Post["/band/add"] = _ => {
                Band newBand = new Band(Request.Form["band-name"]);
                newBand.Save();
                Dictionary<string, object> model = new Dictionary<string, object>{};
                model.Add("bands", Band.GetAll());
                model.Add("venues", Venue.GetAll());
                return View["index.cshtml", model];
            };
        }
    }
}
