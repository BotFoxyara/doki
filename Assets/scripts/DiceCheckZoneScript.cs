using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewDiceCheckZoneScript : MonoBehaviour
{
    Vector3 diceVelocity;

    // Update is called once per frame
    void FixedUpdate()
    {
        diceVelocity = DiceScript.diceVelocity;
    }

    void OnTriggerStay(Collider col)
    {
        if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f && snake.maxon == 1)
        {
            switch (col.gameObject.name)
            {
                case "Side1":
                    snake.diceNumber = 1;
                    break;
                case "Side2":
                    snake.diceNumber = 1;
                    break;
                case "Side3":
                    snake.diceNumber = 1;
                    break;
                case "Side4":
                    snake.diceNumber = 1;
                    break;
                case "Side5":
                    snake.diceNumber = 1;
                    break;
                case "Side6":
                    snake.diceNumber = 1;
                    break;
            }

            StartCoroutine(WaitAndSwitchScene(1f, "SampleScene"));
        }
        else if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f && snake.maxon == 2) {
            
            switch (col.gameObject.name)
            {
                case "Side1":
                    snake.diceNumber = 0;
                    break;
                case "Side2":
                    snake.diceNumber = 0;
                    break;
                case "Side3":
                    snake.diceNumber = 0;
                    break;
                case "Side4":
                    snake.diceNumber = 0;
                    break;
                case "Side5":
                    snake.diceNumber = 0;
                    break;
                case "Side6":
                    snake.diceNumber = 0;
                    break;
            }
            
            StartCoroutine(WaitAndSwitchScene(1f, "SampleScene"));
            
        }
    }

    IEnumerator WaitAndSwitchScene(float waitTime, string sceneName)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
    }
}
