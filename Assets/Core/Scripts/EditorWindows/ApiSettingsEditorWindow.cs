using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

public class ApiSettingsEditorWindow : EditorWindow
{
    private ApiSettings _apiSettings;
    private SerializedObject _serializedObject;
    private SerializedProperty _requestRoutesProperty;

    private bool _showUrls = true;
    private bool _showRoutes = true;
    private Vector2 _scrollPosition = Vector2.zero;

    [MenuItem("Tools/Api Settings")]
    public static void ShowWindow()
    {
        GetWindow<ApiSettingsEditorWindow>("API Settings");
    }

    private void OnEnable()
    {
        // Carrega automaticamente o ApiSettings dos Resources ao abrir a janela
        _apiSettings = ApiSettings.Instance;

        if (_apiSettings != null)
        {
            _serializedObject = new SerializedObject(_apiSettings);
            _requestRoutesProperty = _serializedObject.FindProperty("_requestRoutes");

        }
    }

    private void OnGUI()
    {
        if (_apiSettings != null && _serializedObject != null)
        {
            _serializedObject.Update();

            GUILayout.Space(10);
            GUILayout.Label("API Settings", EditorStyles.boldLabel);

            // Caixa para configuração de URLs
            EditorGUILayout.BeginVertical("box");
            _showUrls = EditorGUILayout.Foldout(_showUrls, "API URLs Configuration");

            if (_showUrls)
            {
                EditorGUILayout.Space();
                _apiSettings._useDevelopmentUrl = EditorGUILayout.Toggle("Use Development URL", _apiSettings._useDevelopmentUrl);
                _apiSettings._developmentApiUrl = EditorGUILayout.TextField("Development API URL", _apiSettings._developmentApiUrl);
                _apiSettings._productionApiUrl = EditorGUILayout.TextField("Production API URL", _apiSettings._productionApiUrl);
                _apiSettings._log = EditorGUILayout.Toggle("Enable Logging", _apiSettings._log);
            }

            EditorGUILayout.EndVertical();
            GUILayout.Space(10);

            EditorGUILayout.BeginVertical("box");
            _showRoutes = EditorGUILayout.Foldout(_showRoutes, "Request Routes");

            if (_showRoutes)
            {
                EditorGUILayout.Space(5);

                GUILayout.Label("List >>>>>>>> ", EditorStyles.boldLabel);

                EditorGUILayout.Space(10);
            

                if (_requestRoutesProperty.arraySize == 0)
                {
                    EditorGUILayout.HelpBox("No request routes defined.", MessageType.Info);
                }

                _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition); // Ajuste a altura conforme necessário
                // Exibe cada rota da lista
                for (int i = 0; i < _requestRoutesProperty.arraySize; i++)
                {


                    SerializedProperty routeProperty = _requestRoutesProperty.GetArrayElementAtIndex(i);


                    _apiSettings._requestRoutes[i].show = EditorGUILayout.Foldout(_apiSettings._requestRoutes[i].show, (_apiSettings._requestRoutes[i].Request));

                    if (_apiSettings._requestRoutes[i].show)
                    {
                        if (_apiSettings._requestRoutes[i] != null)
                        {
                            EditorGUILayout.LabelField("Route " + (_apiSettings._requestRoutes[i].Request), EditorStyles.boldLabel);

                            string request = EditorGUILayout.TextField("Request", _apiSettings._requestRoutes[i].Request);
                            string route = EditorGUILayout.TextField("Route", _apiSettings._requestRoutes[i].Route);

                            _apiSettings._requestRoutes[i].SetInfo(request, route);

                            string textinfp = "Error:";
                            bool erro = false;
                            if (string.IsNullOrEmpty(_apiSettings._requestRoutes[i].Request))
                            {
                                textinfp += "Request roperty is null.";
                                erro = true;
                            }
                            if (string.IsNullOrEmpty(_apiSettings._requestRoutes[i].Route))
                            {
                                textinfp += "Route property is null.";
                                erro = true;
                            }
                            if (erro)
                            {
                                EditorGUILayout.HelpBox(textinfp, MessageType.Error);
                            }
                            // Botão para remover rota
                            if (GUILayout.Button("Remove Route", GUILayout.Width(120)))
                            {
                                // Remove o elemento e reorganiza o array
                                _requestRoutesProperty.DeleteArrayElementAtIndex(i);

                            }
                        }
                        else
                        {
                            EditorGUILayout.HelpBox("Error: Route property is null.", MessageType.Error);
                        }
                    }

                    GUILayout.Space(10);
                }

                EditorGUILayout.EndScrollView();
                GUILayout.Space(10);

                // Botão para adicionar nova rota
                if (GUILayout.Button("Add New Route"))
                {
                    // Adiciona um novo elemento no array e inicializa
                    _requestRoutesProperty.arraySize++;
                    SerializedProperty newRoute = _requestRoutesProperty.GetArrayElementAtIndex(_requestRoutesProperty.arraySize - 1);
                    if (newRoute != null)
                    {
                        // Inicialize os campos necessários, se necessário
                    }
                }
            }

            EditorGUILayout.EndVertical();
            GUILayout.Space(20);

            // Botão para salvar configurações
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Save Settings", GUILayout.Width(150)))
            {
                EditorUtility.SetDirty(_apiSettings);
                AssetDatabase.SaveAssets();
            }
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();

            _serializedObject.ApplyModifiedProperties();
        }
        else
        {
            EditorGUILayout.HelpBox("ApiSettings asset not found in Resources folder. Please create one and place it in 'Resources'.", MessageType.Warning);
        }
    }
}
#endif