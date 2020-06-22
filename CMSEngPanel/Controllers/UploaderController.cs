using AppSettings;
using BlobManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CMSEngPanel.Controllers
{
    public class UploaderController : Controller
    {
        private IBlobManager blobManager;
        private IAppSettings appSettings;

        public UploaderController(IBlobManager _blobManager,IAppSettings _appSettings)
        {
            blobManager = _blobManager;
            appSettings = _appSettings;
        }

        // GET: Image  
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Upload(HttpPostedFileBase content)
        {
            //await blobManager.GetOrCreateContainerAsync(containerName);
            var imageUrl = await blobManager.DoUploadBlobAsync(appSettings["containerName"], content.FileName, content.InputStream);
            return View();
        }
    }
}