Shader "Hidden/PixelateEffect"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_ColorRamp ("ColorRamp", 2D) = "white" {}
		_xTargetSize("Width Pixel Count", int) = 160
		_yTargetSize("Height Pixel Count", int) = 144
	}
	SubShader
	{
		Cull Off ZWrite Off ZTest Always

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

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _ColorRamp;
			uint _xTargetSize;
			uint _yTargetSize;

			fixed4 frag (v2f i) : SV_Target
			{
				float pixelWidth = 1.0f / _xTargetSize;
				float pixelHeight = 1.0f / _yTargetSize;
				i.uv = float2((int)(i.uv.x / pixelWidth) * pixelWidth, (int)(i.uv.y / pixelHeight) * pixelHeight);
			
				return tex2D(_MainTex, i.uv);
			}
			ENDCG
		}
	}
}
