//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- ColorKeyAlphaEffect
//
//--------------------------------------------------------------------------------------

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D  implicitInputSampler : register(S0);

float trashold : register(C0);
float4 replaceColor : register(C1);

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{
   float4 color = tex2D( implicitInputSampler, uv );
   
   if(color.r + color.g + color.b < trashold) {
      color = replaceColor;
   }
   
   return color;
}
