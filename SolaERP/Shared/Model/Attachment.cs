﻿namespace SolaERP.Shared.Model;
public class Attachment : BaseModel
{
    public int AttachmentId { get; set; }
    public string? FileName { get; set; }
    public byte[]? FileData { get; set; }
    public int SourceId { get; set; }
    public int SourceTypeId { get; set; }
    public string? SourceType { get; set; }
    public string? Reference { get; set; }
    public string? EnxtensionType { get; set; }

}