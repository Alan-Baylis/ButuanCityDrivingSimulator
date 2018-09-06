using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TextureTilingController : MonoBehaviour {

    [SerializeField]
    private Texture texture;
    [SerializeField]
    private float textureToMeshZ = 2f;
    [SerializeField]
    private float sizeX = 10f;
    [SerializeField]
    private float sizeY = 10f;

    private Vector3 prevScale = Vector3.one;
    private float prevTextureToMeshZ = -1f;

	// Use this for initialization
	void Start () {
		prevScale = transform.lossyScale;
        prevTextureToMeshZ = textureToMeshZ;

        UpdateTiling();
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.lossyScale != prevScale ||
            !Mathf.Approximately(this.textureToMeshZ, prevTextureToMeshZ)) {
            UpdateTiling();
        }

        prevScale = transform.lossyScale;
        prevTextureToMeshZ = textureToMeshZ;
	}

    [ContextMenu("UpdateTiling")]
    void UpdateTiling() {
        float planeSizeX = sizeX;
        float planeSizeZ = sizeY;

        float textureToMeshX = (texture.width / texture.height) * textureToMeshZ;

        Vector2 newTextureScale = new Vector2(
            planeSizeX * transform.lossyScale.x / textureToMeshX,
            planeSizeZ * transform.lossyScale.z / textureToMeshZ);

        GetComponent<Renderer>().sharedMaterial.mainTextureScale = newTextureScale;
    }
}
