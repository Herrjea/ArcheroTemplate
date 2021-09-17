using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    RectTransform _canvasRectTransform;
    [SerializeField]
    RectTransform[] _tabs;
    [SerializeField]
    RectTransform[] _buttons;
    [SerializeField]
    RectTransform _buttonsHolderRectTransform;
    [SerializeField]
    AnimationCurve _animationCurve;
    float _animationTime;

    Vector2 _leftPanelPosition;
    Vector2 _rightPanelPosition;

    int _currentOption;
    int _selectedButtonScaleFactor = 3;
    float _sliceSize;
    bool _buttonsInstantiated = false;
    bool _changing;


    void Start()
    {
        _leftPanelPosition = new Vector2(_canvasRectTransform.sizeDelta.x, 0);
        _rightPanelPosition = new Vector2(-_canvasRectTransform.sizeDelta.x, 0);
        _currentOption = 2;
        _animationTime = 0.2f;

        float buttonsHeight = _canvasRectTransform.sizeDelta.y / 6.4f;
        //
        // for (int i =0; i < _tabs.Length; i++)
        // {
        //     if (i != 2)
        //     {
        //         _tabs[i].offsetMax = new Vector2(_rightPanelPosition.x,-200);
        //         _tabs[i].offsetMin = new Vector2(_rightPanelPosition.x,buttonsHeight);
        //     }
        //     else
        //     {
        //         _tabs[i].offsetMax = new Vector2(0, -200);
        //         _tabs[i].offsetMin = new Vector2(0, buttonsHeight);
        //     }
        // }

        _buttonsHolderRectTransform.sizeDelta = new Vector2(_canvasRectTransform.sizeDelta.x, buttonsHeight);

        float numberOfSlices = (_buttons.Length * _selectedButtonScaleFactor) + 1;
        _sliceSize = _buttonsHolderRectTransform.sizeDelta.x / (float)(numberOfSlices);

        SelectButton(2);
    }


    public void SelectButton(int selectedButton)
    {

        if (!_buttonsInstantiated)
        {
            _buttonsInstantiated = true;
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].anchoredPosition = new Vector2(_sliceSize * _selectedButtonScaleFactor * i, 0);
                _buttons[i].sizeDelta = new Vector2(_sliceSize * (_selectedButtonScaleFactor), _buttonsHolderRectTransform.sizeDelta.y);


                if (i != selectedButton)
                {
                    if (i > selectedButton)
                    {
                        _buttons[i].anchoredPosition = new Vector2((_sliceSize * (_selectedButtonScaleFactor) * i) + _sliceSize, 0);
                    }
                }
                else
                {
                    _buttons[i].sizeDelta = new Vector2(_sliceSize * (_selectedButtonScaleFactor + 1), _buttonsHolderRectTransform.sizeDelta.y + _buttonsHolderRectTransform.sizeDelta.y * 0.1f);
                }
            }
        }
        else
        {
            if (selectedButton == _currentOption || _changing)
            {
                return;
            }
            _changing = true;
            List<float> currentPositions = new List<float>();
            List<Vector2> currentSizes = new List<Vector2>();
            for (int i = 0; i < _buttons.Length; i++)
            {
                currentPositions.Add(_buttons[i].anchoredPosition.x);
                currentSizes.Add(_buttons[i].sizeDelta);

            }
            List<float> targetPositions = new List<float>();
            List<Vector2> targetSizes = new List<Vector2>();
            float standardYSize = _buttonsHolderRectTransform.sizeDelta.y;
            float oversizedY = _buttonsHolderRectTransform.sizeDelta.y + _buttonsHolderRectTransform.sizeDelta.y * 0.1f;
            for (int i = 0; i < _buttons.Length; i++)
            {
                if (i == selectedButton)
                {
                    targetSizes.Add(new Vector2((_sliceSize * (_selectedButtonScaleFactor)) + _sliceSize, oversizedY));
                }
                else
                {
                    targetSizes.Add(new Vector2(_sliceSize * (_selectedButtonScaleFactor), standardYSize));
                }
                if (i <= selectedButton)
                {
                    targetPositions.Add((_sliceSize * (_selectedButtonScaleFactor) * i));
                }
                else
                {
                    targetPositions.Add((_sliceSize * (_selectedButtonScaleFactor) * i) + _sliceSize);
                }
            }

            if (selectedButton < _currentOption)
            {
                StartCoroutine(SwipeRight(_tabs[_currentOption], _tabs[selectedButton]));
            }
            else
            {
                StartCoroutine(SwipeLeft(_tabs[_currentOption], _tabs[selectedButton]));
            }
            StartCoroutine(CoAnimateSelectButton(selectedButton, currentPositions, targetPositions, currentSizes, targetSizes));
        }
    }


    public IEnumerator SwipeLeft(RectTransform currentPanel, RectTransform targetPanel)
    {
        targetPanel.offsetMin = new Vector2(_leftPanelPosition.x, targetPanel.offsetMin.y);
        targetPanel.offsetMax = new Vector2(_leftPanelPosition.x, targetPanel.offsetMax.y); ;

        for (float i = 0; i < _animationTime; i += Time.deltaTime)
        {
            targetPanel.offsetMin = Vector2.Lerp(new Vector2(_leftPanelPosition.x, targetPanel.offsetMin.y), new Vector2(0, targetPanel.offsetMin.y), i / _animationTime);
            targetPanel.offsetMax = Vector2.Lerp(new Vector2(_leftPanelPosition.x, targetPanel.offsetMax.y), new Vector2(0, targetPanel.offsetMax.y), i / _animationTime);
            currentPanel.offsetMin = Vector2.Lerp(new Vector2(0, currentPanel.offsetMin.y), new Vector2(_rightPanelPosition.x, currentPanel.offsetMin.y), i / _animationTime);
            currentPanel.offsetMax = Vector2.Lerp(new Vector2(0, currentPanel.offsetMax.y), new Vector2(_rightPanelPosition.x, currentPanel.offsetMax.y), i / _animationTime);
            yield return null;
        }

        targetPanel.offsetMin = new Vector2(0, targetPanel.offsetMin.y);
        targetPanel.offsetMax = new Vector2(0, targetPanel.offsetMax.y);
        currentPanel.offsetMin = new Vector2(_rightPanelPosition.x, currentPanel.offsetMin.y);
        currentPanel.offsetMax = new Vector2(_rightPanelPosition.x, currentPanel.offsetMax.y);
    }

    public IEnumerator SwipeRight(RectTransform currentPanel, RectTransform targetPanel)
    {
        targetPanel.offsetMin = new Vector2(_rightPanelPosition.x,targetPanel.offsetMin.y);
        targetPanel.offsetMax = new Vector2(_rightPanelPosition.x, targetPanel.offsetMax.y);

        for (float i = 0; i < _animationTime; i += Time.deltaTime)
        {
            targetPanel.offsetMin = Vector2.Lerp(new Vector2(_rightPanelPosition.x, targetPanel.offsetMin.y), new Vector2(0, targetPanel.offsetMin.y), i / _animationTime);
            targetPanel.offsetMax = Vector2.Lerp(new Vector2(_rightPanelPosition.x, targetPanel.offsetMax.y), new Vector2(0, targetPanel.offsetMax.y), i / _animationTime);
            currentPanel.offsetMin = Vector2.Lerp(new Vector2(0, currentPanel.offsetMin.y), new Vector2(_leftPanelPosition.x, currentPanel.offsetMin.y), i / _animationTime);
            currentPanel.offsetMax = Vector2.Lerp(new Vector2(0, currentPanel.offsetMax.y), new Vector2(_leftPanelPosition.x, currentPanel.offsetMax.y), i / _animationTime);
            yield return null;
        }

        targetPanel.offsetMin = new Vector2(0, targetPanel.offsetMin.y);
        targetPanel.offsetMax = new Vector2(0, targetPanel.offsetMax.y);
        currentPanel.offsetMin = new Vector2(_canvasRectTransform.sizeDelta.x, currentPanel.offsetMin.y);
        currentPanel.offsetMax = new Vector2(_canvasRectTransform.sizeDelta.x, currentPanel.offsetMax.y);
    }


    IEnumerator CoAnimateSelectButton(int selected, List<float> originalPositions, List<float> targetPositions, List<Vector2> originalSizeX, List<Vector2> targetSizeX)
    {
        float animationSpeed = 0.2f;

        for (float i = 0; i < animationSpeed; i += Time.deltaTime)
        {
            for (int j = 0; j < _buttons.Length; j++)
            {
                _buttons[j].anchoredPosition = new Vector2(originalPositions[j] + (targetPositions[j] - originalPositions[j]) * (i / animationSpeed), 0);
                _buttons[j].sizeDelta = Vector2.Lerp(originalSizeX[j], targetSizeX[j], i / animationSpeed);

            }
            yield return 0;
        }
        for (int j = 0; j < _buttons.Length; j++)
        {
            _buttons[j].anchoredPosition = new Vector2(targetPositions[j], 0);
            _buttons[j].sizeDelta = targetSizeX[j];
        }
        _currentOption = selected;
        _changing = false;
    }
}
