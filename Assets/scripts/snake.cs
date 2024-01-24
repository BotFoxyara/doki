using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class snake : MonoBehaviour
{
    public GameObject player;
    public GameObject button;
    Text text;
    public static int diceNumber = 0;
    public static int money = 2000;
    public static int maxon = 1;
    [Range(0, 10), SerializeField] private float _moveSpeed;
    [Range(0, 35), SerializeField] private float _rotateSpeed;

    private float x, y, z;

    void Start()
    {
        
        gameObject.name = "player";
        if (PlayerPrefs.HasKey("PlayerPositionX"))
        {
            x = PlayerPrefs.GetFloat("PlayerPositionX");
            y = PlayerPrefs.GetFloat("PlayerPositionY");
            z = PlayerPrefs.GetFloat("PlayerPositionZ");
        }
        transform.position = new Vector3(x + 2, 1, z);
        UpdateMoveSpeed();
    }

    void Update()
    {
        UpdateMoveSpeed();
        MoveHead(_moveSpeed);
        Rotate(_rotateSpeed);
    }

    void UpdateMoveSpeed()
    {
        if (diceNumber > 0)
        {
            button.SetActive(false);
            _moveSpeed = 5;
        }
        else
        {
            button.SetActive(true);
            _moveSpeed = 0;
        }
    }

    void MoveHead(float speed)
    {
        transform.position = transform.position + transform.right * speed * Time.deltaTime;
    }

    void Rotate(float speed)
    {
        float angle = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Rotate(0, angle, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Eat eat))
        {
            snake.diceNumber -= 1;
            _moveSpeed += 2;
        }
        else if (other.TryGetComponent(out Vopros vopros))
        {
            if (snake.diceNumber == 1)
            {
             PlayerPrefs.SetFloat("PlayerPositionX", player.transform.position.x);
                PlayerPrefs.SetFloat("PlayerPositionY", player.transform.position.y);
                PlayerPrefs.SetFloat("PlayerPositionZ", player.transform.position.z);
                SceneManager.LoadScene("Vopros");
 
            }
        }
    }
}
