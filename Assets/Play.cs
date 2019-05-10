using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Play : MonoBehaviour
{

   // public MenuReferences menu;

 //   public AudioSource yay;
    //  public AudioSource clear;
   // private Animator animator;
    private CanvasGroup group;
    public Exercise exercise;
  //  public Level level;
    public GameObject floatingTitle;
    public GameObject wordsPositions;
    public Dictionary<Exercise, GameObject> floatingExercises = new Dictionary<Exercise, GameObject>();
    public Transform center;
   // public ResultsFiller exam;
    public Tutorial tutorial;
    public LeapTrainer trainer;

    public GameObject exercisePrefab;
    public float adjestheight = 50.0f;
    //   public GameObject[] respown5;

    private bool training = false;
    public float maxScore = 0;
    public float totalScore = 0;
    public string getname;

    private int failCount = 0;

    private Animator tutoanimator;

    // Use this for initialization
    void Start()
    {
    //    menu = GetComponentInParent<MenuReferences>();
     //   animator = GetComponent<Animator>();
      //  animator.SetBool("Show", true);
        //tutoanimator = tutorial.GetComponent<Animator> ();
        group = GetComponent<CanvasGroup>();
        //認識されたら、現時点でのスコアをmaxscoreとする。
        trainer.OnGestureRecognized += (name, value, allHits) => {
            maxScore = value;
            //  getname = name;

        };

        trainer.OnGestureUnknown += (allHits) => {
            failCount++;
            if (failCount == 30)
            {

                //	tutorial.playing = true;
                tutoanimator.SetBool("Show", true);
            }
        };

    }

    // Update is called once per frame
    void Update()
    {

        //playシーンがフェードアウトするときに、タイトルを削除する。
        //if (group.alpha == 0)
        //{
        //    animator.SetBool("Show", true);
        //    //	tutorial.playing = false;
        //    //  Debug.Log("GroupCanvasのα値が0になった");
        //    if (floatingTitle)
        //        DestroyImmediate(floatingTitle);
        //    //認識中の現行のDictionaryのうち、文字の値を消去。
        //    foreach (var v in floatingExercises)
        //    {
        //        DestroyImmediate(v.Value);
        //    }
        //    //黒板の文字を張り付けるオブジェクトを削除
        //    for (int i = wordsPositions.transform.childCount - 1; i >= 0; i--)
        //    {
        //        GameObject.DestroyImmediate(wordsPositions.transform.GetChild(i).gameObject);
        //    }
        //    floatingExercises.Clear();
        //}
    }
    
    public void StartTraining()
    {
        aborted = false;
        training = true;
        StartCoroutine(StartPlay());

    }
    //認識開始のAボタンが押されたら始まる
    public void StartExam()
    {
        aborted = false;
        training = false;
        //   一度初期化
        totalScore = 0;
        StartCoroutine(StartPlay());
    }

    private bool aborted = false;
    //認識を中断する。
    public void Abort()
    {
      //  animator.SetBool("Show", false);
        trainer.Clean();
        trainer.paused = true;
        StopAllCoroutines();

        //	tutorial.GetComponent<Animator> ().SetBool ("Show", false);
       // exam.GetComponent<Animator>().SetBool("Show", false);
    }
    
    // //認識開始のAボタンが押されたら始まる
    private IEnumerator StartPlay()
    {


        //foreach (e in level.exerises)
        //{
           // FlyTo ft = null;
            Transform exercisePos = null;
            ////認識する文字を中心に移動する。
            //try
            //{
            //  //  GameObject floatingExercise = floatingExercises[e];

            //  //  ft = floatingExercise.GetComponent<FlyTo>();
            //  //  exercisePos = ft.destination;

            //   // ft.destination = center;
            //}
            //catch (System.Exception)
            //{
            //    Debug.Log("例外発生");
            //   // break;
            //}//{return false;}
            ////ここは一番初めの認識する前のシーン。
            //yield return new WaitForSeconds(0.1f);
            try
            {

                if (aborted)
                { }//return false;
                   //認識するための枠組みである文字が入力される
                   //        tutorial.gesture = e;
                   //トレーニングモードの時、トレーニング開始。ControllerPlaybackのCGが出る。
                if (training)
                {
                    //    tutorial.playing = true;

                    //     tutorial.GetComponent<Animator>().SetBool("Show", true);

                }
                //認識する前に認識する文字のフレームの前処理をする。
                tutorial.UpdateGesture();



            }
            catch (System.Exception)
        { Debug.Log("例外発生"); }//{return false;}

            yield return new WaitForSeconds(0.1f);
            //if (aborted)
            //  { }return false;
            //     try
            // {
            //以前のplayでのgesturesの情報を削除して、今回の文字における名前とフレームを取得。
            trainer.Clean();
            trainer.loadFromFrames(exercise.exerciseName, tutorial.GetFrames(), false);

            trainer.paused = false;
            //}catch(System.Exception) { 
            //  Debug.Log("例外発生");
            //   break;
            // }//{return false;}
            //スコアが0.3超えるまで中断できる。
            yield return new WaitUntil(() => maxScore > 0.3f);


            //hand5というタグがついた、自分の手の位置を取得し、e.FontObject（３D文字）をインスタンス化して、手の上に表示。
            GameObject respown5 = GameObject.FindGameObjectWithTag("hand5");
            Vector3 konko = respown5.transform.position;

            konko.y += adjestheight;

            var fontObj = Instantiate(exercise.FontObject, konko, Quaternion.identity);
            fontObj.transform.parent = GameObject.FindGameObjectWithTag("hand5").transform;
       
        //それぞれの文字の音を出す。
        // var eAudio = Instantiate(exercise.audio);
        exercise.audio.GetComponent<AudioSource>().Play();
           

            if (maxScore > 0.3f) trainer.paused = true;

            yield return new WaitForSeconds(5f);

            Destroy(fontObj);


            // if (aborted)
            // { return false;}
            try
            {

                //認識モードを終了して、今までのスコアより高いスコアをだしたら、更新。
                trainer.paused = true;

                if (!training && maxScore > exercise.score)
                {
                    exercise.score = maxScore;
                  //  exercise.onname = getname;

                }

                // Save score
                // Give feedback

                totalScore += maxScore;
                maxScore = 0;
                //認識し終わったあとの文字を緑色にかえて、戻す。
              //  ft.destination = exercisePos;
               // ft.destinationColor = Color.green;

                //			tutorial.GetComponent<Animator> ().SetBool ("Show", false);
            }
            catch (System.Exception)
            {

                Debug.Log("例外発生");
               // break;
            }
       // }

        yield return new WaitForSeconds(2f);
        //	tutorial.playing = false;

        try
        {
            //トレーニングモードでないとき、今やったスコアの平均を出して、最高点だったら、更新。その後、戻る。
            if (!training)
            {
            //    yay.PlayDelayed(.5f);
                float score = 0;
                //foreach (var e in level.exercises)
                //{
                    score += exercise.score;
              //  }

                //score /= (level.exercises.Length * 1f);
                //Debug.Log("平均スコア：" + score);
                //if (score > level.score)
                //    level.score = score;

                //exam.level = level;
                //exam.GetComponent<Animator>().SetBool("Show", true);
            }
            else
            {
              //  menu.Menu = 3;
                Abort();
            }
        }
        catch (UnityException) { Debug.Log("例外発生"); }


    }

}
