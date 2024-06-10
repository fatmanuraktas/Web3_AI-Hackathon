using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Text; 

public class APIManager : MonoBehaviour
{
    public InputField inputField;
    public Text responseText;

    void Start()
    {
        inputField.onEndEdit.AddListener(delegate { OnEndEdit(); });
    }

    void OnEndEdit()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SendRequest();
        }
    }

    public void SendRequest()
    {
        string prompt = inputField.text;
         Debug.Log("connecting");
        StartCoroutine(PostRequest("http://localhost:3200/gamechat", "{\"prompt\":\"" + prompt + "\"}"));
    }

    IEnumerator PostRequest(string uri, string jsonData)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.PostWwwForm(uri, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            webRequest.downloadHandler = new DownloadHandlerBuffer();

            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Request successful!");
                responseText.text = webRequest.downloadHandler.text;
            }
            else
            {
                Debug.LogError("Error: " + webRequest.error);
                responseText.text = "Error: " + webRequest.error;
            }
        }
    }
}
