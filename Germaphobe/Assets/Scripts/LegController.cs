using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegController : Controller
{

    public GameObject screen;
    private string dialogue = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.\r\nNunc lacinia metus eu rhoncus consectetur.\r\nCurabitur aliquet nunc nec purus ultricies, vitae tempus turpis ultrices.\r\nCras a mi nec augue tincidunt venenatis.\r\nDonec pulvinar lacus feugiat dolor sodales, sed finibus massa egestas.\r\nNunc semper velit a tellus facilisis, id vehicula nunc blandit.\r\nCurabitur mollis lectus feugiat magna condimentum molestie.\r\nFusce gravida ligula eget interdum imperdiet.\r\nCurabitur sollicitudin est quis magna lobortis maximus.\r\nNullam vel neque imperdiet, eleifend sapien in, consectetur purus.\r\nNam aliquam neque sit amet sapien elementum blandit.\r\nUt tristique ante non pharetra pellentesque.\r\nInteger finibus mi vitae pretium convallis.\r\nIn viverra felis eget consequat viverra.\r\nNunc eu mi pellentesque, fermentum leo ac, rhoncus diam.\r\nMauris rhoncus tortor eu pellentesque pharetra.\r\nEtiam vel nulla in sapien vulputate suscipit.\r\nIn in tortor volutpat, pellentesque elit sed, commodo risus.";

    new void Start()
    {
        StartCoroutine("StartSceneFlow");
    }

    public void Update()
    {

    }

    IEnumerator StartSceneFlow()
    {
        base.Prewarm();
        yield return new WaitForSeconds(2);
        yield return runDialogue(dialogue.Split('\n'));
        base.Start();
        yield return new WaitForSeconds(5);
        base.End();
    }

}
