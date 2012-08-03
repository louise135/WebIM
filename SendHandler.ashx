<%@ WebHandler Language="C#" Class="SendHandler" %>

using System;
using System.Web;

public class SendHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string sender = context.Request["sender"];
        string receiver = context.Request["receiver"];
        string content = context.Request["content"];
        TelStation.ProcessMessage(new Message { Sender = sender, Receiver = receiver, Content = content,Action=Action.Communication.ToString() });
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}