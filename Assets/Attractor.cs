using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Attractor : MonoBehaviour
{

    public TextMeshProUGUI dropText;
    public float AttractorSpeed;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.position = Vector2.MoveTowards(transform.position, collision.transform.position, AttractorSpeed * Time.deltaTime);
            
            Destroy(gameObject, 0.5f);
            
        }
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddItemPoint();
    }

    private void AddItemPoint()
    {
        float drop = PlayerPrefs.GetFloat("drop", 0); //khai báo một biến có thể lưu trữ và có giá trị mặc định = 0 (và được lưu trữ dưới dạng tag name)
        drop+=1;
        PlayerPrefs.SetFloat("drop", drop);
        dropText.text = Mathf.FloorToInt(drop).ToString("D1");

    }
   
}
