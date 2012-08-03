using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

/// <summary>
///电话局
/// </summary>
public static class TelStation
{
    static Hashtable contacts = new Hashtable();
	static TelStation()
	{
	
	}
    public static void Clear()
    {
        contacts.Clear();
    }
    public static bool Contains(string key)
    {
        return contacts.ContainsKey(key);
    }
    public static void Add(string key, AsynchOperation operation)
    {
        contacts[key] = operation;
    }
    /// <summary>
    /// 联系人集合
    /// </summary>
    public static string[] Contacts
    {
        get
        {
            return (from string a in contacts.Keys
             select a).ToArray<string>();
        }
    }
    public static AsynchOperation Get(string key)
    {
        if (contacts.ContainsKey(key))
        {
            return contacts[key] as AsynchOperation;
        }
        return null;
    }
    public static void Remove(string key){
        if (contacts.ContainsKey(key))
        {
            contacts.Remove(key);
        }
    }
    public static void ProcessMessage(Message message)
    {
        if (Contains(message.Receiver))
        {
            var contact = contacts[message.Receiver] as AsynchOperation;
            contact.state = message;
            contact.StartAsyncWork();
        }
    }
    public static void Broadcast(Message message)
    {
        foreach (AsynchOperation item in contacts.Values)
        {
            message.Receiver = item.receiver;
            item.state = message;
            item.StartAsyncWork();
        }
    }
}