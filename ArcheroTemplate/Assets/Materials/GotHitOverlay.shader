Shader "Unlit/GotHitOverlay"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _Thinness ("Thinness", Range(1, 10)) = 4
        _Strength ("Strength", Range(0, 1)) = 0
    }
    SubShader
    {
        Tags {
            "RenderType" = "Sprite"
            "Queue" = "Transparent"
            "AlphaDepth" = "False"
            "CanUseSpriteAtlas" = "True"
            "IgnoreProjector" = "True"
        }
        Blend SrcAlpha OneMinusSrcAlpha
        Lighting Off
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            float _Thinness;
            float _Strength;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = _Color;
                col.a =
                    pow(
                        sqrt(
                            (i.uv.x - 0.5) * (i.uv.x - 0.5)
                            +
                            (i.uv.y - 0.5) * (i.uv.y - 0.5)
                        ),
                        _Thinness
                    )
                    *
                    _Strength;

                return col;
            }
            ENDCG
        }
    }
}
