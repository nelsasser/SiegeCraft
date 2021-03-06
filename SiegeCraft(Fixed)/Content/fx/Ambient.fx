﻿float4x4 World;
float4x4 View;
float4x4 Projection;

float4 AmbientColor = float4(1, 1, 1, 1);
float AmbientIntensity = 0.1;

struct VertexShaderInput {
	float4 Position : SV_Position;
};

struct VertexShaderOutput {
	float4 Position : SV_Position;
};

VertexShaderOutput VS(VertexShaderInput input) {
	VertexShaderOutput output;

	float4 worldPosition = mul(input.Position, World);
	float4 viewPosition = mul(worldPosition, View);
	output.Position = mul(viewPosition, Projection);

	return output;
}

float4 PS(VertexShaderOutput input) : COLOR0
{
	return AmbientColor * AmbientIntensity;
}

technique Ambient {
	pass Pass1 {
		VertexShader = compile vs_4_0_level_9_1 VS();
		PixelShader = compile ps_4_0_level_9_1 PS();
	}
}
