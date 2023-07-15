using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerDataManager : MonoBehaviour
{
    public string playerName;
    public int topScore;
    public string topPlayerName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static PlayerDataManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SavePlayerData (int score, string playerName)
    {
        PlayerData data = new PlayerData();
        data.topScore = score;
        data.topPlayerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData ()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            topScore = data.topScore;
            topPlayerName = data.topPlayerName;
        }
    }

    [SerializeField]
    class PlayerData
    {
        public int topScore;
        public string topPlayerName;
    }
}
