namespace SolaERP.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class PaymentDocumentController : ControllerBase
{
    PaymentDocumentService _paymentDocumentService;

    public PaymentDocumentController(PaymentDocumentService paymentDocumentService)
    {
        _paymentDocumentService = paymentDocumentService;
    }

    [HttpGet("GetVendorBalance")]
    public async Task<IEnumerable<PaymentDocument>> GetVendorBalance(int buid, string vendor_code)
    {
        return await _paymentDocumentService.GetVendorBalance(buid, vendor_code);
    }

    [HttpGet("GetVendorDetails")]
    public async Task<IEnumerable<PaymentDocument>> GetVendorDetails(int buid, string vendor_code, string curr_code, int paym_type)
    {
        return await _paymentDocumentService.GetVendorDetails(buid, vendor_code, curr_code, paym_type);
    }
}
