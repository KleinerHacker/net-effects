//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- ToonEffect
//
//--------------------------------------------------------------------------------------

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D implicitInputSampler : register(S0);
float factor : register(C0);

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{
   float4 color = tex2D( implicitInputSampler, uv );

   color *= factor;
   color = floor(color);
   color /= factor;
   
   return color;
	
}
