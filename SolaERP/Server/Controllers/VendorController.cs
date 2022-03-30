namespace SolaERP.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class VendorController : ControllerBase
{
    //AppUserService _appUserService;
    VendorService _vendorService;

    public VendorController(AppUserService appUserService, VendorService vendorService)
    {
        //_appUserService = appUserService;
        _vendorService = vendorService;
    }

    [HttpGet]
    public async Task<IEnumerable<Vendor>> GetByUserIdAsync (int buid)
    {
        //var currenUser = await _appUserService.GetCurrentUserAsync();
        return await _vendorService.GetAllAsync(buid);
    }
}
