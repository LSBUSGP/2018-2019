using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EdgeEffect : MonoBehaviour
{

	public Material ShaderMat; //The material that we are going to apply to the camera rendering.

	/* We apply a depthTextureMode to the camera, with the parameter DepthNormals. It allows the camera
	   to generate a texture containing both the depths (how far from the camera each part of the render are)
	   and the normals (which way those parts facing). */ 

    void Start() 
    {
        gameObject.GetComponent<Camera>().depthTextureMode = DepthTextureMode.DepthNormals;
    }

	/* Here comes the post processing effect. An image is given to the camera, and before it renders, it will go
	   through our specified shader to sample each pixels, then give the result as our final rendering screen image */

	public void OnRenderImage(RenderTexture Source, RenderTexture Destination)
	{
		Graphics.Blit (Source, Destination, ShaderMat);
	}
}
