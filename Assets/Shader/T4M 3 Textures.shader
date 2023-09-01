Shader "T4MShaders/ShaderModel2/Diffuse/T4M 3 Textures" {
Properties {
 _Splat0 ("Layer 1", 2D) = "white" { }
 _Splat1 ("Layer 2", 2D) = "white" { }
 _Splat2 ("Layer 3", 2D) = "white" { }
 _Control ("Control (RGBA)", 2D) = "white" { }
 _MainTex ("Never Used", 2D) = "white" { }
}
	//DummyShaderTextExporter
	
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard fullforwardshadows
#pragma target 3.0
		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
		}
		ENDCG
	}
}