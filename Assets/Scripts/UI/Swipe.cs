using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using DG.Tweening; 

public class Swipe : MonoBehaviour
{ 
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public RectTransform targetPanel;

    private bool _leftSwipe;
    private bool _rightSwipe;
    public int _positionIndex;

    public List<GameObject> panels;
    void Start()
    {
        //contestPage.GetComponentInParent<ContestUI>();
        //contestPage.currentButtonState = ButtonsState.crypto;
        SetPositionIndex();
    }

    // Update is called once per frame
    void Update()
    {
        SwipeAnimation(); 
    }

    public void SwipeAnimation()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            currentSwipe.Normalize();

            // Calculate the bounds of the target panel
            Rect panelBounds = targetPanel.rect;
            Vector3[] panelCorners = new Vector3[4];
            targetPanel.GetWorldCorners(panelCorners);
            Rect worldPanelBounds = new Rect(panelCorners[0], panelCorners[2] - panelCorners[0]);

            // Check if the swipe is within the bounds of the target panel
            if (worldPanelBounds.Contains(firstPressPos) && worldPanelBounds.Contains(secondPressPos))
            {
                // Swipe left
                if (currentSwipe.x < -0.2 && currentSwipe.y > -0.2f && currentSwipe.y < 0.2f)
                {
                    _leftSwipe = true;
                    GetNextPosition();
                }

                // Swipe right
                if (currentSwipe.x > 0.2 && currentSwipe.y > -0.2f && currentSwipe.y < 0.2f)
                {
                    _rightSwipe = true;
                    GetNextPosition();
                }
            }
        }
    }
    

    //public void SwipeAnimation()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    //    }

    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    //        currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
    //        currentSwipe.Normalize();

    //        // Calculate the bounds of the target panel
    //        Rect panelBounds = targetPanel.rect;
    //        Vector3[] panelCorners = new Vector3[4];
    //        targetPanel.GetWorldCorners(panelCorners);
    //        Rect worldPanelBounds = new Rect(panelCorners[0], panelCorners[2] - panelCorners[0]);

    //        // Check if the swipe is within the bounds of the target panel
    //        if (worldPanelBounds.Contains(firstPressPos) && worldPanelBounds.Contains(secondPressPos))
    //        {
    //            // Swipe left
    //            if (currentSwipe.x < -0.2 && currentSwipe.y > -0.2f && currentSwipe.y < 0.2f)
    //            {
    //                _leftSwipe = true;
    //                GetNextPosition();
    //                //GetComponent<RectTransform>().DOLocalMoveX(GetNextPosition(), 0.5f).SetEase(Ease.OutQuart);
    //            }

    //            // Swipe right
    //            if (currentSwipe.x > 0.2 && currentSwipe.y > -0.2f && currentSwipe.y < 0.2f)
    //            {
    //                _rightSwipe = true;
    //                GetNextPosition();
    //                //GetComponent<RectTransform>().DOLocalMoveX(GetNextPosition(), 0.5f).SetEase(Ease.OutQuart);
    //            }
    //        }
    //    }
    //} 

    private void GetNextPosition()
    {
        switch (_positionIndex)
        {
            case 1:
                {
                    if (_leftSwipe)
                    {
                        //selectContestPage.StocksClick();
                        //Debug.Log("Swipe1 left");
                        _leftSwipe = false;
                        _positionIndex = 2;
                        panels[_positionIndex-2].transform.DOMoveX(panels[_positionIndex - 2].transform.position.x - 800, 1f);
                        panels[_positionIndex-1].transform.DOMoveX(panels[_positionIndex - 1].transform.position.x - 800, 1f);
                        //return -800f;
                    }
                    else
                    {

                        //Debug.Log("Swipe1 right");
                        
                        _rightSwipe = false;
                        //_positionIndex = 1;
                        //return 0f;
                    }
                    break;
                }
            case 2:
                {
                    if (_leftSwipe)
                    {
                        //selectContestPage.CurrencyClick();
                        //Debug.Log("Swipe2 left");

                        _leftSwipe = false;
                        _positionIndex = 3;
                        //return -1600;
                    }
                    else
                    {
                        //selectContestPage.CryptoClick();
                        //Debug.Log("Swipe2 right");

                        _rightSwipe = false;
                        _positionIndex = 1;
                        panels[_positionIndex -2].transform.DOMoveX(panels[_positionIndex - 2].transform.position.x + 800, 1f);
                        panels[_positionIndex-1].transform.DOMoveX(panels[_positionIndex - 1].transform.position.x + 800, 1f);
                        //return 0f;
                    }
                    break;

                }
            case 3:
                {
                    if (_leftSwipe)
                    {
                        //Debug.Log("Swipe3 left");

                        _leftSwipe = false;
                        //_positionIndex = 4;
                        //return -1600f;
                    }
                    else
                    {
                        //selectContestPage.StocksClick();

                        //Debug.Log("Swipe3 right");

                        _rightSwipe = false;
                        _positionIndex = 2;
                        //return -800f;
                    }
                    break;

                }
            default:
                {
                    //if (_leftSwipe)
                    //{
                    //Debug.Log("Swipe left default");
                    //    _leftSwipe = false;
                    //    _positionIndex = 2;
                    //    return -800f;
                    //}
                    //else
                    //{
                    //    Debug.Log("Swipe right default");

                    //    _rightSwipe = false;
                    //    _positionIndex = 1;
                    //    return 0f;
                    //}
                    //return 0f;
                    break;

                }
        }
    }

    private void SetPositionIndex()
    {
        _positionIndex = 1;
    }
}
