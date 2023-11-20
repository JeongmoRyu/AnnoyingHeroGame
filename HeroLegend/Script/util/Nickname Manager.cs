using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************ NICKNAME 관리 ************************************/
/***************************************************************************************/

/* MonoBehaviour 상속받지 않았으므로 Hierarchy에 존재할 필요 없음 */
public class NicknameManager
{

    /* 닉네임 싱글톤 인스턴스 */
    public static string nickname;

    /* 닉네임 싱글톤 인스턴스 Setter, Getter */
    public static string Nickname
    {
        set
        {
            if (!string.IsNullOrEmpty(nickname))
            {
                nickname=value;
            }
        }
        get
        {
            if (!string.IsNullOrEmpty(nickname))
            {
                return nickname;
            }
            return "OO";
        }
    }

    /* 종성 메소드 이용 위한 싱글톤 인스턴스 */
    private static NicknameManager instance;

    /* 인스턴스 Getter */
    public static NicknameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new NicknameManager();
            }
            return instance;
        }
    }

    public string getNickname을를()
    {
        if (!string.IsNullOrEmpty(nickname))
        {
            if (HasJongseong(nickname))
            {
                return nickname + "을 ";
            }
            else
            {
                return nickname + "를 ";
            }
        }
        return "OO를 ";//예외적으로 nickname 데이터 날아간 경우, 받침 없음 기준으로 처리
    }

    public string getNickname이가()
    {
        if (!string.IsNullOrEmpty(nickname))
        {
            if (HasJongseong(nickname))
            {
                return nickname + "이 ";
            }
            else
            {
                return nickname + "가 ";
            }
        }
        return "OO가 ";//예외적으로 nickname 데이터 날아간 경우, 받침 없음 기준으로 처리
    }

    public string getNickname은는()
    {
        if (!string.IsNullOrEmpty(nickname))
        {
            if (HasJongseong(nickname))
            {
                return nickname + "은 ";
            }
            else
            {
                return nickname + "는 ";
            }
        }
        return "OO는 ";//예외적으로 nickname 데이터 날아간 경우, 받침 없음 기준으로 처리
    }

    /* 종성 분석 메소드 */
    bool HasJongseong(string text)
    {
        string lastCharacter = text.Substring(text.Length - 1, 1);
        char c = lastCharacter[0];

        if (!(0xAC00 <= c && c <= 0xD7A3) && !(0x3131 <= c && c <= 0x318E))
        {
            //한글 외의 문자는 받침 없음으로 처리
            Debug.Log("한글 외의 문자");
            return false;
        }

        int codePoint = Char.ConvertToUtf32(c.ToString(), 0);
        int distanceFromGa = codePoint - Char.ConvertToUtf32("가", 0);

        // 한 음절은 초성(19자), 중성(21자), 종성(28자)로 구성되므로 종성이 있는지 여부를 확인하기 위해 거리를 계산
        return distanceFromGa % 28 != 0;
    }
}
