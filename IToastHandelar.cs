namespace DNE.CS.Inventory.Library.Interface;


public interface IToastHandelar
{
    Task Success(string text);
    Task Random(string text);
    Task Info(string text);
    Task Warning(string text);
    Task Error(string text);
    Task ShowMessage(MessageWithStatus message);
}

