<%@ WebHandler Language="C#" Class="ReceiveHandler" %>

using System;
using System.Web;
using System.Threading;
using System.Linq;

public class ReceiveHandler : IHttpAsyncHandler
{

   public bool IsReusable { get { return false; } }
  
    public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, Object extraData)
    {
        string receiver = context.Request["receiver"];
        AsynchOperation operation = new AsynchOperation { receiver = receiver, callback = cb, context = context };
        if (!TelStation.Contains(receiver))
        {
            TelStation.Add(receiver, operation);
            TelStation.Broadcast(new Message { Action = Action.Online.ToString(), Content = string.Join(",", TelStation.Contacts) });
        }
        TelStation.Add(receiver, operation);
        return operation;
    }

    public void EndProcessRequest(IAsyncResult result)
    {
    }

    public void ProcessRequest(HttpContext context)
    {
        throw new InvalidOperationException();
    }
}

