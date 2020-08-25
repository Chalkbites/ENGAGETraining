using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LineRendererManager : MonoBehaviour
{
    private LineRenderer Line;
    [SerializeField] Transform StartPoint;
    [SerializeField] Transform EndPoint;
    // Start is called before the first frame update

  
    void OnEnable()
    {
        Line = GetComponent<LineRenderer>();
        
    }
    
    private void Update()
    {
        Line.SetPosition(0, StartPoint.localPosition) ;
        Line.SetPosition(1, EndPoint.localPosition);
    }

}
