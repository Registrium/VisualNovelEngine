using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DialogueManager : MonoBehaviour
{
    public Text Narrator, Dialogue;
    private int a = 0, i;
    private string c = "1", SceneNum = "1-1", DialogueText = "";
    private bool isGoing;
    string[] Line, Info;

    void Start()
    {
        // 파일의 이름, 줄 수를 불러옵니다.
        
        //SceneNum = dataController.instance.Load(0);
        //c = dataController.instance.Load(1);

        Line = File.ReadAllLines("Assets/Scenario/"+ SceneNum + ".txt");
        isGoing = true;
        StartCoroutine(DialogueGoing());
    }

    IEnumerator DialogueGoing() {
        
        if (isGoing) { // 대화가 진행중일때
            Info = Line[a].Split('/'); // 분리
            Narrator.text = Info[0]; // 등장인물 이름
            DialogueText = ""; // 텍스트 내용 초기화
            for(i = 0; i < Info[1].Length; i++) {
                DialogueText += Info[1][i];
                Dialogue.text = DialogueText;
                yield return new WaitForSeconds(0.1f);
            }
        } else { // isGoing = True;
            yield return null;
        }
    } 

    void Update() // isGoing = false, 기본 = 대화는 진행중이지 않다
    {
        
        if (!isGoing && Input.GetMouseButtonDown(0)) {
            // 대화 진행중이지 않을 때 클릭하면 다음 대화 출력
            a++;
            isGoing = true; // 대화는 진행중이다
            StartCoroutine(DialogueGoing());
        } else if (isGoing && Input.GetMouseButtonDown(0)) { // isGoing = True
            // 대화 진행중이면 이번 대화를 강제로 출력
            isGoing = false;
            i = Info[1].Length; // for문 강제 끝
            Dialogue.text = Info[1]; // 강제 출력
        }
    }
}

// 지금 문제

// 타이핑 중 클릭하면 바로 다음으로 진행

// (타이핑 취소하고 새로 만든 다음 덮어쓰기)