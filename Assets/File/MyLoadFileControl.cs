using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MyLoadFileControl : MonoBehaviour
{
    // 경로
    // Directory.GetCurrentDirectory() 는 현재 프로젝트 최상위 폴더에만 존재하는 파일 검사.
    string filePath = Directory.GetCurrentDirectory() + "/Assets/File/MyLoadFile";

    // 파일이름
    string fileName = "MyLoadText.txt";

    void Start()
    {
        Debug.Log(filePath);
        Debug.Log(fileName);
        CheckFileExist();
    }

    // 경로에 해당 이름의 파일이 있는지 검사
    // DirectoryInfo.GetFiles()와 Directory.GetFiles()
    // 공통점 Debug.Log(item) 출력값은 모두 해당 파일 경로 값으로 같다.
    // 차이점 DirectoryInfo.GetFiles()는 FileInfo[] 형식, Directory.GetFiles()는 string[] 형식이다.
    // 그래서 FileInfo[]에서 제공하는 속성들이 포함된 것과, 아닌 것의 차이로
    // 하나는 "찾았다"를 출력할 수 있는 것이고, 다른 하나는 "파일 있어"를 출력하지 못하는 것이다.
    void CheckFileExist()
    {
        // 인스턴스 메소드 - DirectoryInfo
        DirectoryInfo di = new DirectoryInfo(filePath);
        if (di.Exists)
        {
            foreach (var item in di.GetFiles())
            {
                Debug.Log(item);

                if (item.Name == fileName)
                {
                    Debug.Log("찾았다");
                }
            }
        }

        // 정적 메소드 - Directory
        foreach (var item in Directory.GetFiles(filePath))
        {
            Debug.Log(item);

            // 값이 같은데도 false가 나온다.
            if (item.Equals(fileName))
            {
                Debug.Log("파일 있어");
            }
        }
    }
}
