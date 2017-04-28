sampler2D implicitInput : register(s0);
float scaleX : register(c0);
float scaleY : register(c1);
float transX : register(c2);
float transY : register(c3);

float4 main(float2 uv : TEXCOORD) : COLOR
{
	uv.y += (sin(uv.y*scaleX+transX)*scaleY+transY);
    float4 color = tex2D(implicitInput, uv);  
    
    return color;
}