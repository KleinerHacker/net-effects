sampler2D implicitInput : register(s0);
float opacity : register(c0);
bool invert : register(c1);
bool replaceColor : register(c2);
float4 newColor : register(c3);
float channelR : register(c4);
float channelG : register(c5);
float channelB : register(c6);

float4 main(float2 uv : TEXCOORD) : COLOR
{
	float4 color = tex2D(implicitInput, uv);
	color.rgb = color.rgb * opacity;

	float gray = dot(color.rgb, float3(channelR, channelG, channelB));

	if (!invert) 
	{
		if (replaceColor) 
		{
			color = float4(newColor.rgb, gray);
		}
		else 
		{
			color.a = gray;
		}
	}
	else 
	{
		if (replaceColor) 
		{
			color = float4(newColor.rgb, 1 - gray);
		}
		else
		{
			color.a = 1 - gray;
		}
	}

	return color;
}