using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{
    public VfxType vfxtype;
    public enum VfxType
    {
        MONEY,
        DAMAGE_MAGIC,
        DAMAGE_PHYSIC,
        ORC,
        WOOD,
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 타입에 따라 효과 적용
    /// </summary>
    public void indicateVfx()
    {
        switch (vfxtype)
        {
            case VfxType.MONEY:
                break;
            case VfxType.DAMAGE_MAGIC:
                break;
            case VfxType.DAMAGE_PHYSIC:
                break;
            case VfxType.ORC:
                break;
            case VfxType.WOOD:
                break;
        }
    }
}