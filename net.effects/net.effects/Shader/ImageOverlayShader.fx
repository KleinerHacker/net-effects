sampler2D implicitInput : register(s0);
sampler2D image : register(s1);
float opacity : register(c1);
bool change : register(c0);
int blendType : register(c2);

float4 main(float2 uv : TEXCOORD) : COLOR
{
	float4 color1;
	if (!change)
		color1 = tex2D(implicitInput, uv);
	else
		color1 = tex2D(image, uv);

	float4 color2;
	if (!change)
		color2 = tex2D(image, uv);
	else
		color2 = tex2D(implicitInput, uv);

	float4 result = color1;

	//Overlay
	if (blendType == 0) {
		result.r = color1.r * (1 - opacity) + color2.r * opacity;
		result.g = color1.g * (1 - opacity) + color2.g * opacity;
		result.b = color1.b * (1 - opacity) + color2.b * opacity;
		result.a = color1.a * (1 - opacity) + color2.a * opacity;
	}
	//Add
	else if (blendType == 1)
	{
		result.r = color1.r + color2.r;
		result.g = color1.g + color2.g;
		result.b = color1.b + color2.b;
		result.a = color1.a + color2.a;
	}
	//Sub
	else if (blendType == 2)
	{
		result.r = color1.r - color2.r;
		result.g = color1.g - color2.g;
		result.b = color1.b - color2.b;
		result.a = color1.a - color2.a;
	}
	//Multiply
	else if (blendType == 3)
	{
		result.r = color1.r * color2.r;
		result.g = color1.g * color2.g;
		result.b = color1.b * color2.b;
		result.a = color1.a * color2.a;
	}
	//Divide
	else if (blendType == 4)
	{
		result.r = color1.r / color2.r;
		result.g = color1.g / color2.g;
		result.b = color1.b / color2.b;
		result.a = color1.a / color2.a;
	}
	//Darken
	else if (blendType == 5)
	{
		if (color1.r>color2.r) result.r = color2.r;
		if (color1.g>color2.g) result.g = color2.g;
		if (color1.b>color2.b) result.b = color2.b;
		if (color1.a>color2.a) result.a = color2.a;
	}
	//Lighten
	else if (blendType == 6)
	{
		if (color1.r<color2.r) result.r = color2.r;
		if (color1.g<color2.g) result.g = color2.g;
		if (color1.b<color2.b) result.b = color2.b;
		if (color1.a<color2.a) result.a = color2.a;
	}
    
    return result;
}