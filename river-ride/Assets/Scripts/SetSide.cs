using UnityEngine;

public class SetSide : MonoBehaviour
{
    public Transform leftSide;
    public Transform rightSide;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setLeft(true);
    }

    public void setLeft(bool goLeft)
    {
        if (goLeft)
        {
            transform.position = leftSide.position;
            transform.rotation = leftSide.rotation;
        }
        else
        {
            transform.position = rightSide.position;
            transform.rotation = rightSide.rotation;
        }
    }
}
