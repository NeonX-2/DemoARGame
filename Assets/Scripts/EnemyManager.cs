using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;
    public GameObject player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        player = FindFirstObjectByType<PlayerManager>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        var direction = player.transform.position - transform.position;
        direction.y = 0;
        var movement = direction.normalized * speed;
        characterController.Move(movement * Time.deltaTime);
    }
    
    private void LateUpdate()
    {
        // lay gốc xoay
        var currentRotation = transform.eulerAngles;
        // khóa trục x, z, chỉ xoay y
        transform.rotation = Quaternion.Euler(0, currentRotation.y, 0);
    }
}
