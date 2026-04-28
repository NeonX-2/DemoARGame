using UnityEngine;
using Vuforia;
public class GameManager : MonoBehaviour
{
    [Header("Cấu hình cho game")]
    public GameObject characterPrefab;
    public GameObject environmentPrefab;
    public GameObject imageTarget;
    GameObject characterInstance;
    //khi phát hiện target
    // tạo ra nhân vật tại vị trí của target
    public void OnTargetFound()
    {
        Debug.Log("Target found!");
        //hiện ra bối cảnh môi trường
        var template = Instantiate
            (environmentPrefab, 
            imageTarget.transform.position, 
            Quaternion.identity,
            imageTarget.transform);
        //sau 3s thì nhân vật đc tạo ra
        Invoke(nameof(SpawnCharacter), 3f);
        //sau 5s thì quái/thử thách xuất hiện
        Invoke(nameof(SpawnChallenges), 5f);
    }
    
    //khi target bị mất khỏi khung hình camera
    //...
    public void OnTargetLost()
    {
        Debug.Log("Target lost!");
    }

    void SpawnChallenges()
    {
        
    }
    
    void SpawnCharacter()
    {
        characterInstance = Instantiate
        (characterPrefab, 
            imageTarget.transform.position + new Vector3(0, 0, 0.5f), 
            Quaternion.identity,
            imageTarget.transform);   
    }
}
