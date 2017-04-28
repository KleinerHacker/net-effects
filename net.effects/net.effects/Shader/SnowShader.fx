sampler2D implicitInput : register(s0);
float opacity : register(c0);
float details : register(c1);
float random : register(c2);
bool colored : register(c3);

float rand(float val)
{
	return frac(cos(dot(val, 23.112357678764532004739f) * 123456.f));
}

float4 main(float2 uv : TEXCOORD) : COLOR
{
	float4 color = tex2D(implicitInput, uv);
	float ret = (rand(uv.x * uv.y * random) % 1.0f);
	float redColor = colored ? 1.345f : 1.0f;
	float greenColor = colored ? 2.123f : 1.0f;
	float blueColor = colored ? 3.001f : 1.0f;

	if (ret <= details)
	{
		color.r = color.r * (1 - opacity) + (rand(uv.x * uv.y * random * redColor) % 1.0f) * opacity;
		color.g = color.g * (1 - opacity) + (rand(uv.x * uv.y * random * greenColor) % 1.0f) * opacity;
		color.b = color.b * (1 - opacity) + (rand(uv.x * uv.y * random * blueColor) % 1.0f) * opacity;
	}

    return color;
}