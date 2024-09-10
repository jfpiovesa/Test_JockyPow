using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class ApiRequest : MonoBehaviour
{
    bool erroRequest = false;
    string resultText;
    public async void RequestCreateRoom(string roomName, string playerName, Action action)
    {
        resultText = string.Empty;
        string url = ApiSettings.Instance.GetApiUrl() + ApiSettings.Instance._requestRoutes.Find(x => x.Request.Equals("Create-room")).Route;
        Debug.Log(url);

        CreateRoom createRoom = new CreateRoom(roomName, playerName);

        string json = JsonUtility.ToJson(createRoom);




        //var creteaRoom = GetTextAsync(url, json, UnityWebRequest.kHttpVerbGET);

        //var result = await UniTask.WhenAny(creteaRoom);
        StartCoroutine(WaitForPostRequest(url, json, UnityWebRequest.kHttpVerbGET));

        await UniTask.WaitUntil(() => !string.IsNullOrEmpty(resultText));

        if (!string.IsNullOrEmpty(resultText))
        {
            if (!erroRequest)
            {
                Debug.Log("complete " + resultText);
                S_UiGame.InfoActionSet(resultText);

            }
            else
            {
                Debug.Log("Error  " + resultText);
                S_UiGame.InfoActionSet("Error" + resultText);

            }
        }
        else
        {
            Debug.Log("Error  " + resultText);
            S_UiGame.InfoActionSet("Error" + resultText);
        }

    }
    public async void RequestSubmitChoice(string roomName, string playerName, string choice, Action action)
    {
        resultText = string.Empty;
        string url = ApiSettings.Instance.GetApiUrl() + ApiSettings.Instance._requestRoutes.Find(x => x.Request.Equals("Submit-choice")).Route;
        Debug.Log(url);

        SubmitChoice submitChoice = new SubmitChoice(roomName, playerName, choice);

        string json = JsonUtility.ToJson(submitChoice);



        //var creteaRoom = GetTextAsync(url, json, UnityWebRequest.kHttpVerbGET);

        //var result = await UniTask.WhenAny(creteaRoom);
        StartCoroutine(WaitForPostRequest(url, json, UnityWebRequest.kHttpVerbPOST));

        await UniTask.WaitUntil(() => !string.IsNullOrEmpty(resultText));

        if (!string.IsNullOrEmpty(resultText))
        {
            if (!erroRequest)
            {
                Debug.Log("complete " + resultText);
                S_UiGame.InfoActionSet(resultText);

            }
            else
            {
                Debug.Log("Error  " + resultText);
                S_UiGame.InfoActionSet("Error" + resultText);

            }
        }
        else
        {
            Debug.Log("Error  " + resultText);
            S_UiGame.InfoActionSet("Error" + resultText);
        }


    }
    public async void RequestGetSubmitChoice(string idRoom, string playerName, Action action)
    {
        resultText = string.Empty;
        string url = ApiSettings.Instance.GetApiUrl() + ApiSettings.Instance._requestRoutes.Find(x => x.Request.Equals("Get-Submit-Choice")).Route;
        Debug.Log(url);

        GetSubmitChoice getSubmitChoice = new GetSubmitChoice(idRoom, playerName);

        string json = JsonUtility.ToJson(getSubmitChoice);

        //var creteaRoom = GetTextAsync(url, json, UnityWebRequest.kHttpVerbGET);

        //var result = await UniTask.WhenAny(creteaRoom);
        StartCoroutine(WaitForPostRequest(url, json, UnityWebRequest.kHttpVerbGET));

        await UniTask.WaitUntil(() => !string.IsNullOrEmpty(resultText));


        if (!string.IsNullOrEmpty(resultText))
        {
            if (!erroRequest)
            {
                Debug.Log("complete " + resultText);
                S_UiGame.InfoActionSet(resultText);

            }
            else
            {
                Debug.Log("Error  " + resultText);
                S_UiGame.InfoActionSet("Error" + resultText);

            }
        }
        else
        {
            Debug.Log("Error  " + resultText);
            S_UiGame.InfoActionSet("Error" + resultText);
        }


    }
    public async void RequestGetResult(string idRoom, Action action)
    {
        resultText = string.Empty;
        string url = ApiSettings.Instance.GetApiUrl() + ApiSettings.Instance._requestRoutes.Find(x => x.Request.Equals("Get-Result")).Route;
        Debug.Log(url);

        GetResult createRoom = new GetResult(idRoom);

        string json = JsonUtility.ToJson(createRoom);




        //var creteaRoom = GetTextAsync(url, json, UnityWebRequest.kHttpVerbGET);

        //var result = await UniTask.WhenAny(creteaRoom);
        StartCoroutine(WaitForPostRequest(url, json, UnityWebRequest.kHttpVerbGET));

        await UniTask.WaitUntil(() => !string.IsNullOrEmpty(resultText));

        if (!string.IsNullOrEmpty(resultText))
        {
            if (!erroRequest)
            {
                Debug.Log("complete " + resultText);
                S_UiGame.InfoActionSet(resultText);

            }
            else
            {
                Debug.Log("Error  " + resultText);
                S_UiGame.InfoActionSet("Error" + resultText);

            }
        }
        else
        {
            Debug.Log("Error  " + resultText);
            S_UiGame.InfoActionSet("Error" + resultText);
        }

    }
    public async UniTask GetTextAsync(string url, string jsonData, string method)
    {
        erroRequest = false;
        resultText = string.Empty;
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        UnityWebRequest unityWebRequest = UnityWebRequest.Put(url, bodyRaw);
        unityWebRequest.method = method;
        unityWebRequest.SetRequestHeader("Content-Type", "application/json");

        UnityWebRequest op = await unityWebRequest.SendWebRequest();

        if (op.result != UnityWebRequest.Result.Success)
        {
            resultText = op.downloadHandler.text;
            erroRequest = true;

        }
        else
        {
            resultText = op.downloadHandler.text;
            erroRequest = false;
        }
    }
    public IEnumerator WaitForPostRequest(string url, string jsonData, string method)
    {
        erroRequest = false;
        resultText = string.Empty;
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        UnityWebRequest unityWebRequest = UnityWebRequest.Put(url, bodyRaw);
        unityWebRequest.method = method;
        unityWebRequest.SetRequestHeader("Content-Type", "application/json");

        yield return unityWebRequest.SendWebRequest();


        if (unityWebRequest.result != UnityWebRequest.Result.Success)
        {
            resultText = unityWebRequest.downloadHandler.text;
            erroRequest = true;

        }
        else
        {
            resultText = unityWebRequest.downloadHandler.text;
            erroRequest = false;
        }
    }

}

[Serializable]
public record CreateRoom
{
    public string roomName;
    public string playerName;

    public CreateRoom(string roomName, string playerName)
    {
        this.roomName = roomName;
        this.playerName = playerName;
    }
}
[Serializable]
public record SubmitChoice
{
    public string roomId;
    public string playerName;
    public string choice;

    public SubmitChoice(string roomId, string playerName, string choice)
    {
        this.roomId = roomId;
        this.playerName = playerName;
        this.choice = choice;
    }
}
[Serializable]
public record GetSubmitChoice
{
    public string roomId;
    public string playerName;

    public GetSubmitChoice(string roomId, string playerName)
    {
        this.roomId = roomId;
        this.playerName = playerName;
    }
}
[Serializable]
public record GetResult
{
    public string roomId;


    public GetResult(string roomId)
    {
        this.roomId = roomId;
    }
}