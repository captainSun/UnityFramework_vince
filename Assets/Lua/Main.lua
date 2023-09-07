--主入口函数。从这里开始lua逻辑
local function Main()
	print("====================Lua Main=============================")
	require("Data.Constants.define")

	-- 禁止创建全局变量或全局函数
	setmetatable(_G, {
		__newindex = function(_, name, value)
			error(Constants.E1001)
		end
	})

	local res = resMgr:LoadPrefab("Res/Prefabs/TestImage.prefab")
	local image = GameObject.Instantiate(res) ---@type UnityEngine.GameObject
	image.transform.localPosition = Vector3.zero
	image:GetComponent(typeof(UnityEngine.UI.Image)).color = Color.red
end

Main()