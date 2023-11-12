using PlayFab;
using PlayFab.ClientModels;
using System;
using System.IO;
using UnityEngine;

public class PlayFabService : MonoBehaviour
{
    [SerializeField] private GameObject _playerStandardPrefab;

    private PlayerAccountData _loggedAccountData = new();

    public string Username { get => _loggedAccountData.AccountName; private set => _loggedAccountData.AccountName = value; }
    public string Password { get => _loggedAccountData.AccountPassword; private set => _loggedAccountData.AccountPassword = value; }
    public GameObject PlayerPrefab { get => _loggedAccountData.PlayerPrefab; set => _loggedAccountData.PlayerPrefab = value; }
    public PlayerAccountData LoggedAccountData { get => _loggedAccountData; private set => _loggedAccountData = value; }
    public string AccountCreationMessage { get; private set; }
    public string AccountLoginMessage { get; private set; }
    public string AddFriendMessage { get; private set; }

    public event Action<bool> AccountCreationCallback;
    public event Action<bool> AccountLoginCallback;
    public event Action<bool> AddFriendCallback;

    public static PlayFabService Instance { get; private set; }
    public static string AccountDataPath;

    public void OnEnable()
    {
        Instance = this;
        CheckPreviousLogin();
    }

    public void OnDisable()
    {
        Instance = null;
    }

    private void OnApplicationQuit()
    {
        _loggedAccountData.Dispose();
    }

    private void CheckPreviousLogin()
    {
        CreateAccountFilePath();
        if (CheckLoginFileExistance())
            if (LoadAccountData())
                ConnectViaPlayFab(Username, Password);
            else return;
        else CreateLoginFile();

        if (_loggedAccountData.PlayerPrefab == null) LoadStandardPrefab();
        else return;
    }

    private void CreateAccountFilePath()
    {
        AccountDataPath = Application.dataPath + "/Resources/PlayerData.json";
    }

    private bool CheckLoginFileExistance() => File.Exists(AccountDataPath);

    private void CreateLoginFile()
    {
        var accountDataFile = File.Create(AccountDataPath);
        accountDataFile.Close();
    }

    private bool LoadAccountData()
    {
        JsonData<PlayerAccountData> accountData = new();
        _loggedAccountData = accountData.Load(AccountDataPath);
        return _loggedAccountData.AccountName != null;
    }

    private void LoadStandardPrefab()
    {
        _loggedAccountData.PlayerPrefab = _playerStandardPrefab;
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
                Username = username;
                Password = password;
                AccountLoginMessage = result.ToString();
                AccountLoginCallback?.Invoke(true);
                WriteLoggedAccountData();
                PhotonService.Instance.ConnectToPhotonServer();
            },
            error =>
            {
                AccountLoginMessage = error.ErrorMessage;
                AccountLoginCallback.Invoke(false);
            });
    }

    private void WriteLoggedAccountData()
    {
        JsonData<PlayerAccountData> accountData = new();
        accountData.Save(LoggedAccountData, AccountDataPath);
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
