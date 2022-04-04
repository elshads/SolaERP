namespace SolaERP.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class PaymentDocumentController : ControllerBase
{
    AppUserService _appUserService;
    PaymentDocumentService _paymentDocumentService;

    public PaymentDocumentController(AppUserService appUserService, PaymentDocumentService paymentDocumentService)
    {
        _appUserService = appUserService;
        _paymentDocumentService = paymentDocumentService;
    }

    [HttpGet("GetVendorBalance")]
    public async Task<IEnumerable<PaymentDocumentDetail>> GetVendorBalance(int buid, string vendor_code)
    {
        return await _paymentDocumentService.GetVendorBalance(buid, vendor_code);
    }

    [HttpGet("GetVendorDetails")]
    public async Task<IEnumerable<PaymentDocumentDetail>> GetVendorDetails(int buid, string vendor_code, string curr_code, int paym_type)
    {
        return await _paymentDocumentService.GetVendorDetails(buid, vendor_code, curr_code, paym_type);
    }

    [HttpPost("Save")]
    public async Task<SqlResult> Save([FromBody] PaymentDocumentMain paymentDocumentMain)
    {
        return await _paymentDocumentService.Save(paymentDocumentMain, _appUserService.GetCurrentUserId());
    }
}
