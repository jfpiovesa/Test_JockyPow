using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ApiSettings", menuName = "Tools/ApiSettings", order = 1)]
public class ApiSettings : ScriptableObject
{
    private static ApiSettings _instance;

    [Header("Api Urls")]
    [SerializeField] public bool _useDevelopmentUrl = true;
    [SerializeField] public string _developmentApiUrl;
    [SerializeField] public string _productionApiUrl;

    [SerializeField] public List<RequestRoute> _requestRoutes;

    [Header("Configuration")]
    [SerializeField] public bool _log;

    #region Runtime Config
    public static string ApiUrl { get; private set; }
    public static bool Log { get; private set; }
    #endregion

    /// <summary>
    /// Singleton pattern to load the ApiSettings from the Resources folder.
    /// </summary>
    public static ApiSettings Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<ApiSettings>("ApiSettings");
                if (_instance == null)
                {
                    Debug.LogError("ApiSettings asset not found in Resources folder. Please create one and place it under 'Resources' folder.");
                }
            }
            return _instance;
        }
    }
    public void SetApiUrl()
    {
        ApiUrl = _useDevelopmentUrl ? _developmentApiUrl : _productionApiUrl;
        Log = _log;
    }
    public string GetApiUrl()
    {
        ApiUrl = _useDevelopmentUrl ? _developmentApiUrl : _productionApiUrl;
        return ApiUrl;
    }
}

[Serializable]
public record RequestRoute(string Request, string Route)
{
    public bool show = false;
    [field: SerializeField] public string Request { get; private set; } = Request;
    [field: SerializeField] public string Route { get; private set; } = Route;

    public void SetInfo(string _Request, string _Route)
    {
        Request = _Request;
        Route = _Route;
    }
}


