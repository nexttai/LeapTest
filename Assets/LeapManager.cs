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
        // leap=gameObject.
        leap = handModel.GetLeapRecorder();
        if (leap == null)
        {
            Debug.Log("なし");
        }
        leap.Load(exercise.recording);
        if (leap == null)
        {
            Debug.Log("なし");
        }
        else Debug.Log("あり");
        if (exercise.recording == null)
        {
            Debug.Log("jsonファイルなし");
        }
        else Debug.Log("jsonファイルあり");
        Debug.Log(leap.GetFramesCount());
    }
    public  void RecordTest()
    {
        var newFrames = leap.GetFrames();


    }
    public void UpdateGesture()
    {
        leap.Load(exercise.recording);
        if (leap == null)
        {
            Debug.Log("なし");
        }
        else Debug.Log("あり");
        if (exercise.recording == null)
        {
            Debug.Log("jsonファイルなし");
        }
        else Debug.Log("jsonファイルあり");
        Debug.Log(leap.GetFramesCount());
        var newFrames = leap.GetFrames();

        //フレームの最初と最後あたりを除いたものをLeapRecorderに追加

        newFrames.RemoveRange(leap.GetFramesCount() - 200, 199);

        leap.Reset();

        foreach (var f in newFrames)
            leap.AddFrame(f);
    }
    // Update is called once per frame
    void Update()
    {
        //for(int i = 0; i < 5; i++)
        //{
        //    test += i;
        //}
    }
}
