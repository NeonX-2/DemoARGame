using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        //lay gốc xoay
        var currentRotation = transform.eulerAngles;
        //khóa trục x,z, chỉ xoay y
        transform.rotation = Quaternion.Euler(0, currentRotation.y, 0);
    }
}
