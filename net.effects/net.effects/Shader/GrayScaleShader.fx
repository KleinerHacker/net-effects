sampler2D implicitInput : register(s0);
float channelR : register(c0);
float channelG : register(c1);
float channelB : register(c2);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(implicitInput, uv);
    
    color.rgb = dot(color.rgb, float3(channelR, channelG, channelB));
    
    return color;
}