using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIGameTime : MonoBehaviour
{
    [SerializeField] private RectTransform m_DayImage;
    [SerializeField] private RectTransform m_ClockParent;
    private int m_ClockParentChildNum;
    [SerializeField] private Image m_SeasonImage;
    [SerializeField] private Text m_DateText;
    [SerializeField] private Text m_TimeText;
    [SerializeField] private Sprite[] m_SeasonSprites;
    private List<GameObject> m_ClockImagesObj = new List<GameObject>();

    private void Awake()
    {
        // Register Action
        EventHandler.GameMinuteEvent += OnGameMinuteEvent;
        EventHandler.GameDateEvent += OnGameDateEvent;

        InitGameTime();
    }

    private void InitGameTime()
    {
        GetClockImagesObj();
    }

    private void OnGameMinuteEvent(int minute, int hour)
    {
        m_TimeText.text = hour.ToString("00") + ":" + minute.ToString("00");
    }

    private void OnGameDateEvent(int hour, int day, int month, int year, Season season)
    {
        m_DateText.text = year + "年" + month.ToString("00") + "月" + day.ToString("00") + "日";
        m_SeasonImage.sprite = m_SeasonSprites[(int)season];
        SwitchDayImage(hour);
    }

    private void GetClockImagesObj()
    {
        m_ClockParentChildNum = m_ClockParent.childCount;
        for (var i = 0; i < m_ClockParentChildNum; i++)
        {
            var imageObj = m_ClockParent.GetChild(i).gameObject;
            imageObj.SetActive(false);
            m_ClockImagesObj.Add(imageObj);
        }
    }

    private void SwitchDayImage(int hour)
    {
        var index = hour / 4;

        for (var i = 0; i < m_ClockParentChildNum; i++)
        {
            m_ClockImagesObj[i].SetActive(i <= index);
        }


        var target = new Vector3(0, 0, hour * 15 - 90);
        m_DayImage.DORotate(target, 1f, RotateMode.Fast);
    }

    private void OnDestroy()
    {
        // UnRegister Action
        EventHandler.GameMinuteEvent -= OnGameMinuteEvent;
        EventHandler.GameDateEvent -= OnGameDateEvent;
    }
}