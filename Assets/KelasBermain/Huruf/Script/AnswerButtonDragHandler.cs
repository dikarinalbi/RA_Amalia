using UnityEngine;
using UnityEngine.EventSystems;

public class AnswerButtonDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public QuizGame quizgame;
    private RectTransform buttonRectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;

    private void Start()
    {
        buttonRectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = buttonRectTransform.anchoredPosition;
        quizgame = FindObjectOfType<QuizGame>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localPoint);
        buttonRectTransform.localPosition = localPoint;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        // Check if the button is dropped on the question image
        if (eventData.pointerEnter.CompareTag("QuestionImage"))
        {
            buttonRectTransform.anchoredPosition = originalPosition;
            quizgame.Checked(buttonRectTransform);
        }
        else
        {
            buttonRectTransform.anchoredPosition = originalPosition;
        }
    }

}
