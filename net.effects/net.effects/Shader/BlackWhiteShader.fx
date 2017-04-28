sampler2D implicitInput : register(s0);
float middle : register(c0);
float4 heightColor : register(c1);
float4 lowColor : register(c2);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(implicitInput, uv);
    
    float all = ((color.r + color.g + color.b) / 3.0f);
	if (all < middle)
	{
		color = heightColor;
	}
	else
	{
		color = lowColor;
	}
    
    return color;
}