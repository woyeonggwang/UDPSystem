using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadUdpData : MonoBehaviour
{
    public string[] chaStr;
    public IntroSystem introSys;
    public SelectSystem selectSys;
    public GameSystem gameSys;
    public ScoreSystem scoreSys;
    public RunningSystem runSys;
    public string obj;

    private string targetStr;
    private void Update()
    {
        if (ProjectManager.instance.isOut)
        {
            print("has out");
        }
    }
    private void OnEnable()
    {
    }


    public void ReadData(string str)
    {
        for (int i = 0; i < chaStr.Length; i++)
        {
            if (str == chaStr[i])
            {
                ProjectManager.instance.ChangeIdx(ProjectManager.instance.seatIdx,i);
                ProjectManager.instance.characterIdx[ProjectManager.instance.seatIdx] = i;
                ProjectManager.instance.select[ProjectManager.instance.seatIdx] = true;
            }
        }
        if(str.Contains(","))
        {
            string[] splitStr=str.Split(",");
            if (splitStr[0] == "")
            {
                ProjectManager.instance.playerName[0] = "PLAYER1";
            }
            else
            {
                ProjectManager.instance.playerName[0] = splitStr[0];
            }
            if (splitStr[1] == "")
            {
                ProjectManager.instance.playerName[1] = "PLAYER2";
            }
            else
            {
                ProjectManager.instance.playerName[1] = splitStr[1];
            }
        }
        switch (str)
        {
            case "Select0":
                ProjectManager.instance.seatIdx++;
                ProjectManager.instance.choice[0] = true;
                break;
            case "Select1":
                ProjectManager.instance.choice[1] = true;
                break;
            case "Start":
                ProjectManager.instance.gameStart = true;
                break;
            case "Ready":
                ProjectManager.instance.ready = true;
                break;
            case "Mon0":
                ProjectManager.instance.GoalCheck(ProjectManager.instance.characterIdx[0]);
                break;
            case "Mon1":
                ProjectManager.instance.GoalCheck(ProjectManager.instance.characterIdx[1]);
                break;
            case "Cha0":
                ProjectManager.instance.GoalCheck(12);
                break;
            case "Cha1":
                ProjectManager.instance.GoalCheck(13);
                break;
            case "GameDone":
                ProjectManager.instance.EndGame();
                break;
            case "End":
                ProjectManager.instance.CallReset();
                break;
            case "Reset":
                ProjectManager.instance.EndGame();
                ProjectManager.instance.CallReset();
                break;
            case "IsOut":
                ProjectManager.instance.isOut = true;
                print("is out switch");
                break;
            case "Player":

                break;

        }
    }
}
