#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

float3x3 ModelMatrix;
float3x3 ViewMatrix;
float4 color;

struct VertexShaderInput {
	float3 Position : POSITION0;
};

struct VertexShaderOutput {
	float4 Position : POSITION0;
	float4 Color : COLOR0;
};

VertexShaderOutput VertexShaderFunction(VertexShaderInput input) {
	VertexShaderOutput ret;
	
	ret.Position = float4(mul(mul(input.Position,ModelMatrix), ViewMatrix), 1.0);
	ret.Color = color;
	
	return ret;
}

float4 PixelShaderFunction(VertexShaderOutput input) : COLOR0 {

	return input.Color;

}

technique FillShape
{
    pass Pass1
    {
        VertexShader = compile vs_4_0 VertexShaderFunction();
        PixelShader = compile ps_4_0 PixelShaderFunction();
    }
}