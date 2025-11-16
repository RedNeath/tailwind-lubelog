using CarCareTracker.External.Interfaces;
using CarCareTracker.Helper;
using CarCareTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarCareTracker.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly IFileHelper _fileHelper;
        private readonly IConfigHelper _config;
        private readonly IExtraFieldDataAccess _extraFieldDataAccess;
        
        public SettingsController(ILogger<SettingsController> logger,
            IFileHelper fileHelper,
            IConfigHelper config,
            IExtraFieldDataAccess extraFieldDataAccess)
        {
            _logger = logger;
            _fileHelper = fileHelper;
            _config = config;
            _extraFieldDataAccess = extraFieldDataAccess;
        }

        public IActionResult Index()
        {
            var userConfig = _config.GetUserConfig(User);
            var languages = _fileHelper.GetLanguages();
            var viewModel = new SettingsViewModel
            {
                UserConfig = userConfig,
                UILanguages = languages
            };
            
            return View(viewModel);
        }
        
        [Authorize(Roles = nameof(UserData.IsRootUser))]
        public IActionResult GetExtraFieldsModal(int importMode = 0)
        {
            var recordExtraFields = _extraFieldDataAccess.GetExtraFieldsById(importMode);
            if (recordExtraFields.Id != importMode)
            {
                recordExtraFields.Id = importMode;
            }
            return PartialView("_ExtraFieldsDialog", recordExtraFields);
        }
        
        [Authorize(Roles = nameof(UserData.IsRootUser))]
        public IActionResult UpdateExtraFields(RecordExtraField record)
        {
            try
            {
                _extraFieldDataAccess.SaveExtraFields(record);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            var recordExtraFields = _extraFieldDataAccess.GetExtraFieldsById(record.Id);
            return PartialView("_ExtraFieldsDialog", recordExtraFields);
        }
    }
}
