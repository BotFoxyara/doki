using UnityEngine;
using UnityEngine.SceneManagement;

public class True : MonoBehaviour
{
    public GameObject player;

    // ����� ��� ����� �����
    public void SwitchScene(string sceneName)
    {
        if (player != null)
        {
            // ��������� ���������� ������ ����� ������ �����
            PlayerPrefs.SetFloat("PlayerPositionX", player.transform.position.x);
            PlayerPrefs.SetFloat("PlayerPositionY", player.transform.position.y);
            PlayerPrefs.SetFloat("PlayerPositionZ", player.transform.position.z);
        }

        SceneManager.LoadScene(sceneName);
        snake.money += 50;

    }
    private void OnApplicationQuit()
    {
        if (player != null)
        {
            // ���������� ����������� ����������
            PlayerPrefs.DeleteKey("PlayerPositionX");
            PlayerPrefs.DeleteKey("PlayerPositionY");
            PlayerPrefs.DeleteKey("PlayerPositionZ");
        }
    }
}
