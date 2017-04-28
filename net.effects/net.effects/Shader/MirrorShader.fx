sampler2D implicitInput : register(s0);
float opacity : register(c0);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(implicitInput, float2(uv.x, 1-uv.y));
    float4 mirrow;
   
    mirrow.rgb = color.rgb;
	mirrow.a = (1-uv.y) * opacity;
    
    return mirrow;
}