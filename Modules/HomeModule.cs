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
            Get["/venue/add"] = _ => {
                return View["venue_form.cshtml"];
            };
            Post["/venue/add"] = _ => {
                Venue newVenue = new Venue(Request.Form["venue-name"]);
                newVenue.Save();
                Dictionary<string, object> model = new Dictionary<string, object>{};
                model.Add("bands", Band.GetAll());
                model.Add("venues", Venue.GetAll());
                return View["index.cshtml", model];
            };
            Get["/band/{id}"] = parameters => {
                Band model = Band.FindBand(parameters.id);
                return View["band.cshtml", model];
            };
            Patch["/band/update/{id}"] = parameters => {
                Band updateBand = Band.FindBand(parameters.id);
                updateBand.UpdateBand(Request.Form["band-name"]);
                Dictionary<string, object> model = new Dictionary<string, object>{};
                model.Add("bands", Band.GetAll());
                model.Add("venues", Venue.GetAll());
                return View["index.cshtml", model];
            };
            Delete["/band/delete/{id}"] = parameters => {
                Band deleteBand = Band.FindBand(parameters.id);
                deleteBand.DeleteBand();
                Dictionary<string, object> model = new Dictionary<string, object>{};
                model.Add("bands", Band.GetAll());
                model.Add("venues", Venue.GetAll());
                return View["index.cshtml", model];
            };
        }
    }
}
