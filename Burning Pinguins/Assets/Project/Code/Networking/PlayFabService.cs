using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine;

public class PlayFabService : MonoBehaviour
{
    private PlayerAccountData _loggedAccountData = new();

    public string Username { get => _loggedAccountData.AccountName; private set => _loggedAccountData.AccountName = value; }
    public string Email { get => _loggedAccountData.AccountEmail; private set => _loggedAccountData.AccountEmail = value; }
    public string Password { get => _loggedAccountData.AccountPassword; private set => _loggedAccountData.AccountPassword = value; }
    public PlayerAccountData LoggedAccountData { get => _loggedAccountData; private set => _loggedAccountData = value; }
    public string AccountCreationMessage { get; private set; }
    public string AccountLoginMessage { get; private set; }
    public string AddFriendMessage { get; private set; }
    public string CurrentAccountID { get; private set; }

    public event Action<bool> AccountCreationCallback;
    public event Action<bool> AccountLoginCallback;
    public event Action<bool> AddFriendCallback;

    public static PlayFabService Instance { get; private set; }

    public void OnEnable()
    {
        Instance = this;
    }

    public void OnDisable()
    {
        Instance = null;
    }

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
            AccountCreationMessage = result.ToString();
            AccountCreationCallback.Invoke(true);
        }, error =>
        {
            AccountCreationMessage = error.ErrorMessage;
            AccountCreationCallback.Invoke(false);
        });
    }

    public void ConnectViaPlayFab(string username, string password)
    {
        var request = new LoginWithPlayFabRequest
        {
            Username = username,
            Password = password,
        };

        PlayFabClientAPI.LoginWithPlayFab(
            request,
            result =>
            {
                _loggedAccountData.AccountName = username;
                _loggedAccountData.AccountPassword = password;
                AccountLoginMessage = result.ToString();
                AccountLoginCallback.Invoke(true);
            },
            error =>
            {
                AccountLoginMessage = error.ErrorMessage;
                AccountLoginCallback.Invoke(false);
            });
    }

    public void AddFriend(string username)
    {
        PlayFabClientAPI.AddFriend(new() 
        {
            FriendUsername = username
        },
        result => 
        {
            AddFriendMessage = result.ToString();
            AddFriendCallback.Invoke(true);
        },
        error => 
        {
            AddFriendMessage = error.ErrorMessage;
            AddFriendCallback.Invoke(false);
        });
    }
}
