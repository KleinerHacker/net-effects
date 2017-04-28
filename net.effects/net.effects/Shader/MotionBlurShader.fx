sampler2D implicitInput : register(s0);
float angle : register(c0);
float blurAmount : register(c1);

float4 main(float2 uv : TEXCOORD) : COLOR
{
	float4 output = 0;
	float2 offset;
	int count = 24;
	
	sincos(angle, offset.x, offset.y);
	offset *= blurAmount;
	
	for (int i=0; i<count; i++) 
	{
		output += tex2D(implicitInput, uv - offset * i);
	}        
	
	output /= count;
	
	return output;
}