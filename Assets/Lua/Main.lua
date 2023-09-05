--主入口函数。从这里开始lua逻辑
function Main()					
	print("====================Lua Main=============================")

	local res = resMgr:LoadPrefab("Res/Prefabs/UICanvas.prefab")
	GameObject.Instantiate(res)
end

Main()