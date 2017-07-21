using UnityEngine;
using System.Collections;

[System.Serializable]
public class array2d
{
	public Renderer[] renderers;
	public int[] materialNumbers;
}

public class ColorPickerTester : MonoBehaviour 
{
	public array2d[] paintSections;

	private Renderer[] currentRenderers;
	private int[] currentMatNums;
    
    public ColorPicker picker;

	// Use this for initialization
	void Start () 
    {
		setPaintSection(0);

		picker.CurrentColor = currentRenderers[0].materials[0].color;

        picker.onValueChanged.AddListener(color =>
        {
				for(int n = 0; n < currentRenderers.Length; n++)
				{
					int matN = currentMatNums[n];
					currentRenderers[n].materials[matN].color = picker.CurrentColor;
				}
        });
	}
	
	public void setPaintSection(int _num)
	{
		currentRenderers = paintSections[_num].renderers;
		currentMatNums = paintSections[_num].materialNumbers;

		picker.CurrentColor = currentRenderers[0].materials[currentMatNums[0]].color;
	}
}
