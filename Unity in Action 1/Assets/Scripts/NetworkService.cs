using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkService
{
    //private const string xmlApi = "http://api.openweathermap.org/data/2.5/weather?id=1580578&APPID=a786aa20699aa2fcfba8c689543b8f7f";
    private const string jsonApi = "http://api.openweathermap.org/data/2.5/weather?id=1580578&APPID=a786aa20699aa2fcfba8c689543b8f7f";
    private const string webImage = "https://upload.wikimedia.org/wikipedia/commons/c/c5/Moraine_Lake_17092005.jpg";
    private const string localApi = "http://localhost/uia/api.php";

    private IEnumerator CallAPI(string url, WWWForm form, Action<string> callback)
    {
        using (UnityWebRequest request = (form == null) ? UnityWebRequest.Get(url) : UnityWebRequest.Post(url, form))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError)
            {
                Debug.LogError("network problem: " + request.error);
            }
            else if(request.responseCode != (long)HttpStatusCode.OK)
            {
                Debug.LogError("response error: " + request.responseCode);
            }
            else
            {   //actually use callback function
                callback(request.downloadHandler.text); 
            }
        }
    }
    //callback: delegate for later use
    public IEnumerator GetWeatherJSON(Action<string> callback)
    {
        return CallAPI(jsonApi, null, callback);
    }
    //public IEnumerator GetWeatherXML(Action<string> callback)
    //{
    //    return CallAPI(xmlApi, null, callback);
    //}

    public IEnumerator LogWeather (string name, float cloudValue, Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("message", name);
        form.AddField("cloud value", cloudValue.ToString());
        form.AddField("timestamp", DateTime.UtcNow.Ticks.ToString());

        return CallAPI(localApi, form, callback);
    }

    public IEnumerator DownloadImage(Action<Texture2D> callback)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(webImage);
        yield return request.SendWebRequest();
        callback(DownloadHandlerTexture.GetContent(request));
    }
}
