using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.FillLayers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.ImageLoadOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test_Application.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string file = @"C:\Users\abdul\Documents\GitHub\Test-Application2\Test Application\Content\Lower Ground Floor.psd";
            using (var im = (PsdImage)Aspose.PSD.Image.Load(file, new PsdLoadOptions()))
            {
                foreach (var layer in im.Layers)
                {
                    if (layer.Name == "LG-40")
                    {
                        var fillLayer = layer as FillLayer;
                        if (fillLayer != null)
                        {
                            var settings = fillLayer.FillSettings as IColorFillSettings;
                            if (settings != null)
                            {
                                settings.Color = Aspose.PSD.Color.FromName("Red");
                                fillLayer.Update();
                                break;
                            }
                        }
                    }
                }
                im.Save(file, true);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}