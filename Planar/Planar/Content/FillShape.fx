#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif


float2 resolution;
float4x4 ModelMatrix;
float4x4 ViewMatrix;
float4 color;

struct VertexShaderInput {
	float3 Position : POSITION0;
};

struct VertexShaderOutput {
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
};

VertexShaderOutput VertexShaderFunction(VertexShaderInput input) {
	VertexShaderOutput ret;
	
	float4 Pos4 = float4(input.Position.x, input.Position.y, 0.0, 1.0);
	float4x4 mat = {1.0, 0.0, 0.0, .5,
					0.0, 1.0, 0.0, 0.0,
					0.0, 0.0, 1.0, 0.0,
					0.0, 0.0, 0.0, 1.0};
	
	float4 moved = mul(ModelMatrix, Pos4);
	
	float4 resolved = moved / float4(resolution.x, resolution.y, 1.0, 1.0);
	ret.Position = resolved;
	ret.Color = color;
	
	return ret;
}

float4 PixelShaderFunction(VertexShaderOutput input) : COLOR {

	return input.Color;

}

technique FillShape
{
    pass Pass1
    {
        VertexShader = compile VS_SHADERMODEL VertexShaderFunction();
        PixelShader = compile PS_SHADERMODEL PixelShaderFunction();
    }
}