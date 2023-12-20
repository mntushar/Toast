using DNE.CS.Inventory.Library.Interface;
using Microsoft.JSInterop;

namespace DNE.CS.Inventory.Library;

public class ToastHandelar : IToastHandelar
{
    private IJSRuntime _jSRuntime;

    public ToastHandelar(IJSRuntime jSRuntime)
    {
        _jSRuntime = jSRuntime;
    }

    public async Task Success(string text)
    {
        await _jSRuntime.InvokeVoidAsync("ShowToast", "success", text);
    }

    public async Task Random(string text)
    {
        await _jSRuntime.InvokeVoidAsync("ShowToast", "random", text);
    }

    public async Task Info(string text)
    {
        await _jSRuntime.InvokeVoidAsync("ShowToast", "info", text);
    }

    public async Task Warning(string text)
    {
        await _jSRuntime.InvokeVoidAsync("ShowToast", "warning", text);
    }

    public async Task Error(string text)
    {
        await _jSRuntime.InvokeVoidAsync("ShowToast", "error", text);
    }

    public async Task ShowMessage(MessageWithStatus message)
    {
        if (message.IsSuccess)
        {
            await Success(message.Message);
        }
        else if (message.IsError) 
        { 
            await Error(message.Message);
        }
        else if(message.IsWarning)
        {
            await Warning(message.Message);
        }
        else if (message.IsInfo)
        {
            await Info(message.Message);
        }
        else if (message.IsRandom)
        {
            await Random(message.Message);
        }
    } 
}


public class MessageWithStatus()
{
    public string Message { get; set; } = string.Empty;
    public bool IsSuccess { get; set; } = false;
    public bool IsError { get; set; } = false;
    public bool IsWarning { get; set; } = false;
    public bool IsInfo { get; set; } = false;
    public bool IsRandom{ get; set; } = false;
}
