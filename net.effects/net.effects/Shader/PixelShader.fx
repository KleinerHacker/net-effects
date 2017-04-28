sampler2D implicitInput : register(s0);
float transX : register(c0);
float transY : register(c1);

float4 main(float2 uv : TEXCOORD) : COLOR
{
	uv = float2(uv.x - (uv.x % transX), uv.y - (uv.y % transY));

    float4 color = tex2D(implicitInput, uv);
    return color;
}