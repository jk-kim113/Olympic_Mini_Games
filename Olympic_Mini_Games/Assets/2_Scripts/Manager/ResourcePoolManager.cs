using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePoolManager : MonoBehaviour
{
    Dictionary<IngameStateManager.eGameKind, Dictionary<int, string>> mDicStageExplain;

	static ResourcePoolManager mUniqueInstance;
    public static ResourcePoolManager _instance { get { return mUniqueInstance; } }

    private void Awake()
    {
        mUniqueInstance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        mDicStageExplain = new Dictionary<IngameStateManager.eGameKind, Dictionary<int, string>>();

        SetUpStageExplain();
    }

    void SetUpStageExplain()
    {
        Dictionary<int, string> temp = new Dictionary<int, string>();
        temp.Add(0, "육상경기에 오신 것을 환영합니다.");
        temp.Add(1, "육상경기의 게임 규칙을 설명하겠습니다.");
        temp.Add(2, "1) 3초의 카운트 다운이 끝나면 Start 버튼이 활성화 되고 게임 시간이 흘러가게 됩니다.");
        temp.Add(3, "2) 플레이어가 움직이기 시작하면 각각의 발이 지면에 닿을 때 해당하는 좌우 버튼을 눌러 가속을 할 수 있습니다.");
        temp.Add(4, "3) Miss가 나면 느려지므로 타이밍에 잘 맞춰 버튼을 눌러주세요.");
        mDicStageExplain.Add(IngameStateManager.eGameKind.Athletics, temp);
        temp = new Dictionary<int, string>();
        temp.Add(0, "양궁경기에 오신 것을 환영합니다.");
        temp.Add(1, "양궁경기의 게임 규칙을 설명하겠습니다.");
        mDicStageExplain.Add(IngameStateManager.eGameKind.Archery, temp);
    }

    public string GetStageExplain(IngameStateManager.eGameKind kind, int id)
    {
        return mDicStageExplain[kind][id];
    }
}
