using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Web.Script.Serialization;

public class AsynchOperation : IAsyncResult
{
    private bool completed;
    public Object state;
    public string receiver { get; set; }
    public AsyncCallback callback;
    public HttpContext context;

    bool IAsyncResult.IsCompleted { get { return completed; } }
    WaitHandle IAsyncResult.AsyncWaitHandle { get { return null; } }
    Object IAsyncResult.AsyncState { get { return state; } }
    bool IAsyncResult.CompletedSynchronously { get { return false; } }

    public void StartAsyncWork()
    {
        ThreadPool.QueueUserWorkItem(new WaitCallback(StartAsyncTask), null);
    }

    private void StartAsyncTask(Object workItemState)
    {
        try
        {
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            context.Response.Write(Serializer.Serialize(state));
            completed = true;
            callback(this);
        }
        catch (Exception)
        {
            TelStation.Remove(this.receiver);
        }
    }
}