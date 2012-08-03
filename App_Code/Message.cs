using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///消息
/// </summary>
public class Message
{
	public Message()
	{
		
	}
    public string Sender { get; set; }
    public string Receiver { get; set; }
    public string Action { get; set; }
    public string Content { get; set; }
}
public enum Action
{
    Online,
    Communication,
}