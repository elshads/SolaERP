namespace SolaERP.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AttachmentController : ControllerBase
{
    AttachmentService _attachmentService;

    public AttachmentController(AttachmentService attachmentService)
    {
        _attachmentService = attachmentService;
    }

    [HttpGet]
    public async Task<IEnumerable<Attachment>> GetAllAsync([FromBody] Attachment attachment)
    {
        var sql = $"dbo.SP_AttachmentList_Load";
        var p = new DynamicParameters();
        p.Add("@SourceId", attachment.SourceId, DbType.Int32, ParameterDirection.Input);
        p.Add("@Reference", attachment.Reference, DbType.String, ParameterDirection.Input);
        p.Add("@SourceType", attachment.SourceTypeName, DbType.String, ParameterDirection.Input);

        var result =  await _attachmentService.GetAllAsync(sql, p, CommandType.StoredProcedure);
        return result.ResultList;
    }

    [HttpGet]
    public async Task<Attachment> GetByIdAsync([FromBody] Attachment attachment)
    {
        var sql = $"dbo.SP_Attachment_Load";
        var p = new DynamicParameters();
        p.Add("@AttachmentId", attachment.AttachmentId, DbType.Int32, ParameterDirection.Input);

        return await _attachmentService.GetSingleAsync(sql, p, CommandType.StoredProcedure);
    }

    [HttpDelete]
    public async Task<SqlResult> DeleteAsync([FromBody] List<int> deleteList)
    {
        var sql = $"dbo.SP_Attachments_IUD";
        return await _attachmentService.DeleteAsync(deleteList, sql, "AttachmentId");
    }

    [HttpPost]
    public async Task<SqlResult> InsertAsync([FromBody] List<Attachment> attachments)
    {
        var sql = $"dbo.SP_Attachments_IUD";
        return await _attachmentService.InsertAsync(attachments, sql);
    }
}
