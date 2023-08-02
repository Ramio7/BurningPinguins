using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabService : MonoBehaviour
{
    private PlayerAccountData _accountData = new();

    public string Username { get => _accountData.accountName; private set => _accountData.accountName = value; }
    public string Email { get => _accountData.accountEmail; private set => _accountData.accountEmail = value; }
    public string Password { get => _accountData.accountPassword; private set => _accountData.accountPassword = value; }

    public void CreatePlayFabAccount(string username, string email, string password)
    {
        PlayFabClientAPI.RegisterPlayFabUser(new()
        {
            Username = username,
            Email = email,
            Password = password,
            RequireBothUsernameAndEmail = true,
        }, result =>
        {
            _accountData.accountName = username;
            _accountData.accountEmail = email;
            _accountData.accountPassword = password;
        }, error =>
        {
            Debug.LogError($"Fail: {error.ErrorMessage}");
        });
    }

    public void ConnectViaPlayFab(string username, string password)
    {
        if (PlayFabClientAPI.IsClientLoggedIn()) return;

        var request = new LoginWithPlayFabRequest
        {
            Username = username,
            Password = password,
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
