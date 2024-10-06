namespace IdentityCleanArch.Core.ServiceResult;

public interface IServiceResult
{
    bool Status { get; set; }
    string MessageType { get; set; }
    List<string> Message { get; set; }

}
