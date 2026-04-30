using UnityEngine;
using Vuforia;

public class GameManager : MonoBehaviour
{
    [Header("Cấu hình cho game")] public GameObject characterPrefab;
    public GameObject environmentPrefab;
    public GameObject imageTarget;
    public GameObject enemyPrefab;
    public int numberOfEnemies;

    GameObject characterInstance;
    GameObject[] enemies;
    GameObject environmentInstance;

    // khi phát hiện target
    // tạo ra nhân vật tại vị trí của target
    public void OnTargetFound()
    {
        Debug.Log("Target found!.....");
        if (characterInstance != null) return;
        // hiện ra bối cảnh môi trường
        environmentInstance = Instantiate(
            environmentPrefab,
            imageTarget.transform.position,
            Quaternion.identity,
            imageTarget.transform);
        // sau 3s thì nhân vật dc tạo ra
        Invoke(nameof(SpawnCharacter), 3f);
        // sau 5s thì quái/thử thách xuất hiện
        Invoke(nameof(SpawnChallenges), 5f);
    }

    // khi target bị mất khỏi khung hình camera
    // ....
    public void OnTargetLost()
    {
        Debug.Log("Target lost!.....");
        // xóa cac đối tượng đã tạo ra
        if (characterInstance != null) Destroy(characterInstance);
        if (enemies != null)        {
            foreach (var enemy in enemies)            {
                if (enemy != null) Destroy(enemy);
            }
        }
        if (environmentInstance != null) Destroy(environmentInstance);
    }

    void SpawnChallenges()
    {
        enemies = new GameObject[numberOfEnemies];
        for (var i = 0; i < numberOfEnemies; i++)
        {
            var enemy = Instantiate(
                enemyPrefab,
                imageTarget.transform.position +
                new Vector3(Random.Range(-10f, 10f), 0, Random.Range(0f, 10f)),
                Quaternion.identity,
                imageTarget.transform);
            enemies[i] = enemy;
        }
    }

    void SpawnCharacter()
    {
        characterInstance = Instantiate(
            characterPrefab,
            imageTarget.transform.position + new Vector3(0, 0, 0.5f),
            Quaternion.identity,
            imageTarget.transform);
    }
}