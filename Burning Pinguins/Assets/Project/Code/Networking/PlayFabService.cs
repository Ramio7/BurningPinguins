using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabService : MonoBehaviour
{
    private JsonData<string> _jsonData;
    private string _playerDataPath = Application.dataPath + "/PlayerData";

    private string _username;
    private string _email;
    private string _password;

    public string Username { get => _username; set => _username = value; }
    public string Email { get => _email; set => _email = value; }
    public string Password { get => _password; set => _password = value; }

    public void CreatePlayFabAccount()
    {
        _jsonData.Load(_playerDataPath);
        if (_jsonData == null)
        {

            ConnectViaPlayFab();
        }

        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest
        {
            Username = _username,
            Email = _email,
            Password = _password,
            RequireBothUsernameAndEmail = true,
        }, result =>
        {
        }, error =>
        {
            Debug.LogError($"Fail: {error.ErrorMessage}");
        });
    }

    public void ConnectViaPlayFab()
    {
        if (PlayFabClientAPI.IsClientLoggedIn()) return;

        var request = new LoginWithPlayFabRequest
        {
            Username = _username,
            Password = _password,
        };

        PlayFabClientAPI.LoginWithPlayFab(
            request,
            result =>
            {
                
            },
            error =>
            {
                Debug.LogError($"Fail: {error.ErrorMessage}");
            });
    }
}
