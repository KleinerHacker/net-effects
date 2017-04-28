sampler2D implicitInput : register(s0);
float translation : register(c0);
float interpolar : register(c1);
bool gray : register(c2);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(implicitInput, uv);
    color -= tex2D(implicitInput, uv.xy - translation) * interpolar;
    color += tex2D(implicitInput, uv.xy + translation) * interpolar;
    if (gray == 1.0f)
		color.rgb = (color.r + color.g + color.b) / 3.0f;
    
    return color;
}