using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class LeapManager : MonoBehaviour
{
    public Exercise exercise;
    public LeapRecorder leap;
    public HandModelManager handModel;
    //public int test;
    // Start is called before the first frame update
    void Start()
    {
        //HandControllerのplaybackの機能（今記録したものを再生する。）はとりあえず使わないので、保留。使うとしてもif条件が必要。
        //// leap=gameObject.
        //leap = handModel.GetLeapRecorder();
        //if (leap == null)
        //{
        //    Debug.Log("なし");
        //}
        //leap.Load(exercise.recording);
        //if (leap == null)
        //{
        //    Debug.Log("なし");
        //}
        //else Debug.Log("あり");
        //if (exercise.recording == null)
        //{
        //    Debug.Log("jsonファイルなし");
        //}
        //else Debug.Log("jsonファイルあり");
        //Debug.Log("handにあるframeは"+leap.GetFramesCount());
        //leap.AddFrame();
    }
    //public  void RecordTest()
    //{
    //    var newFrames = leap.GetFrames();


    //}
    //public void UpdateGesture()
    //{
    //    if (exercise == null)
    //    {
    //        print("exerciseはnull");
    //    }
    //    leap.Load(exercise.recording);
    //    if (leap == null)
    //    {
    //        Debug.Log("なし");
    //    }
    //    else Debug.Log("あり");
    //    if (exercise.recording == null)
    //    {
    //        Debug.Log("jsonファイルなし");
    //    }
    //    else Debug.Log("jsonファイルあり");
    //    Debug.Log(leap.GetFramesCount());
    //    var newFrames = leap.GetFrames();
    //    if (newFrames == null)
    //    {
    //        Debug.Log("nullです");
    //    }
    //    else Debug.Log("nullでない");
    //    //フレームの最初と最後あたりを除いたものをLeapRecorderに追加
    //    if (leap.GetFramesCount() > 200)
    //    {
    //        newFrames.RemoveRange(leap.GetFramesCount() - 200, 199);
    //    }
    //    leap.Reset();

    //    foreach (var f in newFrames)
    //        leap.AddFrame(f);
    //}
    // Update is called once per frame
    void Update()
    {
        //for(int i = 0; i < 5; i++)
        //{
        //    test += i;
        //}
    }
}
