using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text; 

public class APICaller : MonoBehaviour
{
    void Start()
    {
        Debug.Log("connecting");
        StartCoroutine(PostRequest("http://localhost:3200/gamechat", "{\"prompt\":\"hi mom\"}"));
    }

    IEnumerator PostRequest(string uri, string jsonData)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.PostWwwForm(uri, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            webRequest.downloadHandler = new DownloadHandlerBuffer();

            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Request successful!");
                Debug.Log(webRequest.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error: " + webRequest.error);
            }
        }
    }
}
