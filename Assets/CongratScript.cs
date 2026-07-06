using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;
    
    private List<string> TextToDisplay;
    
    [SerializeField] private float RotatingSpeed;
    private float TimeToNextText;
    private int CurrentText;
    
    // Start is called before the first frame update
    void Start()
    {
        TimeToNextText = 0.0f;
        CurrentText = 0;
        
        RotatingSpeed = 10.0f;
        TextToDisplay = new List<string>();

        TextToDisplay.Add("Congratulation");
        TextToDisplay.Add("All Errors Fixed");
        
        if(TextToDisplay == null)
        {
            Debug.LogError("TextToDisplay is null");
        }
        Text.text = TextToDisplay[0];
        
        SparksParticles.Play();
        StartCoroutine(test());
    }

    // Update is called once per frame
    void Update()
    {
        TimeToNextText += Time.deltaTime;

        if (TimeToNextText > 1.5f)
        {
            TimeToNextText = 0.0f;

            CurrentText++;
            if (CurrentText >= TextToDisplay.Count)
            {
                CurrentText = 0;

                
            }
            
            Text.text = TextToDisplay[CurrentText];
            
        }
        transform.Rotate(Vector3.right, RotatingSpeed * Time.deltaTime);
    }

    private IEnumerator test()
    {
        yield return new WaitForSeconds(1.5f);
        Debug.Log("test");
        StartCoroutine(test());
    }
}