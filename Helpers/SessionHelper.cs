using System;  
using Microsoft.AspNetCore.Http;  
using Newtonsoft.Json;  
  
public static class SessionHelper
{
    public static T GetObjectFromJson<T>(this ISession session, string key)
    {
        var data = session.GetString(key);
        if (data == null)
        {
            return default(T);
        }
        return JsonConvert.DeserializeObject<T>(data);
    }

    public static void SetObjectAsJson(this ISession session, string key, object value)
    {
        session.SetString(key, JsonConvert.SerializeObject(value));
    }


}