using UnityEngine;
using System.Collections;

public class UISetup : MonoBehaviour
{
	public static string VERSION = "0.0.0";

	void Awake()
	{
		FutileParams futileParams = new FutileParams(true, true, false, false);
		futileParams.AddResolutionLevel(960f, 1.0f, 1.0f, "");
		futileParams.AddResolutionLevel(1920f, 2.0f, 2.0f, "");
		futileParams.origin = new Vector2(0.5f, 0.5f);
		Futile.instance.Init(futileParams);

		Futile.atlasManager.LoadAtlas("UI/ui");
		Futile.atlasManager.LoadFont("kozuka14el", "kozuka14el", "UI/kozuka14el", 0f, 0f);
		Futile.atlasManager.LoadFont("kozuka30el", "kozuka30el", "UI/kozuka30el", 0f, 0f);
		Futile.atlasManager.LoadFont("kozuka72r", "kozuka72r", "UI/kozuka72r", 0f, 0f);
		Futile.atlasManager.GetFontWithName("kozuka14el").textParams.kerningOffset = 1f;
	}

	void Start()
	{
		FLabel title = new FLabel("kozuka72r", "Game Title");
		title.anchorY = 1f;
		title.y = Futile.screen.halfHeight - 10f;
		Futile.stage.AddChild(title);

		FLabel version = new FLabel("kozuka14el", "version " + UISetup.VERSION);
		version.anchorX = 1f;
		version.anchorY = 0f;
		version.x = Futile.screen.halfWidth - 10f;
		version.y = -Futile.screen.halfHeight + 10f;
		Futile.stage.AddChild(version);
	}
}
