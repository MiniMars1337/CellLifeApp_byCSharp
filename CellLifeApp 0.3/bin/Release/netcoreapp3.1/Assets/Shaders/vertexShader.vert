#version 450 core

layout(location = 0) in vec4 position;
layout(location = 1) in vec4 color;
out vec4 vs_color;

void main(void)
{
	vs_color = color;
	gl_Position = position;
}