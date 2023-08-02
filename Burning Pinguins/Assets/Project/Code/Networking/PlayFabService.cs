using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabService : MonoBehaviour
{
    private PlayerAccountData _accountData = new();
    private string _playerDataPath = Application.dataPath + "/PlayerData";

    private string _username;
    private string _email;
    private string _password;

    public string Username { get => _accountData.accountName; set => _accountData.accountName = value; }
    public string Email { get => _accountData.accountEmail; set => _accountData.accountEmail = value; }
    public string Password { get => _accountData.accountPassword; set => _password = value; }

    public void CreatePlayFabAccount()
    {
        

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
