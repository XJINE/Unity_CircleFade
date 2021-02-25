using UnityEngine;

public class CircleFade : ImageEffectBase
{
    #region Field

    [SerializeField] protected Color   fadeColor     = Color.red;
    [SerializeField] protected Vector4 fadeSettings1 = new Vector4(0.5f, 0.5f, 0.3f, 0.5f);
    [SerializeField] protected Vector4 fadeSettings2 = new Vector4(1.0f, 0.0f, 0.0f, 0.0f);

    protected static readonly int PropId_FadeColor;
    protected static readonly int PropId_FadeSettings1;
    protected static readonly int PropId_FadeSettings2;

    #endregion Field

    #region Property

    public Color FadeColor
    {
        get { return this.fadeColor;  }
        set { this.fadeColor = value; }
    }

    public float FadeCenterX
    {
        get { return this.fadeSettings1.x;  }
        set { this.fadeSettings1.x = value; }
    }

    public float FadeCenterY
    {
        get { return this.fadeSettings1.y;  }
        set { this.fadeSettings1.y = value; }
    }

    public float FadeRadiusIn
    {
        get { return this.fadeSettings1.z;  }
        set { this.fadeSettings1.z = value; }
    }

    public float FadeRadiusOut
    {
        get { return this.fadeSettings1.w;  }
        set { this.fadeSettings1.w = value; }
    }

    public float FadeAspect
    {
        get { return this.fadeSettings2.x;  }
        set { this.fadeSettings2.x = value; }
    }

    public bool IgnoreAlpha
    {
        get { return this.fadeSettings2.y > 0;      }
        set { this.fadeSettings2.y = value ? 1 : 0; }
    }

    #endregion Property

    #region Constructor

    static CircleFade()
    {
        PropId_FadeColor     = Shader.PropertyToID("_FadeColor");
        PropId_FadeSettings1 = Shader.PropertyToID("_FadeSettings1");
        PropId_FadeSettings2 = Shader.PropertyToID("_FadeSettings2");
    }

    #endregion Constructor

    #region Method

    protected virtual void OnValidate()
    {
        UpdateSettings();
    }

    public virtual void UpdateSettings()
    {
        base.material.SetColor(PropId_FadeColor,     this.fadeColor);
        base.material.SetColor(PropId_FadeSettings1, this.fadeSettings1);
        base.material.SetColor(PropId_FadeSettings2, this.fadeSettings2);
    }

    #endregion Method
}