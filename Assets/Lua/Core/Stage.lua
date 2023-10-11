---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by sunshuo.
--- DateTime: 2023/9/20 13:49
---
---@class Stage
local Stage = {}


--=[ C#调用 ]=--

--- Update / LateUpdate / FixedUpdate 回调。由 StageLooper.cs 调用
--- 在全局变量 Stage 上抛出 Event.UPDATE / Event.LATE_UPDATE  / Event.FIXED_UPDATE 事件
---@param type string
---@param time number
function Stage._loopHandler(type, time)
    TimeUtil.time = time
    TimeUtil.timeMsec = math.floor(time * 1000 + 0.5)

    --if type == Event.UPDATE then
    --    TimeUtil.frameCount = Time.frameCount
    --    TimeUtil.deltaTime = Time.deltaTime
    --    TimeUtil.totalDeltaTime = TimeUtil.totalDeltaTime + TimeUtil.deltaTime
    --    TimeUtil.timeSinceLevelLoad = Time.timeSinceLevelLoad
    --end

    ---派发lua层事件
    print("TimeUtil.time", type, TimeUtil.time)
end

return Stage