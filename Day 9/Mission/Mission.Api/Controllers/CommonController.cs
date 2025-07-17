using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mission.Entities.ViewModels;
using Mission.Services.IService;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController(ICommonService commonService) : ControllerBase
    {
        private readonly ICommonService _commonService = commonService;
        ResponseResult result = new ResponseResult();

        [HttpGet]
        [Route("CountryList")]
        [Authorize]
        public ResponseResult CountryList()
        {
            try
            {
                result.Data = _commonService.CountryList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("CityList/{countryId}")]
        [Authorize]
        public ResponseResult CityList(int countryId)
        {
            try
            {
                result.Data = _commonService.CityList(countryId);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("MissionThemeList")]
        public ResponseResult MissionThemeList()
        {
            try
            {
                result.Data = _commonService.MissionThemeList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("MissionSkillList")]
        public ResponseResult MissionSkillList()
        {
            try
            {
                result.Data = _commonService.MissionSkillList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("UploadImage")]
        public async Task<ActionResult> UploadImage()
        {
            List<string> fileList = new List<string>();
            var files = Request.Form.Files;
            try
            {
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        var fName = file.FileName;
                        var fPath = Path.Combine("UploadMissionImage", "Mission");
                        string fileRootPath = Path.Combine(Directory.GetCurrentDirectory(), "UploadMissionImage", "Mission");

                        if (!Directory.Exists(fileRootPath))
                        {
                            Directory.CreateDirectory(fileRootPath);
                        }

                        string name = Path.GetFileNameWithoutExtension(fName);
                        string extension = Path.GetExtension(fName);

                        string fullFileName = name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                        fPath = Path.Combine(fPath, fullFileName);
                        string fullRootPath = Path.Combine(fileRootPath, fullFileName);
                        using (var stream = new FileStream(fullRootPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        fileList.Add(fPath);
                    }
                }
                return Ok(new { success = true, Data = fileList });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
