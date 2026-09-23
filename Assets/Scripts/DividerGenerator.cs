using Unity.VisualScripting;
using UnityEngine;

public class DividerGenerator : MonoBehaviour
{

    [SerializeField] private GameObject dashPrefab;
    [SerializeField] private float spacing = 0.1f;
    
    private float topWallY = 3.55f;
    private float bottomWallY = -4.55f;
    private const float wallHeight = 0.1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float dashHeight = dashPrefab.transform.localScale.y;
        float dashDifference = dashHeight + spacing;
        int numDashes = Mathf.FloorToInt((topWallY - bottomWallY - wallHeight) / dashDifference);
        float posY = topWallY - dashHeight/2 - wallHeight/2 - spacing;

        for (int i = 0; i < numDashes; i++)
        {
            Instantiate(dashPrefab, new Vector3(0, posY), Quaternion.identity, transform);
            posY -= dashDifference;
        }
    }

}
