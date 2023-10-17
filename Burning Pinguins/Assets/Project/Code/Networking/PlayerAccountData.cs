using UnityEngine;

public struct PlayerAccountData
{
    public string AccountName;
    public string AccountPassword;
    public int Rating;
    public GameObject PlayerPrefab;

    public void Dispose()
    {
        AccountName = null;
        AccountPassword = null;
        PlayerPrefab = null;
        Rating = default;
    }
}
