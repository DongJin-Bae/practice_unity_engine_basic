using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
    enum Buttons
    {
        PointButton,
    }

    enum Texts
    {
        PointText,
        ScoreText
    }

    enum Images
    {
        ItemIcon,
    }

    enum GameObjects
    {
        TestObject,
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(GameObjects));

        GetButton((int)Buttons.PointButton).gameObject.BindEvent(OnButtonClicked);

        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        BindEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
    }

    int _score = 0;
    
    public void OnButtonClicked(PointerEventData data)
    {
        //Get<Text>((int)Texts.ScoreText).text = "BindText";
        GetText((int)Texts.ScoreText).text = $"Á¡¼ö: {++_score}";
    }
}
