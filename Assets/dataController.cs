using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class dataController : MonoBehaviour
{
    //StreamWriter sw = new StreamWriter("Assets/Scenario/ScenarioInfo.txt");
    public static dataController instance;
    public GameObject Option, Dialogue, NonDialogue, NonOption;
    public RawImage BlackTheme;
    private string[] str;
    private float MVolume, BGVolume, EVolume; // 마스터, 배경, 효과 음악 소리 크기
    private float H1Voice, H2Voice, H3Voice, H4Voice, OtherVoice; // 히로인별 음성 크기
    private float SubSpeed, AutoSpeed, TransparentDegree; // 자막 속도, 오토모드 자막 속도, 창 투명 정도

    // fade 구현!
    float fades = 0.0f;

    public void OptionOpen() {
        StartCoroutine(OptionOpener());
    }

    public void OptionClose() {
        StartCoroutine(OptionCloser());
    }

    IEnumerator OptionOpener() {
        while(true) {
            fades += 0.1f;
            BlackTheme.color = new Color (0, 0, 0, fades);
            if (fades >= 1.0f) {
                break;
            } else {
                yield return new WaitForSeconds(0.04f);
            }
        }
        NonDialogue.SetActive(false);
        Dialogue.SetActive(false);
        Option.SetActive(true);
        NonOption.SetActive(true);
        while(true) {
            fades -= 0.1f;
            BlackTheme.color = new Color (0, 0, 0, fades);
            if (fades <= 0.0f) {
                break;
            } else {
                yield return new WaitForSeconds(0.04f);
            }
        }
        yield return null;
    }

    IEnumerator OptionCloser() {
        while(true) {
            fades += 0.1f;
            BlackTheme.color = new Color (0, 0, 0, fades);
            if (fades >= 1.0f) {
                break;
            } else {
                yield return new WaitForSeconds(0.04f);
            }
        }
        Option.SetActive(false);
        NonOption.SetActive(false);
        Dialogue.SetActive(true);
        NonDialogue.SetActive(true);
        while(true) {
            fades -= 0.1f;
            BlackTheme.color = new Color (0, 0, 0, fades);
            if (fades <= 0.0f) {
                break;
            } else {
                yield return new WaitForSeconds(0.04f);
            }
        }
        yield return null;
    }

    void Awake () {
        instance = this; // 사용법 = dataController.instance.변수 = 뭐시기뭐시기~
    }

    // 1번 저장법 PlayerPrefs
    // 2번 저장법 json / XML

    // 1번 저장법

    //public void Save(string SceneNum, string a) {
        //File.Delete("Assets/Scenario/ScenarioInfo.txt");
        //FileStream fs = File.Create("Assets/Scenario/ScanrioInfo.txt");
        //sw.Write(SceneNum + " " + a);
        //sw.Close();
    //}

    //public string Load(int num) { // 문제의 부분 , void->string
        //str = File.ReadAllLines("Assets/Scenario/ScenarioInfo.txt");
        //string[] words = str[0].Split('/');
        // string[] words = lines[num1].Split('/');
        //if (num == 0) {
            //return words[0]; // 저장 되어있는 SceneNum 반환
        //} else {
            //return words[1]; // 저장 되어있는 a값 반환
        //}
    //}
    
}
