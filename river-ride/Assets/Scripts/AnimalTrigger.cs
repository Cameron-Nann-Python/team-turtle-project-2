using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Splines;
using UnityEngine.UI;

public class AnimalTrigger : MonoBehaviour
{
    public Button questionButton;
    public GameObject specificInfoPanel;
    public bool leftSide; // Is the popup is on the left side of the boat? (off means right side)
    public UnityEvent triggerEnter;
    public UnityEvent triggerExit;
    public UnityEvent goLeft;
    public UnityEvent goRight;

    private void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            questionButton.onClick.RemoveAllListeners();
            questionButton.onClick.AddListener(() => OnButtonPress(specificInfoPanel));
            setside();
            triggerEnter.Invoke();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            questionButton.onClick.RemoveAllListeners();
            triggerExit.Invoke();
        }
    }

    void setside()
    {
        if (leftSide)
        {
            goLeft.Invoke();
        }
        else
        {
            goRight.Invoke();
        }
    }

    void OnButtonPress(GameObject obj)
    {
        obj.SetActive(true);
    }
}
