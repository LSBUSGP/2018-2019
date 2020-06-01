Shader "Custom/EdgeDetectionShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}			// Access to the main texture
        _Threshold("Threshold", float) = 0.01			// How much difference there need to be in order to be considered an edge
        _ExtraSample("Thickness", float) = 1			// Change the number of pixels sampled, essentially detecting an edge further 
        _EdgeColor("Edge color", Color) = (0,0,0,1)		// Final color applied to the edge pixel
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always
 
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
             
            #include "UnityCG.cginc"
 
            struct appdata 					// Pass information about local position and UV coordinate of each pixel
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
 
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
 
            sampler2D _CameraDepthNormalsTexture; 	// Get the texture from camera, containing Depth and Normal information
 
            v2f vert (appdata v)		// Pass the mesh vertex data as input to the mesh vertex function
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            // Access the parameters to use in the functions
             
            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float _Threshold;
            float _ExtraSample;
            fixed4 _EdgeColor;

            // this functions will be run through each pixel, decode the normal and depth from the camera input,
            // then return a color value, where R, G, and B are the normals of the pixel, and A is the float depth.

            float4 GetPixelValue(in float2 uv) {
                half3 normal;
                float depth;
                DecodeDepthNormal(tex2D(_CameraDepthNormalsTexture, uv), depth, normal);
                return fixed4(normal, depth);
            }

            // The fragment function will run through each pixel of the screen and sample the 4 pixels in each corner.
            // Each results are multiplied by the extra samples (to test further than one pixel around) then multiplied
            // by the TexelSize (size of the pixel depending on screen resolution). Each results are added in a SampleValue,
            // divided by the number of sampled pixel. If the depth of a pixel (orValue.a) is more than the depth of the sample value,
            // it is not considered an edge, as it is behind the object. This reduce the extra thickness growing outside a mesh.
            // Finally, we return the color by checking the length between the original value and sampled value, and comparing it to the Threshold.

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 orValue = GetPixelValue(i.uv);
                float2 offsets[4] = {
                    //float2(-1, -1),
                    float2(-1, 0),
                   // float2(-1, 1),
                    float2(0, -1),
                    float2(0, 1),
                    //float2(1, -1),
                    float2(1, 0),
                    //float2(1, 1)
                };
                fixed4 sampledValue = fixed4(0,0,0,0);
                for(int j = 0; j < 4; j++) {
                    sampledValue += GetPixelValue(i.uv + offsets[j] *  _ExtraSample * _MainTex_TexelSize.xy);
                }
                sampledValue /= j;

                if (orValue.a >= sampledValue.a)
                {
                    sampledValue = orValue;
                }

                return lerp(col, _EdgeColor, step(_Threshold, length(orValue - sampledValue)));

            }
            ENDCG
        }
    }
}