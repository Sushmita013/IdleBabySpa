using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TaskPanel : MonoBehaviour
{
    [SerializeField] string taskName;
    [SerializeField] float progress;

    public TextMeshProUGUI taskNameTxt, sliderValue;
    public Slider progressSlider;

    public GameObject incompletePanel;
    public GameObject completePanel;

    public Button taskButton;

    public string TaskName { get => taskName; set { taskName = value; taskNameTxt.text = taskName; } }
    public float Progress
    {
        get => progress;
        set
        {
            DOTween.Kill(1);
            DOTween
                .To(() => progress, x => progress = x, value, 0.1f)
                .SetId(1)
                .SetEase(Ease.Linear)
                .OnUpdate(() => progressSlider.value = progress)
                .OnComplete(() =>
                {
                    progress = value;
                    if (progress >= 1)
                    {
                        Debug.Log("Task Completed");
                        StartCoroutine(OnTaskComplete());
                    }
                });
        }
    }

    public void SetSliderValue(string value)
    {
        sliderValue.text = value;
    }

    public IEnumerator OnTaskComplete()
    {
        RectTransform incompletePos = incompletePanel.GetComponent<RectTransform>();
            incompletePos.DOAnchorPosY(-200, 0.5f)
                        .OnComplete(() =>
                        {
                            incompletePanel.SetActive(false);
                            GameObject completeObject = Instantiate(completePanel, transform);
                            completeObject.GetComponent<Button>().onClick.AddListener(() => { CanvasManager.instance.ShowReward(taskName, TaskManager.Instance.CurrentActiveTask.rewardValue);Destroy(completeObject);});
                        });
        yield return new WaitForSeconds(0.5f); 
        TaskManager.Instance.NextTaskCall();
        incompletePos.DOAnchorPosY(0, 0.5f)
                        .OnComplete(() =>
                        { 
                        incompletePanel.SetActive(true); 
                        }); 
    }
    public void Reset()
    {
        progress = 0f;
        DOTween.Kill(1);
        progressSlider.value = 0;
        transform.localScale = Vector3.one;
    }
}
