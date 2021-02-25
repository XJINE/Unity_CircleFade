Shader "Hidden/CircleFade"
{
    Properties
    {
        [HideInInspector]
        _MainTex      ("Texture",                         2D) = "white" {}
        _FadeColor    ("Fade Color",                   Color) = (1.0, 0.0, 0.0, 1.0)
        _FadeSettings1("(CenterX, Y, RadiusIn, Out)", Vector) = (0.5, 0.5, 0.3, 0.5)
        _FadeSettings2("(Aspect, IgnoreAlpha, -, -)", Vector) = (1.0, 1.0, 0.0, 0.0)
    }
    SubShader
    {
        Cull   Off
        ZWrite Off
        ZTest  Always

        Pass
        {
            CGPROGRAM

            #pragma vertex   vert_img
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;

            float4 _FadeColor;
            float4 _FadeSettings1;
            float4 _FadeSettings2;

            static const float _CenterX     = _FadeSettings1.x;
            static const float _CenterY     = _FadeSettings1.y;
            static const float _InnerRadius = _FadeSettings1.z;
            static const float _OuterRadius = _FadeSettings1.w;
            static const float _AspectRatio = _FadeSettings2.x;
            static const bool  _IgnoreAlpha = _FadeSettings2.y > 0;

            fixed4 frag (v2f_img i) : SV_Target
            {
                fixed4 color = tex2D(_MainTex, i.uv);

                i.uv.x *= _AspectRatio;

                float2 center = float2(_CenterX * _AspectRatio, _CenterY);
                float  l      = length(i.uv - center);
                float  fade   = (l - _InnerRadius) / (_OuterRadius - _InnerRadius);
                       fade   = saturate(fade);

                color = _IgnoreAlpha ? lerp(color, _FadeColor, fade)
                                     : color.a <= 0 ? color
                                                    : lerp(color, _FadeColor, fade);

                return color;
            }

            ENDCG
        }
    }
}