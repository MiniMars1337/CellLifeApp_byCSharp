#version 450 core

layout (location = 0) in vec2 position;
layout (location = 1) in vec2 textureCoordinate;

out vec2 vs_textureCoordinate;

//layout (location = 20) uniform  mat4 projection;
layout (location = 21) uniform  mat4 modelView;

void main(void)
{
	vs_textureCoordinate = textureCoordinate;
	//gl_Position = projection * modelView * vec4(position.xy, -10, 1.0);
	gl_Position = modelView * vec4(position.xy, 0.0, 1.0);
}